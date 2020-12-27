using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBTool.Events
{
    public class ActiveEventArgs
    {
        public Forms.ActiveKey.Status Status;
        public string LicenseValue;
        public DateTime? ExpriedDate;
        public string Message;
        public ActiveEventArgs(Forms.ActiveKey.Status status, string licenseValue, DateTime? expriedDate, string message)
        {
            Status = status;
            LicenseValue = licenseValue;
            Message = message;
            ExpriedDate = expriedDate;
        }
    }
}
