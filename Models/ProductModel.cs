using System.ComponentModel.DataAnnotations;

namespace Electronic_Products_Market_Database_Management_System.Models
{
      public class ProductModel
      {
            [Key]
            public int pId { get; set; }
            public string pName { get; set; }
            public string pImage { get; set; }
            public int price { get; set; }
            public bool inStock { get; set; }
            public int number { get; set; }
      }
}