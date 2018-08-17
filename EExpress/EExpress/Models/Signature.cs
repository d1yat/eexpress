using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EExpress.Models
{
    public class Signature
    {
        public string DomainCode { get; set; }
        public string Tax { get; set; } // m_domain.nmsignpjk
        public string Finance { get; set; } // m_domain.nmpjbt
        public string PaymentDescription { get; set; } // m_domain.paymentx
        public string BankAccDescription { get; set; } // m_domain.bnk
    }
}