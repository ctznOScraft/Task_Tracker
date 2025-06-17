using Task_Tracker.Enums;
using Task_Tracker.Models;
using Task_Tracker.Exceptions;

namespace Task_Tracker.Modules;

public static class CommandsModule {
    public static void AddTask(string[] data) {
        if (data.Length < 1)
            throw new NotEnoughArgumentsException("add");

        List<TTTask> curTasks = JsonModule.ReadFile();
        int newId = UtilityModule.GenerateTaskId(curTasks);
        var newTask = new TTTask {
            Id = newId, 
            Description = data[0], 
            Status = Status.Todo, 
            CreatedAt = DateTime.Now, 
            UpdatedAt = DateTime.Now
        };
    
        curTasks.Add(newTask);
        JsonModule.WriteFile(curTasks);
    }

    public static void DeleteTask(string[] data) {
        if (data.Length < 1)
            throw new NotEnoughArgumentsException("delete");
        if (!data[0].All(char.IsDigit))
            throw new InvalidTaskIdException();
    
        int deleteId = Convert.ToInt32(data[0]);
        List<TTTask> curTasks = JsonModule.ReadFile();
        int index = curTasks.FindIndex(t => t.Id == deleteId);
        if (index == -1)
            throw new TaskNotFoundException(deleteId);

        curTasks.RemoveAt(index);
        JsonModule.WriteFile(curTasks);
    }

    public static void UpdateTask(string[] data) {
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
        List<TTTask> curTasks = JsonModule.ReadFile();
        int index = curTasks.FindIndex(t => t.Id == updateId);
        if (index == -1)
            throw new TaskNotFoundException(updateId);

        curTasks[index].UpdateField(updateField, updateValue);
        curTasks[index].UpdatedAt = DateTime.Now;
        JsonModule.WriteFile(curTasks);
    }
}
