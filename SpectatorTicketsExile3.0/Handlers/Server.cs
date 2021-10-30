using Exiled.API.Features;


namespace SpectatorTickets3.Handlers
{
    /// <summary>
    /// UNUSED, EXAMPLE ONLY
    /// </summary>
    class Server
    {
        public void OnWaitingForPlayers()
        {
            Log.Info("Waiting for players to add to game.");
            DebugLog.Log("Waiting for players to join???.");
        }

        public void OnRoundStarted()
        {
            Map.Broadcast(6, SpectatorTickets.Instance.Config.RoundStartMessage);
        }


    }
}
