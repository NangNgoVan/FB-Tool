using FBTool.CustomEventArgs;
using FBTool.Events;
using FBTool.Models;
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
using System.Timers;
using System.Windows.Forms;

namespace FBTool.Forms
{
    public partial class FBTool : Form
    {
        public enum LoginStatus {
            SUCCESS,
            CHECKPOINT,
            FAILED
        };

        public delegate void LogoutEventHandler(object sender, EventArgs evt);
        public event LogoutEventHandler LogoutEvent;

        private DataTable users;
        private List<DataGridViewRow> selectedRows = new List<DataGridViewRow>();
        private ContextMenu getFbCookieCtxMenu;

        private Log logWindow;

        private bool loginProcessIsRunning = false;

        public FBTool()
        {
            WindowState = FormWindowState.Maximized;
            InitializeComponent();
            CreateFBAccountsGridView();
            CreateFBGetCookieContextMenu();
            CreateFilterResult();
        }

        public void SetExpriedDate(DateTime? expriedDate)
        {
            string expriedStr = "Invalid!";
            if (expriedDate.HasValue) expriedStr = $"Ngày hết hạn: {expriedDate.Value.ToShortDateString()} {expriedDate.Value.ToShortTimeString()}";
            expriedTimeStripStatusLabel.Text = expriedStr;
        }

        private void CreateFilterResult()
        {
            filterResult.Items.Add("----All----");
            filterResult.SelectedIndex = 0;
            foreach (string status in Enum.GetNames(typeof(LoginStatus)))
            {
                filterResult.Items.Add(status);
            }

            filterResult.SelectedIndexChanged += (sender, args) =>
            {
                ToolStripComboBox comboBox = (ToolStripComboBox)sender;
                int statusIndex = comboBox.SelectedIndex-1;
                string status = (string)comboBox.SelectedItem;
                BindingSource bs = new BindingSource();
                bs.DataSource = fbAccountsGridView.DataSource;

                if (statusIndex == (int)LoginStatus.SUCCESS
                    || statusIndex == (int)LoginStatus.CHECKPOINT
                    || statusIndex == (int)LoginStatus.FAILED
                )
                {
                    
                    bs.Filter = "Status like '%" + status + "%'";
                    
                }
                else
                {
                    bs.Filter = null;
                }
                fbAccountsGridView.DataSource = bs;
            };
        }
        private void CreateFBAccountsGridView()
        {
            users = new DataTable("Users");

            DataColumn userNameCol = new DataColumn();
            userNameCol.DataType = System.Type.GetType("System.String");
            userNameCol.ColumnName = "UserName";
            users.Columns.Add(userNameCol);

            DataColumn passWordCol = new DataColumn();
            passWordCol.DataType = System.Type.GetType("System.String");
            passWordCol.ColumnName = "PassWord";
            users.Columns.Add(passWordCol);

            DataColumn uIDCol = new DataColumn();
            uIDCol.DataType = System.Type.GetType("System.String");
            uIDCol.ColumnName = "UID";
            users.Columns.Add(uIDCol);

            DataColumn createdDateCol = new DataColumn();
            createdDateCol.DataType = Type.GetType("System.String");
            createdDateCol.ColumnName = "CreatedDate";
            users.Columns.Add(createdDateCol);

            DataColumn cookieCol = new DataColumn();
            cookieCol.DataType = System.Type.GetType("System.String");
            cookieCol.ColumnName = "Cookie";
            users.Columns.Add(cookieCol);

            DataColumn statusCol = new DataColumn();
            statusCol.DataType = System.Type.GetType("System.String");
            statusCol.ColumnName = "Status";
            //statusCol.ReadOnly = true;
            users.Columns.Add(statusCol);

            DataColumn resultCol = new DataColumn();
            resultCol.DataType = System.Type.GetType("System.String");
            resultCol.ColumnName = "Message";
            users.Columns.Add(resultCol);

            DataColumn proxyCol = new DataColumn();
            proxyCol.DataType = Type.GetType("System.String");
            proxyCol.ColumnName = "Proxy";
            users.Columns.Add(proxyCol);

            fbAccountsGridView.DataBindingComplete += (o, e) =>
            {
                 foreach (DataGridViewRow row in fbAccountsGridView.Rows)
                     row.HeaderCell.Value = (row.Index + 1).ToString();
            };

            fbAccountsGridView.DataSource = users;
        }

