using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CodedUITestProject1
{
    [TestClass]
    public class EncodeTest
    {
        [TestMethod]
        public void Test()
        {
            Encoding utf8=Encoding.UTF8;

            string str1Next = @"https://yeeofficedev.sharepoint.cn/DMS/neil/Forms/AllItems.aspx?Paged=TRUE&p_SortBehavior=0&p_FileLeafRef=test%20%2d%2017%2etxt&p_ID=71&PageFirstRow=31&View=8f991788-06dd-4b17-b16c-29fd4e63f8aa";
            string str2Preve = @"https://yeeofficedev.sharepoint.cn/DMS/neil/Forms/AllItems.aspx?&&p_SortBehavior=0&p_FileLeafRef=test%20%2d%2018%20%2d%20%e5%89%af%e6%9c%ac%2etxt&&PageFirstRow=1&View=8f991788-06dd-4b17-b16c-29fd4e63f8aa";
            string str2Next = @"https://yeeofficedev.sharepoint.cn/DMS/neil/Forms/AllItems.aspx?Paged=TRUE&p_SortBehavior=0&p_FileLeafRef=test%20%2d%2030%2etxt&p_ID=45&PageFirstRow=61&View=8f991788-06dd-4b17-b16c-29fd4e63f8aa";
            string str3Preve = @"https://yeeofficedev.sharepoint.cn/DMS/neil/Forms/AllItems.aspx?Paged=TRUE&PagedPrev=TRUE&p_SortBehavior=0&p_FileLeafRef=test%20%2d%2031%20%2d%20%e5%89%af%e6%9c%ac%2etxt&p_ID=44&PageFirstRow=31&View=8f991788-06dd-4b17-b16c-29fd4e63f8aa";

            string str3Next = @"https://yeeofficedev.sharepoint.cn/DMS/neil/Forms/AllItems.aspx?Paged=TRUE&p_SortBehavior=0&p_FileLeafRef=test%20%2d%207%2etxt&p_ID=91&PageFirstRow=91&View=8f991788-06dd-4b17-b16c-29fd4e63f8aa";

            string str4Pre = @"https://yeeofficedev.sharepoint.cn/DMS/neil/Forms/AllItems.aspx?Paged=TRUE&PagedPrev=TRUE&p_SortBehavior=0&p_FileLeafRef=test%20%2d%208%20%2d%20%e5%89%af%e6%9c%ac%2etxt&p_ID=90&PageFirstRow=61&View=8f991788-06dd-4b17-b16c-29fd4e63f8aa";
            string result1 = HttpUtility.UrlDecode(str1Next, utf8);
            string result2 = HttpUtility.UrlDecode(str2Preve, utf8);
            string result3 = HttpUtility.UrlDecode(str2Next, utf8);
            string result4 = HttpUtility.UrlDecode(str3Preve,utf8);
            string result5 = HttpUtility.UrlDecode(str3Next, utf8);
            string result6 = HttpUtility.UrlDecode(str4Pre, utf8);

            string url = @"https://yeeofficedev.sharepoint.cn/DMS/_layouts/15/WopiFrame.aspx?sourcedoc=%7BEB26D7BF-295A-40C1-9A76-97F8D4632FA6%7D&file=%E6%9E%B6%E6%9E%84%E5%AF%B9%E6%AF%94.docx&action=edit";
            string result7 = HttpUtility.UrlDecode(url,utf8);
        }
    }
}
