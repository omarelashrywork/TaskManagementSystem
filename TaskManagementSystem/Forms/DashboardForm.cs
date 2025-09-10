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
using TaskStatus = TaskManagementSystem.Models.TaskStatus;

namespace TaskManagementSystem.Forms
{
    public partial class DashboardForm : Form
    {
        private AppDbContext _context;
        private User? _currentUser;
        private List<TaskItem> _allTasks;
        private List<TaskItem> _filteredTasks;
        private int _currentPage = 1;
        private int _tasksPerPage = 10;
        private string _currentSearchText = "";
        private Models.TaskStatus? _selectedStatus;
        private string _selectedPriority = "";
        private string _sortBy = "DueDate";
        private string _groupBy = "";

        public DashboardForm()
        {
            InitializeComponent();
            _context = new AppDbContext();
            _allTasks = new List<TaskItem>();
            _filteredTasks = new List<TaskItem>();
        }

        public DashboardForm(User user) : this()
        {
            _currentUser = user;
        }

        private async void DashboardForm_Load(object sender, EventArgs e)
        {
            await InitializeFormAsync();
        }

        private async Task InitializeFormAsync()
        {
            try
            {
                // Set welcome message
                if (_currentUser != null)
                {
                    lblUserWelcome.Text = $"Welcome, {_currentUser.Name}!";
                }

                // Setup combo boxes
                SetupComboBoxes();

                // Setup DataGridView
                SetupDataGridView();

                // Load initial data
                await LoadTasksAsync();
                await UpdateStatisticsAsync();

                // Start refresh timer for overdue checking
                timerRefresh.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing dashboard: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupComboBoxes()
        {
            // Status filter
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("All");
            cmbStatus.Items.AddRange(Enum.GetNames(typeof(TaskStatus)));
            cmbStatus.SelectedIndex = 0;

            // Priority filter
            cmbPriority.Items.Clear();
            cmbPriority.Items.Add("All");
            cmbPriority.Items.AddRange(new[] { "Low", "Medium", "High" });
            cmbPriority.SelectedIndex = 0;

            // Sort by
            cmbSortBy.Items.Clear();
            cmbSortBy.Items.AddRange(new[] { "DueDate", "Priority", "Status", "Title", "CreatedDate" });
            cmbSortBy.SelectedIndex = 0;

            // Group by
            cmbGroupBy.Items.Clear();
            cmbGroupBy.Items.Add("None");
            cmbGroupBy.Items.AddRange(new[] { "Status", "Priority", "Category" });
            cmbGroupBy.SelectedIndex = 0;
        }

        private void SetupDataGridView()
        {
            dataGridViewTasks.AutoGenerateColumns = false;
            dataGridViewTasks.Columns.Clear();

            // Add columns
            dataGridViewTasks.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "ID",
                DataPropertyName = "Id",
                Width = 50,
                Visible = false
            });

            dataGridViewTasks.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Title",
                HeaderText = "Title",
                DataPropertyName = "Title",
                Width = 200,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dataGridViewTasks.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Description",
                HeaderText = "Description",
                DataPropertyName = "Description",
                Width = 300
            });

