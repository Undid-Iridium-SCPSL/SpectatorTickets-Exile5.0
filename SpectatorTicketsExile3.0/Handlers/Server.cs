using Exiled.API.Features;


namespace SpectatorTickets_EXILED3.Handlers
{
    //UNUSED, EXAMPLE ONLY
    class Server
    {
        public void OnWaitingForPlayers()
        {
            Log.Info("Waiting for players.");
            DebugLog.Log("Waiting for players???.");
        }

        public void OnRoundStarted()
        {
            Map.Broadcast(6, SpectatorTickets.Instance.Config.RoundStartMessage);
        }


    }
}
