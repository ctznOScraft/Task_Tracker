using Task_Tracker.Enums;

namespace Task_Tracker.Models {
    public class TTTask {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public Status Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}