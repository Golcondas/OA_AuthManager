using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNetDemo
{
    public class UserInfoService:IUserInfoService
    {
        public string Name { get; set; }
        public Person per { get; set; }
        //public string  Message() {
        //    return "Spring Hello World! " + Name + " Age:" + per.Age;
        //}
        public string Message()
        {
            return "Spring Hello World! " + Name + " Age:" + per.Age;
        }

        
    }
}
