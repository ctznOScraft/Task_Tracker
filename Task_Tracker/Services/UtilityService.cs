using Task_Tracker.Enums;
using Task_Tracker.Models;

namespace Task_Tracker.Services;

public class UtilityService {
    private int[] GetTasksIds(List<TTTask> tasks) {
        return tasks.Select(x => x.Id).ToArray();
    }
    
    public int GenerateTaskId(List<TTTask> tasks) {
        if (tasks.Count == 0)
            return 0;
        int[] taskIds = GetTasksIds(tasks);
        int maxId = taskIds.Max();
        return maxId + 1;
    }

    public List<TTTask> SelectTasks(List<TTTask> tasks, Status status) {
        return tasks.Where(x => x.Status == status).ToList();
    }

    public void ShowTasks(List<TTTask> tasks) {
        if (tasks.Count == 0) {
            Console.WriteLine("There are no tasks to show.");
            return;
        }
        
        const int idWidth = 4;
        const int descWidth = 30;
        const int statusWidth = 10;
        const int dateWidth = 20;
        
        string header = $"{"Id",-idWidth} | {"Description",-descWidth} | {"Status",-statusWidth} | {"Created At",-dateWidth} | {"Updated At",-dateWidth}";
        Console.WriteLine(header);
        Console.WriteLine(new string('-', header.Length));

        foreach (TTTask task in tasks)
        {
            string desc = task.Description.Length > descWidth ? task.Description.Substring(0, descWidth - 3) + "..." : task.Description;
            string status = task.Status.ToString();
            string createdAt = task.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss");
            string updatedAt = task.UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss");
            string line = $"{task.Id,-idWidth} | {desc,-descWidth} | {status,-statusWidth} | {createdAt,-dateWidth} | {updatedAt,-dateWidth}";
            Console.WriteLine(line);
        }
    }
}
