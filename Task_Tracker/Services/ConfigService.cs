using System.Text.Json;
using Task_Tracker.Models;

namespace Task_Tracker.Services;

public class ConfigService {
    private const string ConfigFileName = "config.json";
    private AppConfig _config = new AppConfig();

    public ConfigService() {
        LoadConfig();
    }

    public string GetDbFileName() {
        return _config.DbFileName;
    }

    public void SetDbFileName(string fileName) {
        _config.DbFileName = fileName;
        SaveConfig();
    }

    private void LoadConfig() {
        if (File.Exists(ConfigFileName)) {
            try {
                string jsonString = File.ReadAllText(ConfigFileName);
                _config = JsonSerializer.Deserialize<AppConfig>(jsonString) ?? new AppConfig();
            } 
            catch (Exception ex) {
                Console.WriteLine($"Error loading config: {ex.Message}. Using default settings.");
                _config = new AppConfig();
            }
        }
    }

    private void SaveConfig() {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(_config, options);
        File.WriteAllText(ConfigFileName, jsonString);
    }
}