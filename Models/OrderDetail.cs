namespace Electronic_Products_Market_Database_Management_System.Models
{
      public class OrderDetail
      {

            public int OrderDetailId { get; set; }
            public int OrderId { get; set; }
            public int ProductId { get; set; }
            public int Amount { get; set; }
            public decimal Price { get; set; }
            public virtual ProductModel Product { get; set; }
            public virtual Order Order { get; set; }
      }
}