using Exiled.API.Enums;
using Exiled.API.Features;
using System;
using PlayerEvents = Exiled.Events.Handlers.Player;
using ServerEvents = Exiled.Events.Handlers.Server;

namespace SpectatorTickets3
{



    public class SpectatorTickets : Plugin<Config>
    {


        /// <summary>
        /// Gets a static instance of the <see cref="Plugin"/> class.
        /// </summary>
        public static SpectatorTickets Instance { get; private set; }

        /// <inheritdoc />
        public override string Author => "Undid-Iridium";

        /// <inheritdoc />
        public override string Name => "SpectatorTickets3";

        /// <inheritdoc />
        public override Version RequiredExiledVersion { get; } = new Version(5, 1, 3);

        /// <inheritdoc />
        public override Version Version { get; } = new Version(1, 1, 0);

        private Handlers.SpectatorMonitor currentSpectatorMonitor;
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

            Instance = this;
            currentSpectatorMonitor = new Handlers.SpectatorMonitor();

            if (Config.ForceConstantUpdates)
            {
                eventHandler = new Handlers.ForcedEventHandlers();
                PlayerEvents.ChangingRole += eventHandler.OnRoleChange;
            }
            else
            {
                PlayerEvents.Died += currentSpectatorMonitor.OnDeath;
                PlayerEvents.Spawning += currentSpectatorMonitor.OnRespawn;
                PlayerEvents.ChangingRole += currentSpectatorMonitor.OnChanginRole;

                ServerEvents.EndingRound += currentSpectatorMonitor.OnRoundEnd;
                ServerEvents.RestartingRound += currentSpectatorMonitor.OnRoundRestart;
                ServerEvents.WaitingForPlayers += currentSpectatorMonitor.OnRoundRestart;
                ServerEvents.RespawningTeam += currentSpectatorMonitor.OnTeamSpawn;
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
                eventHandler = null;
                PlayerEvents.ChangingRole -= eventHandler.OnRoleChange;
            }
            else
            {
                PlayerEvents.Died -= currentSpectatorMonitor.OnDeath;
                PlayerEvents.Spawning -= currentSpectatorMonitor.OnRespawn;
                PlayerEvents.ChangingRole -= currentSpectatorMonitor.OnChanginRole;

                ServerEvents.EndingRound -= currentSpectatorMonitor.OnRoundEnd;
                ServerEvents.RestartingRound -= currentSpectatorMonitor.OnRoundRestart;
                ServerEvents.WaitingForPlayers -= currentSpectatorMonitor.OnRoundRestart;
                ServerEvents.RespawningTeam -= currentSpectatorMonitor.OnTeamSpawn;
            }
            Instance = null;
            currentSpectatorMonitor = null;
        }
    }
}
