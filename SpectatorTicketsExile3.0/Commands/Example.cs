using CommandSystem;
using System;

namespace SpectatorTickets_EXILED3.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    class Allow : ICommand
    {
        public string Command { get; } = "Allow";

        public string[] Aliases { get; } = { };

        public string Description { get; } = "A command to be allowed";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (sender is Console)
            {
                response = "Updated plugin to do something if console";
                return true;
            }
            response = "Updated plugin to do nothing if not console";
            return false;
        }
    }
}
