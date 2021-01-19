using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBTool.Models
{
    class LicenseModel
    {
        public enum LICENSE_TYPE {TRIAL, ONE_YEAR, FOREVER, ONE_WEEK, TEN_DAYS};
        public string ProductID;
        public DateTime Date;
        public LICENSE_TYPE LicenseType;
        public LicenseModel()
        {

        }

        public string ToFormatString()
        {
            return $"FBTool-{ProductID}|{Date.ToString("dd/MM/yyyy HH:mm:ss")}|{(int)LicenseType}";
        }
    }
}
