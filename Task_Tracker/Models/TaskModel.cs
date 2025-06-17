using Task_Tracker.Enums;

namespace Task_Tracker.Models;

public class TTTask {
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public Status Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public void UpdateField(string field, object value) {
        switch (field.ToLower()) {
            case "id":
                Id = Convert.ToInt32(value);
                break;
            case "description":
                Description = value.ToString() ?? string.Empty;
                break;
            case "status":
                Status = Enum.Parse<Status>(value.ToString()!);
                break;
            case "createdat":
                if (value is DateTime created)
                    CreatedAt = created;
                break;
            case "updatedat":
                if (value is DateTime updated)
                    UpdatedAt = updated;
                break;
        }
    }
}
