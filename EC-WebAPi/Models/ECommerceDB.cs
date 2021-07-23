using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EC_WebAPi.Models
{
    public class ECommerceDBContext : DbContext
    {
        public ECommerceDBContext():base("TestProduct")
        {
            
            
            
        }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Products> Products { get; set; }
    }
}