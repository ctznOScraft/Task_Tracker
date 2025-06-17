using System.Text.Json;
using Task_Tracker.Interfaces;
using Task_Tracker.Models;

namespace Task_Tracker.Services;

public class JsonStorage(string dbFileName) : IDataStorage {
    public async Task WriteFileAsync(List<TTTask> data) {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(data, options);
        await File.WriteAllTextAsync(dbFileName, jsonString, System.Text.Encoding.UTF8);
    }

    public async Task<List<TTTask>> ReadFileAsync() {
        if (!File.Exists(dbFileName))
            return [];
        string jsonString = await File.ReadAllTextAsync(dbFileName);
        return JsonSerializer.Deserialize<List<TTTask>>(jsonString)!;
    }
}
