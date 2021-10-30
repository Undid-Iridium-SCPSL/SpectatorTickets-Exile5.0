using Exiled.API.Enums;
using Exiled.API.Features;
using System;
using PlayerEvents = Exiled.Events.Handlers.Player;
using ServerEvents = Exiled.Events.Handlers.Server;

namespace SpectatorTickets3
{



    public class SpectatorTickets : Plugin<Config>
    {
        private static readonly Lazy<SpectatorTickets> LazyInstance = new Lazy<SpectatorTickets>(() => new SpectatorTickets());

        /// <summary>
        /// Quiet add SpectatorTickets to reduce performance hit
        /// </summary>
        public static SpectatorTickets Instance => LazyInstance.Value;

        /// <summary>
        /// Medium priority, lower prioritys mean faster loadin
        /// </summary>
        public override PluginPriority Priority { get; } = PluginPriority.Medium;


        private Handlers.SpectatorMonitor currentSpectator;
        private Handlers.ForcedEventHandlers eventHandler;


        /// <summary>
        /// Entrance function called through Exile
        /// </summary>
        public override void OnEnabled()
        {
            RegisterEvents();
        }
        /// <summary>
        /// Destruction function called through Exile
        /// </summary>
        public override void OnDisabled()
        {
            UnRegisterEvents();
        }





        /// <summary>
        /// Registers events for EXILE to hook unto with cororotines (I think?)
        /// </summary>
        public void RegisterEvents()
        {
            // Register the event handler class. And add the event,
            // to the EXILED_Events event listener so we get the event.


            currentSpectator = new Handlers.SpectatorMonitor();

            if (Config.ForceConstantUpdates)
            {
                eventHandler = new Handlers.ForcedEventHandlers();
                PlayerEvents.ChangingRole += eventHandler.OnRoleChange;
            }
            else
            {
                PlayerEvents.Died += currentSpectator.OnDeath;
                PlayerEvents.Spawning += currentSpectator.OnRespawn;
                PlayerEvents.ChangingRole += currentSpectator.OnChanginRole;

                ServerEvents.EndingRound += currentSpectator.OnRoundEnd;
                ServerEvents.RestartingRound += currentSpectator.OnRoundRestart;
                ServerEvents.WaitingForPlayers += currentSpectator.OnRoundRestart;
                ServerEvents.RespawningTeam += currentSpectator.OnTeamSpawn;
            }


            Log.Info("SpectratorTickets3 has been reloaded");

        }
        /// <summary>
        /// Unregisters the events defined in RegisterEvents, recommended that everything created be destroyed if not reused in some way.
        /// </summary>
        public void UnRegisterEvents()
        {
            // Make it dynamically updatable.
            // We do this by removing the listener for the event and then nulling the event handler.
            // This process must be repeated for each event.
            if (Config.ForceConstantUpdates)
            {
                PlayerEvents.ChangingRole -= eventHandler.OnRoleChange;
            }
            else
            {
                PlayerEvents.Died -= currentSpectator.OnDeath;
                PlayerEvents.Spawning -= currentSpectator.OnRespawn;
                PlayerEvents.ChangingRole -= currentSpectator.OnChanginRole;
                ServerEvents.EndingRound -= currentSpectator.OnRoundEnd;
                ServerEvents.RestartingRound -= currentSpectator.OnRoundRestart;
                ServerEvents.WaitingForPlayers -= currentSpectator.OnRoundRestart;
                ServerEvents.RespawningTeam -= currentSpectator.OnTeamSpawn;
            }
            currentSpectator = null;
        }
    }
}
