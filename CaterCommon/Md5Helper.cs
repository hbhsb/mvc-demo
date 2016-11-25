using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CaterCommon
{
    public partial class Md5Helper
    {
        public static string EncryptString(string s)
        {
            MD5 md5=MD5.Create();
            byte[] byteOld = Encoding.UTF8.GetBytes(s);
            byte[] byteNew = md5.ComputeHash(byteOld);
            StringBuilder builder = new StringBuilder();
            foreach (byte b in byteNew)
            {
                builder.Append(b.ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
