using FBTool.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBTool.Services
{
    public class LicenseConverter : ILicenseConverter
    {
        public string ReverseFrom(string originalStr)
        {
            return originalStr;
            byte[] asciiBytes = Encoding.ASCII.GetBytes(originalStr);

            StringBuilder reversedStr = new StringBuilder();
            for (int i = 0; i < asciiBytes.Length; i++)
            {
                byte newAscii = 0;

                if ((asciiBytes[i] >= 48) && (asciiBytes[i] <= 57))
                {
                    newAscii = (byte)((asciiBytes[i]*i) % 10 + 48);
                }
                else if ((asciiBytes[i] >= 97) && (asciiBytes[i] <= 122))
                {
                    newAscii = (byte)((asciiBytes[i] * i + i) % 26 + 97);
                }
                else if ((asciiBytes[i] >= 65) && (asciiBytes[i] <= 90))
                {
                    newAscii = (byte)((asciiBytes[i] * i * i + i) % 26 + 65);
                }
                else newAscii = asciiBytes[i];
                reversedStr.Append((char)newAscii);
            }
            return reversedStr.ToString();
        }
    }
}
