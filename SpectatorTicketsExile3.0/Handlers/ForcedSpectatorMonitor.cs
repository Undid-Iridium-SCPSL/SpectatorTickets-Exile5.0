using Exiled.API.Features;
using MEC;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpectatorTickets3.Handlers
{
    class ForcedSpectatorMonitor : MonoBehaviour
    {

        Config Config = new Config();
        private Player current_player;
#pragma warning disable IDE0051 // Remove unused private members to be ignored
        /// <summary>
        /// Awake function hooked into by Unity, allows game object to know when to run this script
        /// </summary>
        private void Awake()
        {
            current_player = Player.Get(gameObject);
            Timing.RunCoroutine(TicketCoroutine());
        }
#pragma warning restore IDE0051 // Allow unused private members to not be ignored

        /// <summary>
        /// Updates Ticket count every ~second so that information can be readily available to players. 
        /// https://docs.unity3d.com/Packages/com.unity.ugui@1.0/manual/StyledText.html
        /// 
        /// Unfortunately, time_to_respawn, and Respawn can't tell me which team is supposed
        /// to spawn next. So, no information that will be displayed. 
        /// </summary>
        /// <returns></returns>
        IEnumerator<float> TicketCoroutine()
        {

            while (true)
            {
                //Log.Info("What is the current player doing: " + current_player.ToString());
                //Log.Info("What is the current role: " + current_player.Role + " versus : " + RoleType.Spectator);



                String message_to_use = new string('\n', 14) + $"<align=right><color=#1A5E63>NTF Tickets:</color> {Respawn.NtfTickets} </align>" +
                      $"\n<align=right><color=green>Chaos Tickets:</color> {Respawn.ChaosTickets}  </align>";

                if (Config.ShowTimeForRespawn)
                {
                    int time_to_respawn = ((int)Math.Ceiling(Respawn.TimeUntilRespawn / 100.0)) * 100;
                    message_to_use += $"\n<align=right><color=#247BA0>Estimated Respawn Time:</color> {time_to_respawn}  </align>";
                }

                current_player.ShowHint(message_to_use, 1.5F);

                yield return Timing.WaitForSeconds(.8F);

                if ((current_player == null || current_player.Role != RoleType.Spectator) && current_player.IsAlive)
                {
                    current_player.ShowHint("", 1);
                    break;
                }
            }
        }
#pragma warning disable IDE0051 // Remove unused private members to be ignored
        private void Destroy()
        {
            current_player.ShowHint("", 0);
            StopCoroutine(TicketCoroutine());
            Destroy(this);
        }
#pragma warning restore IDE0051 // Allow unused private members to not be ignored
    }
}
