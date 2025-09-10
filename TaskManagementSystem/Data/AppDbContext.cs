using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // SQL Server Auth
            optionsBuilder.UseSqlServer(
                "Server=.;Database=TaskManagerDB;User Id=sa;Password=omar12345;TrustServerCertificate=True;");

            // OR Windows Auth
            // optionsBuilder.UseSqlServer("Server=.;Database=TaskManagerDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}