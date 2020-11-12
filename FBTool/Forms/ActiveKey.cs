using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FBTool.Services;
using System.Diagnostics;

namespace FBTool.Forms
{
    public partial class ActiveKey : Form
    {
        public enum Status { OK, FAILED};
        public delegate void ActiveToolHandler(object sender, Events.ActiveEventArgs evt);
        public event ActiveToolHandler ActiveToolEvent;
        public Services.LicenseManager LicenseManager;

        public ActiveKey(Services.LicenseManager licenseManager = null)
        {
            InitializeComponent();
            LicenseManager = licenseManager;
        }

        public void SetLicenseManager(Services.LicenseManager licenseManager)
        {
            LicenseManager = licenseManager;
        }

        private void activeBtn_Click(object sender, EventArgs e)
        {
            string license = LicenseInput.Text;

            if (LicenseManager == null) throw new Exception("License manager installed!");
            try
            {
                if (LicenseManager.CheckLicense(license))
                {
                    ActiveToolEvent?.Invoke(this, new Events.ActiveEventArgs(Status.OK, license));
                }
                else
                {
                    MessageBox.Show("Mã kích hoạt không hợp lệ!");
                    ActiveToolEvent?.Invoke(this, new Events.ActiveEventArgs(Status.FAILED, ""));
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void getActiveKeyLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://google.com");
        }
    }
}
