using CefSharp;
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




namespace FBTool
{
    public partial class FBToolForm : Form
    {
        private DataTable users;
        private List<DataGridViewRow> selectedRows = new List<DataGridViewRow>();
        private int usersTotalNum = 0;
        private int usersSelectedNum = 0;

        public FBToolForm()
        {
            InitializeComponent();
            InitUserTableView();

        }

        private void InitUserTableView()
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

            UserDataTableView.DataSource = users;
            UserTableInfo.Text = $"(Tổng {usersTotalNum} hàng, đã chọn {usersSelectedNum})";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void OpenFileMenuItem_Click(object sender, EventArgs e)
        {
            //
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

                            WriteLog("Đã import data xong.");
                            usersTotalNum = users.Rows.Count;
                            UserTableInfo.Text = $"(Tổng {usersTotalNum} hàng, đã chọn {usersSelectedNum})";
                        }

                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message); 
                    }
                }
            }
        }

        private void WriteLog(string msg)
        {
            string logs = LogViewer.Text;
            LogViewer.Text = logs + $"\r\n[{DateTime.Now.ToString()}] {msg}";
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (users.Rows.Count == 0) return;

            int maxWindowNum = (int)MaxWindowNum.Value;
            int currentWindowNum = 0;
            int delayTime = (int)TimeDelay.Value*1000;
            int loginSucceed = 0;
            if (maxWindowNum > users.Rows.Count) maxWindowNum = users.Rows.Count;

            List<Task<FBLoginResultModel>> loginTasks = new List<Task<FBLoginResultModel>>();

            Func<int, FBLoginResultModel, FBLoginResultModel> handler = null;

            for (int i = 0; i < maxWindowNum; i++)
            {
                if (i > 0)
                {
                    await Task.Delay(delayTime);
                }

                currentWindowNum += 1;

                DataRow row = users.Rows[i];
                string username = row["UserName"].ToString();
                string pass = row["PassWord"].ToString();

                BrowserFBWindow browser = new BrowserFBWindow(true);
                browser.Show();

                row["Status"] = "Đang lấy cookie ...";
                //
                Task<FBLoginResultModel> loginTask = browser.FBLoginAndGetCookie(i, username, pass, handler = (id, cookie) =>
                {
                    loginSucceed++;
                    users.Rows[id]["Status"] = (cookie.Status==1)?"Thành công":(cookie.Status==0)?"Thất bại":"Checkpoint";
                    users.Rows[id]["Message"] = cookie.Message;
                    users.Rows[id]["Cookie"] = cookie.Cookie;
                    users.Rows[id]["UID"] = cookie.UID;
                    TasksProgress.Value = (int)(100 * loginSucceed / usersTotalNum);
                    //
                    if (currentWindowNum < users.Rows.Count)
                    {
                        BrowserFBWindow browser1 = new BrowserFBWindow(true);
                        browser1.Show();
                        currentWindowNum += 1;
                        users.Rows[currentWindowNum - 1]["Status"] = "Đang lấy cookie ...";
                        string username1 = users.Rows[currentWindowNum - 1]["UserName"].ToString();
                        string pass1 = users.Rows[currentWindowNum - 1]["PassWord"].ToString();
                        Task<FBLoginResultModel> loginTask1 = browser1.FBLoginAndGetCookie(currentWindowNum - 1, username1, pass1, handler);
                        loginTasks.Add(loginTask1);
                    }
                    //
                    return cookie;
                });

                loginTasks.Add(loginTask);
            }
            //

            //for (int i = 0; i < users.Rows.Count; i++)
            //{
            //    if (i > 0)
            //    {
            //        await Task.Delay(delayTime);
            //    }

            //    DataRow row = users.Rows[i];
            //    string username = row["UserName"].ToString();
            //    string pass = row["PassWord"].ToString();

            //    BrowserWindow browser = new BrowserWindow(true);
            //    browser.Show();

            //    row["Status"] = "Đang lấy cookie ...";
            //    //
            //    Task<string> loginTask = browser.FBLoginAndGetCookie(username, pass, cookie =>
            //    {
            //        row["Status"] = "Đã lấy xong cookie.";
            //        row["Cookie"] = cookie;
            //        loginSucceeded += 1;
            //        TasksProgress.Value = (int)(100 * loginSucceeded / usersTotalNum);
            //        return cookie;
            //    });

            //    loginTasks.Add(loginTask);
            //}
            WriteLog("Đang tự động đăng nhập lấy cookie...");

            await Task.WhenAll(loginTasks);
            TasksProgress.Value = 0;

            WriteLog("Đã lấy xong cookie.");
        }

        private void EditStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoginStripButton_Click(object sender, EventArgs e)
        {
            if(selectedRows.Count>0)
            {
                for (int i = 0; i < selectedRows.Count; i++)
                {
                    BrowserFBWindow browser = new BrowserFBWindow(true);
                    browser.Show();
                    string cookieStr = selectedRows.ElementAt(i).Cells[3].Value.ToString();
                    Task loginWithCookie = browser.LoginWithCookie(cookieStr);
                }
            }
            else
            {
                
            }
        }

        private void userDataTableView_SelectionChanged(object sender, EventArgs e)
        {
            int selectedRowCount = UserDataTableView.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                selectedRows.Clear();
                for (int i = 0; i < selectedRowCount; i++)
                {
                    DataGridViewRow selectedRow = UserDataTableView.Rows[UserDataTableView.SelectedRows[i].Index];
                    selectedRows.Add(selectedRow);
                }
            }
            usersSelectedNum = selectedRowCount;
            UserTableInfo.Text = $"(Tổng {usersTotalNum} hàng, đã chọn {usersSelectedNum})";
        }

        private void ClearLogStripButton_Click(object sender, EventArgs e)
        {
            LogViewer.Clear();
        }

        private void SaveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //
            //SaveFileDialog folderDialog = new SaveFileDialog();
            //folderDialog.InitialDirectory = @"C:\";      
            //folderDialog.Title = "Save text Files";
            //folderDialog.CheckFileExists = true;
            //folderDialog.CheckPathExists = true;
            //folderDialog.DefaultExt = "txt";
            //folderDialog.Filter = "txt files (*.txt)|*.txt";
            //folderDialog.FilterIndex = 1;
            //folderDialog.RestoreDirectory = true;

            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string selectedPath = fbd.SelectedPath;

                string savedTime = DateTime.Now.ToString("yyMMddHHmmss");

                string pathOK = Path.Combine(selectedPath,$"{savedTime}_OK.txt");
                string pathFailed = Path.Combine(selectedPath, $"{savedTime}_Failed.txt");

                StreamWriter fileWriterOk = new StreamWriter(pathOK);
                StreamWriter fileWriterFailed = new StreamWriter(pathFailed);
                

                for (int i = 0; i < UserDataTableView.Rows.Count; i++)
                {
                    DataGridViewRow row = UserDataTableView.Rows[i];

                    string username = "";
                    string password = "";
                    string cookie = "";
                    string uid = "";
                    string message = "";

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

                    if ((row.Cells[5].Value != DBNull.Value) && (row.Cells[5].Value != null))
                    {
                        message = row.Cells[5].Value.ToString();
                    }

                    if (uid.Length > 0)
                    {
                        string line = $"{uid}|{password}|{cookie}";
                        fileWriterOk.WriteLine(line);
                    }
                    else
                    {
                        string line = $"{username}|{password}|{message}";
                        fileWriterFailed.WriteLine(line);
                    }
                }
                WriteLog($"Lưu tệp lấy thành công ({pathOK})");
                fileWriterOk.Close();
                WriteLog($"Lưu tệp lấy thất bại ({pathFailed})");
                fileWriterFailed.Close();
            }
        }

        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            string msg = "+FB Cookie Tool (v1.0)\n+NangNgo";
            string title = "Thông tin";
            MessageBox.Show(msg, title);
        }

        private void userDataTableView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int selectedCellCount = UserDataTableView.GetCellCount(DataGridViewElementStates.Selected);
            PropertyLayout.Controls.Clear();

            //if (selectedCellCount > 0)
            //{
            //    for (int i = 0; i < selectedCellCount; i++)
            //    {
            //        int rowIndex = UserDataTableView.SelectedCells[i].RowIndex;
            //        int cellIndex = UserDataTableView.SelectedCells[i].ColumnIndex;
            //
            //        Label cellName = new Label();
            //        cellName.Text = UserDataTableView.Columns[cellIndex].Name;
            //        PropertyLayout.Controls.Add(cellName);
            //        Label cellValue = new Label();
            //        cellValue.Text = UserDataTableView.Rows[rowIndex].Cells[cellIndex].Value.ToString();
            //        PropertyLayout.Controls.Add(cellValue);
            //    }
            //}
            
        }

        private void LoginStripButton_1_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("login fb with username");
        }
    }
}
