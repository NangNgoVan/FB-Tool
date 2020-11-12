using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FBTool.Forms
{
    public partial class Login : Form
    {
        public enum Status { OK, Failed};

        private static Login Instance = null;

        public delegate void LoginEventHandler(object sender, Events.LoginEventArgs evt);
        private Login()
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();
        }

        public static Login GetInstance()
        {
            if (Instance == null) Instance = new Login();
            return Instance;
        }

        public event LoginEventHandler LoginEvent;

        private void loginBtn_Click(object sender, EventArgs e)
        {
            //Hide();
            //FBTool fbTool = new FBTool();
            //fbTool.Show();
            LoginEvent?.Invoke(this, new Events.LoginEventArgs(Status.OK));
        }

        private void signupLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Signup signupForm = new Signup();
            signupForm.Show();
        }
    }
}
