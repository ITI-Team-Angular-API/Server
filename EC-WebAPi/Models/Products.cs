using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EC_WebAPi.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
        
        //Relations
        [ForeignKey("Categories")]
        public int CategoryId { get; set; }
        public virtual Categories Categories { get; set; }
    }
}