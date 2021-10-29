using Exiled.API.Features;
using Exiled.Events.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TutorialPlugin_EXILED.Handlers
{
    class Server
    {
        public void OnWaitingForPlayers()
        {
            Log.Info("Waiting for players.");
            DebugLog.Log("Waiting for players???.");
        }

        public void OnRoundStarted()
        {
            Map.Broadcast(6, TutorialPlugin.Instance.Config.RoundStartMessage);
        }

       
    }
}
