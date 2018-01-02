using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neil.Commom
{
    public class ResponseResult
    {
        private bool _isSuccess;
        public bool issuccess
        {
            get { return _isSuccess = false; }
            set { _isSuccess = value; }
        }
        public object data { get; set; }
        public string message { get; set; }
        public string reponsecode { get; set; }
    }
}
