using System.Collections.Generic;

namespace TaskManagementSystem.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;  // Using hash for security

        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    }
}