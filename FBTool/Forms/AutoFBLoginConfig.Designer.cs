namespace FBTool.Forms
{
    partial class AutoFBLoginConfig
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.maxFBBrowserNum = new System.Windows.Forms.NumericUpDown();
            this.timeFbLoginDelay = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.dComResetLogin = new System.Windows.Forms.NumericUpDown();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.useProxyCheckbox = new System.Windows.Forms.CheckBox();
            this.proxyList = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.startLoginProcessBtn = new System.Windows.Forms.Button();
            this.cancelSettingBtn = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxFBBrowserNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeFbLoginDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dComResetLogin)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(485, 301);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(477, 274);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Lấy Cookie";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.52174F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.47826F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.maxFBBrowserNum, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.timeFbLoginDelay, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.dComResetLogin, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.64935F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.35065F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(471, 244);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số lượng cửa sổ song song:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 33);
            this.label2.TabIndex = 1;
            this.label2.Text = "Thời gian giữa các lần đăng nhập (giây):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 117);
            this.label3.TabIndex = 2;
            this.label3.Text = "Danh sách Proxy:";
            // 
            // maxFBBrowserNum
            // 
            this.maxFBBrowserNum.Location = new System.Drawing.Point(151, 3);
            this.maxFBBrowserNum.Name = "maxFBBrowserNum";
            this.maxFBBrowserNum.Size = new System.Drawing.Size(120, 20);
            this.maxFBBrowserNum.TabIndex = 4;
            // 
            // timeFbLoginDelay
            // 
            this.timeFbLoginDelay.Location = new System.Drawing.Point(151, 37);
            this.timeFbLoginDelay.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.timeFbLoginDelay.Name = "timeFbLoginDelay";
            this.timeFbLoginDelay.Size = new System.Drawing.Size(120, 20);
            this.timeFbLoginDelay.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 60);
            this.label4.TabIndex = 6;
            this.label4.Text = "Reset mạng sau mỗi lần đăng nhập (thường dùng với Dcom):";
            // 
            // dComResetLogin
            // 
            this.dComResetLogin.Location = new System.Drawing.Point(151, 187);
            this.dComResetLogin.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.dComResetLogin.Name = "dComResetLogin";
            this.dComResetLogin.Size = new System.Drawing.Size(120, 20);
            this.dComResetLogin.TabIndex = 7;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.useProxyCheckbox);
            this.flowLayoutPanel2.Controls.Add(this.proxyList);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(151, 70);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(317, 111);
            this.flowLayoutPanel2.TabIndex = 8;
            // 
            // useProxyCheckbox
            // 
            this.useProxyCheckbox.AutoSize = true;
            this.useProxyCheckbox.Dock = System.Windows.Forms.DockStyle.Top;
            this.useProxyCheckbox.Location = new System.Drawing.Point(3, 3);
            this.useProxyCheckbox.Name = "useProxyCheckbox";
            this.useProxyCheckbox.Size = new System.Drawing.Size(98, 18);
            this.useProxyCheckbox.TabIndex = 0;
            this.useProxyCheckbox.Text = "Sử dụng proxy";
            this.useProxyCheckbox.UseVisualStyleBackColor = true;
            // 
            // proxyList
            // 
            this.proxyList.Dock = System.Windows.Forms.DockStyle.Top;
            this.proxyList.Location = new System.Drawing.Point(3, 27);
            this.proxyList.Multiline = true;
            this.proxyList.Name = "proxyList";
            this.proxyList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.proxyList.Size = new System.Drawing.Size(306, 68);
            this.proxyList.TabIndex = 4;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(477, 274);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Hướng dẫn";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.startLoginProcessBtn);
            this.flowLayoutPanel1.Controls.Add(this.cancelSettingBtn);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 269);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel1.Size = new System.Drawing.Size(485, 32);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // startLoginProcessBtn
            // 
            this.startLoginProcessBtn.Location = new System.Drawing.Point(407, 3);
            this.startLoginProcessBtn.Name = "startLoginProcessBtn";
            this.startLoginProcessBtn.Size = new System.Drawing.Size(75, 23);
            this.startLoginProcessBtn.TabIndex = 1;
            this.startLoginProcessBtn.Text = "Bắt đầu";
            this.startLoginProcessBtn.UseVisualStyleBackColor = true;
            this.startLoginProcessBtn.Click += new System.EventHandler(this.startLoginProcessBtn_Click);
            // 
            // cancelSettingBtn
            // 
            this.cancelSettingBtn.Location = new System.Drawing.Point(326, 3);
            this.cancelSettingBtn.Name = "cancelSettingBtn";
            this.cancelSettingBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelSettingBtn.TabIndex = 0;
            this.cancelSettingBtn.Text = "Hủy";
            this.cancelSettingBtn.UseVisualStyleBackColor = true;
            this.cancelSettingBtn.Click += new System.EventHandler(this.cancelSettingBtn_Click);
            // 
            // AutoFBLoginConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 301);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AutoFBLoginConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cấu hình";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxFBBrowserNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeFbLoginDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dComResetLogin)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown maxFBBrowserNum;
        private System.Windows.Forms.NumericUpDown timeFbLoginDelay;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button startLoginProcessBtn;
        private System.Windows.Forms.Button cancelSettingBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown dComResetLogin;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.CheckBox useProxyCheckbox;
        private System.Windows.Forms.TextBox proxyList;
    }
}