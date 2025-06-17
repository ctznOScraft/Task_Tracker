using Task_Tracker.Enums;
using Task_Tracker.Modules;
using Task_Tracker.Exceptions;

namespace Task_Tracker;

internal static class Program {
    private static int Main(string[] args) {
        if (args.Length < 1) {
            Console.WriteLine("Usage: Task_Tracker [command] [arguments]");
            return (int)ReturnCodes.ERR_NOT_ENOUGH_ARGS;
        }
        
        string command = args[0];
        string[] arguments = args[1..];
        
        try {
            switch (command) {
                case "add":
                    CommandsModule.AddTask(arguments);
                    Console.WriteLine("Added task successfully.");
                    break;
                
                case "delete":
                    CommandsModule.DeleteTask(arguments);
                    Console.WriteLine("Deleted task successfully.");
                    break;
                
                case "update":
                    CommandsModule.UpdateTask(arguments);
                    Console.WriteLine("Updated task successfully.");
                    break;
                
                default:
                    Console.WriteLine("Invalid command.");
                    return (int)ReturnCodes.ERR_INVALID_COMMAND;
            }
        }
        catch (TaskTrackerException ex) {
            Console.WriteLine(ex.Message);
            return (int)ex.ErrorCode;
        }
        catch (Exception ex) {
            Console.WriteLine($"Unexpected error: {ex.Message}");
            return -1;
        }
        
        return (int)ReturnCodes.OK;
    }
}
