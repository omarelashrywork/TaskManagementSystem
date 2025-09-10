namespace TaskManagementSystem.Models
{
    public enum TaskStatus
    {
        Pending,
        InProgress,
        Completed
    }

    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public System.DateTime DueDate { get; set; }
        public string Priority { get; set; } = "Normal"; // Low, Medium, High
        public TaskStatus Status { get; set; }
        public System.DateTime CreatedDate { get; set; } = System.DateTime.Now;
        public System.DateTime? CompletedDate { get; set; }

        // Relationships
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    }
}