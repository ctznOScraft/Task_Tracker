using System.Text.Json;
using Task_Tracker.Models;

namespace Task_Tracker.Modules {
    public static class JsonModule {
        public static void WriteTask(TTTask task) {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(task, options);
            try {
                File.WriteAllText("Data.json", jsonString, System.Text.Encoding.UTF8);
            }
            catch (Exception ex) {
                Console.WriteLine($"Error while writing data: {ex.Message}");
            }
        }
    }
}