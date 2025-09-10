using System;
using System.Windows.Forms;
using TaskManagementSystem.Data;

namespace TaskManagementSystem
{
    static class Program
    {
        [STAThread]
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            // Initialize database on startup
            try
            {
                using var context = new AppDbContext();
                await context.Database.EnsureCreatedAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database initialization failed: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if we should run in test mode
            if (args.Length > 0 && args[0] == "--test")
            {
                await TestDB.TestDatabaseAsync();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return;
            }

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Start with Login Form
            Application.Run(new Forms.LoginForm());
        }
    }
}