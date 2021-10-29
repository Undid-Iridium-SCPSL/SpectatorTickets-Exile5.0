using Exiled.API.Features;
using Exiled.Events.EventArgs;
using Exiled.Events.Commands.Show;
namespace TutorialPlugin_EXILED.Handlers
{
    class Player
    {
        public void OnLeave(LeftEventArgs leftEvent)
        {
            string leaveMessage = TutorialPlugin.Instance.Config.LeaveMessage.Replace("{Player}", leftEvent.Player.Nickname);
            //Map.Broadcast(6, $"{leftEvent.Player} has left the server.");
            Map.Broadcast(6, leaveMessage);
        }

        public void OnJoin(JoinedEventArgs joinedEvent)
        {



            Log.Info("TutorialPlugin.Instance.Config.JoinMessage: " + TutorialPlugin.Instance.Config.JoinMessage);
            string joinMessage = TutorialPlugin.Instance.Config.JoinMessage.Replace("{Player}", joinedEvent.Player.RawUserId);

            //Map.Broadcast(6, $"{enterEvent.Player} has joined the server.");

            Log.Info("What was join Message? " + joinMessage);
            //Map.Broadcast(200, "Hi THERE PARTNER", Broadcast.BroadcastFlags.AdminChat, true);

            joinedEvent.Player.Broadcast(20, "<color=yellow>Welcome to my cool server!</color>", Broadcast.BroadcastFlags.Normal, true);

            //Map.Broadcast(6, "Hello??????");
        }

        ///// <inheritdoc cref="Exiled.Events.Handlers.Player.OnJoined(JoinedEventArgs)"/>
        //public void OnVerified(VerifiedEventArgs ev)
        //{
        //    if (!TutorialPlugin.Instance.Config.JoinedBroadcast.Show)
        //        return;

        //    ev.Player.Broadcast(TutorialPlugin.Instance.Config.JoinedBroadcast.Duration, Instance.Config.JoinedBroadcast.Content, Instance.Config.JoinedBroadcast.Type, false);
        //}


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
