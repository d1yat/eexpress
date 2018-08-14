using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EExpress.Models
{
    public class Divisi
    {
        public Guid? id { get; set; }
        public string nm { get; set; }
        public string alm1 { get; set; }
        public string alm2 { get; set; }
        public string tlp { get; set; }
        public string ct_person { get; set; }
        public string statusx { get; set; }
        public string ctk_hrg { get; set; }
        public string npwp { get; set; }
        public string k_payment { get; set; }
        public int? countx { get; set; }
        public string user_entry { get; set; }
        public Guid cust_id { get; set; }
    }
}