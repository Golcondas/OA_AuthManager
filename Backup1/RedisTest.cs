using Microsoft.VisualStudio.TestTools.UnitTesting;
using Neil.Commom;
using Neil.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodedUITestProject1
{
    [TestClass]
    public class RedisTest
    {
        [TestMethod]
        public void TestGetRedis() 
        {
            //var keyA = RedisHelper.GetString("a");
            //var keyB = RedisHelper.SetString("a","宝山");
            for (int i = 1; i < 10000;i++ )
            {
                string key=i+"";
                var keyC = RedisHelper.SetStringTime(key, "宝山", DateTime.Now.AddMinutes(1));
            }
            
        }
    }
}
