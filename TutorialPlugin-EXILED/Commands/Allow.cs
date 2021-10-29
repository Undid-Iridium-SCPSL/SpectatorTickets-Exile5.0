using CommandSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialPlugin_EXILED.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    class Allow : ICommand
    {
        public string Command { get; } = "Allow";

        public string[] Aliases { get; } = { };

        public string Description { get; } = "A command to be allowed";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {

            response = "Accepted command";
            return true;

        }
    }
}
