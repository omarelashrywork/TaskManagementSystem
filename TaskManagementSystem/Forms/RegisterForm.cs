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
    public partial class RegisterForm : Form
    {
        private AppDbContext _context;
        public User? RegisteredUser { get; private set; }

        public RegisterForm()
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
            CustomizeTextBox(txtName);
            CustomizeTextBox(txtEmail);
            CustomizeTextBox(txtPassword);
            CustomizeTextBox(txtConfirmPassword);
            
            // Set placeholders
            SetPlaceholder(txtName, "Enter your full name");
            SetPlaceholder(txtEmail, "Enter your email");
            SetPlaceholder(txtPassword, "Enter your password");
            SetPlaceholder(txtConfirmPassword, "Confirm your password");
            
            // Add key event handlers
            txtName.KeyPress += TxtName_KeyPress;
            txtEmail.KeyPress += TxtEmail_KeyPress;
            txtPassword.KeyPress += TxtPassword_KeyPress;
            txtConfirmPassword.KeyPress += TxtConfirmPassword_KeyPress;
            this.KeyPreview = true;
            this.KeyDown += RegisterForm_KeyDown;
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

        private void SetPlaceholder(TextBox textBox, string placeholder)
        {
            textBox.Text = placeholder;
            textBox.ForeColor = Color.Gray;
            
            if (textBox == txtPassword || textBox == txtConfirmPassword)
            {
                textBox.PasswordChar = '\0';
            }
        }

        // Key navigation handlers
        private void RegisterForm_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnRegister_Click(this, EventArgs.Empty);
            }
        }

        private void TxtName_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtEmail.Focus();
                e.Handled = true;
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
                txtConfirmPassword.Focus();
                e.Handled = true;
            }
        }

        private void TxtConfirmPassword_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnRegister_Click(this, EventArgs.Empty);
                e.Handled = true;
            }
        }

        private async void btnRegister_Click(object sender, EventArgs e)
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

                // Disable register button to prevent multiple clicks
                btnRegister.Enabled = false;
                btnRegister.Text = "Creating Account...";

                // Get actual field values (not placeholder text)
                string name = GetActualFieldValue(txtName, "Enter your full name");
                string email = GetActualFieldValue(txtEmail, "Enter your email");
                string password = GetActualFieldValue(txtPassword, "Enter your password");
                
                // Normalize email for consistent storage
                string normalizedEmail = email.Trim().ToLower();

                // Hash the password
                string hashedPassword = HashPassword(password);

                // Create new user - let database handle duplicate email constraints
                var newUser = new User
                {
                    Name = name,
                    Email = normalizedEmail,
                    PasswordHash = hashedPassword,
                    Tasks = new List<TaskItem>()
                };

                // Add user to database
                _context.Users.Add(newUser);
                await _context.SaveChangesAsync();

                RegisteredUser = newUser;

                // Show success message
                MessageBox.Show("Account created successfully!",
                    "Registration Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Set dialog result and close
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                // Handle database constraint errors (for actual duplicate emails)
                if (ex.Message.Contains("UNIQUE constraint failed") || 
                    ex.Message.Contains("duplicate") || 
                    ex.InnerException?.Message.Contains("UNIQUE") == true)
                {
                    ShowErrorMessage("An account with this email already exists. Please use a different email.");
                }
                else
                {
                    ShowErrorMessage($"Registration failed: {ex.Message}");
                }
                
                btnRegister.Enabled = true;
                btnRegister.Text = "CREATE ACCOUNT";
            }
        }

        private bool ValidateInput()
        {
            // Check if name is empty
            if (string.IsNullOrWhiteSpace(txtName.Text) || txtName.Text == "Enter your full name")
            {
                ShowErrorMessage("Please enter your full name.");
                txtName.Focus();
                return false;
            }

            // Check name length
            if (txtName.Text.Trim().Length < 2)
            {
                ShowErrorMessage("Name must be at least 2 characters long.");
                txtName.Focus();
                return false;
            }

            // Check if email is empty or still placeholder
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || 
                txtEmail.Text == "Enter your email" || 
                txtEmail.ForeColor == Color.Gray)
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

            // Check password strength
            if (!IsPasswordStrong(txtPassword.Text))
            {
                ShowErrorMessage("Password must contain at least one uppercase letter, one lowercase letter, and one number.");
                txtPassword.Focus();
                return false;
            }

            // Check if confirm password is empty
            if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text) || txtConfirmPassword.Text == "Confirm your password")
            {
                ShowErrorMessage("Please confirm your password.");
                txtConfirmPassword.Focus();
                return false;
            }

            // Check if passwords match
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                ShowErrorMessage("Passwords do not match. Please try again.");
                txtConfirmPassword.Focus();
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

        private bool IsPasswordStrong(string password)
        {
            return password.Any(char.IsUpper) && 
                   password.Any(char.IsLower) && 
                   password.Any(char.IsDigit);
        }

        private void btnBackToLogin_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
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

        // Text box placeholder and focus effects
        private void txtName_Enter(object sender, EventArgs e)
        {
            if (txtName.ForeColor == Color.Gray)
            {
                txtName.Text = "";
                txtName.ForeColor = Color.FromArgb(73, 80, 87);
            }
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                txtName.Text = "Enter your full name";
                txtName.ForeColor = Color.Gray;
            }
        }

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

        private void txtConfirmPassword_Enter(object sender, EventArgs e)
        {
            if (txtConfirmPassword.ForeColor == Color.Gray)
            {
                txtConfirmPassword.Text = "";
                txtConfirmPassword.ForeColor = Color.FromArgb(73, 80, 87);
                txtConfirmPassword.PasswordChar = '●';
            }
        }

        private void txtConfirmPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                txtConfirmPassword.Text = "Confirm your password";
                txtConfirmPassword.ForeColor = Color.Gray;
                txtConfirmPassword.PasswordChar = '\0';
            }
        }

        // Button hover effects
        private void btnRegister_MouseEnter(object sender, EventArgs e)
        {
            btnRegister.BackColor = Color.FromArgb(41, 128, 185);
        }

        private void btnRegister_MouseLeave(object sender, EventArgs e)
        {
            btnRegister.BackColor = Color.FromArgb(52, 152, 219);
        }

        private void btnBackToLogin_MouseEnter(object sender, EventArgs e)
        {
            btnBackToLogin.BackColor = Color.FromArgb(52, 152, 219);
            btnBackToLogin.ForeColor = Color.White;
        }

        private void btnBackToLogin_MouseLeave(object sender, EventArgs e)
        {
            btnBackToLogin.BackColor = Color.Transparent;
            btnBackToLogin.ForeColor = Color.FromArgb(52, 152, 219);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _context?.Dispose();
            base.OnFormClosed(e);
        }

        private string GetActualFieldValue(TextBox textBox, string placeholderText)
        {
            // Check if the textbox contains placeholder text (gray color)
            if (textBox.ForeColor == Color.Gray || string.IsNullOrWhiteSpace(textBox.Text) || textBox.Text == placeholderText)
            {
                return string.Empty;
            }
            return textBox.Text.Trim();
        }
    }
}
