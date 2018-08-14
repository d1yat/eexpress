using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EExpress.Models
{
    public class Pager
    {
        public ICollection<object> IndexViewModel { get; set; }
        public int TotalCount { get; set; }
    }
}