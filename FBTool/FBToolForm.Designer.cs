namespace FBTool
{
    partial class FBToolForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FBToolForm));
            this.menuBar = new System.Windows.Forms.MenuStrip();
            this.FileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.TasksProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.UserTableInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.GetCookieStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.LoginStripButton = new System.Windows.Forms.ToolStripButton();
            this.LoginStripButton_1 = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.PropertyLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.MaxWindowNum = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.TimeDelay = new System.Windows.Forms.NumericUpDown();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.UserDataTableView = new System.Windows.Forms.DataGridView();
            this.LogViewer = new System.Windows.Forms.TextBox();
            this.LogViewerToolBar = new System.Windows.Forms.ToolStrip();
            this.ClearLogStripButton = new System.Windows.Forms.ToolStripButton();
            this.menuBar.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.PropertyLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxWindowNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserDataTableView)).BeginInit();
            this.LogViewerToolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuBar
            // 
            this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuItem,
            this.AboutMenuItem});
            this.menuBar.Location = new System.Drawing.Point(0, 0);
            this.menuBar.Name = "menuBar";
            this.menuBar.Size = new System.Drawing.Size(832, 24);
            this.menuBar.TabIndex = 0;
            this.menuBar.Text = "menuStrip1";
            // 
            // FileMenuItem
            // 
            this.FileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenFileMenuItem,
            this.SaveFileToolStripMenuItem,
            this.EditStripMenuItem});
            this.FileMenuItem.Name = "FileMenuItem";
            this.FileMenuItem.Size = new System.Drawing.Size(39, 20);
            this.FileMenuItem.Text = "Tệp";
            // 
            // OpenFileMenuItem
            // 
            this.OpenFileMenuItem.Name = "OpenFileMenuItem";
            this.OpenFileMenuItem.Size = new System.Drawing.Size(126, 22);
            this.OpenFileMenuItem.Text = "Mở tệp ...";
            this.OpenFileMenuItem.Click += new System.EventHandler(this.OpenFileMenuItem_Click);
            // 
            // SaveFileToolStripMenuItem
            // 
            this.SaveFileToolStripMenuItem.Name = "SaveFileToolStripMenuItem";
            this.SaveFileToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.SaveFileToolStripMenuItem.Text = "Lưu tệp ...";
            this.SaveFileToolStripMenuItem.Click += new System.EventHandler(this.SaveFileToolStripMenuItem_Click);
            // 
            // EditStripMenuItem
            // 
            this.EditStripMenuItem.Name = "EditStripMenuItem";
            this.EditStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.EditStripMenuItem.Text = "Thoát";
            this.EditStripMenuItem.Click += new System.EventHandler(this.EditStripMenuItem_Click);
            // 
            // AboutMenuItem
            // 
            this.AboutMenuItem.Name = "AboutMenuItem";
            this.AboutMenuItem.Size = new System.Drawing.Size(71, 20);
            this.AboutMenuItem.Text = "Thông tin";
            this.AboutMenuItem.Click += new System.EventHandler(this.AboutMenuItem_Click);
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TasksProgress,
            this.UserTableInfo});
            this.statusBar.Location = new System.Drawing.Point(0, 494);
            this.statusBar.Name = "statusBar";
            this.statusBar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusBar.Size = new System.Drawing.Size(832, 22);
            this.statusBar.TabIndex = 1;
            this.statusBar.Text = "statusStrip1";
            // 
            // TasksProgress
            // 
            this.TasksProgress.Name = "TasksProgress";
            this.TasksProgress.Size = new System.Drawing.Size(100, 16);
            // 
            // UserTableInfo
            // 
            this.UserTableInfo.Name = "UserTableInfo";
            this.UserTableInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.UserTableInfo.Size = new System.Drawing.Size(140, 17);
            this.UserTableInfo.Text = "(Tổng 0 hàng, đã chọn 0)";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GetCookieStripButton,
            this.toolStripSeparator1,
            this.LoginStripButton,
            this.LoginStripButton_1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(832, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // GetCookieStripButton
            // 
            this.GetCookieStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.GetCookieStripButton.Image = ((System.Drawing.Image)(resources.GetObject("GetCookieStripButton.Image")));
            this.GetCookieStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.GetCookieStripButton.Name = "GetCookieStripButton";
            this.GetCookieStripButton.Size = new System.Drawing.Size(23, 22);
            this.GetCookieStripButton.Text = "Tự động đăng nhập FB lấy Cookie";
            this.GetCookieStripButton.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // LoginStripButton
            // 
            this.LoginStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.LoginStripButton.Image = ((System.Drawing.Image)(resources.GetObject("LoginStripButton.Image")));
            this.LoginStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LoginStripButton.Name = "LoginStripButton";
            this.LoginStripButton.Size = new System.Drawing.Size(23, 22);
            this.LoginStripButton.Text = "Đăng nhập với Cookie";
            this.LoginStripButton.ToolTipText = "Đăng nhập FB với Cookie";
            this.LoginStripButton.Click += new System.EventHandler(this.LoginStripButton_Click);
            // 
            // LoginStripButton_1
            // 
            this.LoginStripButton_1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.LoginStripButton_1.Image = ((System.Drawing.Image)(resources.GetObject("LoginStripButton_1.Image")));
            this.LoginStripButton_1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LoginStripButton_1.Name = "LoginStripButton_1";
            this.LoginStripButton_1.Size = new System.Drawing.Size(23, 22);
            this.LoginStripButton_1.Text = "toolStripButton1";
            this.LoginStripButton_1.ToolTipText = "Đăng nhập FB với tên tài khoản";
            this.LoginStripButton_1.Click += new System.EventHandler(this.LoginStripButton_1_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.PropertyLayout);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(832, 445);
            this.splitContainer1.SplitterDistance = 169;
            this.splitContainer1.TabIndex = 3;
            // 
            // PropertyLayout
            // 
            this.PropertyLayout.AutoScroll = true;
            this.PropertyLayout.Controls.Add(this.label1);
            this.PropertyLayout.Controls.Add(this.MaxWindowNum);
            this.PropertyLayout.Controls.Add(this.label2);
            this.PropertyLayout.Controls.Add(this.TimeDelay);
            this.PropertyLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PropertyLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.PropertyLayout.Location = new System.Drawing.Point(0, 0);
            this.PropertyLayout.MaximumSize = new System.Drawing.Size(500, 0);
            this.PropertyLayout.MinimumSize = new System.Drawing.Size(50, 0);
            this.PropertyLayout.Name = "PropertyLayout";
            this.PropertyLayout.Padding = new System.Windows.Forms.Padding(10);
            this.PropertyLayout.Size = new System.Drawing.Size(169, 445);
            this.PropertyLayout.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số cửa sổ tối đa:";
            // 
            // MaxWindowNum
            // 
            this.MaxWindowNum.Location = new System.Drawing.Point(13, 27);
            this.MaxWindowNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MaxWindowNum.Name = "MaxWindowNum";
            this.MaxWindowNum.Size = new System.Drawing.Size(120, 20);
            this.MaxWindowNum.TabIndex = 1;
            this.MaxWindowNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 28);
            this.label2.TabIndex = 2;
            this.label2.Text = "Thời gian giữa các lần đăng nhập (giây):";
            // 
            // TimeDelay
            // 
            this.TimeDelay.Location = new System.Drawing.Point(13, 81);
            this.TimeDelay.Name = "TimeDelay";
            this.TimeDelay.Size = new System.Drawing.Size(120, 20);
            this.TimeDelay.TabIndex = 3;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.UserDataTableView);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.LogViewer);
            this.splitContainer2.Panel2.Controls.Add(this.LogViewerToolBar);
            this.splitContainer2.Size = new System.Drawing.Size(659, 445);
            this.splitContainer2.SplitterDistance = 295;
            this.splitContainer2.TabIndex = 0;
            // 
            // UserDataTableView
            // 
            this.UserDataTableView.AllowUserToDeleteRows = false;
            this.UserDataTableView.AllowUserToOrderColumns = true;
            this.UserDataTableView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.UserDataTableView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.UserDataTableView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UserDataTableView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserDataTableView.Location = new System.Drawing.Point(0, 0);
            this.UserDataTableView.Name = "UserDataTableView";
            this.UserDataTableView.ReadOnly = true;
            this.UserDataTableView.Size = new System.Drawing.Size(659, 295);
            this.UserDataTableView.TabIndex = 2;
            this.UserDataTableView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.userDataTableView_CellContentClick);
            this.UserDataTableView.SelectionChanged += new System.EventHandler(this.userDataTableView_SelectionChanged);
            // 
            // LogViewer
            // 
            this.LogViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogViewer.Location = new System.Drawing.Point(0, 25);
            this.LogViewer.MinimumSize = new System.Drawing.Size(200, 4);
            this.LogViewer.Multiline = true;
            this.LogViewer.Name = "LogViewer";
            this.LogViewer.ReadOnly = true;
            this.LogViewer.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.LogViewer.Size = new System.Drawing.Size(659, 121);
            this.LogViewer.TabIndex = 4;
            // 
            // LogViewerToolBar
            // 
            this.LogViewerToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ClearLogStripButton});
            this.LogViewerToolBar.Location = new System.Drawing.Point(0, 0);
            this.LogViewerToolBar.Name = "LogViewerToolBar";
            this.LogViewerToolBar.Size = new System.Drawing.Size(659, 25);
            this.LogViewerToolBar.TabIndex = 0;
            this.LogViewerToolBar.Text = "toolStrip2";
            // 
            // ClearLogStripButton
            // 
            this.ClearLogStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ClearLogStripButton.Image = ((System.Drawing.Image)(resources.GetObject("ClearLogStripButton.Image")));
            this.ClearLogStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ClearLogStripButton.Name = "ClearLogStripButton";
            this.ClearLogStripButton.Size = new System.Drawing.Size(23, 22);
            this.ClearLogStripButton.Text = "Xóa log";
            this.ClearLogStripButton.Click += new System.EventHandler(this.ClearLogStripButton_Click);
            // 
            // FBToolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 516);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.menuBar);
            this.MainMenuStrip = this.menuBar;
            this.Name = "FBToolForm";
            this.Text = "FB Cookie Tool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuBar.ResumeLayout(false);
            this.menuBar.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.PropertyLayout.ResumeLayout(false);
            this.PropertyLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxWindowNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeDelay)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UserDataTableView)).EndInit();
            this.LogViewerToolBar.ResumeLayout(false);
            this.LogViewerToolBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuBar;
        private System.Windows.Forms.ToolStripMenuItem FileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenFileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutMenuItem;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripButton GetCookieStripButton;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView UserDataTableView;
        private System.Windows.Forms.ToolStripMenuItem SaveFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditStripMenuItem;
        private System.Windows.Forms.ToolStripButton LoginStripButton;
        private System.Windows.Forms.TextBox LogViewer;
        private System.Windows.Forms.ToolStrip LogViewerToolBar;
        private System.Windows.Forms.ToolStripButton ClearLogStripButton;
        private System.Windows.Forms.FlowLayoutPanel PropertyLayout;
        private System.Windows.Forms.ToolStripProgressBar TasksProgress;
        private System.Windows.Forms.ToolStripStatusLabel UserTableInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown MaxWindowNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown TimeDelay;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton LoginStripButton_1;
    }
}

