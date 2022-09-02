using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_SpringLibrary.Models
{
    public class Delivery
    {
        public bool statDel { get; set; }
        public DateTime dtPrevDel { get; set; }
        public DateTime dtFinDel { get; set; }
    }
}