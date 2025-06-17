using Task_Tracker.Enums;
using Task_Tracker.Exceptions;
using Task_Tracker.Interfaces;
using Task_Tracker.Models;

namespace Task_Tracker.Services;

public class CommandService(IDataStorage dataStorage, UtilityService utilityService, ConfigService configService) { 
    public async Task<TTTask> AddTask(string[] data) {
        if (data.Length < 1)
            throw new NotEnoughArgumentsException("add");

        List<TTTask> curTasks = await dataStorage.ReadFileAsync();
        int newId = utilityService.GenerateTaskId(curTasks);
        var newTask = new TTTask {
            Id = newId, 
            Description = data[0], 
            Status = Status.Todo, 
            CreatedAt = DateTime.Now, 
            UpdatedAt = DateTime.Now
        };
    
        curTasks.Add(newTask);
        await dataStorage.WriteFileAsync(curTasks);
        
        return newTask;
    }

    public async Task DeleteTask(string[] data) {
        if (data.Length < 1)
            throw new NotEnoughArgumentsException("delete");
        if (!data[0].All(char.IsDigit))
            throw new InvalidTaskIdException();
    
        int deleteId = Convert.ToInt32(data[0]);
        List<TTTask> curTasks = await dataStorage.ReadFileAsync();
        int index = curTasks.FindIndex(t => t.Id == deleteId);
        if (index == -1)
            throw new TaskNotFoundException(deleteId);

        curTasks.RemoveAt(index);
        await dataStorage.WriteFileAsync(curTasks);
    }

    public async Task UpdateTask(string[] data) {
        if (data.Length < 3)
            throw new NotEnoughArgumentsException("update");
        if (!data[0].All(char.IsDigit))
            throw new InvalidTaskIdException();
        if (data[1] != "description" && data[1] != "status")
            throw new InvalidUpdateFieldException(data[1]);
        if (data[1] == "status" && !Enum.IsDefined(typeof(Status), data[2]))
            throw new InvalidStatusValueException(data[2]);
    
        int updateId = Convert.ToInt32(data[0]);
        string updateField = data[1];
        string updateValue = data[2];
        List<TTTask> curTasks = await dataStorage.ReadFileAsync();
        int index = curTasks.FindIndex(t => t.Id == updateId);
        if (index == -1)
            throw new TaskNotFoundException(updateId);

        curTasks[index].UpdateField(updateField, updateValue);
        curTasks[index].UpdatedAt = DateTime.Now;
        await dataStorage.WriteFileAsync(curTasks);
    }

    public async Task ListTasks(string[] data) {
        List<TTTask> curTasks = await dataStorage.ReadFileAsync();
        if (data.Length > 0) {
            if (!Enum.IsDefined(typeof(Status), data[0])) 
                throw new InvalidListOptionException(data[0]);
            Status option = Enum.Parse<Status>(data[0]);
            List<TTTask> tasksToShow = utilityService.SelectTasks(curTasks, option);
            utilityService.ShowTasks(tasksToShow);
        }
        else {
            utilityService.ShowTasks(curTasks);
        }
    }

    public void Config(string[] data) {
        if (data.Length < 1)
            throw new NotEnoughArgumentsException("config");
        
        switch (data[0]) {
            case "dbname":
                if (data.Length < 2)
                    throw new UnspecifiedFileNameException();
                configService.SetDbFileName(data[1]);
                break;
            
            default:
                throw new InvalidConfigOptionException(data[0]);
        }
    }
}
