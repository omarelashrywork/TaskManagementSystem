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
            this.components = new System.ComponentModel.Container();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelTasks = new System.Windows.Forms.Panel();
            this.dataGridViewTasks = new System.Windows.Forms.DataGridView();
            this.panelPagination = new System.Windows.Forms.Panel();
            this.lblPageInfo = new System.Windows.Forms.Label();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.btnPrevPage = new System.Windows.Forms.Button();
            this.panelFilters = new System.Windows.Forms.Panel();
            this.groupBoxFilters = new System.Windows.Forms.GroupBox();
            this.btnClearFilters = new System.Windows.Forms.Button();
            this.btnApplyFilters = new System.Windows.Forms.Button();
            this.cmbGroupBy = new System.Windows.Forms.ComboBox();
            this.lblGroupBy = new System.Windows.Forms.Label();
            this.cmbSortBy = new System.Windows.Forms.ComboBox();
            this.lblSortBy = new System.Windows.Forms.Label();
            this.cmbPriority = new System.Windows.Forms.ComboBox();
            this.lblPriority = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.panelStatistics = new System.Windows.Forms.Panel();
            this.groupBoxStats = new System.Windows.Forms.GroupBox();
            this.lblAvgCompletionTime = new System.Windows.Forms.Label();
            this.lblOverdueTasks = new System.Windows.Forms.Label();
            this.lblCompletedTasks = new System.Windows.Forms.Label();
            this.lblPendingTasks = new System.Windows.Forms.Label();
            this.lblTotalTasks = new System.Windows.Forms.Label();
            this.panelActions = new System.Windows.Forms.Panel();
            this.groupBoxActions = new System.Windows.Forms.GroupBox();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.btnDeleteTask = new System.Windows.Forms.Button();
            this.btnEditTask = new System.Windows.Forms.Button();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblUserWelcome = new System.Windows.Forms.Label();
            this.lblDashboardTitle = new System.Windows.Forms.Label();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.panelMain.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.panelTasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTasks)).BeginInit();
            this.panelPagination.SuspendLayout();
            this.panelFilters.SuspendLayout();
            this.groupBoxFilters.SuspendLayout();
            this.panelSidebar.SuspendLayout();
            this.panelStatistics.SuspendLayout();
            this.groupBoxStats.SuspendLayout();
            this.panelActions.SuspendLayout();
            this.groupBoxActions.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelMain.Controls.Add(this.panelContent);
            this.panelMain.Controls.Add(this.panelSidebar);
            this.panelMain.Controls.Add(this.panelHeader);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1400, 800);
            this.panelMain.TabIndex = 0;
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.White;
            this.panelContent.Controls.Add(this.panelTasks);
            this.panelContent.Controls.Add(this.panelFilters);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(300, 80);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(20);
            this.panelContent.Size = new System.Drawing.Size(1100, 720);
            this.panelContent.TabIndex = 2;
            // 
            // panelTasks
            // 
            this.panelTasks.Controls.Add(this.dataGridViewTasks);
            this.panelTasks.Controls.Add(this.panelPagination);
            this.panelTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTasks.Location = new System.Drawing.Point(20, 170);
            this.panelTasks.Name = "panelTasks";
            this.panelTasks.Size = new System.Drawing.Size(1060, 530);
            this.panelTasks.TabIndex = 1;
            // 
            // dataGridViewTasks
            // 
            this.dataGridViewTasks.AllowUserToAddRows = false;
            this.dataGridViewTasks.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewTasks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTasks.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(221)))), ((int)(((byte)(222)))));
            this.dataGridViewTasks.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewTasks.MultiSelect = false;
            this.dataGridViewTasks.Name = "dataGridViewTasks";
            this.dataGridViewTasks.ReadOnly = true;
            this.dataGridViewTasks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTasks.Size = new System.Drawing.Size(1060, 480);
            this.dataGridViewTasks.TabIndex = 0;
            this.dataGridViewTasks.SelectionChanged += new System.EventHandler(this.dataGridViewTasks_SelectionChanged);
            this.dataGridViewTasks.DoubleClick += new System.EventHandler(this.dataGridViewTasks_DoubleClick);
            // 
            // panelPagination
            // 
            this.panelPagination.Controls.Add(this.lblPageInfo);
            this.panelPagination.Controls.Add(this.btnNextPage);
            this.panelPagination.Controls.Add(this.btnPrevPage);
            this.panelPagination.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelPagination.Location = new System.Drawing.Point(0, 480);
            this.panelPagination.Name = "panelPagination";
            this.panelPagination.Size = new System.Drawing.Size(1060, 50);
            this.panelPagination.TabIndex = 1;
            // 
            // lblPageInfo
            // 
            this.lblPageInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPageInfo.AutoSize = true;
            this.lblPageInfo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPageInfo.Location = new System.Drawing.Point(480, 15);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(85, 19);
            this.lblPageInfo.TabIndex = 2;
            this.lblPageInfo.Text = "Page 1 of 10";
            // 
            // btnNextPage
            // 
            this.btnNextPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnNextPage.FlatAppearance.BorderSize = 0;
            this.btnNextPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextPage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnNextPage.ForeColor = System.Drawing.Color.White;
            this.btnNextPage.Location = new System.Drawing.Point(960, 10);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(80, 30);
            this.btnNextPage.TabIndex = 1;
            this.btnNextPage.Text = "Next";
            this.btnNextPage.UseVisualStyleBackColor = false;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // btnPrevPage
            // 
            this.btnPrevPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnPrevPage.FlatAppearance.BorderSize = 0;
            this.btnPrevPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevPage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnPrevPage.ForeColor = System.Drawing.Color.White;
            this.btnPrevPage.Location = new System.Drawing.Point(20, 10);
            this.btnPrevPage.Name = "btnPrevPage";
            this.btnPrevPage.Size = new System.Drawing.Size(80, 30);
            this.btnPrevPage.TabIndex = 0;
            this.btnPrevPage.Text = "Previous";
            this.btnPrevPage.UseVisualStyleBackColor = false;
            this.btnPrevPage.Click += new System.EventHandler(this.btnPrevPage_Click);
            // 
            // panelFilters
            // 
            this.panelFilters.Controls.Add(this.groupBoxFilters);
            this.panelFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilters.Location = new System.Drawing.Point(20, 20);
            this.panelFilters.Name = "panelFilters";
            this.panelFilters.Size = new System.Drawing.Size(1060, 150);
            this.panelFilters.TabIndex = 0;
            // 
            // groupBoxFilters
            // 
            this.groupBoxFilters.Controls.Add(this.btnClearFilters);
            this.groupBoxFilters.Controls.Add(this.btnApplyFilters);
            this.groupBoxFilters.Controls.Add(this.cmbGroupBy);
            this.groupBoxFilters.Controls.Add(this.lblGroupBy);
            this.groupBoxFilters.Controls.Add(this.cmbSortBy);
            this.groupBoxFilters.Controls.Add(this.lblSortBy);
            this.groupBoxFilters.Controls.Add(this.cmbPriority);
            this.groupBoxFilters.Controls.Add(this.lblPriority);
            this.groupBoxFilters.Controls.Add(this.cmbStatus);
            this.groupBoxFilters.Controls.Add(this.lblStatus);
            this.groupBoxFilters.Controls.Add(this.txtSearch);
            this.groupBoxFilters.Controls.Add(this.lblSearch);
            this.groupBoxFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxFilters.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxFilters.Location = new System.Drawing.Point(0, 0);
            this.groupBoxFilters.Name = "groupBoxFilters";
            this.groupBoxFilters.Size = new System.Drawing.Size(1060, 150);
            this.groupBoxFilters.TabIndex = 0;
            this.groupBoxFilters.TabStop = false;
            this.groupBoxFilters.Text = "Filters & Search";
            // 
            // btnClearFilters
            // 
            this.btnClearFilters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnClearFilters.FlatAppearance.BorderSize = 0;
            this.btnClearFilters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearFilters.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnClearFilters.ForeColor = System.Drawing.Color.White;
            this.btnClearFilters.Location = new System.Drawing.Point(950, 100);
            this.btnClearFilters.Name = "btnClearFilters";
            this.btnClearFilters.Size = new System.Drawing.Size(100, 35);
            this.btnClearFilters.TabIndex = 11;
            this.btnClearFilters.Text = "Clear";
            this.btnClearFilters.UseVisualStyleBackColor = false;
            this.btnClearFilters.Click += new System.EventHandler(this.btnClearFilters_Click);
            // 
            // btnApplyFilters
            // 
            this.btnApplyFilters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnApplyFilters.FlatAppearance.BorderSize = 0;
            this.btnApplyFilters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplyFilters.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnApplyFilters.ForeColor = System.Drawing.Color.White;
            this.btnApplyFilters.Location = new System.Drawing.Point(830, 100);
            this.btnApplyFilters.Name = "btnApplyFilters";
            this.btnApplyFilters.Size = new System.Drawing.Size(100, 35);
            this.btnApplyFilters.TabIndex = 10;
            this.btnApplyFilters.Text = "Apply";
            this.btnApplyFilters.UseVisualStyleBackColor = false;
            this.btnApplyFilters.Click += new System.EventHandler(this.btnApplyFilters_Click);
            // 
            // cmbGroupBy
            // 
            this.cmbGroupBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroupBy.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbGroupBy.FormattingEnabled = true;
            this.cmbGroupBy.Location = new System.Drawing.Point(650, 70);
            this.cmbGroupBy.Name = "cmbGroupBy";
            this.cmbGroupBy.Size = new System.Drawing.Size(150, 23);
            this.cmbGroupBy.TabIndex = 9;
            // 
            // lblGroupBy
            // 
            this.lblGroupBy.AutoSize = true;
            this.lblGroupBy.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblGroupBy.Location = new System.Drawing.Point(650, 50);
            this.lblGroupBy.Name = "lblGroupBy";
            this.lblGroupBy.Size = new System.Drawing.Size(60, 15);
            this.lblGroupBy.TabIndex = 8;
            this.lblGroupBy.Text = "Group By:";
            // 
            // cmbSortBy
            // 
            this.cmbSortBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSortBy.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbSortBy.FormattingEnabled = true;
            this.cmbSortBy.Location = new System.Drawing.Point(480, 70);
            this.cmbSortBy.Name = "cmbSortBy";
            this.cmbSortBy.Size = new System.Drawing.Size(150, 23);
            this.cmbSortBy.TabIndex = 7;
            // 
            // lblSortBy
            // 
            this.lblSortBy.AutoSize = true;
            this.lblSortBy.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSortBy.Location = new System.Drawing.Point(480, 50);
            this.lblSortBy.Name = "lblSortBy";
            this.lblSortBy.Size = new System.Drawing.Size(50, 15);
            this.lblSortBy.TabIndex = 6;
            this.lblSortBy.Text = "Sort By:";
            // 
            // cmbPriority
            // 
            this.cmbPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPriority.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbPriority.FormattingEnabled = true;
            this.cmbPriority.Location = new System.Drawing.Point(310, 70);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Size = new System.Drawing.Size(150, 23);
            this.cmbPriority.TabIndex = 5;
            // 
            // lblPriority
            // 
            this.lblPriority.AutoSize = true;
            this.lblPriority.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPriority.Location = new System.Drawing.Point(310, 50);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(48, 15);
            this.lblPriority.TabIndex = 4;
            this.lblPriority.Text = "Priority:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(140, 70);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(150, 23);
            this.cmbStatus.TabIndex = 3;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatus.Location = new System.Drawing.Point(140, 50);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(42, 15);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Status:";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtSearch.Location = new System.Drawing.Point(20, 40);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "Search tasks by title or description...";
            this.txtSearch.Size = new System.Drawing.Size(400, 27);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSearch.Location = new System.Drawing.Point(20, 22);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(45, 15);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search:";
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.panelSidebar.Controls.Add(this.panelStatistics);
            this.panelSidebar.Controls.Add(this.panelActions);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 80);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Padding = new System.Windows.Forms.Padding(20);
            this.panelSidebar.Size = new System.Drawing.Size(300, 720);
            this.panelSidebar.TabIndex = 1;
            // 
            // panelStatistics
            // 
            this.panelStatistics.Controls.Add(this.groupBoxStats);
            this.panelStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelStatistics.Location = new System.Drawing.Point(20, 220);
            this.panelStatistics.Name = "panelStatistics";
            this.panelStatistics.Size = new System.Drawing.Size(260, 480);
            this.panelStatistics.TabIndex = 1;
            // 
            // groupBoxStats
            // 
            this.groupBoxStats.Controls.Add(this.lblAvgCompletionTime);
            this.groupBoxStats.Controls.Add(this.lblOverdueTasks);
            this.groupBoxStats.Controls.Add(this.lblCompletedTasks);
            this.groupBoxStats.Controls.Add(this.lblPendingTasks);
            this.groupBoxStats.Controls.Add(this.lblTotalTasks);
            this.groupBoxStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxStats.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.groupBoxStats.ForeColor = System.Drawing.Color.White;
            this.groupBoxStats.Location = new System.Drawing.Point(0, 0);
            this.groupBoxStats.Name = "groupBoxStats";
            this.groupBoxStats.Size = new System.Drawing.Size(260, 480);
            this.groupBoxStats.TabIndex = 0;
            this.groupBoxStats.TabStop = false;
            this.groupBoxStats.Text = "Statistics";
            // 
            // lblAvgCompletionTime
            // 
            this.lblAvgCompletionTime.AutoSize = true;
            this.lblAvgCompletionTime.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAvgCompletionTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(195)))), ((int)(((byte)(199)))));
            this.lblAvgCompletionTime.Location = new System.Drawing.Point(20, 150);
            this.lblAvgCompletionTime.Name = "lblAvgCompletionTime";
            this.lblAvgCompletionTime.Size = new System.Drawing.Size(153, 19);
            this.lblAvgCompletionTime.TabIndex = 4;
            this.lblAvgCompletionTime.Text = "Avg Completion: 0 days";
            // 
            // lblOverdueTasks
            // 
            this.lblOverdueTasks.AutoSize = true;
            this.lblOverdueTasks.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblOverdueTasks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblOverdueTasks.Location = new System.Drawing.Point(20, 120);
            this.lblOverdueTasks.Name = "lblOverdueTasks";
            this.lblOverdueTasks.Size = new System.Drawing.Size(81, 19);
            this.lblOverdueTasks.TabIndex = 3;
            this.lblOverdueTasks.Text = "Overdue: 0";
            // 
            // lblCompletedTasks
            // 
            this.lblCompletedTasks.AutoSize = true;
            this.lblCompletedTasks.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCompletedTasks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.lblCompletedTasks.Location = new System.Drawing.Point(20, 90);
            this.lblCompletedTasks.Name = "lblCompletedTasks";
            this.lblCompletedTasks.Size = new System.Drawing.Size(91, 19);
            this.lblCompletedTasks.TabIndex = 2;
            this.lblCompletedTasks.Text = "Completed: 0";
            // 
            // lblPendingTasks
            // 
            this.lblPendingTasks.AutoSize = true;
            this.lblPendingTasks.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPendingTasks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.lblPendingTasks.Location = new System.Drawing.Point(20, 60);
            this.lblPendingTasks.Name = "lblPendingTasks";
            this.lblPendingTasks.Size = new System.Drawing.Size(75, 19);
            this.lblPendingTasks.TabIndex = 1;
            this.lblPendingTasks.Text = "Pending: 0";
            // 
            // lblTotalTasks
            // 
            this.lblTotalTasks.AutoSize = true;
            this.lblTotalTasks.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalTasks.ForeColor = System.Drawing.Color.White;
            this.lblTotalTasks.Location = new System.Drawing.Point(20, 30);
            this.lblTotalTasks.Name = "lblTotalTasks";
            this.lblTotalTasks.Size = new System.Drawing.Size(108, 21);
            this.lblTotalTasks.TabIndex = 0;
            this.lblTotalTasks.Text = "Total Tasks: 0";
            // 
            // panelActions
            // 
            this.panelActions.Controls.Add(this.groupBoxActions);
            this.panelActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelActions.Location = new System.Drawing.Point(20, 20);
            this.panelActions.Name = "panelActions";
            this.panelActions.Size = new System.Drawing.Size(260, 200);
            this.panelActions.TabIndex = 0;
            // 
            // groupBoxActions
            // 
            this.groupBoxActions.Controls.Add(this.btnGenerateReport);
            this.groupBoxActions.Controls.Add(this.btnDeleteTask);
            this.groupBoxActions.Controls.Add(this.btnEditTask);
            this.groupBoxActions.Controls.Add(this.btnAddTask);
            this.groupBoxActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxActions.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.groupBoxActions.ForeColor = System.Drawing.Color.White;
            this.groupBoxActions.Location = new System.Drawing.Point(0, 0);
            this.groupBoxActions.Name = "groupBoxActions";
            this.groupBoxActions.Size = new System.Drawing.Size(260, 200);
            this.groupBoxActions.TabIndex = 0;
            this.groupBoxActions.TabStop = false;
            this.groupBoxActions.Text = "Actions";
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnGenerateReport.FlatAppearance.BorderSize = 0;
            this.btnGenerateReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateReport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGenerateReport.ForeColor = System.Drawing.Color.White;
            this.btnGenerateReport.Location = new System.Drawing.Point(20, 150);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(220, 35);
            this.btnGenerateReport.TabIndex = 3;
            this.btnGenerateReport.Text = "📊 Generate Report";
            this.btnGenerateReport.UseVisualStyleBackColor = false;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // btnDeleteTask
            // 
            this.btnDeleteTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnDeleteTask.Enabled = false;
            this.btnDeleteTask.FlatAppearance.BorderSize = 0;
            this.btnDeleteTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteTask.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDeleteTask.ForeColor = System.Drawing.Color.White;
            this.btnDeleteTask.Location = new System.Drawing.Point(20, 110);
            this.btnDeleteTask.Name = "btnDeleteTask";
            this.btnDeleteTask.Size = new System.Drawing.Size(220, 35);
            this.btnDeleteTask.TabIndex = 2;
            this.btnDeleteTask.Text = "🗑️ Delete Task";
            this.btnDeleteTask.UseVisualStyleBackColor = false;
            this.btnDeleteTask.Click += new System.EventHandler(this.btnDeleteTask_Click);
            // 
            // btnEditTask
            // 
            this.btnEditTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnEditTask.Enabled = false;
            this.btnEditTask.FlatAppearance.BorderSize = 0;
            this.btnEditTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditTask.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEditTask.ForeColor = System.Drawing.Color.White;
            this.btnEditTask.Location = new System.Drawing.Point(20, 70);
            this.btnEditTask.Name = "btnEditTask";
            this.btnEditTask.Size = new System.Drawing.Size(220, 35);
            this.btnEditTask.TabIndex = 1;
            this.btnEditTask.Text = "✏️ Edit Task";
            this.btnEditTask.UseVisualStyleBackColor = false;
            this.btnEditTask.Click += new System.EventHandler(this.btnEditTask_Click);
            // 
            // btnAddTask
            // 
            this.btnAddTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnAddTask.FlatAppearance.BorderSize = 0;
            this.btnAddTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTask.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddTask.ForeColor = System.Drawing.Color.White;
            this.btnAddTask.Location = new System.Drawing.Point(20, 30);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(220, 35);
            this.btnAddTask.TabIndex = 0;
            this.btnAddTask.Text = "➕ Add New Task";
            this.btnAddTask.UseVisualStyleBackColor = false;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.panelHeader.Controls.Add(this.btnLogout);
            this.panelHeader.Controls.Add(this.lblUserWelcome);
            this.panelHeader.Controls.Add(this.lblDashboardTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1400, 80);
            this.panelHeader.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(1280, 25);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(100, 30);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblUserWelcome
            // 
            this.lblUserWelcome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserWelcome.AutoSize = true;
            this.lblUserWelcome.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblUserWelcome.ForeColor = System.Drawing.Color.White;
            this.lblUserWelcome.Location = new System.Drawing.Point(1100, 30);
            this.lblUserWelcome.Name = "lblUserWelcome";
            this.lblUserWelcome.Size = new System.Drawing.Size(104, 20);
            this.lblUserWelcome.TabIndex = 1;
            this.lblUserWelcome.Text = "Welcome, User!";
            // 
            // lblDashboardTitle
            // 
            this.lblDashboardTitle.AutoSize = true;
            this.lblDashboardTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblDashboardTitle.ForeColor = System.Drawing.Color.White;
            this.lblDashboardTitle.Location = new System.Drawing.Point(20, 25);
            this.lblDashboardTitle.Name = "lblDashboardTitle";
            this.lblDashboardTitle.Size = new System.Drawing.Size(234, 32);
            this.lblDashboardTitle.TabIndex = 0;
            this.lblDashboardTitle.Text = "Task Management";
            // 
            // timerRefresh
            // 
            this.timerRefresh.Enabled = true;
            this.timerRefresh.Interval = 30000;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1400, 800);
            this.Controls.Add(this.panelMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1200, 600);
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Task Management System - Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            this.panelMain.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.panelTasks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTasks)).EndInit();
            this.panelPagination.ResumeLayout(false);
            this.panelPagination.PerformLayout();
            this.panelFilters.ResumeLayout(false);
            this.groupBoxFilters.ResumeLayout(false);
            this.groupBoxFilters.PerformLayout();
            this.panelSidebar.ResumeLayout(false);
            this.panelStatistics.ResumeLayout(false);
            this.groupBoxStats.ResumeLayout(false);
            this.groupBoxStats.PerformLayout();
            this.panelActions.ResumeLayout(false);
            this.groupBoxActions.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);
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