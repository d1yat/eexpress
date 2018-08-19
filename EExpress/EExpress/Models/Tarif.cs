using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace EExpress.Models
{
    public class Tarif
    {
        public string custno { get; set; }

        public string kdproduct { get; set; }

        public string dst { get; set; }

        public string kdpengiriman { get; set; }

        public decimal discnt { get; set; }

        [Description("Weight Minimum / Shipment")]
        public decimal kilo1 { get; set; }

        public string kategory { get; set; }

        public string jns_shipment { get; set; }

        [Description("Price")]
        public decimal prckilo1 { get; set; }

        [Description("Next")]
        public decimal prckilo2 { get; set; }

        public string valuta_kurs { get; set; }

        public string ctk_hrg { get; set; }

        [Description("Weight Minimum charge")]
        public decimal kilo_min  { get; set; }

        public string xtake { get; set; }

        public string xlangsam { get; set; }

        public string xnoflat { get; set; }

        public Guid? id { get; set; }
    }
}