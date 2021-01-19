using FBTool.Interfaces;
using FBTool.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FBTool.Services
{
    public class LicenseManager
    {
        private string LICENSE_PATH_FILE = "";
        private static LicenseManager Instance = null;
        private static ILicenseConverter LicenseConverter = null;

        public DateTime? ExpriedDate;

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

        public bool SaveLicense(string license = "")
        {
            try
            {
                // save license.
                string LicenseDirPath = String.Format(@"{0}\Data\Activation",Application.StartupPath);
                if (!Directory.Exists(LicenseDirPath))
                {
                    Directory.CreateDirectory(LicenseDirPath);
                }
                string LicenseFilePath = String.Format(@"{0}\key.lic", LicenseDirPath);

                if (File.Exists(LicenseFilePath)) File.Delete(LicenseFilePath);
                FileStream fs = File.Create(LicenseFilePath);
                fs.Close();
                using (StreamWriter writer = new StreamWriter(LicenseFilePath))
                {
                    writer.WriteLine(license);
                }
                return true;
            }
            catch (Exception e)
            {
                // error.
                throw e;
            }
        }

        public string LoadLicense()
        {
            string license = "";
            string LicenseDirPath = String.Format(@"{0}\Data\Activation\key.lic", Application.StartupPath);
            using (StreamReader reader = new StreamReader(LicenseDirPath))
            {
                license = reader.ReadLine();
            }
            //return "load license from lic file";
            return (license==null)?"":license;
        }

        public bool CheckLicense(string license)
        {
            
            try
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
                int licenseType = -1;

                licenseType = Int32.Parse(licenseParts[3]);

                LicenseModel hiddenLicenseModel = new LicenseModel()
                {
                    Date = DateTime.ParseExact(licenseDate, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    ProductID = "this-isxx-uniq-uepr-oduc-tidx",
                    LicenseType = (LicenseModel.LICENSE_TYPE)licenseType
                };

               
                MD5 md5 = new MD5CryptoServiceProvider();
                md5.ComputeHash(Encoding.UTF8.GetBytes(hiddenLicenseModel.ToFormatString()));
                byte[] result = md5.Hash;
                StringBuilder md5LicenseBuilder = new StringBuilder();
                for (int i = 0; i < result.Length; i++)
                {
                    md5LicenseBuilder.Append(result[i].ToString("x2"));
                }

                if (licenseData == LicenseConverter
                   .ReverseFrom(md5LicenseBuilder.ToString()))
                {
                    //

                    SaveLicense(license);

                    if (hiddenLicenseModel.LicenseType == LicenseModel.LICENSE_TYPE.TRIAL)
                    {
                        ExpriedDate = hiddenLicenseModel.Date.AddDays(3);
                    }
                    else if (hiddenLicenseModel.LicenseType == LicenseModel.LICENSE_TYPE.ONE_YEAR)
                    {
                        ExpriedDate = hiddenLicenseModel.Date.AddDays(365);
                    }
                    else if (hiddenLicenseModel.LicenseType == LicenseModel.LICENSE_TYPE.FOREVER)
                    {
                        DateTime forever = DateTime.MaxValue.Date;
                        ExpriedDate = forever;
                    }
                    else if (hiddenLicenseModel.LicenseType == LicenseModel.LICENSE_TYPE.ONE_WEEK)
                    {
                        DateTime tenSeconds = hiddenLicenseModel.Date.AddDays(7);
                        ExpriedDate = tenSeconds;
                    }
                    else if (hiddenLicenseModel.LicenseType == LicenseModel.LICENSE_TYPE.TEN_DAYS)
                    {
                        DateTime tenSeconds = hiddenLicenseModel.Date.AddDays(10);
                        ExpriedDate = tenSeconds;
                    }

                    DateTime today = DateTime.Now;


                    if ((ExpriedDate < today) || (ExpriedDate == null))
                    {
                        throw new Exception("Mã hết hạn.");
                    }

                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                //throw e;
                return false;
            }
        }
        public bool CheckAndLoadLicense()
        {
            string license = LoadLicense();
            if (license == null) return false;
            if (license == "") return false;
            return CheckLicense(license);
        }
    }
}
