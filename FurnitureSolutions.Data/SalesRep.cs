using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSolutions.Data
{
    public class SalesRep
    {
        [Key]
        public int RepId { get; set; }
        public string RepName { get; set; }
        public string Territory { get; set; }
    }
}
