using System;
using System.Windows.Forms;

namespace TaskManagementSystem
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Start with Login Form
            Application.Run(new Forms.LoginForm());
        }
    }
}