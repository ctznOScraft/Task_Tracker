using Task_Tracker.Enums;
using Task_Tracker.Models;

namespace Task_Tracker.Modules {
    public static class CommandsModule {
        public static int AddTask(string[] data) {
            if (data.Length < 1) {
                return (int) ReturnCodes.ERR_NOT_ENOUGH_ARGS;
            }

            List<TTTask> curTasks = JsonModule.ReadFile();
            int newId = UtilityModule.GenerateTaskId(curTasks);
            var newTask = new TTTask {
                Id = newId, 
                Description = data[0], 
                Status = Status.Todo, 
                CreatedAt = DateTime.Now, 
                UpdatedAt = DateTime.Now
            };
            
            if (curTasks.Count == 0) {
                curTasks = [newTask];
            }
            else {
                curTasks.Add(newTask);
            }
            JsonModule.WriteFile(curTasks);
            
            return (int) ReturnCodes.OK;
        }

        public static int DeleteTask(string[] data) {
            if (data.Length < 1) {
                return (int) ReturnCodes.ERR_NOT_ENOUGH_ARGS;
            }
            
            int deleteId = Convert.ToInt32(data[0]);
            List<TTTask> curTasks = JsonModule.ReadFile();
            int[] curTasksIds = UtilityModule.GetTasksIds(curTasks);
            bool found = false;

            for (int i = 0; i < curTasksIds.Length; i++) {
                if (curTasksIds[i] == deleteId) {
                    curTasks.RemoveAt(i);
                    found = true;
                    break;
                }
            }
            if (!found) {
                return (int)ReturnCodes.NOT_FOUND;
            }
            JsonModule.WriteFile(curTasks);
            
            return (int) ReturnCodes.OK;
        }
    }
}