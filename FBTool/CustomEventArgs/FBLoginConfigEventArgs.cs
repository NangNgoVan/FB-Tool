using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBTool.CustomEventArgs
{
    public class FBLoginConfigEventArgs
    {
        public Forms.AutoFBLoginConfig.State Status;
        public int MaxFBBrowserNum;
        public int TimeFBLoginDelay;
        public bool UseProxy;
        public List<string> Proxies;
        // proxy

    }
}
