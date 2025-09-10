namespace TaskManagementSystem.Forms
{
    partial class DashboardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panelMain = new Panel();
            panelContent = new Panel();
            panelTasks = new Panel();
            dataGridViewTasks = new DataGridView();
            panelPagination = new Panel();
            lblPageInfo = new Label();
            btnNextPage = new Button();
            btnPrevPage = new Button();
            panelFilters = new Panel();
            groupBoxFilters = new GroupBox();
            btnClearFilters = new Button();
            btnApplyFilters = new Button();
            cmbGroupBy = new ComboBox();
            lblGroupBy = new Label();
            cmbSortBy = new ComboBox();
            lblSortBy = new Label();
            cmbPriority = new ComboBox();
            lblPriority = new Label();
            cmbStatus = new ComboBox();
            lblStatus = new Label();
            txtSearch = new TextBox();
            lblSearch = new Label();
            panelSidebar = new Panel();
            panelStatistics = new Panel();
            groupBoxStats = new GroupBox();
            lblAvgCompletionTime = new Label();
            lblOverdueTasks = new Label();
            lblCompletedTasks = new Label();
            lblPendingTasks = new Label();
            lblTotalTasks = new Label();
            panelActions = new Panel();
            groupBoxActions = new GroupBox();
            btnGenerateReport = new Button();
            btnDeleteTask = new Button();
            btnEditTask = new Button();
            btnAddTask = new Button();
            panelHeader = new Panel();
            btnLogout = new Button();
            lblUserWelcome = new Label();
            lblDashboardTitle = new Label();
            timerRefresh = new System.Windows.Forms.Timer(components);
            panelMain.SuspendLayout();
            panelContent.SuspendLayout();
            panelTasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTasks).BeginInit();
            panelPagination.SuspendLayout();
            panelFilters.SuspendLayout();
            groupBoxFilters.SuspendLayout();
            panelSidebar.SuspendLayout();
            panelStatistics.SuspendLayout();
            groupBoxStats.SuspendLayout();
            panelActions.SuspendLayout();
            groupBoxActions.SuspendLayout();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.FromArgb(248, 249, 250);
            panelMain.Controls.Add(panelContent);
            panelMain.Controls.Add(panelSidebar);
            panelMain.Controls.Add(panelHeader);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1400, 800);
            panelMain.TabIndex = 0;
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.White;
            panelContent.Controls.Add(panelTasks);
            panelContent.Controls.Add(panelFilters);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(300, 80);
            panelContent.Name = "panelContent";
            panelContent.Padding = new Padding(20);
            panelContent.Size = new Size(1100, 720);
            panelContent.TabIndex = 2;
            // 
            // panelTasks
            // 
            panelTasks.Controls.Add(dataGridViewTasks);
            panelTasks.Controls.Add(panelPagination);
            panelTasks.Dock = DockStyle.Fill;
            panelTasks.Location = new Point(20, 170);
            panelTasks.Name = "panelTasks";
            panelTasks.Size = new Size(1060, 530);
            panelTasks.TabIndex = 1;
            // 
            // dataGridViewTasks
            // 
            dataGridViewTasks.AllowUserToAddRows = false;
            dataGridViewTasks.BackgroundColor = Color.White;
            dataGridViewTasks.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewTasks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewTasks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridViewTasks.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewTasks.Dock = DockStyle.Fill;
            dataGridViewTasks.GridColor = Color.FromArgb(220, 221, 222);
            dataGridViewTasks.Location = new Point(0, 0);
            dataGridViewTasks.MultiSelect = false;
            dataGridViewTasks.Name = "dataGridViewTasks";
            dataGridViewTasks.ReadOnly = true;
            dataGridViewTasks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewTasks.Size = new Size(1060, 480);
            dataGridViewTasks.TabIndex = 0;
            dataGridViewTasks.SelectionChanged += dataGridViewTasks_SelectionChanged;
            dataGridViewTasks.DoubleClick += dataGridViewTasks_DoubleClick;
            // 
            // panelPagination
            // 
            panelPagination.Controls.Add(lblPageInfo);
            panelPagination.Controls.Add(btnNextPage);
            panelPagination.Controls.Add(btnPrevPage);
            panelPagination.Dock = DockStyle.Bottom;
            panelPagination.Location = new Point(0, 480);
            panelPagination.Name = "panelPagination";
            panelPagination.Size = new Size(1060, 50);
            panelPagination.TabIndex = 1;
            // 
            // lblPageInfo
            // 
            lblPageInfo.Anchor = AnchorStyles.None;
            lblPageInfo.AutoSize = true;
            lblPageInfo.Font = new Font("Segoe UI", 10F);
            lblPageInfo.Location = new Point(480, 15);
            lblPageInfo.Name = "lblPageInfo";
            lblPageInfo.Size = new Size(87, 19);
            lblPageInfo.TabIndex = 2;
            lblPageInfo.Text = "Page 1 of 10";
            // 
            // btnNextPage
            // 
            btnNextPage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNextPage.BackColor = Color.FromArgb(52, 152, 219);
            btnNextPage.FlatAppearance.BorderSize = 0;
            btnNextPage.FlatStyle = FlatStyle.Flat;
            btnNextPage.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnNextPage.ForeColor = Color.White;
            btnNextPage.Location = new Point(960, 10);
            btnNextPage.Name = "btnNextPage";
            btnNextPage.Size = new Size(80, 30);
            btnNextPage.TabIndex = 1;
            btnNextPage.Text = "Next";
            btnNextPage.UseVisualStyleBackColor = false;
            btnNextPage.Click += btnNextPage_Click;
            // 
            // btnPrevPage
            // 
            btnPrevPage.BackColor = Color.FromArgb(52, 152, 219);
            btnPrevPage.FlatAppearance.BorderSize = 0;
            btnPrevPage.FlatStyle = FlatStyle.Flat;
            btnPrevPage.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnPrevPage.ForeColor = Color.White;
            btnPrevPage.Location = new Point(20, 10);
            btnPrevPage.Name = "btnPrevPage";
            btnPrevPage.Size = new Size(80, 30);
            btnPrevPage.TabIndex = 0;
            btnPrevPage.Text = "Previous";
            btnPrevPage.UseVisualStyleBackColor = false;
            btnPrevPage.Click += btnPrevPage_Click;
            // 
            // panelFilters
            // 
            panelFilters.Controls.Add(groupBoxFilters);
            panelFilters.Dock = DockStyle.Top;
            panelFilters.Location = new Point(20, 20);
            panelFilters.Name = "panelFilters";
            panelFilters.Size = new Size(1060, 150);
            panelFilters.TabIndex = 0;
            // 
            // groupBoxFilters
            // 
            groupBoxFilters.Controls.Add(btnClearFilters);
            groupBoxFilters.Controls.Add(btnApplyFilters);
            groupBoxFilters.Controls.Add(cmbGroupBy);
            groupBoxFilters.Controls.Add(lblGroupBy);
            groupBoxFilters.Controls.Add(cmbSortBy);
            groupBoxFilters.Controls.Add(lblSortBy);
            groupBoxFilters.Controls.Add(cmbPriority);
            groupBoxFilters.Controls.Add(lblPriority);
            groupBoxFilters.Controls.Add(cmbStatus);
            groupBoxFilters.Controls.Add(lblStatus);
            groupBoxFilters.Controls.Add(txtSearch);
            groupBoxFilters.Controls.Add(lblSearch);
            groupBoxFilters.Dock = DockStyle.Fill;
            groupBoxFilters.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxFilters.Location = new Point(0, 0);
            groupBoxFilters.Name = "groupBoxFilters";
            groupBoxFilters.Size = new Size(1060, 150);
            groupBoxFilters.TabIndex = 0;
            groupBoxFilters.TabStop = false;
            groupBoxFilters.Text = "Filters & Search";
            // 
            // btnClearFilters
            // 
            btnClearFilters.BackColor = Color.FromArgb(231, 76, 60);
            btnClearFilters.FlatAppearance.BorderSize = 0;
            btnClearFilters.FlatStyle = FlatStyle.Flat;
            btnClearFilters.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnClearFilters.ForeColor = Color.White;
            btnClearFilters.Location = new Point(950, 100);
            btnClearFilters.Name = "btnClearFilters";
            btnClearFilters.Size = new Size(100, 35);
            btnClearFilters.TabIndex = 11;
            btnClearFilters.Text = "Clear";
            btnClearFilters.UseVisualStyleBackColor = false;
            btnClearFilters.Click += btnClearFilters_Click;
            // 
            // btnApplyFilters
            // 
            btnApplyFilters.BackColor = Color.FromArgb(39, 174, 96);
            btnApplyFilters.FlatAppearance.BorderSize = 0;
            btnApplyFilters.FlatStyle = FlatStyle.Flat;
            btnApplyFilters.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnApplyFilters.ForeColor = Color.White;
            btnApplyFilters.Location = new Point(830, 100);
            btnApplyFilters.Name = "btnApplyFilters";
            btnApplyFilters.Size = new Size(100, 35);
            btnApplyFilters.TabIndex = 10;
            btnApplyFilters.Text = "Apply";
            btnApplyFilters.UseVisualStyleBackColor = false;
            btnApplyFilters.Click += btnApplyFilters_Click;
            // 
            // cmbGroupBy
            // 
            cmbGroupBy.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGroupBy.Font = new Font("Segoe UI", 9F);
            cmbGroupBy.FormattingEnabled = true;
            cmbGroupBy.Location = new Point(650, 107);
            cmbGroupBy.Name = "cmbGroupBy";
            cmbGroupBy.Size = new Size(150, 23);
            cmbGroupBy.TabIndex = 9;
            // 
            // lblGroupBy
            // 
            lblGroupBy.AutoSize = true;
            lblGroupBy.Font = new Font("Segoe UI", 9F);
            lblGroupBy.Location = new Point(650, 81);
            lblGroupBy.Name = "lblGroupBy";
            lblGroupBy.Size = new Size(59, 15);
            lblGroupBy.TabIndex = 8;
            lblGroupBy.Text = "Group By:";
            // 
            // cmbSortBy
            // 
            cmbSortBy.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSortBy.Font = new Font("Segoe UI", 9F);
            cmbSortBy.FormattingEnabled = true;
            cmbSortBy.Location = new Point(480, 107);
            cmbSortBy.Name = "cmbSortBy";
            cmbSortBy.Size = new Size(150, 23);
            cmbSortBy.TabIndex = 7;
            // 
            // lblSortBy
            // 
            lblSortBy.AutoSize = true;
            lblSortBy.Font = new Font("Segoe UI", 9F);
            lblSortBy.Location = new Point(480, 81);
            lblSortBy.Name = "lblSortBy";
            lblSortBy.Size = new Size(47, 15);
            lblSortBy.TabIndex = 6;
            lblSortBy.Text = "Sort By:";
            // 
            // cmbPriority
            // 
            cmbPriority.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPriority.Font = new Font("Segoe UI", 9F);
            cmbPriority.FormattingEnabled = true;
            cmbPriority.Location = new Point(310, 107);
            cmbPriority.Name = "cmbPriority";
            cmbPriority.Size = new Size(150, 23);
            cmbPriority.TabIndex = 5;
            // 
            // lblPriority
            // 
            lblPriority.AutoSize = true;
            lblPriority.Font = new Font("Segoe UI", 9F);
            lblPriority.Location = new Point(310, 81);
            lblPriority.Name = "lblPriority";
            lblPriority.Size = new Size(48, 15);
            lblPriority.TabIndex = 4;
            lblPriority.Text = "Priority:";
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Font = new Font("Segoe UI", 9F);
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(140, 107);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(150, 23);
            cmbStatus.TabIndex = 3;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9F);
            lblStatus.Location = new Point(140, 81);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(42, 15);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "Status:";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 11F);
            txtSearch.Location = new Point(20, 40);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search tasks by title or description...";
            txtSearch.Size = new Size(400, 27);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 9F);
            lblSearch.Location = new Point(20, 22);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(45, 15);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Search:";
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.FromArgb(52, 73, 94);
            panelSidebar.Controls.Add(panelStatistics);
            panelSidebar.Controls.Add(panelActions);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 80);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Padding = new Padding(20);
            panelSidebar.Size = new Size(300, 720);
            panelSidebar.TabIndex = 1;
            // 
            // panelStatistics
            // 
            panelStatistics.Controls.Add(groupBoxStats);
            panelStatistics.Dock = DockStyle.Fill;
            panelStatistics.Location = new Point(20, 220);
            panelStatistics.Name = "panelStatistics";
            panelStatistics.Size = new Size(260, 480);
            panelStatistics.TabIndex = 1;
            // 
            // groupBoxStats
            // 
            groupBoxStats.Controls.Add(lblAvgCompletionTime);
            groupBoxStats.Controls.Add(lblOverdueTasks);
            groupBoxStats.Controls.Add(lblCompletedTasks);
            groupBoxStats.Controls.Add(lblPendingTasks);
            groupBoxStats.Controls.Add(lblTotalTasks);
            groupBoxStats.Dock = DockStyle.Fill;
            groupBoxStats.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            groupBoxStats.ForeColor = Color.White;
            groupBoxStats.Location = new Point(0, 0);
            groupBoxStats.Name = "groupBoxStats";
            groupBoxStats.Size = new Size(260, 480);
            groupBoxStats.TabIndex = 0;
            groupBoxStats.TabStop = false;
            groupBoxStats.Text = "Statistics";
            // 
            // lblAvgCompletionTime
            // 
            lblAvgCompletionTime.AutoSize = true;
            lblAvgCompletionTime.Font = new Font("Segoe UI", 10F);
            lblAvgCompletionTime.ForeColor = Color.FromArgb(189, 195, 199);
            lblAvgCompletionTime.Location = new Point(20, 150);
            lblAvgCompletionTime.Name = "lblAvgCompletionTime";
            lblAvgCompletionTime.Size = new Size(155, 19);
            lblAvgCompletionTime.TabIndex = 4;
            lblAvgCompletionTime.Text = "Avg Completion: 0 days";
            // 
            // lblOverdueTasks
            // 
            lblOverdueTasks.AutoSize = true;
            lblOverdueTasks.Font = new Font("Segoe UI", 10F);
            lblOverdueTasks.ForeColor = Color.FromArgb(231, 76, 60);
            lblOverdueTasks.Location = new Point(20, 120);
            lblOverdueTasks.Name = "lblOverdueTasks";
            lblOverdueTasks.Size = new Size(77, 19);
            lblOverdueTasks.TabIndex = 3;
            lblOverdueTasks.Text = "Overdue: 0";
            // 
            // lblCompletedTasks
            // 
            lblCompletedTasks.AutoSize = true;
            lblCompletedTasks.Font = new Font("Segoe UI", 10F);
            lblCompletedTasks.ForeColor = Color.FromArgb(39, 174, 96);
            lblCompletedTasks.Location = new Point(20, 90);
            lblCompletedTasks.Name = "lblCompletedTasks";
            lblCompletedTasks.Size = new Size(91, 19);
            lblCompletedTasks.TabIndex = 2;
            lblCompletedTasks.Text = "Completed: 0";
            // 
            // lblPendingTasks
            // 
            lblPendingTasks.AutoSize = true;
            lblPendingTasks.Font = new Font("Segoe UI", 10F);
            lblPendingTasks.ForeColor = Color.FromArgb(230, 126, 34);
            lblPendingTasks.Location = new Point(20, 60);
            lblPendingTasks.Name = "lblPendingTasks";
            lblPendingTasks.Size = new Size(73, 19);
            lblPendingTasks.TabIndex = 1;
            lblPendingTasks.Text = "Pending: 0";
            // 
            // lblTotalTasks
            // 
            lblTotalTasks.AutoSize = true;
            lblTotalTasks.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalTasks.ForeColor = Color.White;
            lblTotalTasks.Location = new Point(20, 30);
            lblTotalTasks.Name = "lblTotalTasks";
            lblTotalTasks.Size = new Size(109, 21);
            lblTotalTasks.TabIndex = 0;
            lblTotalTasks.Text = "Total Tasks: 0";
            // 
            // panelActions
            // 
            panelActions.Controls.Add(groupBoxActions);
            panelActions.Dock = DockStyle.Top;
            panelActions.Location = new Point(20, 20);
            panelActions.Name = "panelActions";
            panelActions.Size = new Size(260, 200);
            panelActions.TabIndex = 0;
            // 
            // groupBoxActions
            // 
            groupBoxActions.Controls.Add(btnGenerateReport);
            groupBoxActions.Controls.Add(btnDeleteTask);
            groupBoxActions.Controls.Add(btnEditTask);
            groupBoxActions.Controls.Add(btnAddTask);
            groupBoxActions.Dock = DockStyle.Fill;
            groupBoxActions.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            groupBoxActions.ForeColor = Color.White;
            groupBoxActions.Location = new Point(0, 0);
            groupBoxActions.Name = "groupBoxActions";
            groupBoxActions.Size = new Size(260, 200);
            groupBoxActions.TabIndex = 0;
            groupBoxActions.TabStop = false;
            groupBoxActions.Text = "Actions";
            // 
            // btnGenerateReport
            // 
            btnGenerateReport.BackColor = Color.FromArgb(155, 89, 182);
            btnGenerateReport.FlatAppearance.BorderSize = 0;
            btnGenerateReport.FlatStyle = FlatStyle.Flat;
            btnGenerateReport.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGenerateReport.ForeColor = Color.White;
            btnGenerateReport.Location = new Point(20, 150);
            btnGenerateReport.Name = "btnGenerateReport";
            btnGenerateReport.Size = new Size(220, 35);
            btnGenerateReport.TabIndex = 3;
            btnGenerateReport.Text = "📊 Generate Report";
            btnGenerateReport.UseVisualStyleBackColor = false;
            btnGenerateReport.Click += btnGenerateReport_Click;
            // 
            // btnDeleteTask
            // 
            btnDeleteTask.BackColor = Color.FromArgb(231, 76, 60);
            btnDeleteTask.Enabled = false;
            btnDeleteTask.FlatAppearance.BorderSize = 0;
            btnDeleteTask.FlatStyle = FlatStyle.Flat;
            btnDeleteTask.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDeleteTask.ForeColor = Color.White;
            btnDeleteTask.Location = new Point(20, 110);
            btnDeleteTask.Name = "btnDeleteTask";
            btnDeleteTask.Size = new Size(220, 35);
            btnDeleteTask.TabIndex = 2;
            btnDeleteTask.Text = "🗑️ Delete Task";
            btnDeleteTask.UseVisualStyleBackColor = false;
            btnDeleteTask.Click += btnDeleteTask_Click;
            // 
            // btnEditTask
            // 
            btnEditTask.BackColor = Color.FromArgb(230, 126, 34);
            btnEditTask.Enabled = false;
            btnEditTask.FlatAppearance.BorderSize = 0;
            btnEditTask.FlatStyle = FlatStyle.Flat;
            btnEditTask.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEditTask.ForeColor = Color.White;
            btnEditTask.Location = new Point(20, 70);
            btnEditTask.Name = "btnEditTask";
            btnEditTask.Size = new Size(220, 35);
            btnEditTask.TabIndex = 1;
            btnEditTask.Text = "✏️ Edit Task";
            btnEditTask.UseVisualStyleBackColor = false;
            btnEditTask.Click += btnEditTask_Click;
            // 
            // btnAddTask
            // 
            btnAddTask.BackColor = Color.FromArgb(39, 174, 96);
            btnAddTask.FlatAppearance.BorderSize = 0;
            btnAddTask.FlatStyle = FlatStyle.Flat;
            btnAddTask.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAddTask.ForeColor = Color.White;
            btnAddTask.Location = new Point(20, 30);
            btnAddTask.Name = "btnAddTask";
            btnAddTask.Size = new Size(220, 35);
            btnAddTask.TabIndex = 0;
            btnAddTask.Text = "➕ Add New Task";
            btnAddTask.UseVisualStyleBackColor = false;
            btnAddTask.Click += btnAddTask_Click;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(52, 152, 219);
            panelHeader.Controls.Add(btnLogout);
            panelHeader.Controls.Add(lblUserWelcome);
            panelHeader.Controls.Add(lblDashboardTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1400, 80);
            panelHeader.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLogout.BackColor = Color.FromArgb(231, 76, 60);
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(1280, 25);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(100, 30);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // lblUserWelcome
            // 
            lblUserWelcome.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblUserWelcome.AutoSize = true;
            lblUserWelcome.Font = new Font("Segoe UI", 11F);
            lblUserWelcome.ForeColor = Color.White;
            lblUserWelcome.Location = new Point(1100, 30);
            lblUserWelcome.Name = "lblUserWelcome";
            lblUserWelcome.Size = new Size(111, 20);
            lblUserWelcome.TabIndex = 1;
            lblUserWelcome.Text = "Welcome, User!";
            // 
            // lblDashboardTitle
            // 
            lblDashboardTitle.AutoSize = true;
            lblDashboardTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblDashboardTitle.ForeColor = Color.White;
            lblDashboardTitle.Location = new Point(20, 25);
            lblDashboardTitle.Name = "lblDashboardTitle";
            lblDashboardTitle.Size = new Size(221, 32);
            lblDashboardTitle.TabIndex = 0;
            lblDashboardTitle.Text = "Task Management";
            // 
            // timerRefresh
            // 
            timerRefresh.Enabled = true;
            timerRefresh.Interval = 30000;
            timerRefresh.Tick += timerRefresh_Tick;
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1400, 800);
            Controls.Add(panelMain);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(1200, 600);
            Name = "DashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Task Management System - Dashboard";
            WindowState = FormWindowState.Maximized;
            Load += DashboardForm_Load;
            panelMain.ResumeLayout(false);
            panelContent.ResumeLayout(false);
            panelTasks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewTasks).EndInit();
            panelPagination.ResumeLayout(false);
            panelPagination.PerformLayout();
            panelFilters.ResumeLayout(false);
            groupBoxFilters.ResumeLayout(false);
            groupBoxFilters.PerformLayout();
            panelSidebar.ResumeLayout(false);
            panelStatistics.ResumeLayout(false);
            groupBoxStats.ResumeLayout(false);
            groupBoxStats.PerformLayout();
            panelActions.ResumeLayout(false);
            groupBoxActions.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblDashboardTitle;
        private System.Windows.Forms.Label lblUserWelcome;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelActions;
        private System.Windows.Forms.GroupBox groupBoxActions;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.Button btnEditTask;
        private System.Windows.Forms.Button btnDeleteTask;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.Panel panelStatistics;
        private System.Windows.Forms.GroupBox groupBoxStats;
        private System.Windows.Forms.Label lblTotalTasks;
        private System.Windows.Forms.Label lblPendingTasks;
        private System.Windows.Forms.Label lblCompletedTasks;
        private System.Windows.Forms.Label lblOverdueTasks;
        private System.Windows.Forms.Label lblAvgCompletionTime;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelFilters;
        private System.Windows.Forms.GroupBox groupBoxFilters;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbPriority;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.ComboBox cmbSortBy;
        private System.Windows.Forms.Label lblSortBy;
        private System.Windows.Forms.ComboBox cmbGroupBy;
        private System.Windows.Forms.Label lblGroupBy;
        private System.Windows.Forms.Button btnApplyFilters;
        private System.Windows.Forms.Button btnClearFilters;
        private System.Windows.Forms.Panel panelTasks;
        private System.Windows.Forms.DataGridView dataGridViewTasks;
        private System.Windows.Forms.Panel panelPagination;
        private System.Windows.Forms.Button btnPrevPage;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Label lblPageInfo;
        private System.Windows.Forms.Timer timerRefresh;
    }
}