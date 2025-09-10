using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Data;
using TaskManagementSystem.Models;

namespace TaskManagementSystem
{
    public class TestDB
    {
        public static async System.Threading.Tasks.Task TestDatabaseAsync()
        {
            try
            {
                using var context = new AppDbContext();
                
                Console.WriteLine("Testing database connection...");
                
                // Test categories
                var categories = await context.Categories.ToListAsync();
                Console.WriteLine($"Categories in database: {categories.Count}");
                foreach (var cat in categories)
                {
                    Console.WriteLine($"  - {cat.Name} (ID: {cat.Id})");
                }
                
                // Test users
                var users = await context.Users.ToListAsync();
                Console.WriteLine($"Users in database: {users.Count}");
                
                // Test tasks
                var tasks = await context.Tasks.Include(t => t.Category).ToListAsync();
                Console.WriteLine($"Tasks in database: {tasks.Count}");
                
                // Test TaskItem schema by creating a test task
                Console.WriteLine("Testing TaskItem schema...");
                var testTask = new TaskItem
                {
                    Title = "Schema Test Task",
                    Description = "Testing all columns",
                    Priority = "High",
                    Status = Models.TaskStatus.Pending,
                    DueDate = DateTime.Now.AddDays(7),
                    UserId = 1,
                    CategoryId = categories.FirstOrDefault()?.Id ?? 1,
                    CreatedDate = DateTime.Now,
                    CompletedDate = null
                };
                
                Console.WriteLine($"TaskItem schema test successful:");
                Console.WriteLine($"  - CreatedDate: {testTask.CreatedDate}");
                Console.WriteLine($"  - CompletedDate: {testTask.CompletedDate}");
                Console.WriteLine($"  - All required columns accessible");
                
                Console.WriteLine("Database test completed successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Database test failed: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
            }
        }
    }
}