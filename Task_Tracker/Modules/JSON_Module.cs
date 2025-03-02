using System.Text.Json;
using Task_Tracker.Models;

namespace Task_Tracker.Modules {
    public static class JsonModule {
        public static void WriteTask(TTTask task) {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(task, options);
            File.WriteAllText("Data.json", jsonString, System.Text.Encoding.UTF8);
        }
    }
}