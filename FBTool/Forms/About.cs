using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FBTool.Forms
{
    partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            this.Text = String.Format("About {0}", "FB Tool");
            this.labelProductName.Text = "FB Tool";
            this.labelVersion.Text = String.Format("Version: {0}", "v1.0");
            this.textBoxDescription.Text = "Công cụ.";
        }

        public void SetActivationState(bool isActivated = false, string expried = "")
        {
            if (isActivated)
            {
                this.labelActivated.Text = String.Format("Trạng thái: {0}", "Đã kích hoạt");
            }
            else
            {
                this.labelActivated.Text = String.Format("Trạng thái: {0}", "Chưa kích hoạt");
            }
            
            this.labelExpried.Text = String.Format("{0}", expried);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
