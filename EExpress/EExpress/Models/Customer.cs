using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EExpress.Models
{
    public partial class Customer
    {
        //[DisplayName("Customer Id")]
        //[Required(ErrorMessage ="Customer Id is required")]
        public Guid id { get; set; }

        //[DisplayName("Customer Name")]
        //[Required(ErrorMessage = "Customer Name is required")]
        public string nm { get; set; }

        //[DisplayName("Alamat")]
        //[Required(ErrorMessage = "Alamat 1 is required")]
        public string alm1 { get; set; }

        //[DisplayName("Alamat 2")]
        //[Required(ErrorMessage = "Alamat 2 is required")]
        public string alm2 { get; set; }

        //[DisplayName("Alamat 3")]
        //[Required(ErrorMessage = "Alamat 3 is required")]
        public string alm3 { get; set; }

        //[DisplayName("Telp")]
        //[Required(ErrorMessage = "Telp is required")]
        public string tlp { get; set; }

        //[DisplayName("Contact Person")]
        //[Required(ErrorMessage = "Contact Person is required")]
        public string ct_person { get; set; }

        //[DisplayName("Status")]
        //[Required(ErrorMessage = "Status is required")]
        public string statusx { get; set; }

        //[DisplayName("Cetak / Print Connocement")]
        //[Required(ErrorMessage = "Cetak / Print Connocement is required")]
        public string ctk_hrg { get; set; }

        //[DisplayName("NPWP")]
        //[Required(ErrorMessage = "NPWP is required")]
        public string npwp { get; set; }

        //[DisplayName("Jenis Pembayaran")]
        //[Required(ErrorMessage = "Jenis Pembayaran is required")]
        public string k_payment { get; set; }

        //[DisplayName("Harga Khusus")]
        //[Required(ErrorMessage = "Harga Khusus is required")]
        public char hrgkhs { get; set; }

        //[DisplayName("Cetak Penerima Connocement")]
        //[Required(ErrorMessage = "Cetak Penerima Connocement is required")]
        public char cetak_penerima { get; set; }

        public string user_entry { get; set; }

        //[DisplayName("Special Minimum Price (Tarif)")]
        //[Required(ErrorMessage = "'Special Minimum Price (Tarif)' is required")]
        public string hrgspecial { get; set; }

        //public ICollection<Customer> Customers { get; set; }
    }
}