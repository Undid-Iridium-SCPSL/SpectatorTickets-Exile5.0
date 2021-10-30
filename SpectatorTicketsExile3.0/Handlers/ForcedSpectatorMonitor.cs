using Exiled.API.Features;
using System;
using System.Collections;
using UnityEngine;

namespace SpectatorTickets3.Handlers
{
    class ForcedSpectatorMonitor : MonoBehaviour
    {

        private Player current_player;
#pragma warning disable IDE0051 // Remove unused private members to be ignored
        private void Awake()
        {
            current_player = Player.Get(gameObject);
            StartCoroutine(TicketCoroutine());
        }
#pragma warning restore IDE0051 // Allow unused private members to be not ignored

        // Update both CountsPerSecond values every second.
        IEnumerator TicketCoroutine()
        {

            while (true)
            {
                //Log.Info("What is the current player doing: " + current_player.ToString());
                //Log.Info("What is the current role: " + current_player.Role + " versus : " + RoleType.Spectator);


                String message_to_use = new string('\n', 14) + $"<align=right><color=blue>NTF Tickets:</color> {Respawn.NtfTickets} </align>" +
                      $"\n<align=right><color=green>Chaos Tickets:</color> {Respawn.ChaosTickets} </align>";
                current_player.ShowHint(message_to_use, 1.5F);

                yield return new WaitForSeconds(.8F);

                if ((current_player == null || current_player.Role != RoleType.Spectator) && current_player.IsAlive)
                {
                    current_player.ShowHint("", 1);
                    break;
                }
            }
        }

    }
}
