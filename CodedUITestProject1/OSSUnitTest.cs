using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodedUITestProject1
{
    [TestClass]
    public class OSSUnitTest
    {
        [TestMethod]
        public void TestDeleteFile() 
        {
            for (int i = 1; i <= 30;i++ )
            {
                OSSHelper help = new OSSHelper();
                help.DeleteObjects("huadong1");
                System.Diagnostics.Debug.WriteLine("----------删除成功------------> i:" + i);
            }
            
        }
    }
}
