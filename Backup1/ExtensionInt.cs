using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodedUITestProject1
{
    public static class ExtensionInt
    {
        /// <summary>
        /// 为A新增一个ExtensionMethod方法
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int ExtensionMethod(this int a)//扩建的方法必须是静态方法，参数里面必须含有this关键字，this关键字后面的类型
        {
            return 10;
        }

    }

    public class A//先定义A类
    {
        
    }
}
