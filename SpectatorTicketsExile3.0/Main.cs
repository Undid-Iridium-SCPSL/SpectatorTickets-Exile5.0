using Exiled.API.Enums;
using Exiled.API.Features;
using System;
using Player = Exiled.Events.Handlers.Player;
using Server = Exiled.Events.Handlers.Server;

namespace SpectatorTickets_EXILED3
{



    public class SpectatorTickets : Plugin<Config>
    {
        private static readonly Lazy<SpectatorTickets> LazyInstance = new Lazy<SpectatorTickets>(() => new SpectatorTickets());

        public static SpectatorTickets Instance => LazyInstance.Value;

        public override PluginPriority Priority { get; } = PluginPriority.Medium;

        private Handlers.SpectatorInfo currentSpectator;



        public override void OnEnabled()
        {
            RegisterEvents();
        }

        public override void OnDisabled()
        {
            UnRegisterEvents();
        }

        public void RegisterEvents()
        {
            // Register the event handler class. And add the event,
            // to the EXILED_Events event listener so we get the event.


            currentSpectator = new Handlers.SpectatorInfo();

            Player.Died += currentSpectator.OnDeath;
            Player.Spawning += currentSpectator.OnRespawn;
            Server.RestartingRound += currentSpectator.onRoundRestart;
            Server.EndingRound += currentSpectator.OnRoundEnd;
            Server.WaitingForPlayers += currentSpectator.onRoundRestart;
        }

        public void UnRegisterEvents()
        {
            // Make it dynamically updatable.
            // We do this by removing the listener for the event and then nulling the event handler.
            // This process must be repeated for each event.
            Player.Died -= currentSpectator.OnDeath;
            Server.EndingRound -= currentSpectator.OnRoundEnd;
            Server.RestartingRound -= currentSpectator.onRoundRestart;
            Server.WaitingForPlayers -= currentSpectator.onRoundRestart;


            currentSpectator = null;
        }
    }
}
