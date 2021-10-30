using Exiled.API.Features;
using Exiled.Events.EventArgs;


namespace SpectatorTickets3.Handlers
{
    class ForcedEventHandlers
    {
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
