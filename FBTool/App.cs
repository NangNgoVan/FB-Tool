using FBTool.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FBTool.Forms
{
    class App : ApplicationContext
    {//20201108-204622-890f05f347ecad0f47df4551bce7d89e-0
        private ActiveKey activeKeyForm;
        private FBTool fbToolForm;
        private AppKeyManager appKeyManager = AppKeyManager.GetInstance();
        private LicenseManager licenseManager;
        
        public App()
        {
            licenseManager = LicenseManager.GetInstance();
            licenseManager.SetLicenseConverter(new LicenseConverter());
           
            try
            {
                if (!licenseManager.CheckAndLoadLicense())
                {
                    activeKeyForm = new ActiveKey();
                    activeKeyForm.SetLicenseManager(licenseManager);
                    activeKeyForm.ActiveToolEvent += OnActiveToolEvent;
                    activeKeyForm.FormClosing += OnApplicationExit;
                    activeKeyForm.Show();
                }
                else
                {

                }
            }
            catch (Exception e)
            {
                var ok = MessageBox.Show(e.Message);
            }
        }

        private void OnActiveToolEvent(object sender, Events.ActiveEventArgs evt)
        {
            Form senderFormObj = (Form)sender;

            if (evt.Status == ActiveKey.Status.OK)
            {
                fbToolForm = new FBTool();
                fbToolForm.FormClosing += OnApplicationExit;
                fbToolForm.Show();
                senderFormObj.FormClosing -= OnApplicationExit;
                senderFormObj.Close();
            }
            
        }

        private void OnLoginEvent(object sender, Events.LoginEventArgs evt)
        {
            Form form = (Form)sender;
            form.Hide();
            if (evt.Status == Login.Status.OK)
            {
                FBTool fbToolForm = new FBTool();
                fbToolForm.LogoutEvent += OnLogoutEvent;
                fbToolForm.FormClosing += OnApplicationExit;
                fbToolForm.Show();
            }
            else if (evt.Status == Login.Status.Failed)
            {
                // failed
            }
        }

        private void OnLogoutEvent(object sender, EventArgs evt)
        {
            
        }

        private void OnApplicationExit(object sender, EventArgs evt)
        {
            Debug.WriteLine("Application exit");
            ExitThread();
        }
    }
}
