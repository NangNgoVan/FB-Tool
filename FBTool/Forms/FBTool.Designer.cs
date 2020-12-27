namespace FBTool.Forms
{
    partial class FBTool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FBTool));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utilitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activeKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.expriedTimeStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.fbAccountsGridView = new System.Windows.Forms.DataGridView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.importToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.importUserPassMessageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.importFBAccountStripBtn = new System.Windows.Forms.ToolStripButton();
            this.proxyListStripBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.loginFBWithUsernameBtn = new System.Windows.Forms.ToolStripButton();
            this.loginFBWithCookieBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.filterResult = new System.Windows.Forms.ToolStripComboBox();
            this.clearFbAccountGripViewToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveDataTableStripBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.showLogStripBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fbAccountsGridView)).BeginInit();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.utilitiesToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(665, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.fileToolStripMenuItem.Text = "Tệp";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.exitToolStripMenuItem.Text = "Thoát";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // utilitiesToolStripMenuItem
            // 
            this.utilitiesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configToolStripMenuItem});
            this.utilitiesToolStripMenuItem.Name = "utilitiesToolStripMenuItem";
            this.utilitiesToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.utilitiesToolStripMenuItem.Text = "Tiện ích";
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.configToolStripMenuItem.Text = "Cài đặt...";
            this.configToolStripMenuItem.Click += new System.EventHandler(this.configToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoToolStripMenuItem,
            this.activeKeyToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.helpToolStripMenuItem.Text = "Thông tin";
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.infoToolStripMenuItem.Text = "Thông tin công cụ...";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // activeKeyToolStripMenuItem
            // 
            this.activeKeyToolStripMenuItem.Name = "activeKeyToolStripMenuItem";
            this.activeKeyToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.activeKeyToolStripMenuItem.Text = "Mã kích hoạt...";
            this.activeKeyToolStripMenuItem.Click += new System.EventHandler(this.activeKeyToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.expriedTimeStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 335);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(665, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // expriedTimeStripStatusLabel
            // 
            this.expriedTimeStripStatusLabel.Name = "expriedTimeStripStatusLabel";
            this.expriedTimeStripStatusLabel.Size = new System.Drawing.Size(101, 17);
            this.expriedTimeStripStatusLabel.Text = "Hết hạn: 1/1/2021";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(665, 311);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.fbAccountsGridView);
            this.tabPage1.Controls.Add(this.toolStrip2);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(657, 284);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Quản lý Cookie";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // fbAccountsGridView
            // 
            this.fbAccountsGridView.AllowUserToOrderColumns = true;
            this.fbAccountsGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.fbAccountsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fbAccountsGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fbAccountsGridView.Location = new System.Drawing.Point(3, 28);
            this.fbAccountsGridView.Name = "fbAccountsGridView";
            this.fbAccountsGridView.Size = new System.Drawing.Size(651, 253);
            this.fbAccountsGridView.TabIndex = 4;
            this.fbAccountsGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.fbAccountsGridView_CellClick);
            this.fbAccountsGridView.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.fbAccountsGridView_CellMouseUp);
            this.fbAccountsGridView.SelectionChanged += new System.EventHandler(this.fbAccountsGridView_SelectionChanged);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripDropDownButton,
            this.toolStripSeparator1,
            this.importFBAccountStripBtn,
            this.proxyListStripBtn,
            this.toolStripSeparator5,
            this.loginFBWithUsernameBtn,
            this.loginFBWithCookieBtn,
            this.toolStripSeparator2,
            this.toolStripLabel1,
            this.filterResult,
            this.clearFbAccountGripViewToolStripButton,
            this.saveDataTableStripBtn,
            this.toolStripSeparator3,
            this.showLogStripBtn,
            this.toolStripSeparator4});
            this.toolStrip2.Location = new System.Drawing.Point(3, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(651, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // importToolStripDropDownButton
            // 
            this.importToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.importToolStripDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importUserPassMessageToolStripMenuItem});
            this.importToolStripDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("importToolStripDropDownButton.Image")));
            this.importToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.importToolStripDropDownButton.Name = "importToolStripDropDownButton";
            this.importToolStripDropDownButton.Size = new System.Drawing.Size(29, 22);
            this.importToolStripDropDownButton.Text = "Import dữ liệu...";
            // 
            // importUserPassMessageToolStripMenuItem
            // 
            this.importUserPassMessageToolStripMenuItem.Name = "importUserPassMessageToolStripMenuItem";
            this.importUserPassMessageToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.importUserPassMessageToolStripMenuItem.Text = "Import dạng {user|pass|message}...";
            this.importUserPassMessageToolStripMenuItem.Click += new System.EventHandler(this.importUserPassMessageToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // importFBAccountStripBtn
            // 
            this.importFBAccountStripBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.importFBAccountStripBtn.Image = ((System.Drawing.Image)(resources.GetObject("importFBAccountStripBtn.Image")));
            this.importFBAccountStripBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.importFBAccountStripBtn.Name = "importFBAccountStripBtn";
            this.importFBAccountStripBtn.Size = new System.Drawing.Size(23, 22);
            this.importFBAccountStripBtn.Text = "Thêm hàng...";
            // 
            // proxyListStripBtn
            // 
            this.proxyListStripBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.proxyListStripBtn.Image = ((System.Drawing.Image)(resources.GetObject("proxyListStripBtn.Image")));
            this.proxyListStripBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.proxyListStripBtn.Name = "proxyListStripBtn";
            this.proxyListStripBtn.Size = new System.Drawing.Size(23, 22);
            this.proxyListStripBtn.Text = "Thêm danh sách proxy...";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // loginFBWithUsernameBtn
            // 
            this.loginFBWithUsernameBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.loginFBWithUsernameBtn.Image = ((System.Drawing.Image)(resources.GetObject("loginFBWithUsernameBtn.Image")));
            this.loginFBWithUsernameBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.loginFBWithUsernameBtn.Name = "loginFBWithUsernameBtn";
            this.loginFBWithUsernameBtn.Size = new System.Drawing.Size(23, 22);
            this.loginFBWithUsernameBtn.Text = "Đăng nhập toàn bộ với user|pass";
            this.loginFBWithUsernameBtn.Click += new System.EventHandler(this.loginFBWithUsernameBtn_Click);
            // 
            // loginFBWithCookieBtn
            // 
            this.loginFBWithCookieBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.loginFBWithCookieBtn.Image = ((System.Drawing.Image)(resources.GetObject("loginFBWithCookieBtn.Image")));
            this.loginFBWithCookieBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.loginFBWithCookieBtn.Name = "loginFBWithCookieBtn";
            this.loginFBWithCookieBtn.Size = new System.Drawing.Size(23, 22);
            this.loginFBWithCookieBtn.Text = "Đăng nhập toàn bộ với cookie";
            this.loginFBWithCookieBtn.Click += new System.EventHandler(this.loginFBWithCookieBtn_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(107, 22);
            this.toolStripLabel1.Text = "Lọc theo trạng thái";
            // 
            // filterResult
            // 
            this.filterResult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterResult.Name = "filterResult";
            this.filterResult.Size = new System.Drawing.Size(121, 25);
            // 
            // clearFbAccountGripViewToolStripButton
            // 
            this.clearFbAccountGripViewToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.clearFbAccountGripViewToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("clearFbAccountGripViewToolStripButton.Image")));
            this.clearFbAccountGripViewToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearFbAccountGripViewToolStripButton.Name = "clearFbAccountGripViewToolStripButton";
            this.clearFbAccountGripViewToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.clearFbAccountGripViewToolStripButton.Text = "Clear dữ liệu...";
            this.clearFbAccountGripViewToolStripButton.Click += new System.EventHandler(this.clearFbAccountGripViewToolStripButton_Click);
            // 
            // saveDataTableStripBtn
            // 
            this.saveDataTableStripBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveDataTableStripBtn.Image = ((System.Drawing.Image)(resources.GetObject("saveDataTableStripBtn.Image")));
            this.saveDataTableStripBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveDataTableStripBtn.Name = "saveDataTableStripBtn";
            this.saveDataTableStripBtn.Size = new System.Drawing.Size(23, 22);
            this.saveDataTableStripBtn.Text = "Lưu toàn bộ...";
            this.saveDataTableStripBtn.Click += new System.EventHandler(this.OnSaveAllFbAccTableToFile);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // showLogStripBtn
            // 
            this.showLogStripBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.showLogStripBtn.Image = ((System.Drawing.Image)(resources.GetObject("showLogStripBtn.Image")));
            this.showLogStripBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.showLogStripBtn.Name = "showLogStripBtn";
            this.showLogStripBtn.Size = new System.Drawing.Size(23, 22);
            this.showLogStripBtn.Text = "toolStripButton3";
            this.showLogStripBtn.ToolTipText = "Hiển thị bảng log";
            this.showLogStripBtn.Click += new System.EventHandler(this.showLogStripBtn_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // FBTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 357);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FBTool";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FBTool";
            this.Load += new System.EventHandler(this.FBTool_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fbAccountsGridView)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem utilitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem activeKeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel expriedTimeStripStatusLabel;
        private System.Windows.Forms.ToolStripButton importFBAccountStripBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox filterResult;
        private System.Windows.Forms.DataGridView fbAccountsGridView;
        private System.Windows.Forms.ToolStripButton proxyListStripBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton showLogStripBtn;
        private System.Windows.Forms.ToolStripButton saveDataTableStripBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripDropDownButton importToolStripDropDownButton;
        private System.Windows.Forms.ToolStripMenuItem importUserPassMessageToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton clearFbAccountGripViewToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton loginFBWithUsernameBtn;
        private System.Windows.Forms.ToolStripButton loginFBWithCookieBtn;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}