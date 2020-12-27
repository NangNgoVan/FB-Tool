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
    public partial class Log : Form
    {
        public Log()
        {
            InitializeComponent();
        }
        public void LoadLog(string[] messages)
        {
            for (int i = 0; i < messages.Length; i++)
                logList.AppendText($"{messages[i]}\n");
        }

        private void clearLogBtn_Click(object sender, EventArgs e)
        {
            logList.Clear();
        }
    }
}
