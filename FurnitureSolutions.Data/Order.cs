using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSolutions.Data
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        public int RepId { get; set; }
        [ForeignKey("RepId")]
        public virtual SalesRep SalesRep { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public string DeliveryDate { get; set; }

    }
}
