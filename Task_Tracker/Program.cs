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
                            case (int) ReturnCodes.ERR_NOT_FOUND:
                                Console.WriteLine("Specified task not found.");
                                break;
                            case (int) ReturnCodes.ERR_INVALID_INPUT:
                                Console.WriteLine("Please specify a correct task id.");
                                break;
                        }
                        return returnCode;
                    }
                    Console.WriteLine("Deleted task successfully.");
                    break;
                
                case "update":
                    returnCode = CommandsModule.UpdateTask(arguments);
                    if (returnCode != (int)ReturnCodes.OK) {
                        switch (returnCode) {
                            case (int) ReturnCodes.ERR_NOT_ENOUGH_ARGS:
                                Console.WriteLine("Usage: Task_Tracker update [id] [description/status] [new description/status]");
                                break;
                            case (int) ReturnCodes.ERR_INVALID_INPUT + 1001:
                                Console.WriteLine("Please specify a correct task id.");
                                returnCode -= 1001;
                                break;
                            case (int) ReturnCodes.ERR_INVALID_INPUT + 1002:
                                Console.WriteLine("Please specify what do you want to update correctly (description/status).");
                                returnCode -= 1002;
                                break;
                            case (int) ReturnCodes.ERR_INVALID_INPUT + 1003:
                                Console.WriteLine("Please specify a correct status (Todo, InProgress, Done).");
                                returnCode -= 1003;
                                break;
                            case (int) ReturnCodes.ERR_NOT_FOUND:
                                Console.WriteLine("Specified task not found.");
                                break;
                        }
                        return returnCode;
                    }
                    Console.WriteLine("Updated task successfully.");
                    break;
                
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
            
            return (int) ReturnCodes.OK;
        }
    }
}
