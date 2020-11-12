using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FBTool.Services
{
    class AppKeyManager
    {
        private string FBTOOL_CONTAINER_NAME = "FBToolKeyContainer";
        private static AppKeyManager Instance;
        private AppKeyManager()
        {

        }
        public static AppKeyManager GetInstance()
        {
            if (Instance == null) Instance = new AppKeyManager();
            return Instance;
        }

        public string GetAppKeyFromKeyContainer(bool priKey = false)
        {
            var parameters = new CspParameters
            {
                KeyContainerName = FBTOOL_CONTAINER_NAME
            };

            var rsa = new RSACryptoServiceProvider(parameters);

            return rsa.ToXmlString(priKey);
        }

        public void GenAndSaveAppKeyInKeyContainer()
        {
            var parameters = new CspParameters
            {
                KeyContainerName = FBTOOL_CONTAINER_NAME
            };

            var rsa = new RSACryptoServiceProvider(parameters);

            //return rsa.ToXmlString(false);
        }

        public void DeleteAppKeyFromKeyContainer()
        {

        }
    }
}
