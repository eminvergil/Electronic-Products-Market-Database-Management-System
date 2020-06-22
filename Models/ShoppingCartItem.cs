namespace Electronic_Products_Market_Database_Management_System.Models
{
      public class ShoppingCartItem
      {
            public int ShoppingCartItemId { get; set; }
            public ProductModel Product { get; set; }
            public int Amount { get; set; }
            public string ShoppingCartId { get; set; }
      }
}