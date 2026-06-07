using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace APBD_Kolokwium.Entities;

[Table("Client")]
public class Client
{
    [Key]
    public int Id { get; set; }
    
    [MaxLength(50)]
    public string FirstName { get; set; } = null!;
    
    [MaxLength(100)]
    public string LastName { get; set; } = null!;

    public ICollection<Order> Orders { get; set; } = new List<Order>();
}