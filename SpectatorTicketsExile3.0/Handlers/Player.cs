using Exiled.API.Features;
using Exiled.Events.EventArgs;
using Exiled.Events.Commands.Show;
namespace SpectatorTickets_EXILED3.Handlers
{
    class Player
    {
        public void OnLeave(LeftEventArgs leftEvent)
        {
            string leaveMessage = TutorialPlugin.Instance.Config.LeaveMessage.Replace("{Player}", leftEvent.Player.Nickname);
            Map.Broadcast(6, leaveMessage);
        }

        public void OnJoin(JoinedEventArgs joinedEvent)
        {
            Log.Info("TutorialPlugin.Instance.Config.JoinMessage: " + TutorialPlugin.Instance.Config.JoinMessage);
            string joinMessage = TutorialPlugin.Instance.Config.JoinMessage.Replace("{Player}", joinedEvent.Player.RawUserId);
            Log.Info("What was join Message? " + joinMessage);
            joinedEvent.Player.Broadcast(20, "<color=yellow>Welcome to my cool server!</color>", Broadcast.BroadcastFlags.Normal, true);
        }

        public void OnInteractingDoor(InteractingDoorEventArgs doorInteraction)
        {
            if (!doorInteraction.IsAllowed)
            {
                doorInteraction.Player.Broadcast(3, TutorialPlugin.Instance.Config.DoorTrapMessage);
                doorInteraction.Player.Kill(DamageTypes.Bleeding);
            }
        }
    }
}
