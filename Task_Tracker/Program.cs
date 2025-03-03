using Task_Tracker.Enums;
using Task_Tracker.Modules;

namespace Task_Tracker {
    internal static class Program {
        private static int Main(string[] args) {
            if (args.Length < 1) {
                Console.WriteLine("Usage: Task_Tracker [command] [arguments]");
                return (int) ReturnCodes.ERR_NOT_ENOUGH_ARGS;
            }
            
            int returnCode;
            string command = args[0];
            string[] arguments = args[1..];
            
            switch (command) {
                case "add":
                    returnCode = CommandsModule.AddTask(arguments);
                    if (returnCode != (int) ReturnCodes.OK) {
                        switch (returnCode) {
                            case (int) ReturnCodes.ERR_NOT_ENOUGH_ARGS:
                                Console.WriteLine("Usage: Task_Tracker add [description]");
                                break;
                        }
                        return returnCode;
                    }
                    Console.WriteLine("Added task successfully.");
                    break;
                
                case "delete":
                    returnCode = CommandsModule.DeleteTask(arguments);
                    if (returnCode != (int) ReturnCodes.OK) {
                        switch (returnCode) {
                            case (int) ReturnCodes.ERR_NOT_ENOUGH_ARGS:
                                Console.WriteLine("Usage: Task_Tracker delete [id]");
                                break;
                            case (int) ReturnCodes.NOT_FOUND:
                                Console.WriteLine("Specified task not found.");
                                break;
                            case (int) ReturnCodes.INVALID_INPUT:
                                Console.WriteLine("Please specify a task id.");
                                break;
                        }
                        return returnCode;
                    }
                    Console.WriteLine("Deleted task successfully.");
                    break;
                
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
            
            return (int) ReturnCodes.OK;
        }
    }
}
