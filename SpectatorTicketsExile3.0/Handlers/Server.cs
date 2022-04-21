using Exiled.API.Features;


namespace SpectatorTickets3.Handlers
{
    /// <summary>
    /// UNUSED, EXAMPLE ONLY
    /// </summary>
    class Server
    {

        public void OnRoundStarted()
        {
            Map.Broadcast(6, SpectatorTickets.Instance.Config.RoundStartMessage);
        }


    }
}
