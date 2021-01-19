using FBTool.CustomEventArgs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FBTool.Forms
{
    public partial class AutoFBLoginConfig : Form
    {
        public enum State { OK, CANCEL};
        public delegate void FBLoginConfigEventHandler(object sender, FBLoginConfigEventArgs evt);
        public event FBLoginConfigEventHandler FbLoginConfigEvent;
        public AutoFBLoginConfig()
        {
            InitializeComponent();
            try
            {
                string helpPageDirPath = String.Format(@"{0}\help.html", Application.StartupPath);
                helpPage.DocumentText = File.ReadAllText(helpPageDirPath);
            }
            catch (Exception e)
            {
                helpPage.DocumentText = "Không tìm thấy đường dẫn.";
            }

            maxFBBrowserNum.Value = 5;
            timeFbLoginDelay.Value = 0;
            dComResetLogin.Value = 0;
        }

        private void cancelSettingBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void startLoginProcessBtn_Click(object sender, EventArgs e)
        {
            FBLoginConfigEventArgs args = new FBLoginConfigEventArgs();
            args.Status = State.OK;
            args.MaxFBBrowserNum = (int)maxFBBrowserNum.Value;
            args.TimeFBLoginDelay = (int)timeFbLoginDelay.Value;
            args.UseProxy = useProxyCheckbox.Checked;
            // proxies
            args.Proxies = new List<string>();
            for (int i = 0; i < proxyList.Lines.Length; i++)
            {
                args.Proxies.Add(proxyList.Lines[i]);
            }
            //
            args.NetworkResetAfter = (int)dComResetLogin.Value;
            FbLoginConfigEvent?.Invoke(this, args);
        }
    }
}
