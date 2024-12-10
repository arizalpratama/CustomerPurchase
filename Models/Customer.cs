using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerPurchase.Models
{
    public class Customer
    {
        public int CustomerCode { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public int CustomerType { get; set; }
        public string CustomerAddress { get; set; } = string.Empty;
        public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
    }
}
