using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using System.Diagnostics;
using FBTool.Models;

namespace FBTool
{
    public partial class BrowserFBWindow : Form
    {
        private string FB_URL = "https://www.facebook.com/";
        public ChromiumWebBrowser chromeBrowser;
        public BrowserFBWindow(bool icogino = false)
        {
            InitializeComponent();
            InitBrowser(icogino);
        }

        public void InitBrowser(bool icogino)
        {
            if (!Cef.IsInitialized)
            {
                CefSettings settings = new CefSettings();
                Cef.Initialize(settings);
            }
            chromeBrowser = new ChromiumWebBrowser("");
            //
            if (icogino)
            {
                RequestContextSettings requestContextSettings = new RequestContextSettings();

                requestContextSettings.PersistSessionCookies = false;
                requestContextSettings.PersistUserPreferences = false;
                requestContextSettings.CachePath = "";

                chromeBrowser.RequestContext = new RequestContext(requestContextSettings);
            }

            Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;
            //chromeBrowser.ExecuteScriptAsyncWhenPageLoaded("alert('All Resources Have Loaded');", false);
        }

        public async Task<FBLoginResultModel> FBLoginAndGetCookie(int id, string username, string pass, Func<int, FBLoginResultModel, FBLoginResultModel> callback = null)
        {
            string cookie = null;

            bool loadLoginPage = await LoadPageAsync(FB_URL);

            string jsCode = $"var u=document.getElementById('email');u.value='{username}';var p=document.getElementById('pass');p.value='{pass}';var btn=document.getElementsByName('login')[0];btn.click();";
            bool login = await ExecuteJS(jsCode);
            //chromeBrowser.ExecuteScriptAsyncWhenPageLoaded(jsCode);

            string checkLoginSucceedJsCode = "var e=document.getElementsByClassName('_9ay7')[0];var e1=document.getElementById('error_box');var str='error=';if(e!=undefined){str+=e.textContent;};if(e1!=undefined){str+='+'+e1.textContent;};document.cookie=str;";
            //bool checkIsSucceeded = await ExecuteJS(checkLoginSucceedJsCode);
            chromeBrowser.ExecuteScriptAsync(checkLoginSucceedJsCode);

            await Task.Delay(5000);

            List<Cookie> cookies = await chromeBrowser.GetCookieManager().VisitAllCookiesAsync();

            List<string> cookieArr = new List<string>();

            string cUser = "";
            string xs = "";
            string error = "";
            int isCheckpoint = 0;
           
            for (int i = 0; i < cookies.Count; i++)
            {
                if ((cookies.ElementAt(i).Name == "c_user")) cUser = cookies.ElementAt(i).Value;
                if ((cookies.ElementAt(i).Name == "xs")) xs = cookies.ElementAt(i).Value;
                if ((cookies.ElementAt(i).Name == "error")) error += cookies.ElementAt(i).Value;
                if ((cookies.ElementAt(i).Name == "checkpoint"))
                {
                    error += "Tài khoản bị Checkpoint.";
                    isCheckpoint = 2;
                }

                if (cookies.ElementAt(i).Domain == ".facebook.com")
                    cookieArr.Add($"{cookies.ElementAt(i).Name}={cookies.ElementAt(i).Value}");
            }

            FBLoginResultModel value = new FBLoginResultModel();

            if ((cUser.Length==0) && (xs.Length==0))
            {
                if (error.Length == 0) error = "Lỗi xác thực khi đăng nhập.";
                value.Message = error;
                value.Status = isCheckpoint;
                Debug.WriteLine(error);
            }
            else
            {
                cookie = string.Join("; ", cookieArr);
                value.UID = cUser;
                value.Status = 1;
                value.Cookie = cookie;
            }

            callback?.Invoke(id, value);
            Close();

            return value;
        }

        public async Task LoginWithCookie(string cookie, Func<bool> callback = null)
        {
            string jsCode = "void(function(){ function setCookie(t) { var list = t.split(';');for(var i = list.length - 1; i >= 0; i--) { var cname = list[i].split('=')[0]; var cvalue = list[i].split('=')[1]; var d = new Date(); d.setTime(d.getTime() + (7*24*60*60*1000)); var expires = '; domain =.facebook.com; expires = '+ d.toUTCString(); document.cookie = cname + ' = ' + cvalue + '; ' + expires; } } var cookie ="+$"'{cookie}'"+" ; setCookie(cookie); location.href = 'https://facebook.com'; })();";
            chromeBrowser.Load(FB_URL);
            chromeBrowser.ExecuteScriptAsyncWhenPageLoaded(jsCode);
        }

        public Task<bool> LoadPageAsync(string url, Func<bool> callback = null)
        {
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            EventHandler<LoadingStateChangedEventArgs> handler = null;

            handler = (sender, args) =>
            {
                if (!args.IsLoading)
                {
                    chromeBrowser.LoadingStateChanged -= handler;
                    callback?.Invoke();
                    tcs.SetResult(true);
                }
            };
            chromeBrowser.LoadingStateChanged += handler;
            chromeBrowser.Load(url);

            return tcs.Task;
        }

        public Task<bool> ExecuteJS(string js, Func<bool> callback = null)
        {
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();

            EventHandler<LoadingStateChangedEventArgs> handler = null;

            handler = (sender, args) =>
            {
                if (!args.IsLoading)
                {
                    chromeBrowser.LoadingStateChanged -= handler;
                    callback?.Invoke();
                    tcs.SetResult(true);
                }
            };

            chromeBrowser.LoadingStateChanged += handler;
            chromeBrowser.ExecuteScriptAsync(js);

            return tcs.Task;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }
    }
}
