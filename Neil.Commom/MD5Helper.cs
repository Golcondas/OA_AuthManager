using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Neil.Commom
{
    public class MD5Helper
    {
        /// <summary>
        /// MD5
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetMD5(string str)
        {
            MD5 md5 = MD5.Create();
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(str);
            byte[] md5Buffer = md5.ComputeHash(bytes);
            StringBuilder strBuilder = new StringBuilder();
            foreach (var item in md5Buffer)
            {
                strBuilder.Append(item.ToString("X2"));
            }
            md5.Clear();
            return strBuilder.ToString();
        }
    }
}
