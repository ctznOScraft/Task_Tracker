using Task_Tracker.Enums;
using Task_Tracker.Exceptions;
using Task_Tracker.Services;
using Task_Tracker.Models;

namespace Task_Tracker;

internal static class Program {
    private static async Task<int> Main(string[] args) {
        if (args.Length < 1) {
            Console.WriteLine("Usage: Task_Tracker [command] [arguments]");
            return (int)ReturnCodes.ERR_NOT_ENOUGH_ARGS;
        }

        var configService = new ConfigService();
        var dataStorage = new JsonStorage(configService.GetDbFileName());

        var utilityService = new UtilityService();
        var commandService = new CommandService(dataStorage, utilityService, configService);
        
        string command = args[0];
        string[] arguments = args[1..];
        
        try {
            switch (command) {
                case "add":
                    TTTask addedTask = await commandService.AddTask(arguments);
                    Console.WriteLine($"Added task successfully: [ID: {addedTask.Id}] \"{addedTask.Description}\"");
                    break;
                
                case "delete":
                    await commandService.DeleteTask(arguments);
                    Console.WriteLine("Deleted task successfully.");
                    break;
                
                case "update":
                    await commandService.UpdateTask(arguments);
                    Console.WriteLine("Updated task successfully.");
                    break;
                
                case "list":
                    await commandService.ListTasks(arguments);
                    break;
                
                case "config":
                    commandService.Config(arguments);
                    Console.WriteLine("Updated configuration successfully.");
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
