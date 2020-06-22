using System.Linq;
using Electronic_Products_Market_Database_Management_System.Data;
using Electronic_Products_Market_Database_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Electronic_Products_Market_Database_Management_System.Controllers
{
      public class ShoppingCartController : Controller
      {
            private readonly ShoppingCart _shoppingCart;
            private readonly ApplicationDbContext _context;

            public ShoppingCartController(ShoppingCart shoppingCart, ApplicationDbContext context)
            {
                  _shoppingCart = shoppingCart;
                  _context = context;
            }

            public ViewResult Index()
            {
                  var items = _shoppingCart.GetShoppingCartItems();
                  _shoppingCart.ShoppingCartItems = items;

                  var sCVM = new ShoppingCartViewModel
                  {
                        ShoppingCart = _shoppingCart,
                        ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
                  };

                  //   return View(sCVM);
                  return View(sCVM);
            }

            public RedirectToActionResult AddToShoppingCart(int productId)
            {
                  var selectedProduct = _context.Products.FirstOrDefault(p => p.pId == productId);

                  if (selectedProduct != null)
                  {
                        _shoppingCart.AddToCart(selectedProduct, 1);
                  }
                  return RedirectToAction("Index");
            }

            public RedirectToActionResult RemoveFromShoppingCart(int productId)
            {

                  var selectedProduct = _context.Products.FirstOrDefault(p => p.pId == productId);

                  if (selectedProduct != null)
                  {
                        _shoppingCart.RemoveFromCart(selectedProduct);
                  }
                  return RedirectToAction("Index");
            }
      }
}

