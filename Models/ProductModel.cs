using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Electronic_Products_Market_Database_Management_System.Models
{
      public class ProductModel
      {
            [Key]
            public int pId { get; set; }

            [Column(TypeName = "varchar(250)")]
            [Required(ErrorMessage = "this field is required")]
            [DisplayName("Product Name")]
            public string pName { get; set; }
            [Column(TypeName = "varchar(250)")]
            [Required(ErrorMessage = "this field is required")]
            [DisplayName("Product Image")]
            public string pImage { get; set; }
            [DisplayName("Price")]
            public int price { get; set; }
            [DisplayName("Product is stock")]
            public bool inStock { get; set; }
            [DisplayName("Num of Product")]
            public int number { get; set; }
            public int Count { get; set; }
      }
}