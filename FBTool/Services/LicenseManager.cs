using FBTool.Interfaces;
using FBTool.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FBTool.Services
{
    public class LicenseManager
    {
        private string LICENSE_PATH_FILE = "";
        private static LicenseManager Instance = null;
        private static ILicenseConverter LicenseConverter = null;

        private LicenseManager()
        {
            
        }

        public void SetLicenseConverter(ILicenseConverter licenseConverter)
        {
            LicenseConverter = licenseConverter;
        }

        public static LicenseManager GetInstance()
        {
            if (Instance == null) Instance = new LicenseManager();
            return Instance;
        }

        public void SaveLicense()
        {
            // save license.
        }

        public string LoadLicense()
        {
            //return "load license from lic file";
            return "";
        }

        public bool CheckLicense(string license)
        {
            if (license.Length == 0) return false;
            if (LicenseConverter == null)
            {
                throw new Exception("LicenseConverter is not set!");
            }

            string[] licenseParts = license.Split('-');

            if (licenseParts.Length != 4) throw new Exception("Mã kích hoạt sai định dạng!");

            var fullYear = licenseParts[0].Substring(0, 4);
            var month = licenseParts[0].Substring(4, 2);
            var date = licenseParts[0].Substring(6, 2);
            var hours = licenseParts[1].Substring(0, 2);
            var minutes = licenseParts[1].Substring(2, 2);
            var seconds = licenseParts[1].Substring(4, 2);

            var licenseDate = $"{date}/{month}/{fullYear} {hours}:{minutes}:{seconds}";

            string licenseData = licenseParts[2];
            int licenseType;

            Int32.TryParse(licenseParts[3], out licenseType);

            try
            {
                LicenseModel hiddenLicenseModel = new LicenseModel()
                {
                    Date = DateTime.ParseExact(licenseDate, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    ProductID = "this-isxx-uniq-uepr-oduc-tidx",
                    LicenseType = (LicenseModel.LICENSE_TYPE)licenseType
                };

               
                //Debug.WriteLine(hiddenLicenseModel.ToFormatString());
               
                MD5 md5 = new MD5CryptoServiceProvider();
                md5.ComputeHash(Encoding.UTF8.GetBytes(hiddenLicenseModel.ToFormatString()));
                byte[] result = md5.Hash;
                StringBuilder md5LicenseBuilder = new StringBuilder();
                for (int i = 0; i < result.Length; i++)
                {
                    md5LicenseBuilder.Append(result[i].ToString("x2"));
                }
                //Debug.WriteLine(md5LicenseBuilder);
                //Debug.WriteLine(LicenseConverter
                //   .ReverseFrom(md5LicenseBuilder.ToString()));
                if (licenseData == LicenseConverter
                   .ReverseFrom(md5LicenseBuilder.ToString())) return true;
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool CheckAndLoadLicense()
        {
            string license = LoadLicense();
            //if (license == "") throw new Exception("No license settle!");
            return CheckLicense(license);
        }
    }
}
