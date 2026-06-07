using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_Kolokwium.Entities;

[Table("Product")]
 public class Product
 {
     [Key]
     public int Id { get; set; }
     
     [MaxLength(50)]
     public string Name { get; set; } = null!;
     
     [Column(TypeName = "numeric(10,2)")]
     public decimal Price { get; set; }
     public ICollection<ProductOrder> ProductOrders { get; set; } = new List<ProductOrder>();
 }