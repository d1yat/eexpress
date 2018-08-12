using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EExpress.Models
{
    public class TermInvoice
    {
        public Guid cust_id { get; set; }
        public string nm { get; set; }
        public string termx { get; set; }
        public string descx { get; set; }
    }
}