using Exiled.API.Features;
using Exiled.Events.EventArgs;


namespace SpectatorTickets3.Handlers
{
    class ForcedEventHandlers
    {
        /// <summary>
        /// Handles changing of class to spectator or others, if spectator then we apply game component
        /// which hijacks the GameObject's script and adds extra logic to handle showing tickets. 
        /// </summary>
        /// <param name="changeRoleEvent"></param>
        internal void OnRoleChange(ChangingRoleEventArgs changeRoleEvent)
        {
            if (changeRoleEvent.NewRole is RoleType.Spectator && Round.IsStarted)
            {
                changeRoleEvent.Player.GameObject.AddComponent<ForcedSpectatorMonitor>();
            }
            else if (Round.IsStarted)
            {
                changeRoleEvent.Player.ShowHint("", 1);
            }

        }
    }
}
