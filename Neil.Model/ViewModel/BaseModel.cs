using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neil.Model.ViewModel
{
    public class BaseModel
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public int totalCount { get; set; }
        public bool result { get; set; }
        public object data { get; set; }
    }
}
