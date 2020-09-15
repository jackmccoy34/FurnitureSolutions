using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSolutions.Models
{
    public class ProductListItem
    {
        public int ProductId { get; set; }
        public string FurnitureType { get; set; }
        public decimal Price { get; set; }
    }
}
