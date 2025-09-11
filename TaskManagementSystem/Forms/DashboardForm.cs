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
        private List<int> _alertedOverdueTaskIds; // Track which overdue tasks we've already alerted about
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
            _alertedOverdueTaskIds = new List<int>();
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
                // Check if form is disposed or context is null
                if (this.IsDisposed || this.Disposing || _context == null || _currentUser == null) 
                    return;

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

                // Filter out tasks we've already alerted about
                var newOverdueTasks = overdueTasks.Where(t => !_alertedOverdueTaskIds.Contains(t.Id)).ToList();

                if (newOverdueTasks.Any())
                {
                    var message = $"You have {newOverdueTasks.Count} overdue task(s):\n\n";
                    message += string.Join("\n", newOverdueTasks.Take(5).Select(t => 
                        $"• {t.Title} (Due: {t.DueDate:dd/MM/yyyy})"));
                    
                    if (newOverdueTasks.Count > 5)
                    {
                        message += $"\n... and {newOverdueTasks.Count - 5} more.";
                    }

                    MessageBox.Show(message, "Overdue Tasks Alert", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                    // Mark these tasks as alerted
                    _alertedOverdueTaskIds.AddRange(newOverdueTasks.Select(t => t.Id));
                }
                
                // Clean up: remove IDs of tasks that are no longer overdue (completed or deleted)
                var currentOverdueIds = overdueTasks.Select(t => t.Id).ToList();
                _alertedOverdueTaskIds = _alertedOverdueTaskIds.Where(id => currentOverdueIds.Contains(id)).ToList();
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
                // Stop the timer to prevent errors after logout
                timerRefresh?.Stop();
                
                // Set dialog result to indicate logout
                this.DialogResult = DialogResult.OK;
                
                // Close this form - this will return control to the login form
                this.Close();
            }
        }

        private async void timerRefresh_Tick(object sender, EventArgs e)
        {
            try
            {
                // Check if form is disposed or disposing
                if (this.IsDisposed || this.Disposing || _context == null || _currentUser == null)
                {
                    timerRefresh?.Stop();
                    return;
                }

                await UpdateStatisticsAsync();
                await CheckOverdueTasksAsync();
            }
            catch (ObjectDisposedException)
            {
                // Form or context was disposed, stop the timer
                timerRefresh?.Stop();
            }
            catch (Exception ex)
            {
                // Log other errors but don't show to user during logout
                System.Diagnostics.Debug.WriteLine($"Timer error: {ex.Message}");
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // Stop timer first to prevent any race conditions
            timerRefresh?.Stop();
            
            // Dispose context
            _context?.Dispose();
            
            base.OnFormClosed(e);
        }
    }

    // Simple TaskEditForm class (you can expand this)


    // Simple ReportForm class (you can expand this)
    public partial class ReportForm : Form
    {
        private User _user;
        private AppDbContext _context;

        public ReportForm(User user)
        {
            _user = user;
            _context = new AppDbContext();
            InitializeReportForm();
            LoadReportData();
        }

        private void InitializeReportForm()
        {
            this.Text = "Task Report";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.White;
            
            // Main panel
            var mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(20)
            };
            
            // Title
            var lblTitle = new Label
            {
                Text = $"Task Report for {_user.Name}",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 152, 219),
                AutoSize = true,
                Location = new Point(0, 0)
            };
            
            // Statistics panel
            var statsPanel = new Panel
            {
                Location = new Point(0, 40),
                Size = new Size(760, 100),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.FromArgb(248, 249, 250)
            };
            
            // Task list
            var lblTaskListTitle = new Label
            {
                Text = "Your Tasks:",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(0, 160),
                AutoSize = true
            };
            
            var listView = new ListView
            {
                Location = new Point(0, 190),
                Size = new Size(760, 300),
                View = View.Details,
                FullRowSelect = true,
                GridLines = true,
                BorderStyle = BorderStyle.FixedSingle
            };
            
            // Configure ListView columns
            listView.Columns.Add("Title", 200);
            listView.Columns.Add("Description", 250);
            listView.Columns.Add("Category", 100);
            listView.Columns.Add("Priority", 80);
            listView.Columns.Add("Status", 80);
            listView.Columns.Add("Due Date", 100);
            
            // Close button
            var btnClose = new Button
            {
                Text = "Close",
                Size = new Size(100, 35),
                Location = new Point(660, 510),
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += (s, e) => this.Close();
            
            // Add controls
            mainPanel.Controls.AddRange(new Control[] 
            { 
                lblTitle, statsPanel, lblTaskListTitle, listView, btnClose 
            });
            
            this.Controls.Add(mainPanel);
            
            // Store references for data loading
            this.Tag = new { StatsPanel = statsPanel, ListView = listView };
        }

        private async void LoadReportData()
        {
            try
            {
                // Get user's tasks
                var userTasks = await _context.Tasks
                    .Include(t => t.Category)
                    .Where(t => t.UserId == _user.Id)
                    .ToListAsync();

                // Calculate statistics
                var totalTasks = userTasks.Count;
                var completedTasks = userTasks.Count(t => t.Status == TaskStatus.Completed);
                var pendingTasks = totalTasks - completedTasks;
                var overdueTasks = userTasks.Count(t => t.Status != TaskStatus.Completed && t.DueDate < DateTime.Now);
                var todayTasks = userTasks.Count(t => t.DueDate.Date == DateTime.Today);

                // Update statistics panel
                var refs = (dynamic)this.Tag!;
                var statsPanel = (Panel)refs.StatsPanel;
                
                statsPanel.Controls.Clear();
                
                var stats = new[]
                {
                    new { Label = "Total Tasks", Value = totalTasks.ToString(), Color = Color.FromArgb(52, 152, 219) },
                    new { Label = "Completed", Value = completedTasks.ToString(), Color = Color.FromArgb(46, 204, 113) },
                    new { Label = "Pending", Value = pendingTasks.ToString(), Color = Color.FromArgb(241, 196, 15) },
                    new { Label = "Overdue", Value = overdueTasks.ToString(), Color = Color.FromArgb(231, 76, 60) },
                    new { Label = "Due Today", Value = todayTasks.ToString(), Color = Color.FromArgb(155, 89, 182) }
                };

                for (int i = 0; i < stats.Length; i++)
                {
                    var statPanel = new Panel
                    {
                        Size = new Size(140, 80),
                        Location = new Point(i * 150 + 10, 10),
                        BackColor = Color.White,
                        BorderStyle = BorderStyle.FixedSingle
                    };

                    var lblValue = new Label
                    {
                        Text = stats[i].Value,
                        Font = new Font("Segoe UI", 20, FontStyle.Bold),
                        ForeColor = stats[i].Color,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Dock = DockStyle.Top,
                        Height = 40
                    };

                    var lblName = new Label
                    {
                        Text = stats[i].Label,
                        Font = new Font("Segoe UI", 9),
                        ForeColor = Color.FromArgb(108, 117, 125),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Dock = DockStyle.Bottom,
                        Height = 30
                    };

                    statPanel.Controls.AddRange(new Control[] { lblValue, lblName });
                    statsPanel.Controls.Add(statPanel);
                }

                // Populate task list
                var listView = (ListView)refs.ListView;
                listView.Items.Clear();

                foreach (var task in userTasks.OrderBy(t => t.DueDate))
                {
                    var item = new ListViewItem(task.Title);
                    item.SubItems.Add(task.Description?.Length > 30 ? task.Description.Substring(0, 30) + "..." : task.Description ?? "");
                    item.SubItems.Add(task.Category?.Name ?? "No Category");
                    item.SubItems.Add(task.Priority.ToString());
                    item.SubItems.Add(task.Status.ToString());
                    item.SubItems.Add(task.DueDate.ToString("MMM dd, yyyy"));

                    // Color coding
                    if (task.Status == TaskStatus.Completed)
                    {
                        item.ForeColor = Color.FromArgb(108, 117, 125);
                    }
                    else if (task.Status != TaskStatus.Completed && task.DueDate < DateTime.Now)
                    {
                        item.ForeColor = Color.FromArgb(231, 76, 60); // Overdue - red
                    }
                    else if (task.DueDate.Date == DateTime.Today)
                    {
                        item.ForeColor = Color.FromArgb(243, 156, 18); // Due today - orange
                    }

                    listView.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading report data: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _context?.Dispose();
            base.OnFormClosed(e);
        }
    }
}
