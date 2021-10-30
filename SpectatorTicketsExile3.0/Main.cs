using Exiled.API.Enums;
using Exiled.API.Features;
using System;
using Player = Exiled.Events.Handlers.Player;
using Server = Exiled.Events.Handlers.Server;

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


        private Handlers.SpectatorInfo currentSpectator;


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


            currentSpectator = new Handlers.SpectatorInfo();

            Player.Died += currentSpectator.OnDeath;
            Player.Spawning += currentSpectator.OnRespawn;
            Server.EndingRound += currentSpectator.OnRoundEnd;
            Server.RestartingRound += currentSpectator.OnRoundRestart;
            Server.WaitingForPlayers += currentSpectator.OnRoundRestart;
            Server.RespawningTeam += currentSpectator.OnTeamSpawn;


            Player.ChangingRole += currentSpectator.OnChanginRole;

            //Player.ChangingGroup += currentSpectator.OnChangingGroup;

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
            Player.Died -= currentSpectator.OnDeath;
            Player.Spawning -= currentSpectator.OnRespawn;
            Server.EndingRound -= currentSpectator.OnRoundEnd;
            Server.RestartingRound -= currentSpectator.OnRoundRestart;
            Server.WaitingForPlayers -= currentSpectator.OnRoundRestart;
            Server.RespawningTeam -= currentSpectator.OnTeamSpawn;

            Player.ChangingRole -= currentSpectator.OnChanginRole;
            //Player.ChangingGroup -= currentSpectator.OnChangingGroup;


            currentSpectator = null;
        }
    }
}
