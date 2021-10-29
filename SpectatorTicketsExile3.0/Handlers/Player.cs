using Exiled.API.Features;
using Exiled.Events.EventArgs;
namespace SpectatorTickets_EXILED3.Handlers
{
    //NOT USED - EXAMPLE ONLY. 
    class Player
    {
        public void OnLeave(LeftEventArgs leftEvent)
        {
            string leaveMessage = SpectatorTickets.Instance.Config.LeaveMessage.Replace("{Player}", leftEvent.Player.Nickname);
            Map.Broadcast(6, leaveMessage);
        }

        public void OnJoin(JoinedEventArgs joinedEvent)
        {
            Log.Info("TutorialPlugin.Instance.Config.JoinMessage: " + SpectatorTickets.Instance.Config.JoinMessage);
            string joinMessage = SpectatorTickets.Instance.Config.JoinMessage.Replace("{Player}", joinedEvent.Player.RawUserId);
            Log.Info("What was join Message? " + joinMessage);
            joinedEvent.Player.Broadcast(20, "<color=yellow>Welcome to my cool server!</color>", Broadcast.BroadcastFlags.Normal, true);
        }

        public void OnInteractingDoor(InteractingDoorEventArgs doorInteraction)
        {
            if (!doorInteraction.IsAllowed)
            {
                doorInteraction.Player.Broadcast(3, SpectatorTickets.Instance.Config.DoorTrapMessage);
                doorInteraction.Player.Kill(DamageTypes.Bleeding);
            }
        }
    }
}
