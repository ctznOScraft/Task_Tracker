using Task_Tracker.Enums;

namespace Task_Tracker.Models {
    public class Task {
        public int Id;
        public string Description = string.Empty;
        public Status Status;
        public DateTime CreatedAt;
        public DateTime UpdatedAt;
    }
}