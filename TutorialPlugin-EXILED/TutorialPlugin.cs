using Exiled.API.Enums;
using Exiled.API.Features;
using System;

using Server = Exiled.Events.Handlers.Server;
using Player = Exiled.Events.Handlers.Player;

namespace TutorialPlugin_EXILED
{



    //warning MSB3270:
    public class TutorialPlugin : Plugin<Config>
    {
        private static readonly Lazy<TutorialPlugin> LazyInstance = new Lazy<TutorialPlugin>(() => new TutorialPlugin());

        public static TutorialPlugin Instance => LazyInstance.Value;

        public override PluginPriority Priority { get; } = PluginPriority.Medium;

        private Handlers.Player currentPlayer;
        private Handlers.SpectatorInfo currentSpectator;
        private Handlers.Server currentServer;

        private TutorialPlugin()
        {

        }

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


            currentPlayer = new Handlers.Player();
            currentSpectator = new Handlers.SpectatorInfo();
            currentServer = new Handlers.Server();

            Server.WaitingForPlayers += currentServer.OnWaitingForPlayers;
            Server.RoundStarted += currentServer.OnRoundStarted;

            Player.Left += currentPlayer.OnLeave;
            
            Player.Joined += currentPlayer.OnJoin;
            Player.InteractingDoor += currentPlayer.OnInteractingDoor;
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
            Server.WaitingForPlayers -= currentServer.OnWaitingForPlayers;
            Server.RoundStarted -= currentServer.OnRoundStarted;

            Player.Left -= currentPlayer.OnLeave;
            Player.Joined -= currentPlayer.OnJoin;
            Player.InteractingDoor -= currentPlayer.OnInteractingDoor;
            Player.Died -= currentSpectator.OnDeath;
            Server.EndingRound -= currentSpectator.OnRoundEnd;
            Server.RestartingRound -= currentSpectator.onRoundRestart;
            Server.WaitingForPlayers -= currentSpectator.onRoundRestart;


            currentPlayer = null;
            currentServer = null;
        }
    }
}
