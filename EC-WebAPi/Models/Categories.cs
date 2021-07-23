using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EC_WebAPi.Models
{
    public class Categories
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Relations 
        public virtual ICollection<Products> Products { get; set; }
    }
}