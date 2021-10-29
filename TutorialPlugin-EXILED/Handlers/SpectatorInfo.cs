using Exiled.API.Features;
using Exiled.Events;
using Exiled.Events.EventArgs;
using Hints;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;


namespace TutorialPlugin_EXILED.Handlers 
{
    class SpectatorInfo 
    {

        bool stop_showing_tickets = false;

        public async void OnDeath(DiedEventArgs deathEvent)
        {

            Log.Info("Player has died; here's some broadcast");

            stop_showing_tickets = false;
            while (!stop_showing_tickets)
            {
                //deathEvent.Target.Broadcast(1, "<color=yellow>Welcome to my cool server!</color>" + Respawn.ChaosTickets + "\n" + Respawn.NtfTickets, Broadcast.BroadcastFlags.Normal, true);
                Log.Info("Player has died; here's some broadcast in loop");


                String message_to_use = $"\n\n\n\n\n\n\n\n\n\n\n\n\n\n<align=right><color=blue>MTF Tickets:</color> {Respawn.NtfTickets} </align>" +
                        $"\n<align=right><color=green>Chaos Tickets:</color> {Respawn.ChaosTickets} </align>";

                //deathEvent.Target.ShowHint(
                //    $"We have {Respawn.NtfTickets} NTF tickets left \n" +
                //    $"We have {Respawn.ChaosTickets} Chaos tickets left \n"
                //    , 1);

                deathEvent.Target.ShowHint(message_to_use);

                //deathEvent.Target.Show(new TextHint(message_to_use,
                //        new HintParameter[]
                //        {
                //            new StringHintParameter(message_to_use)
                //        },
                //        HintEffectPresets.FadeInAndOut(0f, 0f, 0.6f), 1);

                await Task.Delay(1000);
            }
        


            //Map.Broadcast(6, "Hello??????");
        }


        internal void OnRespawn(SpawningEventArgs respawnEvent)
        {
            Log.Info("Player has revived; here's some broadcast");
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

        //Respawn has:

        //        public static int TimeUntilRespawn { get; }
        //public static bool IsSpawning { get; }
        //public static int NtfTickets { get; }
        //public static int ChaosTickets { get; }

        //public void onRespawn(Respawn respawnEvent)
        //{
        //    respawnEvent.
        //    Log.Info("Player has died; here's some broadcast");

        //    respawnEvent.Broadcast(20, "<color=yellow>Welcome to my cool server!</color>", Broadcast.BroadcastFlags.Normal, true);

        //    //Map.Broadcast(6, "Hello??????");
        //}

        //private void Awake()
        //{
        //    current_player = new Player();
        //    _coroutineHandle = Timing.RunCoroutine(HintDisplay());
        //}

        //private void Update()
        //{
        //    if (_player == null || _player.Role != RoleType.Spectator)
        //        Destroy();
        //}

        //private IEnumerator<float> HintDisplay()
        //{
        //    while (true)
        //    {
        //        _player.HintDisplay.Show(
        //            new TextHint(
        //                $"\n\n\n\n\n\n\n\n\n\n\n\n\n\n<align=right><color=blue>MTF Tickets:</color> {Respawning.RespawnTickets.Singleton.GetAvailableTickets(Respawning.SpawnableTeamType.NineTailedFox)}</align>" +
        //                $"\n<align=right><color=green>Chaos Tickets:</color> {Respawning.RespawnTickets.Singleton.GetAvailableTickets(Respawning.SpawnableTeamType.ChaosInsurgency)}</align>",
        //                new HintParameter[]
        //                {
        //                    new StringHintParameter("")
        //                },
        //                HintEffectPresets.FadeInAndOut(0f, 0f, 0f), 0.6f));
        //        yield return Timing.WaitForSeconds(0.5f);
        //    }
        //}

        //private void Destroy()
        //{
        //    Timing.KillCoroutines(_coroutineHandle);
        //    Destroy(this);
        //}
    }
}

