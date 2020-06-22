using System;
using Electronic_Products_Market_Database_Management_System.Data;
using Electronic_Products_Market_Database_Management_System.Models.interfaces;

namespace Electronic_Products_Market_Database_Management_System.Models
{
      public class OrderRepository : IOrderRepository
      {
            private readonly ApplicationDbContext _appDbContext;
            private readonly ShoppingCart _shoppingCart;
            public OrderRepository(ApplicationDbContext appDbContext, ShoppingCart shoppingCart)
            {
                  _appDbContext = appDbContext;
                  _shoppingCart = shoppingCart;
            }

            public void CreateOrder(Order order)
            {

                  order.OrderPlaced = DateTime.Now;

                  _appDbContext.Orders.Add(order);

                  _appDbContext.SaveChanges();

                  var shoppingCartItems = _shoppingCart.ShoppingCartItems;

                  foreach (var shoppingCartItem in shoppingCartItems)
                  {
                        var orderDetail = new OrderDetail()
                        {
                              Amount = shoppingCartItem.Amount,
                              ProductId = shoppingCartItem.Product.pId,
                              OrderId = order.OrderId,
                              Price = shoppingCartItem.Product.price
                        };

                        _appDbContext.OrderDetails.Add(orderDetail);

                        _appDbContext.SaveChanges();
                  }

            }
      }
}