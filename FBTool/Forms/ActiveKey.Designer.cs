namespace FBTool.Forms
{
    partial class ActiveKey
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.LicenseInput = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.activeAppBtn = new System.Windows.Forms.Button();
            this.getActiveKeyLinkLabel = new System.Windows.Forms.LinkLabel();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.8798F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.1202F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.LicenseInput, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62.63736F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.36264F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(391, 115);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 72);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập mã:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LicenseInput
            // 
            this.LicenseInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LicenseInput.Location = new System.Drawing.Point(68, 3);
            this.LicenseInput.Multiline = true;
            this.LicenseInput.Name = "LicenseInput";
            this.LicenseInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LicenseInput.Size = new System.Drawing.Size(320, 66);
            this.LicenseInput.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.activeAppBtn);
            this.flowLayoutPanel1.Controls.Add(this.getActiveKeyLinkLabel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(68, 75);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel1.Size = new System.Drawing.Size(320, 37);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // activeAppBtn
            // 
            this.activeAppBtn.Location = new System.Drawing.Point(242, 3);
            this.activeAppBtn.Name = "activeAppBtn";
            this.activeAppBtn.Size = new System.Drawing.Size(75, 23);
            this.activeAppBtn.TabIndex = 4;
            this.activeAppBtn.Text = "Kích hoạt";
            this.activeAppBtn.UseVisualStyleBackColor = true;
            this.activeAppBtn.Click += new System.EventHandler(this.activeBtn_Click);
            // 
            // getActiveKeyLinkLabel
            // 
            this.getActiveKeyLinkLabel.AutoSize = true;
            this.getActiveKeyLinkLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.getActiveKeyLinkLabel.Location = new System.Drawing.Point(119, 0);
            this.getActiveKeyLinkLabel.Name = "getActiveKeyLinkLabel";
            this.getActiveKeyLinkLabel.Size = new System.Drawing.Size(117, 29);
            this.getActiveKeyLinkLabel.TabIndex = 3;
            this.getActiveKeyLinkLabel.TabStop = true;
            this.getActiveKeyLinkLabel.Text = "Chưa có mã kích hoạt?";
            this.getActiveKeyLinkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.getActiveKeyLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.getActiveKeyLinkLabel_LinkClicked);
            // 
            // ActiveKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 115);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ActiveKey";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kích hoạt FB Tool";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox LicenseInput;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button activeAppBtn;
        private System.Windows.Forms.LinkLabel getActiveKeyLinkLabel;
    }
}