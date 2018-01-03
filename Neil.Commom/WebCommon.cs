using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Neil.Commom
{
    public class WebCommon
    {
        public static string MD5ToString(string str) 
        {
            MD5 md5 = MD5.Create();
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(str);

            byte[] md5Buffer= md5.ComputeHash(buffer);
            StringBuilder sb = new StringBuilder();
            foreach (var item in md5Buffer)
            {
                sb.Append(item.ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
