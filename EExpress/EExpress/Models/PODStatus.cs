using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EExpress.Models
{
    public class PODStatus
    {
        public int kode { get; set; }
        public string nm { get; set; }
        public string statusx { get; set; }
        public string kode_relasi { get; set; }
        public Guid id { get; set; }
    }
}