        private void CreateFBGetCookieContextMenu()
        {
            getFbCookieCtxMenu = new ContextMenu();
            getFbCookieCtxMenu.MenuItems.Add(new MenuItem("Đăng nhập bằng {user|pass}", onLoginFbWithUsername));
            getFbCookieCtxMenu.MenuItems.Add("Đăng nhập bằng cookie", onLoginFbWithCookie);
            getFbCookieCtxMenu.MenuItems.Add("Lưu toàn bộ", OnSaveAllFbAccTableToFile);
            getFbCookieCtxMenu.MenuItems.Add("Lưu dưới dạng {uid|cookie}");
            getFbCookieCtxMenu.MenuItems.Add("Lưu dưới dạng {user|pass|status}");
        }
        private void WriteLog(string message)
        {
            string currentTime = DateTime.Now.ToString();
            string logMsg = $"[{currentTime}] {message}\n";
            logViewer.AppendText(logMsg);
        }
        private void FBTool_Load(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About aboutBox = new About();
            aboutBox.SetActivationState(true, expriedTimeStripStatusLabel.Text);
            aboutBox.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogoutEvent?.Invoke(this, new EventArgs());
        }

        private void importToolStripButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.InitialDirectory = "c:\\";
                fileDialog.Filter = "txt files (*.txt)|*.txt";
                fileDialog.FilterIndex = 1;
                fileDialog.RestoreDirectory = true;

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    //String filePath = fileDialog.FileName;
                    var fileStream = fileDialog.OpenFile();

                    users.Clear();

