using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Data;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Forms
{
    public partial class TaskEditForm : Form
    {
        private readonly AppDbContext _context;
        private readonly User _currentUser;
        private TaskItem? _task;
        private bool _isEditMode;

        public TaskItem? Task => _task;

        public TaskEditForm(AppDbContext context, User currentUser, TaskItem? task = null)
        {
            InitializeComponent();
            _context = context;
            _currentUser = currentUser;
            _task = task;
            _isEditMode = task != null;
        }

        private async void TaskEditForm_Load(object sender, EventArgs e)
        {
            await InitializeFormAsync();
        }

        private async Task InitializeFormAsync()
        {
            try
            {
                // Initialize combo boxes
                InitializePriorityComboBox();
                InitializeStatusComboBox();
                await InitializeCategoryComboBoxAsync();

                // Set form title and button text
                if (_isEditMode)
                {
                    lblFormTitle.Text = "Edit Task";
                    btnSave.Text = "Update";
                    this.Text = "Task Management - Edit Task";
                    PopulateFields();
                }
                else
                {
                    lblFormTitle.Text = "Add New Task";
                    btnSave.Text = "Save";
                    this.Text = "Task Management - Add Task";
                    SetDefaultValues();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing form: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializePriorityComboBox()
        {
            cmbPriority.Items.Clear();
            cmbPriority.Items.AddRange(new string[] { "Low", "Normal", "High", "Critical" });
            cmbPriority.SelectedIndex = 1; // Default to Normal
        }

        private void InitializeStatusComboBox()
        {
            cmbStatus.Items.Clear();
            cmbStatus.Items.AddRange(new string[] { "Pending", "InProgress", "Completed" });
            cmbStatus.SelectedIndex = 0; // Default to Pending
        }

        private async Task InitializeCategoryComboBoxAsync()
        {
            try
            {
                var categories = await _context.Categories.ToListAsync();
                cmbCategory.Items.Clear();
                cmbCategory.DisplayMember = "Name";
                cmbCategory.ValueMember = "Id";
                
                if (categories.Count == 0)
                {
                    // Create a default category if none exist
                    var defaultCategory = new Category { Name = "General" };
                    _context.Categories.Add(defaultCategory);
                    await _context.SaveChangesAsync();
                    categories.Add(defaultCategory);
                }

                foreach (var category in categories)
                {
                    cmbCategory.Items.Add(category);
                }

                if (cmbCategory.Items.Count > 0)
                {
                    cmbCategory.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading categories: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
                // Add a fallback category
                var fallbackCategory = new Category { Id = 0, Name = "General" };
                cmbCategory.Items.Add(fallbackCategory);
                cmbCategory.SelectedIndex = 0;
            }
        }

        private void SetDefaultValues()
        {
            txtTitle.Clear();
            txtDescription.Clear();
            dtpDueDate.Value = DateTime.Now.AddDays(7); // Default due date to one week from now
            cmbPriority.SelectedIndex = 1; // Normal
            cmbStatus.SelectedIndex = 0; // Pending
            if (cmbCategory.Items.Count > 0)
                cmbCategory.SelectedIndex = 0;
        }

        private void PopulateFields()
        {
            if (_task == null) return;

            txtTitle.Text = _task.Title;
            txtDescription.Text = _task.Description;
            dtpDueDate.Value = _task.DueDate;

            // Set priority
            var priorityIndex = Array.IndexOf(new[] { "Low", "Normal", "High", "Critical" }, _task.Priority);
            cmbPriority.SelectedIndex = priorityIndex >= 0 ? priorityIndex : 1;

            // Set status
            var statusIndex = Array.IndexOf(new[] { "Pending", "InProgress", "Completed" }, _task.Status.ToString());
            cmbStatus.SelectedIndex = statusIndex >= 0 ? statusIndex : 0;

            // Set category
            if (_task.CategoryId > 0)
            {
                for (int i = 0; i < cmbCategory.Items.Count; i++)
                {
                    if (cmbCategory.Items[i] is Category category && category.Id == _task.CategoryId)
                    {
                        cmbCategory.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                btnSave.Enabled = false;
                btnSave.Text = _isEditMode ? "Updating..." : "Saving...";

                if (_isEditMode)
                {
                    await UpdateTaskAsync();
                }
                else
                {
                    await CreateTaskAsync();
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving task: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSave.Enabled = true;
                btnSave.Text = _isEditMode ? "Update" : "Save";
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Please enter a task title.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle.Focus();
                return false;
            }

            if (txtTitle.Text.Length > 200)
            {
                MessageBox.Show("Task title cannot exceed 200 characters.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle.Focus();
                return false;
            }

            if (txtDescription.Text.Length > 1000)
            {
                MessageBox.Show("Task description cannot exceed 1000 characters.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescription.Focus();
                return false;
            }

            if (dtpDueDate.Value < DateTime.Today)
            {
                var result = MessageBox.Show("The due date is in the past. Do you want to continue?", 
                    "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    dtpDueDate.Focus();
                    return false;
                }
            }

            return true;
        }

        private async Task CreateTaskAsync()
        {
            // Ensure we have a valid category
            if (cmbCategory.SelectedItem == null || !(cmbCategory.SelectedItem is Category))
            {
                MessageBox.Show("Please select a valid category.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedCategory = (Category)cmbCategory.SelectedItem;

            _task = new TaskItem
            {
                Title = txtTitle.Text.Trim(),
                Description = txtDescription.Text.Trim(),
                DueDate = dtpDueDate.Value,
                Priority = cmbPriority.SelectedItem?.ToString() ?? "Normal",
                Status = Enum.Parse<Models.TaskStatus>(cmbStatus.SelectedItem?.ToString() ?? "Pending"),
                CategoryId = selectedCategory.Id,
                UserId = _currentUser.Id,
                CreatedDate = DateTime.Now
            };

            // Set completion date if status is completed
            if (_task.Status == Models.TaskStatus.Completed)
            {
                _task.CompletedDate = DateTime.Now;
            }

            _context.Tasks.Add(_task);
            await _context.SaveChangesAsync();

            MessageBox.Show("Task created successfully!", "Success", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async Task UpdateTaskAsync()
        {
            if (_task == null) return;

            // Ensure we have a valid category
            if (cmbCategory.SelectedItem == null || !(cmbCategory.SelectedItem is Category))
            {
                MessageBox.Show("Please select a valid category.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedCategory = (Category)cmbCategory.SelectedItem;
            
            _task.Title = txtTitle.Text.Trim();
            _task.Description = txtDescription.Text.Trim();
            _task.DueDate = dtpDueDate.Value;
            _task.Priority = cmbPriority.SelectedItem?.ToString() ?? "Normal";
            
            var newStatus = Enum.Parse<Models.TaskStatus>(cmbStatus.SelectedItem?.ToString() ?? "Pending");
            var oldStatus = _task.Status;
            _task.Status = newStatus;
            
            _task.CategoryId = selectedCategory.Id;

            // Update completion date when status changes to/from completed
            if (newStatus == Models.TaskStatus.Completed && oldStatus != Models.TaskStatus.Completed)
            {
                _task.CompletedDate = DateTime.Now;
            }
            else if (newStatus != Models.TaskStatus.Completed && oldStatus == Models.TaskStatus.Completed)
            {
                _task.CompletedDate = null;
            }

            _context.Tasks.Update(_task);
            await _context.SaveChangesAsync();

            MessageBox.Show("Task updated successfully!", "Success", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}