using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Data;
using TaskManagementSystem.Models;
using TaskManagementSystem.Forms;
using System.Security.Cryptography;

namespace TaskManagementSystem.Forms
{
    public partial class LoginForm : Form
    {
        private AppDbContext _context;
        public User? LoggedInUser { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
            _context = new AppDbContext();
            SetupFormStyle();
        }

        private void SetupFormStyle()
        {
            // Set form properties for modern look
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            
            // Add custom styling to textboxes
            CustomizeTextBox(txtEmail);
            CustomizeTextBox(txtPassword);
            
            // Set placeholders
            SetPlaceholder(txtEmail, "Enter your email");
            SetPlaceholder(txtPassword, "Enter your password");
            
            // Add key event handlers
            txtEmail.KeyPress += TxtEmail_KeyPress;
            txtPassword.KeyPress += TxtPassword_KeyPress;
            this.KeyPreview = true;
            this.KeyDown += LoginForm_KeyDown;
        }

        private void SetPlaceholder(TextBox textBox, string placeholder)
        {
            textBox.Text = placeholder;
            textBox.ForeColor = Color.Gray;
            
            if (textBox == txtPassword)
            {
                textBox.PasswordChar = '\0';
            }
        }

        private void LoginForm_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(this, EventArgs.Empty);
            }
        }

        private void TxtEmail_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtPassword.Focus();
                e.Handled = true;
            }
        }

        private void TxtPassword_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin_Click(this, EventArgs.Empty);
                e.Handled = true;
            }
        }

        private void CustomizeTextBox(TextBox textBox)
        {
            // Add padding effect by creating a panel border
            Panel panel = new Panel();
            panel.BackColor = Color.FromArgb(248, 249, 250);
            panel.Size = new Size(textBox.Width + 30, textBox.Height + 20);
            panel.Location = new Point(textBox.Location.X - 15, textBox.Location.Y - 10);
            panel.BorderStyle = BorderStyle.FixedSingle;
            
            if (textBox.Parent != null)
            {
                textBox.Parent.Controls.Add(panel);
                panel.BringToFront();
                textBox.BringToFront();
            }
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                // Clear previous error message
                lblErrorMessage.Visible = false;
                
                // Validate input
                if (!ValidateInput())
                {
                    return;
                }

                // Disable login button to prevent multiple clicks
                btnLogin.Enabled = false;
                btnLogin.Text = "Logging in...";

                // Hash the password for comparison
                string hashedPassword = HashPassword(txtPassword.Text);

                // Check credentials in database
                var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.Email == txtEmail.Text && u.PasswordHash == hashedPassword);

                if (user != null)
                {
                    LoggedInUser = user;
                    
                    // Open dashboard and close login form
                    var dashboardForm = new DashboardForm(user);
                    dashboardForm.Show();
                    this.Hide();
                }
                else
                {
                    ShowErrorMessage("Invalid email or password. Please try again.");
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Login failed: {ex.Message}");
            }
            finally
            {
                // Re-enable login button
                btnLogin.Enabled = true;
                btnLogin.Text = "LOGIN";
            }
        }

        private bool ValidateInput()
        {
            // Check if email is empty
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || txtEmail.Text == "Enter your email")
            {
                ShowErrorMessage("Please enter your email address.");
                txtEmail.Focus();
                return false;
            }

            // Check email format
            if (!IsValidEmail(txtEmail.Text))
            {
                ShowErrorMessage("Please enter a valid email address.");
                txtEmail.Focus();
                return false;
            }

            // Check if password is empty
            if (string.IsNullOrWhiteSpace(txtPassword.Text) || txtPassword.Text == "Enter your password")
            {
                ShowErrorMessage("Please enter your password.");
                txtPassword.Focus();
                return false;
            }

            // Check password length
            if (txtPassword.Text.Length < 6)
            {
                ShowErrorMessage("Password must be at least 6 characters long.");
                txtPassword.Focus();
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Open register form
            var registerForm = new RegisterForm();
            registerForm.ShowDialog();
            
            // If registration was successful, close login form
            if (registerForm.DialogResult == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void ShowErrorMessage(string message)
        {
            lblErrorMessage.Text = message;
            lblErrorMessage.Visible = true;
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // Text box hover and focus effects
        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.ForeColor == Color.Gray)
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = Color.FromArgb(73, 80, 87);
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                txtEmail.Text = "Enter your email";
                txtEmail.ForeColor = Color.Gray;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.ForeColor == Color.Gray)
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.FromArgb(73, 80, 87);
                txtPassword.PasswordChar = '●';
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.Text = "Enter your password";
                txtPassword.ForeColor = Color.Gray;
                txtPassword.PasswordChar = '\0';
            }
        }

        // Button hover effects
        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.FromArgb(41, 128, 185);
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.FromArgb(52, 152, 219);
        }

        private void btnRegister_MouseEnter(object sender, EventArgs e)
        {
            btnRegister.BackColor = Color.FromArgb(52, 152, 219);
            btnRegister.ForeColor = Color.White;
        }

        private void btnRegister_MouseLeave(object sender, EventArgs e)
        {
            btnRegister.BackColor = Color.Transparent;
            btnRegister.ForeColor = Color.FromArgb(52, 152, 219);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _context?.Dispose();
            base.OnFormClosed(e);
        }
    }
}
