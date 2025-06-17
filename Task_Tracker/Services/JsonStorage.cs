using System.Text.Json;
using Task_Tracker.Interfaces;
using Task_Tracker.Models;

namespace Task_Tracker.Services;

public class JsonStorage : IDataStorage {
    private const string FileName = "Data.json";
    
    public async Task WriteFileAsync(List<TTTask> data) {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(data, options);
        await File.WriteAllTextAsync(FileName, jsonString, System.Text.Encoding.UTF8);
    }

    public async Task<List<TTTask>> ReadFileAsync() {
        if (!File.Exists(FileName))
            return [];
        string jsonString = await File.ReadAllTextAsync(FileName);
        return JsonSerializer.Deserialize<List<TTTask>>(jsonString)!;
    }
}
