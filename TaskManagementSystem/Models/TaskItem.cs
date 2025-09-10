using Microsoft.VisualBasic.ApplicationServices;

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
        public string Title { get; set; }
        public string Description { get; set; }
        public System.DateTime DueDate { get; set; }
        public string Priority { get; set; } // Low, Medium, High
        public TaskStatus Status { get; set; }

        // Relationships
        public int UserId { get; set; }
        public User User { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}