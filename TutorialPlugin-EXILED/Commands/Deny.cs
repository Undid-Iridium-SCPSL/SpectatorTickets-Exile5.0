using CommandSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialPlugin_EXILED.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    class Deny : ICommand
    {
        public string Command { get; } = "Deny";

        public string[] Aliases { get; } = { };

        public string Description { get; } = "A command to be denied";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {

            response = "Rejected command";
            return false;

        }
    }
}
