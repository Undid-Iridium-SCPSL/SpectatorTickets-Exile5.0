using Exiled.API.Features;
using Exiled.Events.EventArgs;
using System;
using System.Threading.Tasks;


namespace SpectatorTickets_EXILED3.Handlers
{

    class SpectatorInfo
    {

        bool stop_showing_tickets = false;

        /// <summary>
        /// Purpose is to show hint in the bottom right corner on death regarding how many NTF/Chaos can spawn
        /// </summary>
        /// <param name="deathEvent"></param>
        public async void OnDeath(DiedEventArgs deathEvent)
        {
            //Automatically assume when death is called, if person died that they need to be shown hint.
            stop_showing_tickets = false;
            while (!stop_showing_tickets)
            {
                String message_to_use = new string('\n', 14) + $"<align=right><color=blue>NTF Tickets:</color> {Respawn.NtfTickets} </align>" +
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


        /// <summary>
        /// Function purpose is to stop showing him in OnDeath when round ends, respawn, etc. 
        /// </summary>
        public void onRoundRestart()
        {
            this.stop_showing_tickets = true;
        }

        /// <summary>
        /// Function purpose is a dummy function to allow us to run this on round end to stop pushing hint in OnDeath
        /// </summary>
        /// <param name="args"></param>
        public void OnRoundEnd(EndingRoundEventArgs args)
        {
            this.stop_showing_tickets = true;
        }


    }
}

