﻿using Exiled.API.Interfaces;
using System.ComponentModel;
namespace SpectatorTickets3
{
    public sealed class Config : IConfig
    {
        //public bool IsEnabled { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        [Description("Whether to enable or disable plugin")]
        public bool IsEnabled { get; set; } = true;

        [Description("Force updates by hijacking gameobject component. ")]
        public bool ForceConstantUpdates { get; set; } = false;

        [Description("Whether to allow time for respawn for either team")]
        public bool ShowTimeForRespawn { get; set; } = false;



        [Description("Sets the message when the rounds starts.")]
        public string RoundStartMessage { get; set; } = "Time to die!";


        [Description("Sets the message when a booby trapped door is touched")]
        public string DoorTrapMessage { get; set; } = "My trap door is activated My trap has been activated!!";


    }
}
