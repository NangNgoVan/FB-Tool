using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBTool.Events
{
    public class LoginEventArgs
    {
        public Forms.Login.Status Status;
        public LoginEventArgs(Forms.Login.Status status)
        {
            Status = status;
        }
    }
}