                    try
                    {
                        using (StreamReader fileReader = new StreamReader(fileStream))
                        {
                            string line;
                            DataRow newRow;

                            //WriteLog("Đang import data...");

                            while ((line = fileReader.ReadLine()) != null)
                            {
                                string[] lineSplited = line.Split('|');

                                string username = "";
                                string password = "";
                                string cookie = "";

                                if (lineSplited.Length >= 2)
                                {
                                    if (lineSplited.Length == 2)
                                    {
                                        username = lineSplited[0];
                                        password = lineSplited[1];
                                    }
                                    if (lineSplited.Length == 3)
                                    {
                                        username = lineSplited[0];
                                        password = lineSplited[1];
                                        cookie = lineSplited[2];
                                    }
                                    newRow = users.NewRow();
                                    newRow["UserName"] = username;
                                    newRow["PassWord"] = password;
                                    newRow["Cookie"] = cookie;
                                    users.Rows.Add(newRow);
                                }
                                else
                                {

                                }

                            }
                            //WriteLog("Đã import data xong.");
                            //usersTotalNum = users.Rows.Count;
                            //UserTableInfo.Text = $"(Tổng {usersTotalNum} hàng, đã chọn {usersSelectedNum})";
                        }

                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }
                }
            }
        }

        private void configToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void activeKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActiveKey activeKeyForm = new ActiveKey();
            activeKeyForm.SetLicenseManager(Services.LicenseManager.GetInstance());
            activeKeyForm.ActiveToolEvent += OnReactiveLicenseEvent;
            activeKeyForm.Show();
        }

        private void fbAccountsGridView_CellMouseUp(object sender, DataGridViewCellMouseEventArgs evt)
        {
            if (evt.Button == MouseButtons.Right)
            {
                if (selectedRows.Count > 0)
                {
                    var pos = ((DataGridView)sender)
                    .GetCellDisplayRectangle(evt.ColumnIndex, evt.RowIndex, false)
                    .Location;
                    pos.X += evt.X;
                    pos.Y += evt.Y;
                    getFbCookieCtxMenu.Show((DataGridView)sender, pos);
                }
            }
        }

        private void OnReactiveLicenseEvent(object sender, ActiveEventArgs evt)
        {
            if (evt.Status == ActiveKey.Status.OK)
            {
                // reactive license
                MessageBox.Show("Thành công!");
                ((Form)sender).Close();
                SetExpriedDate(evt.ExpriedDate);
            }
            else if (evt.Status == ActiveKey.Status.FAILED)
            {
                // failed
            }
        }

        private void fbAccountsGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //selectedRows.Clear();
        }

        private void getCookieSettingStripBtn_Click(object sender, EventArgs e)
        {
            //AutoFBLoginConfig settingForm = new AutoFBLoginConfig();
            //settingForm.Show();
        }

        private void fbAccountsGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (loginProcessIsRunning) return;

            int selectedRowCount = fbAccountsGridView.Rows.GetRowCount(DataGridViewElementStates.Selected);
            selectedRows.Clear();
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {
                    DataGridViewRow selectedRow = fbAccountsGridView.Rows[fbAccountsGridView.SelectedRows[i].Index];
                    selectedRows.Add(selectedRow);
                }
            }
            else
            {
                selectedRows.Clear();
            }
        }

        private async void onLoginFbWithUsername(object sender, EventArgs e)
        {
            loginFbWithUsername();   
        }
        private void loginFbWithUsername()
        {
            List<Task<FBLoginResultModel>> loginTasks = new List<Task<FBLoginResultModel>>();
            AutoFBLoginConfig configForm = new AutoFBLoginConfig();
            AutoFBLoginConfig.FBLoginConfigEventHandler fbLoginHandler = async (object fbCfgFormObj, FBLoginConfigEventArgs evt) =>
            {
                ((AutoFBLoginConfig)fbCfgFormObj).Close();
                if (evt.Status == AutoFBLoginConfig.State.OK)
                {
                    loginProcessIsRunning = true;
                    int maxWindowNum = evt.MaxFBBrowserNum;
                    int currentWindowNum = 0;
                    int delayTime = evt.TimeFBLoginDelay * 1000;
                    int loginSucceed = 0;
                    if (maxWindowNum > selectedRows.Count) maxWindowNum = selectedRows.Count;
                    //set proxy
                    int proxyIndex = 0;
                    int proxyNum = evt.Proxies.Count;
                    WriteLog("Set địa chỉ proxy (nếu có).");
                    foreach (DataGridViewRow row in selectedRows)
                    {
                        if (evt.UseProxy)
                        {
                            row.Cells[6].Value = evt.Proxies[proxyIndex % proxyNum];
                            proxyIndex += 1;
                        }
                        else row.Cells[6].Value = "";
                    }

                    Func<object, int, FBLoginResultModel, FBLoginResultModel> handler = null;

                    WriteLog("Đang tiến hành thu thập cookie...");

                    for (int i = 0; i < maxWindowNum; i++)
                    {
                        currentWindowNum += 1;

                        if ((evt.NetworkResetAfter > 0) && (currentWindowNum % evt.NetworkResetAfter == 0))
                        {
                            resetIPProcess();
                        }
                        if (i > 0)
                        {
                            await Task.Delay(delayTime);
                        }

                        DataGridViewRow row = selectedRows[i];
                        string username = row.Cells[0].Value?.ToString();
                        string pass = row.Cells[1].Value?.ToString();


                        FBBrowser browser = new FBBrowser(true);
                        browser.Show();

                        if (evt.UseProxy)
                        {
                            string proxyUrl = row.Cells[7].Value.ToString();
                            if (proxyUrl.Length > 0)
                            {
                                bool setProxy = await browser.SetProxy(proxyUrl);
                            }

                        }

                        row.Cells[5].Value = "Đang lấy cookie ...";
                        WriteLog($"Đang lấy cookie tài khoản: {username}");
                        //
                        Task<FBLoginResultModel> loginTask = browser.FBLoginAndGetCookie(i, username, pass, handler = (obj, id, cookie) =>
                        {
                            loginSucceed++;
                            selectedRows[id].Cells[5].Value = (cookie.Status == 1) ?
                                LoginStatus.SUCCESS.ToString() : (cookie.Status == 0)
                                ? LoginStatus.FAILED.ToString() : LoginStatus.CHECKPOINT.ToString();
                            selectedRows[id].Cells[6].Value = cookie.Message;
                            selectedRows[id].Cells[4].Value = cookie.Cookie;
                            selectedRows[id].Cells[3].Value = cookie.CreatedDate;
                            selectedRows[id].Cells[2].Value = cookie.UID;
                            //TasksProgress.Value = (int)(100 * loginSucceed / usersTotalNum);
                            //
                            if (currentWindowNum < selectedRows.Count)
                            {
                                currentWindowNum += 1;
                                if ((evt.NetworkResetAfter > 0) && (currentWindowNum % evt.NetworkResetAfter == 0))
                                {
                                    resetIPProcess();
                                }

                                FBBrowser browser1 = new FBBrowser(true);
                                browser1.Show();

                                selectedRows[currentWindowNum - 1].Cells[5].Value = "Đang lấy cookie ...";

                                string username1 = selectedRows[currentWindowNum - 1].Cells[0].Value?.ToString();
                                string pass1 = selectedRows[currentWindowNum - 1].Cells[1].Value?.ToString();

                                //Debug.WriteLine(username1 + " " + pass1);
                                WriteLog($"Đang lấy cookie tài khoản: {username1}");

                                Task<FBLoginResultModel> loginTask1 = browser1.FBLoginAndGetCookie(currentWindowNum - 1, username1, pass1, handler);
                                loginTasks.Add(loginTask1);
                            }
                            //
                            return cookie;
                        });

                        loginTasks.Add(loginTask);
                    }
                    await Task.WhenAll(loginTasks);
                    WriteLog("Đã lấy xong cookie.");
                    loginProcessIsRunning = false;
                }
            };
            configForm.FbLoginConfigEvent += fbLoginHandler;
            configForm.Show();
        }
        private void resetIPProcess()
        {
            // reset network
            //Debug.WriteLine("Reset network started...");
            WriteLog("Đang reset địa chỉ IP...");
            Process releaseIpProcess = Process.Start("ipconfig", "/release");
            releaseIpProcess.WaitForExit();
            Process renewIpProcess = Process.Start("ipconfig", "/renew");
            renewIpProcess.WaitForExit();
            //Debug.WriteLine("Đã reset địa chỉ IP xong.");
            WriteLog("Đã reset địa chỉ IP xong.");
            //
        }
        private async void onLoginFbWithCookie(object sender, EventArgs e)
        {
            loginFbWithCookie();
        }
        private void loginFbWithCookie()
        {
            AutoFBLoginConfig configForm = new AutoFBLoginConfig();
            AutoFBLoginConfig.FBLoginConfigEventHandler fbLoginHandler = async (object fbCfgFormObj, FBLoginConfigEventArgs evt) =>
            {
                ((AutoFBLoginConfig)fbCfgFormObj).Close();
                if (evt.Status == AutoFBLoginConfig.State.OK)
                {
                    int maxWindowNum = evt.MaxFBBrowserNum;
                    int delayTime = evt.TimeFBLoginDelay * 1000;
                    if (maxWindowNum > selectedRows.Count) maxWindowNum = selectedRows.Count;
                    List<Task<FBLoginResultModel>> loginTasks = new List<Task<FBLoginResultModel>>();

                    if (evt.UseProxy)
                    {//set proxy
                        int proxyIndex = 0;
                        int proxyNum = evt.Proxies.Count;
                        WriteLog("Set địa chỉ proxy (nếu có).");
                        foreach (DataGridViewRow row in selectedRows)
                        {

                            row.Cells[6].Value = evt.Proxies[proxyIndex % proxyNum];
                            proxyIndex += 1;
                        }
                    }
                    for (int i = 0; i < selectedRows.Count; i++)
                    {
                        string cookieStr = selectedRows.ElementAt(i).Cells[4].Value?.ToString();
                        if ((cookieStr != null) && (cookieStr.Length > 0))
                        {
                            BrowserFBWindow browser = new BrowserFBWindow(true);
                            browser.Show();
                            WriteLog($"Đăng nhập bằng cookie: {cookieStr}.");
                            Task loginWithCookie = browser.LoginWithCookie(cookieStr);
                        }
                        else
                        {
                            WriteLog($"Không thể đăng nhập bằng cookie (trống).");
                        }
                    }
                }
            };
            configForm.FbLoginConfigEvent += fbLoginHandler;
            configForm.Show();
        }

        private void OnSaveAllFbAccTableToFile(object sender, EventArgs evt)
        {
            if (fbAccountsGridView.Rows.Count == 0) return;
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string selectedPath = fbd.SelectedPath;

                string savedTime = DateTime.Now.ToString("yyMMddHHmmss");

                string pathOK = Path.Combine(selectedPath, $"{savedTime}_All.txt");
                
                StreamWriter fileWriterOk = new StreamWriter(pathOK);

                for (int i = 0; i < fbAccountsGridView.Rows.Count; i++)
                {
                    DataGridViewRow row = fbAccountsGridView.Rows[i];

                    string username = "";
                    string password = "";
                    string cookie = "";
                    string uid = "";
                    string status = "";
                    string message = "";
                    string proxy = "";

                    if ((row.Cells[0].Value != DBNull.Value) && (row.Cells[0].Value != null))
                    {
                        username = row.Cells[0].Value.ToString();
                    }

                    if ((row.Cells[1].Value != DBNull.Value) && (row.Cells[1].Value != null))
                    {
                        password = row.Cells[1].Value.ToString();
                    }

                    if ((row.Cells[2].Value != DBNull.Value) && (row.Cells[2].Value != null))
                    {
                        uid = row.Cells[2].Value.ToString();
                    }

                    if ((row.Cells[3].Value != DBNull.Value) && (row.Cells[3].Value != null))
                    {
                        cookie = row.Cells[3].Value.ToString();
                    }

                    if ((row.Cells[4].Value != DBNull.Value) && (row.Cells[4].Value != null))
                    {
                        status = row.Cells[4].Value.ToString();
                    }

                    if ((row.Cells[5].Value != DBNull.Value) && (row.Cells[5].Value != null))
                    {
                        message = row.Cells[5].Value.ToString();
                    }

                    if ((row.Cells[6].Value != DBNull.Value) && (row.Cells[6].Value != null))
                    {
                        proxy = row.Cells[6].Value.ToString();
                    }

                    fileWriterOk.WriteLine($"{username}|{password}|{uid}|{cookie}|{status}|{message}|{proxy}");
                }
                fileWriterOk.Close();
                WriteLog($"Lưu vào file: {pathOK}");
            }
        }

        private void importUserPassMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.InitialDirectory = "c:\\";
                fileDialog.Filter = "txt files (*.txt)|*.txt";
                fileDialog.FilterIndex = 1;
                fileDialog.RestoreDirectory = true;

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    //String filePath = fileDialog.FileName;
                    var fileStream = fileDialog.OpenFile();

                    users.Clear();
                    
                    try
                    {
                        using (StreamReader fileReader = new StreamReader(fileStream))
                        {
                            string line;
                            DataRow newRow;

                            WriteLog("Đang import data...");

                            while ((line = fileReader.ReadLine()) != null)
                            {
                                string[] lineSplited = line.Split('|');

                                string username = "";
                                string password = "";
                                string message = "";

                                if (lineSplited.Length >= 2)
                                {
                                    if (lineSplited.Length == 2)
                                    {
                                        username = lineSplited[0];
                                        password = lineSplited[1];
                                    }
                                    if (lineSplited.Length == 3)
                                    {
                                        username = lineSplited[0];
                                        password = lineSplited[1];
                                        message = lineSplited[2];
                                    }
                                    newRow = users.NewRow();
                                    newRow["UserName"] = username;
                                    newRow["PassWord"] = password;
                                    newRow["Cookie"] = message;
                                    users.Rows.Add(newRow);
                                }
                                else
                                {

                                }

                            }
                            WriteLog("Đã import data xong.");
                            //usersTotalNum = users.Rows.Count;
                            //UserTableInfo.Text = $"(Tổng {usersTotalNum} hàng, đã chọn {usersSelectedNum})";
                        }

                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }
                }
            }
        }

        private void clearFbAccountGripViewToolStripButton_Click(object sender, EventArgs e)
        {
            DialogResult clearConfirm = MessageBox.Show("Xóa dữ liệu trên bảng?", 
                "Xóa", MessageBoxButtons.YesNo);
            if (clearConfirm == DialogResult.Yes)
            {
                users.Clear();
            }
        }

        private void showLogStripBtn_Click(object sender, EventArgs e)
        {
            bool logPanelCollapsed = splitContainer1.Panel2Collapsed;
            if (logPanelCollapsed)
            {
                splitContainer1.Panel2Collapsed = false;
                splitContainer1.Panel2.Show();
            }
            else
            {
                splitContainer1.Panel2Collapsed = true;
                splitContainer1.Panel2.Hide();
            }
        }

        private void loginFBWithUsernameBtn_Click(object sender, EventArgs e)
        {
            fbAccountsGridView.SelectAll();
            loginFbWithUsername();
        }

        private void loginFBWithCookieBtn_Click(object sender, EventArgs e)
        {
            fbAccountsGridView.SelectAll();
            loginFbWithCookie();
        }

        private void importUIDCookieToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
