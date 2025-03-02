using Task_Tracker.Enums;
using Task_Tracker.Modules;

namespace Task_Tracker {
    internal static class Program {
        private static int Main(string[] args) {
            if (args.Length < 1) {
                Console.WriteLine("Usage: Task_Tracker.exe [command]");
                return (int) ReturnCodes.ERR_NOT_ENOUGH_ARGS;
            }
            
            string command = args[0];
            string[] arguments = args[1..];
            switch (command) {
                case "add":
                    int returnCode = CommandsModule.AddTask(arguments);
                    if (returnCode != (int) ReturnCodes.OK) {
                        Console.WriteLine("Add task failed.");
                        return returnCode;
                    }
                    break;
            }
            
            return (int) ReturnCodes.OK;
        }
    }
}
