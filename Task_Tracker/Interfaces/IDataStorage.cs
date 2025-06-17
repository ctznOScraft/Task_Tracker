using Task_Tracker.Models;

namespace Task_Tracker.Interfaces;

public interface IDataStorage {
    Task<List<TTTask>> ReadFileAsync();
    Task WriteFileAsync(List<TTTask> data);
}