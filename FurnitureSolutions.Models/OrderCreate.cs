using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSolutions.Models
{
    public class OrderCreate
    {
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public string DeliveryDate { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int RepId { get; set; }
    }
}
