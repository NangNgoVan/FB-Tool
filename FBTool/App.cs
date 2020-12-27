using FBTool.Forms;
using FBTool.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace FBTool
{
    
    class App : ApplicationContext
    {//20201108-204622-890f05f347ecad0f47df4551bce7d89e-0
        private ActiveKey activeKeyForm;
        private Forms.FBTool fbToolForm;
        private AppKeyManager appKeyManager = AppKeyManager.GetInstance();
        private LicenseManager licenseManager;
        private int intervalTime = 1000;

        private System.Windows.Forms.Timer appTimer = new System.Windows.Forms.Timer();

        private void OnTimerEvent(object source, EventArgs e)
        {
            if (DateTime.Now >= licenseManager.ExpriedDate)
            {
                ExitThread();
                appTimer.Stop();
            }
        }

        private void SetTimer()
        {
            //
            appTimer.Tick += OnTimerEvent;
            appTimer.Interval = intervalTime;
            //appTimer.Enabled = true;
        }

        private void InitFBToolForm()
        {
            fbToolForm = new Forms.FBTool();
            fbToolForm.SetExpriedDate(licenseManager.ExpriedDate);
            fbToolForm.FormClosing += OnApplicationExit;
            fbToolForm.Show();
        }

        public App()
        {
            SetTimer();

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
                    InitFBToolForm();
                    appTimer.Start();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void OnActiveToolEvent(object sender, Events.ActiveEventArgs evt)
        {
            Form senderFormObj = (Form)sender;

            if (evt.Status == ActiveKey.Status.OK)
            {
                InitFBToolForm();
                senderFormObj.FormClosing -= OnApplicationExit;
                senderFormObj.Close();
                appTimer.Start();
            }
            else if (evt.Status == ActiveKey.Status.ERROR)
            {
                MessageBox.Show(evt.Message);
                ExitThread();
            }
        }

        private void OnLoginEvent(object sender, Events.LoginEventArgs evt)
        {
            
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
