using Exiled.API.Features;
using Exiled.Events.EventArgs;
using System;


namespace SpectatorTickets_EXILED3.Handlers
{

    class SpectatorInfo
    {

        /// <summary>
        /// Purpose is to show hint in the bottom right corner on death regarding how many NTF/Chaos can spawn
        /// I would use new Hint(); however, since EXILE took the ability to use custom hints, I can't
        /// without updating their source code (Which I looked at). I don't know the limits of 
        /// what I can do, and whether it breaks dependencies. I might fork and create what I need
        /// and then have that be easier to use. 
        /// </summary>
        /// <param name="deathEvent"></param>
        public void OnDeath(DiedEventArgs deathEvent)
        {
            //Automatically assume when death is called, if person died that they need to be shown hint.

            String message_to_use = new string('\n', 14) + $"<align=right><color=blue>NTF Tickets:</color> {Respawn.NtfTickets} </align>" +
                        $"\n<align=right><color=green>Chaos Tickets:</color> {Respawn.ChaosTickets} </align>";
            deathEvent.Target.ShowHint(message_to_use, 1);


        }


        internal void OnRespawn(SpawningEventArgs respawnEvent)
        {
            respawnEvent.Player.Broadcast(1, "Welcome back to the living", Broadcast.BroadcastFlags.Normal, true);
            if (respawnEvent.Player.HasHint)
            {
                respawnEvent.Player.ShowHint("", 0);
            }

        }


        /// <summary>
        /// Function purpose is to stop showing hint when round ends, respawn, etc. 
        /// </summary>
        public void onRoundRestart()
        {
            Map.ShowHint("", 0);
        }

        /// <summary>
        /// Function purpose is to force hint clear on RoundEnd
        /// </summary>
        /// <param name="args"></param>
        public void OnRoundEnd(EndingRoundEventArgs args)
        {
            Map.ShowHint("", 0);
        }


    }
}

