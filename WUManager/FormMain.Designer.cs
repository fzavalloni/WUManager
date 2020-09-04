namespace WUManager
{
    partial class FormMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Host = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BatchStep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastBoot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cluster = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ServicesRunning = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PingReply = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Progress = new WUManager.ProgBar.DataGridViewProgressColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Updates = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RebootRequired = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.OperationResults = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.startPingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopPingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.getLastBootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkRebootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.countUpdatesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.reportUpdatesToWsusMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetAuthorizationOnWsus = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.installUpdatesBatchingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.installUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.rebootToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.removeItensToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.startPingToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.stopPingToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.getLastBootToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.checkRebootToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.countUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.installUpdatesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.rebootToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.removeItensToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.grpBoxOptions = new System.Windows.Forms.GroupBox();
            this.lblCluster = new System.Windows.Forms.Label();
            this.chkBoxClusterResources = new System.Windows.Forms.CheckBox();
            this.chkBoxCluster = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numUpDownTreads = new System.Windows.Forms.NumericUpDown();
            this.numUpDownAttemptsNumber = new System.Windows.Forms.NumericUpDown();
            this.numUpDownMinutesReboot = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdAddHosts = new System.Windows.Forms.Button();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.rebootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rebootForcedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.addHostsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFile = new System.Windows.Forms.SaveFileDialog();
            this.dataGridViewProgressColumn1 = new WUManager.ProgBar.DataGridViewProgressColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.grpBoxOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownTreads)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownAttemptsNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownMinutesReboot)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView);
            this.splitContainer1.Panel1.Controls.Add(this.menuStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grpBoxOptions);
            this.splitContainer1.Panel2.Controls.Add(this.cmdAddHosts);
            this.splitContainer1.Size = new System.Drawing.Size(1244, 455);
            this.splitContainer1.SplitterDistance = 312;
            this.splitContainer1.TabIndex = 1;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Host,
            this.BatchStep,
            this.LastBoot,
            this.Cluster,
            this.ServicesRunning,
            this.PingReply,
            this.Progress,
            this.Status,
            this.Updates,
            this.RebootRequired,
            this.OperationResults});
            this.dataGridView.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SlateBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView.Location = new System.Drawing.Point(0, 24);
            this.dataGridView.Name = "dataGridView";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(1244, 288);
            this.dataGridView.TabIndex = 2;
            // 
            // Host
            // 
            this.Host.HeaderText = "Host";
            this.Host.Name = "Host";
            // 
            // BatchStep
            // 
            this.BatchStep.HeaderText = "Batch Step";
            this.BatchStep.Name = "BatchStep";
            this.BatchStep.ReadOnly = true;
            this.BatchStep.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BatchStep.Width = 120;
            // 
            // LastBoot
            // 
            this.LastBoot.HeaderText = "Last Boot";
            this.LastBoot.Name = "LastBoot";
            // 
            // Cluster
            // 
            this.Cluster.HeaderText = "Clustered";
            this.Cluster.Name = "Cluster";
            this.Cluster.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Cluster.Width = 60;
            // 
            // ServicesRunning
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ServicesRunning.DefaultCellStyle = dataGridViewCellStyle1;
            this.ServicesRunning.HeaderText = "Services Running";
            this.ServicesRunning.Name = "ServicesRunning";
            this.ServicesRunning.Width = 60;
            // 
            // PingReply
            // 
            this.PingReply.HeaderText = "Ping Reply";
            this.PingReply.Name = "PingReply";
            this.PingReply.Width = 160;
            // 
            // Progress
            // 
            this.Progress.HeaderText = "Progress";
            this.Progress.Name = "Progress";
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.Width = 150;
            // 
            // Updates
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Updates.DefaultCellStyle = dataGridViewCellStyle2;
            this.Updates.HeaderText = "Updates";
            this.Updates.Name = "Updates";
            this.Updates.Width = 55;
            // 
            // RebootRequired
            // 
            this.RebootRequired.HeaderText = "Reboot";
            this.RebootRequired.Name = "RebootRequired";
            this.RebootRequired.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.RebootRequired.Width = 55;
            // 
            // OperationResults
            // 
            this.OperationResults.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.OperationResults.HeaderText = "Operation Results";
            this.OperationResults.Name = "OperationResults";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startPingToolStripMenuItem,
            this.stopPingToolStripMenuItem,
            this.toolStripSeparator3,
            this.getLastBootToolStripMenuItem,
            this.checkRebootToolStripMenuItem,
            this.countUpdatesToolStripMenuItem1,
            this.reportUpdatesToWsusMenuItem,
            this.resetAuthorizationOnWsus,
            this.toolStripSeparator4,
            this.installUpdatesBatchingToolStripMenuItem,
            this.installUpdatesToolStripMenuItem,
            this.toolStripSeparator8,
            this.rebootToolStripMenuItem1,
            this.toolStripSeparator7,
            this.removeItensToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(292, 292);
            // 
            // startPingToolStripMenuItem
            // 
            this.startPingToolStripMenuItem.Name = "startPingToolStripMenuItem";
            this.startPingToolStripMenuItem.Size = new System.Drawing.Size(291, 22);
            this.startPingToolStripMenuItem.Text = "Start Ping";
            this.startPingToolStripMenuItem.Click += new System.EventHandler(this.StartPingToolStripMenuItem_Click);
            // 
            // stopPingToolStripMenuItem
            // 
            this.stopPingToolStripMenuItem.Name = "stopPingToolStripMenuItem";
            this.stopPingToolStripMenuItem.Size = new System.Drawing.Size(291, 22);
            this.stopPingToolStripMenuItem.Text = "Stop Ping";
            this.stopPingToolStripMenuItem.Click += new System.EventHandler(this.RtopPingToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(288, 6);
            // 
            // getLastBootToolStripMenuItem
            // 
            this.getLastBootToolStripMenuItem.Name = "getLastBootToolStripMenuItem";
            this.getLastBootToolStripMenuItem.Size = new System.Drawing.Size(291, 22);
            this.getLastBootToolStripMenuItem.Text = "Get Last Boot Date";
            this.getLastBootToolStripMenuItem.Click += new System.EventHandler(this.GetLastBootToolStripMenuItem_Click);
            // 
            // checkRebootToolStripMenuItem
            // 
            this.checkRebootToolStripMenuItem.Name = "checkRebootToolStripMenuItem";
            this.checkRebootToolStripMenuItem.Size = new System.Drawing.Size(291, 22);
            this.checkRebootToolStripMenuItem.Text = "Check Pending Reboot";
            this.checkRebootToolStripMenuItem.Click += new System.EventHandler(this.CheckRebootToolStripMenuItem_Click);
            // 
            // countUpdatesToolStripMenuItem1
            // 
            this.countUpdatesToolStripMenuItem1.Name = "countUpdatesToolStripMenuItem1";
            this.countUpdatesToolStripMenuItem1.Size = new System.Drawing.Size(291, 22);
            this.countUpdatesToolStripMenuItem1.Text = "Count Updates (Audit)";
            this.countUpdatesToolStripMenuItem1.Click += new System.EventHandler(this.CountUpdatesToolStripMenuItem1_Click);
            // 
            // reportUpdatesToWsusMenuItem
            // 
            this.reportUpdatesToWsusMenuItem.Name = "reportUpdatesToWsusMenuItem";
            this.reportUpdatesToWsusMenuItem.Size = new System.Drawing.Size(291, 22);
            this.reportUpdatesToWsusMenuItem.Text = "Wsus - Report Updates Now";
            this.reportUpdatesToWsusMenuItem.Click += new System.EventHandler(this.ReportUpdatesToWsusMenuItem_Click);
            // 
            // resetAuthorizationOnWsus
            // 
            this.resetAuthorizationOnWsus.Name = "resetAuthorizationOnWsus";
            this.resetAuthorizationOnWsus.Size = new System.Drawing.Size(291, 22);
            this.resetAuthorizationOnWsus.Text = "Wsus - Reset Authorization && DetectNow";
            this.resetAuthorizationOnWsus.Click += new System.EventHandler(this.ResetAuthorizationOnWsusMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(288, 6);
            // 
            // installUpdatesBatchingToolStripMenuItem
            // 
            this.installUpdatesBatchingToolStripMenuItem.Name = "installUpdatesBatchingToolStripMenuItem";
            this.installUpdatesBatchingToolStripMenuItem.Size = new System.Drawing.Size(291, 22);
            this.installUpdatesBatchingToolStripMenuItem.Text = "Install Updates - Batch";
            this.installUpdatesBatchingToolStripMenuItem.Click += new System.EventHandler(this.InstallUpdatesBatchingToolStripMenuItem_Click);
            // 
            // installUpdatesToolStripMenuItem
            // 
            this.installUpdatesToolStripMenuItem.Name = "installUpdatesToolStripMenuItem";
            this.installUpdatesToolStripMenuItem.Size = new System.Drawing.Size(291, 22);
            this.installUpdatesToolStripMenuItem.Text = "Install Updates";
            this.installUpdatesToolStripMenuItem.Click += new System.EventHandler(this.InstallUpdatesContextToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(288, 6);
            // 
            // rebootToolStripMenuItem1
            // 
            this.rebootToolStripMenuItem1.Name = "rebootToolStripMenuItem1";
            this.rebootToolStripMenuItem1.Size = new System.Drawing.Size(291, 22);
            this.rebootToolStripMenuItem1.Text = "Reboot";
            this.rebootToolStripMenuItem1.Click += new System.EventHandler(this.RebootToolStripMenuItem1_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(288, 6);
            // 
            // removeItensToolStripMenuItem
            // 
            this.removeItensToolStripMenuItem.Name = "removeItensToolStripMenuItem";
            this.removeItensToolStripMenuItem.Size = new System.Drawing.Size(291, 22);
            this.removeItensToolStripMenuItem.Text = "Remove Itens";
            this.removeItensToolStripMenuItem.Click += new System.EventHandler(this.RemoveContextToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1244, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.actionsToolStripMenuItem1,
            this.saveListToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.AddToolStripMenuItem_Click);
            // 
            // actionsToolStripMenuItem1
            // 
            this.actionsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startPingToolStripMenuItem1,
            this.stopPingToolStripMenuItem1,
            this.toolStripSeparator9,
            this.getLastBootToolStripMenuItem1,
            this.checkRebootToolStripMenuItem1,
            this.countUpdatesToolStripMenuItem,
            this.toolStripSeparator10,
            this.installUpdatesToolStripMenuItem1,
            this.toolStripSeparator6,
            this.rebootToolStripMenuItem2,
            this.toolStripSeparator5,
            this.removeItensToolStripMenuItem1});
            this.actionsToolStripMenuItem1.Name = "actionsToolStripMenuItem1";
            this.actionsToolStripMenuItem1.Size = new System.Drawing.Size(147, 22);
            this.actionsToolStripMenuItem1.Text = "Actions";
            // 
            // startPingToolStripMenuItem1
            // 
            this.startPingToolStripMenuItem1.Name = "startPingToolStripMenuItem1";
            this.startPingToolStripMenuItem1.Size = new System.Drawing.Size(195, 22);
            this.startPingToolStripMenuItem1.Text = "Start Ping";
            this.startPingToolStripMenuItem1.Click += new System.EventHandler(this.StartPingToolStripMenuItem1_Click);
            // 
            // stopPingToolStripMenuItem1
            // 
            this.stopPingToolStripMenuItem1.Name = "stopPingToolStripMenuItem1";
            this.stopPingToolStripMenuItem1.Size = new System.Drawing.Size(195, 22);
            this.stopPingToolStripMenuItem1.Text = "Stop Ping";
            this.stopPingToolStripMenuItem1.Click += new System.EventHandler(this.StopPingToolStripMenuItem1_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(192, 6);
            // 
            // getLastBootToolStripMenuItem1
            // 
            this.getLastBootToolStripMenuItem1.Name = "getLastBootToolStripMenuItem1";
            this.getLastBootToolStripMenuItem1.Size = new System.Drawing.Size(195, 22);
            this.getLastBootToolStripMenuItem1.Text = "Get Last Boot";
            this.getLastBootToolStripMenuItem1.Click += new System.EventHandler(this.GetLastBootToolStripMenuItem1_Click);
            // 
            // checkRebootToolStripMenuItem1
            // 
            this.checkRebootToolStripMenuItem1.Name = "checkRebootToolStripMenuItem1";
            this.checkRebootToolStripMenuItem1.Size = new System.Drawing.Size(195, 22);
            this.checkRebootToolStripMenuItem1.Text = "Check Pending Reboot";
            this.checkRebootToolStripMenuItem1.Click += new System.EventHandler(this.CheckRebootToolStripMenuItem1_Click);
            // 
            // countUpdatesToolStripMenuItem
            // 
            this.countUpdatesToolStripMenuItem.Name = "countUpdatesToolStripMenuItem";
            this.countUpdatesToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.countUpdatesToolStripMenuItem.Text = "Count Updates";
            this.countUpdatesToolStripMenuItem.Click += new System.EventHandler(this.CountUpdatesToolStripMenuItem_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(192, 6);
            // 
            // installUpdatesToolStripMenuItem1
            // 
            this.installUpdatesToolStripMenuItem1.Name = "installUpdatesToolStripMenuItem1";
            this.installUpdatesToolStripMenuItem1.Size = new System.Drawing.Size(195, 22);
            this.installUpdatesToolStripMenuItem1.Text = "Install Updates";
            this.installUpdatesToolStripMenuItem1.Click += new System.EventHandler(this.InstallUpdatesToolStripMenuItem1_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(192, 6);
            // 
            // rebootToolStripMenuItem2
            // 
            this.rebootToolStripMenuItem2.Name = "rebootToolStripMenuItem2";
            this.rebootToolStripMenuItem2.Size = new System.Drawing.Size(195, 22);
            this.rebootToolStripMenuItem2.Text = "Reboot";
            this.rebootToolStripMenuItem2.Click += new System.EventHandler(this.RebootToolStripMenuItem2_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(192, 6);
            // 
            // removeItensToolStripMenuItem1
            // 
            this.removeItensToolStripMenuItem1.Name = "removeItensToolStripMenuItem1";
            this.removeItensToolStripMenuItem1.Size = new System.Drawing.Size(195, 22);
            this.removeItensToolStripMenuItem1.Text = "Remove Itens";
            this.removeItensToolStripMenuItem1.Click += new System.EventHandler(this.RemoveItensToolStripMenuItem_Click);
            // 
            // saveListToolStripMenuItem
            // 
            this.saveListToolStripMenuItem.Name = "saveListToolStripMenuItem";
            this.saveListToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.saveListToolStripMenuItem.Text = "Save hosts list";
            this.saveListToolStripMenuItem.Click += new System.EventHandler(this.SaveListToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(147, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.ExitToolStripMenuItem1_Click);
            // 
            // grpBoxOptions
            // 
            this.grpBoxOptions.Controls.Add(this.lblCluster);
            this.grpBoxOptions.Controls.Add(this.chkBoxClusterResources);
            this.grpBoxOptions.Controls.Add(this.chkBoxCluster);
            this.grpBoxOptions.Controls.Add(this.label3);
            this.grpBoxOptions.Controls.Add(this.numUpDownTreads);
            this.grpBoxOptions.Controls.Add(this.numUpDownAttemptsNumber);
            this.grpBoxOptions.Controls.Add(this.numUpDownMinutesReboot);
            this.grpBoxOptions.Controls.Add(this.label2);
            this.grpBoxOptions.Controls.Add(this.label1);
            this.grpBoxOptions.Dock = System.Windows.Forms.DockStyle.Right;
            this.grpBoxOptions.Location = new System.Drawing.Point(808, 0);
            this.grpBoxOptions.Name = "grpBoxOptions";
            this.grpBoxOptions.Size = new System.Drawing.Size(436, 139);
            this.grpBoxOptions.TabIndex = 2;
            this.grpBoxOptions.TabStop = false;
            this.grpBoxOptions.Text = "Batch Exection Options";
            // 
            // lblCluster
            // 
            this.lblCluster.AutoSize = true;
            this.lblCluster.Location = new System.Drawing.Point(214, 10);
            this.lblCluster.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCluster.Name = "lblCluster";
            this.lblCluster.Size = new System.Drawing.Size(200, 13);
            this.lblCluster.TabIndex = 9;
            this.lblCluster.Text = "Cluster Options(Requires PowerShell 3.0)";
            // 
            // chkBoxClusterResources
            // 
            this.chkBoxClusterResources.AutoSize = true;
            this.chkBoxClusterResources.Location = new System.Drawing.Point(214, 46);
            this.chkBoxClusterResources.Margin = new System.Windows.Forms.Padding(2);
            this.chkBoxClusterResources.Name = "chkBoxClusterResources";
            this.chkBoxClusterResources.Size = new System.Drawing.Size(228, 17);
            this.chkBoxClusterResources.TabIndex = 8;
            this.chkBoxClusterResources.Text = "Check Active Resources (Host Readiness)";
            this.chkBoxClusterResources.UseVisualStyleBackColor = true;
            // 
            // chkBoxCluster
            // 
            this.chkBoxCluster.AutoSize = true;
            this.chkBoxCluster.Location = new System.Drawing.Point(214, 27);
            this.chkBoxCluster.Margin = new System.Windows.Forms.Padding(2);
            this.chkBoxCluster.Name = "chkBoxCluster";
            this.chkBoxCluster.Size = new System.Drawing.Size(165, 17);
            this.chkBoxCluster.TabIndex = 7;
            this.chkBoxCluster.Text = "Failover Cluster prior patching";
            this.chkBoxCluster.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 64);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Number of Threads";
            // 
            // numUpDownTreads
            // 
            this.numUpDownTreads.Location = new System.Drawing.Point(5, 64);
            this.numUpDownTreads.Margin = new System.Windows.Forms.Padding(2);
            this.numUpDownTreads.Name = "numUpDownTreads";
            this.numUpDownTreads.ReadOnly = true;
            this.numUpDownTreads.Size = new System.Drawing.Size(31, 20);
            this.numUpDownTreads.TabIndex = 5;
            // 
            // numUpDownAttemptsNumber
            // 
            this.numUpDownAttemptsNumber.Location = new System.Drawing.Point(5, 45);
            this.numUpDownAttemptsNumber.Margin = new System.Windows.Forms.Padding(2);
            this.numUpDownAttemptsNumber.Name = "numUpDownAttemptsNumber";
            this.numUpDownAttemptsNumber.ReadOnly = true;
            this.numUpDownAttemptsNumber.Size = new System.Drawing.Size(31, 20);
            this.numUpDownAttemptsNumber.TabIndex = 4;
            this.numUpDownAttemptsNumber.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // numUpDownMinutesReboot
            // 
            this.numUpDownMinutesReboot.Location = new System.Drawing.Point(5, 22);
            this.numUpDownMinutesReboot.Margin = new System.Windows.Forms.Padding(2);
            this.numUpDownMinutesReboot.Name = "numUpDownMinutesReboot";
            this.numUpDownMinutesReboot.ReadOnly = true;
            this.numUpDownMinutesReboot.Size = new System.Drawing.Size(31, 20);
            this.numUpDownMinutesReboot.TabIndex = 3;
            this.numUpDownMinutesReboot.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 45);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Number of Attempts (boot checks)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Minutes between last boot time";
            // 
            // cmdAddHosts
            // 
            this.cmdAddHosts.Location = new System.Drawing.Point(3, 2);
            this.cmdAddHosts.Name = "cmdAddHosts";
            this.cmdAddHosts.Size = new System.Drawing.Size(75, 23);
            this.cmdAddHosts.TabIndex = 1;
            this.cmdAddHosts.Text = "Add Hosts";
            this.cmdAddHosts.UseVisualStyleBackColor = true;
            this.cmdAddHosts.Click += new System.EventHandler(this.AddHosts_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.fileToolStripMenuItem.Text = "Menu";
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.actionsToolStripMenuItem.Text = "Actions";
            // 
            // updatesToolStripMenuItem
            // 
            this.updatesToolStripMenuItem.Name = "updatesToolStripMenuItem";
            this.updatesToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // rebootToolStripMenuItem
            // 
            this.rebootToolStripMenuItem.Name = "rebootToolStripMenuItem";
            this.rebootToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.rebootToolStripMenuItem.Text = "Reboot";
            // 
            // rebootForcedToolStripMenuItem
            // 
            this.rebootForcedToolStripMenuItem.Name = "rebootForcedToolStripMenuItem";
            this.rebootForcedToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.rebootForcedToolStripMenuItem.Text = "Reboot forced";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 433);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1244, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // addHostsToolStripMenuItem
            // 
            this.addHostsToolStripMenuItem.Name = "addHostsToolStripMenuItem";
            this.addHostsToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // dataGridViewProgressColumn1
            // 
            this.dataGridViewProgressColumn1.HeaderText = "Progress";
            this.dataGridViewProgressColumn1.Name = "dataGridViewProgressColumn1";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 455);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WUManager - v1.4";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.grpBoxOptions.ResumeLayout(false);
            this.grpBoxOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownTreads)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownAttemptsNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownMinutesReboot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button cmdAddHosts;
        //private WUManager.ProgBar.DataGridViewProgressColumn dataGridViewProgressColumn1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rebootToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rebootForcedToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem installUpdatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem rebootToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem removeItensToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem addHostsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem installUpdatesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem removeItensToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem rebootToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem startPingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopPingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getLastBootToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        //private WUManager.ProgBar.DataGridViewProgressColumn Progress;
        private System.Windows.Forms.ToolStripMenuItem startPingToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem stopPingToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem getLastBootToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem checkRebootToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem countUpdatesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem checkRebootToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem countUpdatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveListToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFile;
        //private ProgBar.DataGridViewProgressColumn dataGridViewProgressColumn2;
        //private ProgBar.DataGridViewProgressColumn dataGridViewProgressColumn3;
        //private ProgBar.DataGridViewProgressColumn dataGridViewProgressColumn4;
        //private ProgBar.DataGridViewProgressColumn dataGridViewProgressColumn5;
        //private ProgBar.DataGridViewProgressColumn dataGridViewProgressColumn6;
        private System.Windows.Forms.GroupBox grpBoxOptions;
        private System.Windows.Forms.ToolStripMenuItem installUpdatesBatchingToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numUpDownAttemptsNumber;
        private System.Windows.Forms.NumericUpDown numUpDownMinutesReboot;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numUpDownTreads;
        private System.Windows.Forms.CheckBox chkBoxCluster;
        private System.Windows.Forms.CheckBox chkBoxClusterResources;
        private System.Windows.Forms.Label lblCluster;
        private ProgBar.DataGridViewProgressColumn dataGridViewProgressColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Host;
        private System.Windows.Forms.DataGridViewTextBoxColumn BatchStep;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastBoot;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Cluster;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServicesRunning;
        private System.Windows.Forms.DataGridViewTextBoxColumn PingReply;
        private ProgBar.DataGridViewProgressColumn Progress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Updates;
        private System.Windows.Forms.DataGridViewCheckBoxColumn RebootRequired;
        private System.Windows.Forms.DataGridViewTextBoxColumn OperationResults;
        private System.Windows.Forms.ToolStripMenuItem reportUpdatesToWsusMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetAuthorizationOnWsus;
    }
}

