using CefSharp;
using CefSharp.WinForms;
using FBTool.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FBTool.Forms
{
    public partial class FBBrowser : Form
    {
        private string FB_URL = "https://www.facebook.com/";
        //private string FB_URL = "https://m.facebook.com/";

        public ChromiumWebBrowser chromeBrowser;

        public FBBrowser(bool icogino = false)
        {
            InitializeComponent();
            InitFBBrowser(icogino);
        }

        public void InitFBBrowser(bool icogino)
        {
            if (!Cef.IsInitialized)
            {
                CefSettings settings = new CefSettings();
                Cef.Initialize(settings);
            }
            chromeBrowser = new ChromiumWebBrowser("");
            RequestContextSettings requestContextSettings = new RequestContextSettings();
            //
            if (icogino)
            {
                //requestContextSettings.PersistSessionCookies = true;
                //requestContextSettings.PersistUserPreferences = true;
                requestContextSettings.CachePath = "";
            }
            chromeBrowser.RequestContext = new RequestContext(requestContextSettings);
           
            Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;
            //chromeBrowser.ExecuteScriptAsyncWhenPageLoaded("alert('All Resources Have Loaded');", false);
        }

        public async Task<FBLoginResultModel> FBLoginAndGetCookie(int id, string username, string pass, Func<object, int, FBLoginResultModel, FBLoginResultModel> callback = null)
        {
            try
            {
                string cookie = null;

                bool loadLoginPage = await LoadPageAsync(FB_URL);
                string jsLoginCode = $"(function(){{var u=document.getElementById('email');if(u!=null&&u!=undefined)u.value='{username}';var p=document.getElementById('pass');if(p!=null&&p!=undefined)p.value='{pass}';var btn=document.getElementsByName('login')[0];if(btn!=null&&btn!=undefined){{btn.click(); return true;}}else return false;}})();";

                EventHandler<LoadingStateChangedEventArgs> loginProcessHandler = null;
                TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
                loginProcessHandler = (sender, args) =>
                {
                    if (!args.IsLoading)
                    {
                        Debug.WriteLine("Login process done!");
                        chromeBrowser.LoadingStateChanged -= loginProcessHandler;
                        tcs.SetResult(true);
                    }
                    else
                    {
                        Debug.WriteLine("Login processing...");
                    }
                };

                chromeBrowser.LoadingStateChanged += loginProcessHandler;
                JavascriptResponse x = await chromeBrowser.GetMainFrame().EvaluateScriptAsync(jsLoginCode);
                dynamic loginSuccessed = x.Result;

                if (!loginSuccessed) tcs.SetResult(false);

                bool done = await tcs.Task;
                //
                string checkLoginSucceedJsCode = "(function(){var e=document.getElementsByClassName('_9ay7')[0];var e1=document.getElementById('error_box');var str='error=';if(e!=undefined){str+=e.textContent;};if(e1!=undefined){str+='+'+e1.textContent;};document.cookie=str;})();";
                //chromeBrowser.ExecuteScriptAsync(checkLoginSucceedJsCode);
                await chromeBrowser.GetMainFrame().EvaluateScriptAsync(checkLoginSucceedJsCode);
                //await Task.Delay(5000);
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

                if ((cUser.Length == 0) && (xs.Length == 0))
                {
                    if (error.Length == 0) error = "Đã xảy ra lỗi.";
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

                callback?.Invoke(this, id, value);
                
                return value;
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }
            finally
            {
                Close();
            }
            return null;
        }

        public async Task LoginWithCookie(string cookie, Func<bool> callback = null)
        {
            string jsCode = "void(function(){ function setCookie(t) { var list = t.split(';');for(var i = list.length - 1; i >= 0; i--) { var cname = list[i].split('=')[0]; var cvalue = list[i].split('=')[1]; var d = new Date(); d.setTime(d.getTime() + (7*24*60*60*1000)); var expires = '; domain =.facebook.com; expires = '+ d.toUTCString(); document.cookie = cname + ' = ' + cvalue + '; ' + expires; } } var cookie =" + $"'{cookie}'" + " ; setCookie(cookie); location.href = 'https://facebook.com'; })();";
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
                    Debug.WriteLine("Loaded!");
                    chromeBrowser.LoadingStateChanged -= handler;
                    callback?.Invoke();
                    tcs.SetResult(true);
                }
                else
                {
                    Debug.WriteLine("Page is loading");
                }
            };
            chromeBrowser.LoadingStateChanged += handler;
            chromeBrowser.Load(url);

            return tcs.Task;
        }
        public async Task<bool> SetProxy(string address)
        {
            bool success = false;
            await Cef.UIThreadTaskFactory.StartNew(delegate
            {
                var rc = chromeBrowser.GetBrowser().GetHost().RequestContext;
                
                if (rc!=null)
                {
                    var v = new Dictionary<string, object>();
                    v["mode"] = "fixed_servers";
                    v["server"] = address;
                    string error;
                    success = rc.SetPreference("proxy", v, out error);
                }
            });
            return success;
        }
    }
}