            dataGridViewTasks.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Status",
                HeaderText = "Status",
                DataPropertyName = "Status",
                Width = 100
            });

            dataGridViewTasks.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Priority",
                HeaderText = "Priority",
                DataPropertyName = "Priority",
                Width = 80
            });

            dataGridViewTasks.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DueDate",
                HeaderText = "Due Date",
                DataPropertyName = "DueDate",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });

            dataGridViewTasks.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Category",
                HeaderText = "Category",
                DataPropertyName = "CategoryName",
                Width = 120
            });

            // Style the grid
            dataGridViewTasks.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dataGridViewTasks.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridViewTasks.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dataGridViewTasks.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewTasks.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        }

        private async Task LoadTasksAsync()
        {
            try
            {
                if (_currentUser == null) return;

                _allTasks = await _context.Tasks
                    .Include(t => t.Category)
                    .Where(t => t.UserId == _currentUser.Id)
                    .OrderBy(t => t.DueDate)
                    .ToListAsync();

                // Check for overdue tasks and show alerts
                await CheckOverdueTasksAsync();

                // Apply current filters
                ApplyFilters();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading tasks: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyFilters()
        {
            _filteredTasks = _allTasks.AsQueryable().AsEnumerable().ToList();

            // Apply search filter
            if (!string.IsNullOrWhiteSpace(_currentSearchText))
            {
                _filteredTasks = _filteredTasks.Where(t =>
                    t.Title.Contains(_currentSearchText, StringComparison.OrdinalIgnoreCase) ||
                    t.Description.Contains(_currentSearchText, StringComparison.OrdinalIgnoreCase)
                ).ToList();
            }

            // Apply status filter
            if (_selectedStatus.HasValue)
            {
                _filteredTasks = _filteredTasks.Where(t => t.Status == _selectedStatus.Value).ToList();
            }

            // Apply priority filter
            if (!string.IsNullOrEmpty(_selectedPriority) && _selectedPriority != "All")
            {
                _filteredTasks = _filteredTasks.Where(t => t.Priority == _selectedPriority).ToList();
            }

            // Apply sorting
            _filteredTasks = _sortBy switch
            {
                "DueDate" => _filteredTasks.OrderBy(t => t.DueDate).ToList(),
                "Priority" => _filteredTasks.OrderBy(t => GetPriorityOrder(t.Priority)).ToList(),
                "Status" => _filteredTasks.OrderBy(t => t.Status).ToList(),
                "Title" => _filteredTasks.OrderBy(t => t.Title).ToList(),
                _ => _filteredTasks.OrderBy(t => t.DueDate).ToList()
            };

            // Reset to first page
            _currentPage = 1;

            // Apply pagination and update display
            UpdateTaskDisplay();
            UpdatePaginationInfo();
        }

        private int GetPriorityOrder(string priority)
        {
            return priority switch
            {
                "High" => 1,
                "Medium" => 2,
                "Low" => 3,
                _ => 4
            };
        }

        private void UpdateTaskDisplay()
        {
            try
            {
                // Calculate pagination
                int startIndex = (_currentPage - 1) * _tasksPerPage;
                var pagedTasks = _filteredTasks.Skip(startIndex).Take(_tasksPerPage).ToList();

                // Create display data with category names
                var displayTasks = pagedTasks.Select(t => new
                {
                    t.Id,
                    t.Title,
                    t.Description,
                    Status = t.Status.ToString(),
                    t.Priority,
                    t.DueDate,
                    CategoryName = t.Category?.Name ?? "No Category",
                    IsOverdue = t.DueDate < DateTime.Now && t.Status != Models.TaskStatus.Completed
                }).ToList();

                dataGridViewTasks.DataSource = displayTasks;

                // Color overdue tasks
                ColorOverdueTasks();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating task display: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ColorOverdueTasks()
        {
            foreach (DataGridViewRow row in dataGridViewTasks.Rows)
            {
                if (row.DataBoundItem != null)
                {
                    var task = row.DataBoundItem;
                    var isOverdueProperty = task.GetType().GetProperty("IsOverdue");
                    if (isOverdueProperty != null && (bool)(isOverdueProperty.GetValue(task) ?? false))
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 235);
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(169, 68, 66);
                    }
                }
            }
        }

        private void UpdatePaginationInfo()
        {
            int totalPages = (int)Math.Ceiling((double)_filteredTasks.Count / _tasksPerPage);
            lblPageInfo.Text = $"Page {_currentPage} of {Math.Max(totalPages, 1)}";
            
            btnPrevPage.Enabled = _currentPage > 1;
            btnNextPage.Enabled = _currentPage < totalPages;
        }

        private async Task UpdateStatisticsAsync()
        {
            try
            {
                if (_currentUser == null) return;

                var tasks = await _context.Tasks
                    .Where(t => t.UserId == _currentUser.Id)
                    .ToListAsync();

                var totalTasks = tasks.Count;
                var pendingTasks = tasks.Count(t => t.Status == TaskStatus.Pending);
                var inProgressTasks = tasks.Count(t => t.Status == TaskStatus.InProgress);
                var completedTasks = tasks.Count(t => t.Status == TaskStatus.Completed);
                var overdueTasks = tasks.Count(t => t.DueDate < DateTime.Now && t.Status != TaskStatus.Completed);

                // Calculate average completion time
                var completedTasksWithDates = tasks.Where(t => t.Status == TaskStatus.Completed).ToList();
                double avgCompletionDays = 0;
                if (completedTasksWithDates.Any())
                {
                    // For demo purposes, using creation to due date as completion time
                    avgCompletionDays = completedTasksWithDates
                        .Average(t => (t.DueDate - DateTime.Now.AddDays(-7)).TotalDays); // Simulated
                }

                // Update labels
                lblTotalTasks.Text = $"Total Tasks: {totalTasks}";
                lblPendingTasks.Text = $"Pending: {pendingTasks}";
                lblCompletedTasks.Text = $"Completed: {completedTasks}";
                lblOverdueTasks.Text = $"Overdue: {overdueTasks}";
                lblAvgCompletionTime.Text = $"Avg Completion: {avgCompletionDays:F1} days";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating statistics: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Task CheckOverdueTasksAsync()
        {
            try
            {
                if (_currentUser == null) return Task.CompletedTask;

                var overdueTasks = _allTasks.Where(t => 
                    t.DueDate < DateTime.Now && 
                    t.Status != TaskStatus.Completed).ToList();

                if (overdueTasks.Any())
                {
                    var message = $"You have {overdueTasks.Count} overdue task(s):\n\n";
                    message += string.Join("\n", overdueTasks.Take(5).Select(t => 
                        $"• {t.Title} (Due: {t.DueDate:dd/MM/yyyy})"));
                    
                    if (overdueTasks.Count > 5)
                    {
                        message += $"\n... and {overdueTasks.Count - 5} more.";
                    }

                    MessageBox.Show(message, "Overdue Tasks Alert", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking overdue tasks: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Task.CompletedTask;
        }

        // Event Handlers
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            _currentSearchText = txtSearch.Text;
            ApplyFilters();
        }

        private void btnApplyFilters_Click(object sender, EventArgs e)
        {
            // Get filter values
            _selectedStatus = cmbStatus.SelectedItem?.ToString() == "All" ? 
                null : Enum.Parse<Models.TaskStatus>(cmbStatus.SelectedItem?.ToString() ?? "");
            _selectedPriority = cmbPriority.SelectedItem?.ToString() ?? "";
            _sortBy = cmbSortBy.SelectedItem?.ToString() ?? "DueDate";
            _groupBy = cmbGroupBy.SelectedItem?.ToString() ?? "";

            ApplyFilters();
        }

        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            // Reset all filters
            txtSearch.Text = "";
            cmbStatus.SelectedIndex = 0;
            cmbPriority.SelectedIndex = 0;
            cmbSortBy.SelectedIndex = 0;
            cmbGroupBy.SelectedIndex = 0;

            _currentSearchText = "";
            _selectedStatus = null;
            _selectedPriority = "";
            _sortBy = "DueDate";
            _groupBy = "";

            ApplyFilters();
        }

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                UpdateTaskDisplay();
                UpdatePaginationInfo();
            }
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            int totalPages = (int)Math.Ceiling((double)_filteredTasks.Count / _tasksPerPage);
            if (_currentPage < totalPages)
            {
                _currentPage++;
                UpdateTaskDisplay();
                UpdatePaginationInfo();
            }
        }

        private void dataGridViewTasks_SelectionChanged(object sender, EventArgs e)
        {
            bool hasSelection = dataGridViewTasks.SelectedRows.Count > 0;
            btnEditTask.Enabled = hasSelection;
            btnDeleteTask.Enabled = hasSelection;
        }

        private void dataGridViewTasks_DoubleClick(object sender, EventArgs e)
        {
            btnEditTask_Click(sender, e);
        }

        private async void btnAddTask_Click(object sender, EventArgs e)
        {
            try
            {
                if (_currentUser == null) return;
                var taskForm = new TaskEditForm(_context, _currentUser);
                if (taskForm.ShowDialog() == DialogResult.OK)
                {
                    await LoadTasksAsync();
                    await UpdateStatisticsAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening add task form: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnEditTask_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewTasks.SelectedRows.Count == 0) return;

                var selectedTaskId = (int)dataGridViewTasks.SelectedRows[0].Cells["Id"].Value;
                var task = _allTasks.FirstOrDefault(t => t.Id == selectedTaskId);

                if (task != null && _currentUser != null)
                {
                    var taskForm = new TaskEditForm(_context, _currentUser, task);
                    if (taskForm.ShowDialog() == DialogResult.OK)
                    {
                        await LoadTasksAsync();
                        await UpdateStatisticsAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening edit task form: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDeleteTask_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewTasks.SelectedRows.Count == 0) return;

                var result = MessageBox.Show("Are you sure you want to delete this task?", 
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    var selectedTaskId = (int)dataGridViewTasks.SelectedRows[0].Cells["Id"].Value;
                    var task = await _context.Tasks.FindAsync(selectedTaskId);

                    if (task != null)
                    {
                        _context.Tasks.Remove(task);
                        await _context.SaveChangesAsync();

                        await LoadTasksAsync();
                        await UpdateStatisticsAsync();

                        MessageBox.Show("Task deleted successfully!", "Success", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting task: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (_currentUser == null) return;

                var reportForm = new ReportForm(_currentUser);
                reportForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating report: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to logout?", 
                "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var loginForm = new LoginForm();
                loginForm.Show();
                this.Close();
            }
        }

        private async void timerRefresh_Tick(object sender, EventArgs e)
        {
            await UpdateStatisticsAsync();
            await CheckOverdueTasksAsync();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _context?.Dispose();
            base.OnFormClosed(e);
        }
    }

    // Simple TaskEditForm class (you can expand this)


    // Simple ReportForm class (you can expand this)
    public partial class ReportForm : Form
    {
        private User _user;

        public ReportForm(User user)
        {
            _user = user;
            InitializeSimpleReportForm();
        }

        private void InitializeSimpleReportForm()
        {
            this.Text = "Task Report";
            this.Size = new Size(600, 400);
            this.StartPosition = FormStartPosition.CenterParent;
            
            // Add report content - you can expand this
            var lblReport = new Label 
            { 
                Text = "Task Report Generated",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };
            
            this.Controls.Add(lblReport);
        }
    }
}
