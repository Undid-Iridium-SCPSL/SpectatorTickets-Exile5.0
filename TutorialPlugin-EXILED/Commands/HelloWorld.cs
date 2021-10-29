using CommandSystem;
using RemoteAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialPlugin_EXILED.Commands
{

    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    class HelloWorld : ICommand
    {
        public string Command { get; }  = "Hi";

        public string[] Aliases { get; } = { "hw" };

        public string Description { get; } = "Command to say hello world";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if(sender is PlayerCommandSender currentPlayer)
            {
                response = $"Hello {currentPlayer.Nickname}";
                return false;
            }
            response = "World!";
            return true;

        }
    }
}
