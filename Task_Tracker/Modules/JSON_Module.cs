using System.Text.Json;
using Task_Tracker.Models;

namespace Task_Tracker.Modules;

public static class JsonModule {
    private const string FileName = "Data.json";
    
    public static void WriteFile(List<TTTask> data) {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(data, options);
        File.WriteAllText(FileName, jsonString, System.Text.Encoding.UTF8);
    }

    public static List<TTTask> ReadFile() {
        if (!File.Exists(FileName))
            return [];
        string jsonString = File.ReadAllText(FileName);
        return JsonSerializer.Deserialize<List<TTTask>>(jsonString)!;
    }
}
