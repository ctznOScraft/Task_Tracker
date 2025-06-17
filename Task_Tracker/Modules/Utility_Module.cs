using Task_Tracker.Models;

namespace Task_Tracker.Modules;

public static class UtilityModule {
    public static int[] GetTasksIds(List<TTTask> tasks) {
        return tasks.Select(x => x.Id).ToArray();
    }
    
    public static int GenerateTaskId(List<TTTask> tasks) {
        if (tasks.Count == 0) {
            return 0;
        }
        int[] taskIds = GetTasksIds(tasks);
        int maxId = taskIds.Max();
        return maxId + 1;
    }
}
