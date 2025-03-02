using Task_Tracker.Models;
using Task_Tracker.Modules;

namespace Task_Tracker {
    internal static class Program {
        private static void Main(string[] args) {
            var newTask = new TTTask { Id = 1, Description = "Test", Status = 0, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now };
            JsonModule.WriteTask(newTask);
        }
    }
}