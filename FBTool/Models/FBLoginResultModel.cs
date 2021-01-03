using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBTool.Models
{
    public class FBLoginResultModel
    {
        // 1: success, 0: fail, 2: checkpoint
        public int Status = 1;
        public string Message = "";
        public string Cookie = "";
        public string UID;
        public string CreatedDate = "";
    }
}
