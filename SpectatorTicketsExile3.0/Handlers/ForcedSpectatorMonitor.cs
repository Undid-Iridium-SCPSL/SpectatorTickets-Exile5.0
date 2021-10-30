using Exiled.API.Features;
using System;
using System.Collections;
using UnityEngine;

namespace SpectatorTickets3.Handlers
{
    class ForcedSpectatorMonitor : MonoBehaviour
    {
        private Config ConfigObj { get; }


        //private void Update()
        //{
        //    StartCoroutine(WaitForEndOfFrame());
        //}

        /// <summary>
        /// Constant checking of player status and updating tickets appropriately. 
        /// </summary>
        /// <returns></returns>
        //IEnumerator WaitForEndOfFrame()
        //{
        //    //yield return new WaitForEndOfFrame();

        //    Log.Info("Maybe.. WaitForEndOfFrame but!: " + ConfigObj.ForceConstantUpdates);
        //    yield return null;
        //    Log.Info("Yes.. WaitForEndOfFrame but!: " + ConfigObj.ForceConstantUpdates);
        //    foreach (Player player in (Player.List))
        //    {
        //        if (player != null && player.Role != RoleType.Spectator)
        //        {
        //            if (player.HasHint)
        //            {
        //                player.ShowHint("", 0);
        //            }
        //        }
        //        else
        //        {
        //            if (!player.HasHint)
        //            {
        //                String message_to_use = new string('\n', 14) + $"<align=right><color=blue>NTF Tickets:</color> {Respawn.NtfTickets} </align>" +
        //                   $"\n<align=right><color=green>Chaos Tickets:</color> {Respawn.ChaosTickets} </align>";
        //                player.ShowHint(message_to_use, 1);

        //            }
        //        }

        //    }

        //    yield return Task.Delay(500);
        //}

        //private CoroutineHandle _coroutineHandle;
        //private Player _player;

        //private void Awake()
        //{
        //    _player = Player.Get(gameObject);
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
        //        String message_to_use = new string('\n', 14) + $"<align=right><color=blue>NTF Tickets:</color> {Respawn.NtfTickets} </align>" +
        //                           $"\n<align=right><color=green>Chaos Tickets:</color> {Respawn.ChaosTickets} </align>";
        //        TextHint test = new TextHint(message_to_use,
        //            new HintParameter[]
        //                {
        //                    new StringHintParameter("")
        //                }, HintEffectPresets.FadeInAndOut(0f, 0f, 0f), 0.6f));
        //        _player.ShowHint(message_to_use, 100);
        //        yield return Task.Delay(500);
        //    }
        //}

        //private void Destroy()
        //{
        //    Timing.KillCoroutines(_coroutineHandle);
        //    Destroy(this);
        //}
        private float updateCount = 0;
        private float fixedUpdateCount = 0;
        private float updateUpdateCountPerSecond;
        private float updateFixedUpdateCountPerSecond;



        void Awake()
        {
            // Uncommenting this will cause framerate to drop to 10 frames per second.
            // This will mean that FixedUpdate is called more often than Update.
            //Application.targetFrameRate = 10;
            StartCoroutine(Loop());
        }

        // Increase the number of calls to Update.
        void Update()
        {
            updateCount += 1;
        }


        void FixedUpdate()
        {
            Log.Info("Fixed update: " + fixedUpdateCount);
            Console.WriteLine(fixedUpdateCount);
            fixedUpdateCount += 1;
        }



        // Update both CountsPerSecond values every second.
        IEnumerator Loop()
        {
            while (true)
            {
                Log.Info(fixedUpdateCount);
                Console.WriteLine(fixedUpdateCount);
                yield return new WaitForSeconds(1);

                updateUpdateCountPerSecond = updateCount;
                updateFixedUpdateCountPerSecond = fixedUpdateCount;

                updateCount = 0;
                fixedUpdateCount = 0;
            }
        }

    }
}
