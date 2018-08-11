using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EExpress.Models
{
    public class CustomerViewModel
    {
        public Customer Customer { get; set; }
        public ICollection<Customer> Customers { get; set; }
    }
}