using System.Collections.Generic;
using Electronic_Products_Market_Database_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Electronic_Products_Market_Database_Management_System.Components
{
      public class ShoppingCartSummary : ViewComponent
      {
            private readonly ShoppingCart _shoppingCart;

            public ShoppingCartSummary(ShoppingCart shoppingCart)
            {
                  _shoppingCart = shoppingCart;
            }

            public IViewComponentResult Invoke()
            {
                  var items = _shoppingCart.GetShoppingCartItems();
                  // var items = new List<ShoppingCartItem>() { new ShoppingCartItem(), new ShoppingCartItem() };
                  _shoppingCart.ShoppingCartItems = items;

                  var shoppingCartViewModel = new ShoppingCartViewModel
                  {
                        ShoppingCart = _shoppingCart,
                        ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
                  };

                  return View(shoppingCartViewModel);
            }
      }
}