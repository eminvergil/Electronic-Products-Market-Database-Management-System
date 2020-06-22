using System;
using System.Collections.Generic;
using System.Text;
using Electronic_Products_Market_Database_Management_System.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Electronic_Products_Market_Database_Management_System.Data
{
      public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
      {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
            {
            }

            public DbSet<ProductModel> Products { get; set; }

            public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }


            public DbSet<Order> Orders { get; set; }
            public DbSet<OrderDetail> OrderDetails { get; set; }
      }
}
