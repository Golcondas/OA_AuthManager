using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neil.Commom
{
    public class ResultData
    {
        public bool result { get; set; }
        public object data { get; set; }
        public string message { get; set; }
        public object rows { get; set; }
        public int total { get; set; }
        public int status { get; set; }
        public string reponseCode { get; set; }
    }
}
