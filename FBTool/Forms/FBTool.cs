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
using System.Windows.Forms;

namespace FBTool.Forms
{
    public partial class FBTool : Form
    {
        public enum LoginStatus { SUCCESS, CHECKPOINT, FAILED};

        public delegate void LogoutEventHandler(object sender, EventArgs evt);
        public event LogoutEventHandler LogoutEvent;

        private DataTable users;
        private List<DataGridViewRow> selectedRows = new List<DataGridViewRow>();
        private ContextMenu getFbCookieCtxMenu;

        public FBTool()
        {
            WindowState = FormWindowState.Maximized;
            InitializeComponent();
            CreateFBAccountsGridView();
            CreateFBGetCookieContextMenu();
            CreateFilterResult();
        }

        private void CreateFilterResult()
        {
            filterResult.Items.Add("---All---");
            filterResult.SelectedIndex = 0;
            foreach (string status in Enum.GetNames(typeof(LoginStatus)))
            {
                filterResult.Items.Add(status);
            }
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

            fbAccountsGridView.DataSource = users;
        }

        private void CreateFBGetCookieContextMenu()
        {
            getFbCookieCtxMenu = new ContextMenu();
            getFbCookieCtxMenu.MenuItems.Add(new MenuItem("Đăng nhập bằng {user|pass}", onLoginFbWithUsername));
            getFbCookieCtxMenu.MenuItems.Add("Đăng nhập bằng cookie", onLoginFbWithCookie);
            getFbCookieCtxMenu.MenuItems.Add("Lưu toàn bộ");
            getFbCookieCtxMenu.MenuItems.Add("Lưu dưới dạng {uid|cookie}");
            getFbCookieCtxMenu.MenuItems.Add("Lưu dưới dạng {user|pass|status}");
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

        private async void getCookieToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void configToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void editAccountToolStripMenuItem_Click(object sender, EventArgs e)
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
        }

        private async void onLoginFbWithUsername(object sender, EventArgs e)
        {
            AutoFBLoginConfig configForm = new AutoFBLoginConfig();
            
            AutoFBLoginConfig.FBLoginConfigEventHandler fbLoginHandler = async (object fbCfgFormObj, FBLoginConfigEventArgs evt) =>
            {
                ((AutoFBLoginConfig)fbCfgFormObj).Close();
                if (evt.Status == AutoFBLoginConfig.State.OK)
                {
                    int maxWindowNum = evt.MaxFBBrowserNum;
                    int currentWindowNum = 0;
                    int delayTime = evt.TimeFBLoginDelay * 1000;
                    int loginSucceed = 0;
                    if (maxWindowNum > selectedRows.Count) maxWindowNum = selectedRows.Count;
                    List<Task<FBLoginResultModel>> loginTasks = new List<Task<FBLoginResultModel>>();

                    //set proxy
                    int proxyIndex = 0;
                    int proxyNum = evt.Proxies.Count;
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
                    for (int i = 0; i < maxWindowNum; i++)
                    {
                        if (i > 0)
                        {
                            await Task.Delay(delayTime);
                        }

                        currentWindowNum += 1;

                        DataGridViewRow row = selectedRows[i];
                        string username = row.Cells[0].Value.ToString();
                        string pass = row.Cells[1].Value.ToString();


                        FBBrowser browser = new FBBrowser(true);
                        browser.Show();

                        if (evt.UseProxy)
                        {
                            string proxyUrl = row.Cells[6].Value.ToString();
                            if (proxyUrl.Length > 0)
                            {
                                bool setProxy = await browser.SetProxy(proxyUrl);
                            }

                        }

                        row.Cells[4].Value = "Đang lấy cookie ...";
                        //
                        Task<FBLoginResultModel> loginTask = browser.FBLoginAndGetCookie(i, username, pass, handler = (obj, id, cookie) =>
                        {
                            loginSucceed++;
                            selectedRows[id].Cells[4].Value = (cookie.Status == 1) ? 
                                LoginStatus.SUCCESS.ToString() : (cookie.Status == 0) 
                                ? LoginStatus.FAILED.ToString() : LoginStatus.CHECKPOINT.ToString();
                            selectedRows[id].Cells[5].Value = cookie.Message;
                            selectedRows[id].Cells[3].Value = cookie.Cookie;
                            selectedRows[id].Cells[2].Value = cookie.UID;
                            //TasksProgress.Value = (int)(100 * loginSucceed / usersTotalNum);
                            //
                            if (currentWindowNum < selectedRows.Count)
                            {
                                FBBrowser browser1 = new FBBrowser(true);
                                browser1.Show();
                                currentWindowNum += 1;
                                selectedRows[currentWindowNum - 1].Cells[4].Value = "Đang lấy cookie ...";
                                string username1 = selectedRows[currentWindowNum - 1].Cells[0].Value.ToString();
                                string pass1 = selectedRows[currentWindowNum - 1].Cells[1].Value.ToString();
                                Debug.WriteLine(username1 + " " + pass1);
                                Task<FBLoginResultModel> loginTask1 = browser1.FBLoginAndGetCookie(currentWindowNum - 1, username1, pass1, handler);
                                loginTasks.Add(loginTask1);
                            }
                            //
                            return cookie;
                        });

                        loginTasks.Add(loginTask);
                    }
                }
            };
            configForm.FbLoginConfigEvent += fbLoginHandler;
            configForm.Show();
        }
        private async void onLoginFbWithCookie(object sender, EventArgs e)
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
                        foreach (DataGridViewRow row in selectedRows)
                        {

                            row.Cells[6].Value = evt.Proxies[proxyIndex % proxyNum];
                            proxyIndex += 1;
                        }
                    }
                    for (int i = 0; i < selectedRows.Count; i++)
                    {
                        BrowserFBWindow browser = new BrowserFBWindow(true);
                        browser.Show();
                        string cookieStr = selectedRows.ElementAt(i).Cells[3].Value.ToString();
                        if (cookieStr.Length > 0)
                        {
                            Task loginWithCookie = browser.LoginWithCookie(cookieStr);
                        }
                    }
                }
            };
            configForm.FbLoginConfigEvent += fbLoginHandler;
            configForm.Show();  
        }
    }
}
