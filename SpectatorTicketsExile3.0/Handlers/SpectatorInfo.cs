using Exiled.API.Features;
using Exiled.Events.EventArgs;
using System;
using System.Threading.Tasks;


namespace SpectatorTickets_EXILED3.Handlers
{
    class SpectatorInfo
    {

        bool stop_showing_tickets = false;

        public async void OnDeath(DiedEventArgs deathEvent)
        {
            stop_showing_tickets = false;
            while (!stop_showing_tickets)
            {
                String message_to_use = $"\n\n\n\n\n\n\n\n\n\n\n\n\n\n<align=right><color=blue>MTF Tickets:</color> {Respawn.NtfTickets} </align>" +
                        $"\n<align=right><color=green>Chaos Tickets:</color> {Respawn.ChaosTickets} </align>";

                deathEvent.Target.ShowHint(message_to_use);
                await Task.Delay(1000);
            }
        }


        internal void OnRespawn(SpawningEventArgs respawnEvent)
        {
            respawnEvent.Player.Broadcast(1, "Welcome back to the living", Broadcast.BroadcastFlags.Normal, true);
            this.stop_showing_tickets = true;
        }


        public void onRoundRestart()
        {
            this.stop_showing_tickets = true;
        }
        public void OnRoundEnd(EndingRoundEventArgs args)
        {
            this.stop_showing_tickets = true;
        }


    }
}

