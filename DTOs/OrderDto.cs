namespace APBD_Kolokwium.DTOs;

public class OrderDto
{
    public int Id { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime? FulfilledAt { get; set; }
    
    public string Status { get; set; } = null!;
    
    public ClientInfoDto Client { get; set; } = null!;
    
    public List<OrderLineItemDto> Products { get; set; } = new();
    
}