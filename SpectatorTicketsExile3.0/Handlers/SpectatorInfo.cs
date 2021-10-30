
namespace SpectatorTickets3.Handlers
{
    using Exiled.API.Features;
    using Exiled.Events.EventArgs;
    using System;
    using System.Threading.Tasks;
    using Player = Exiled.API.Features.Player;
    class SpectatorInfo : Plugin<Config>, MonoBehaviour
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
            deathEvent.Target.ShowHint(message_to_use, 10000);
        }

        /// <summary>
        /// When a player respawns, we need a way to wipe their hints if they have any. 
        /// We DO not care about updating on every respawn, I do not think we should. Why?
        /// Because that's expensive, and minimal difference in experience. 
        /// </summary>
        /// <param name="respawnEvent"></param>
        internal void OnRespawn(SpawningEventArgs respawnEvent)
        {
            if (respawnEvent.Player.HasHint)
            {
                respawnEvent.Player.ShowHint("", 0);
            }

        }

        /// <summary>
        /// Class change to spectator should allow you to see NTF/Chaos tickets. 
        /// </summary>
        /// <param name="changedRoleEvent"></param>
        internal void OnChanginRole(ChangingRoleEventArgs changedRoleEvent)
        {
            if (changedRoleEvent.NewRole is RoleType.Spectator)
            {
                String message_to_use = new string('\n', 14) + $"<align=right><color=blue>NTF Tickets:</color> {Respawn.NtfTickets} </align>" +
                        $"\n<align=right><color=green>Chaos Tickets:</color> {Respawn.ChaosTickets} </align>";
                changedRoleEvent.Player.ShowHint(message_to_use, 10000);
            }
        }


        /// <summary>
        /// Function purpose is to stop showing hint when round ends, respawn, etc. 
        /// </summary>
        public void OnRoundRestart()
        {
            Map.ShowHint("", 0);
        }

        /// <summary>
        /// All respawned players need hint removed (should be done by OnRespawn but secondary check)
        /// All non-respawned who are dead need to have their values updated. 
        /// </summary>
        /// <param name="team_respawn"></param>
        internal void OnTeamSpawn(RespawningTeamEventArgs team_respawn)
        {
            System.Collections.Generic.List<Player> current_respawning_players = team_respawn.Players;
            foreach (Player current_respawned_player in current_respawning_players)
            {
                if (current_respawned_player.HasHint)
                {
                    current_respawned_player.ShowHint("", 0);
                }
            }

            foreach (Player player in (Player.List))
            {
                if (!current_respawning_players.Contains(player) && player.IsDead)
                {
                    String message_to_use = new string('\n', 14) + $"<align=right><color=blue>NTF Tickets:</color> {Respawn.NtfTickets} </align>" +
                       $"\n<align=right><color=green>Chaos Tickets:</color> {Respawn.ChaosTickets} </align>";
                    player.ShowHint(message_to_use, 10000);
                }

            }
        }



        /// <summary>
        /// Constant checking of player status and updating tickets appropriately. 
        /// </summary>
        /// <returns></returns>
        public System.Collections.Generic.IEnumerable<Task> HintDisplay()
        {
            Log.Info("Yes.. force update but!: " + Config.ForceConstantUpdates);
            while (Config.ForceConstantUpdates)
            {
                Log.Info("Constantly forcing this to run.. right?");
                foreach (Player player in (Player.List))
                {
                    if (player.IsDead && player.Role is RoleType.Spectator)
                    {
                        String message_to_use = new string('\n', 14) + $"<align=right><color=blue>NTF Tickets:</color> {Respawn.NtfTickets} </align>" +
                           $"\n<align=right><color=green>Chaos Tickets:</color> {Respawn.ChaosTickets} </align>";
                        player.ShowHint(message_to_use, 1);
                    }

                }
                yield return Task.Delay(800);
            }
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

