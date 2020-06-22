using System;
using System.Collections.Generic;
using System.Linq;
using Electronic_Products_Market_Database_Management_System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Electronic_Products_Market_Database_Management_System.Models
{
      public class ShoppingCart
      {

            private readonly ApplicationDbContext _context;

            public ShoppingCart(ApplicationDbContext context)
            {
                  _context = context;
            }

            public string ShoppingCartId { get; set; }
            public List<ShoppingCartItem> ShoppingCartItems { get; set; }

            public static ShoppingCart GetCart(IServiceProvider services)
            {
                  ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                      .HttpContext.Session;

                  var context = services.GetService<ApplicationDbContext>();
                  string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

                  session.SetString("CartId", cartId);

                  return new ShoppingCart(context) { ShoppingCartId = cartId };
            }

            public void AddToCart(ProductModel product, int amount)
            {
                  var shoppingCartItem =
                      _context.ShoppingCartItems.SingleOrDefault(
                          s => s.Product.pId == product.pId && s.ShoppingCartId == ShoppingCartId);
                  if (shoppingCartItem == null)
                  {
                        shoppingCartItem = new ShoppingCartItem
                        {
                              ShoppingCartId = ShoppingCartId,
                              Product = product,
                              Amount = 1
                        };

                        _context.ShoppingCartItems.Add(shoppingCartItem);
                  }
                  else
                  {
                        shoppingCartItem.Amount++;
                  }

                  _context.SaveChanges();
            }

            public int RemoveFromCart(ProductModel product)
            {
                  var shoppingCartItem =
                      _context.ShoppingCartItems.SingleOrDefault(
                          s => s.Product.pId == product.pId && s.ShoppingCartId == ShoppingCartId);

                  var localAmount = 0;

                  if (shoppingCartItem != null)
                  {
                        if (shoppingCartItem.Amount > 1)
                        {
                              shoppingCartItem.Amount--;
                              localAmount = shoppingCartItem.Amount;
                        }
                        else
                        {
                              _context.ShoppingCartItems.Remove(shoppingCartItem);
                        }
                  }

                  _context.SaveChanges();

                  return localAmount;
            }


            public List<ShoppingCartItem> GetShoppingCartItems()
            {
                  return ShoppingCartItems ??
                      (ShoppingCartItems =
                          _context.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                          .Include(s => s.Product)
                          .ToList());
            }
            public void ClearCart()
            {
                  var cartItems = _context.ShoppingCartItems
                      .Where(cart => cart.ShoppingCartId == ShoppingCartId);

                  _context.ShoppingCartItems.RemoveRange(cartItems);
                  _context.SaveChanges();
            }

            public decimal GetShoppingCartTotal()
            {
                  var total = _context.ShoppingCartItems
                      .Where(c => c.ShoppingCartId == ShoppingCartId)
                      .Select(c => c.Product.price * c.Amount).Sum();

                  return total;
            }


      }
}