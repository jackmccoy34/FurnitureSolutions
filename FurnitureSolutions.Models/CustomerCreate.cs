using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSolutions.Models
{
    public class CustomerCreate
    {
        [Required]
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
    }
}
