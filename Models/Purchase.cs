using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerPurchase.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public int CustomerCode { get; set; }
        public string Item { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime PurchaseDate { get; set; }

        public Customer Customer { get; set; } = null!;
    }
}
