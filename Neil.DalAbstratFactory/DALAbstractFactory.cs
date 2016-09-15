using Neil.IDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Neil.DalAbstratFactory
{
    public class DALAbstractFactory
    {
        public static readonly string assemblyFullName = ConfigurationManager.ConnectionStrings["dalFullName"].ConnectionString;
        public static readonly string assembly = ConfigurationManager.ConnectionStrings["assemblyName"].ConnectionString;

        public static IUserDal CreatNewDal()
        {
            string fullNameSpace = assemblyFullName + ".UserDal";
            return GetIntence(fullNameSpace, assembly) as IUserDal;
        }

        public static object GetIntence(string assemblyFullName, string assembly)
        {
            var assemblyName = Assembly.Load(assembly);
            return assemblyName.CreateInstance(assemblyFullName);
        }
    }
}
