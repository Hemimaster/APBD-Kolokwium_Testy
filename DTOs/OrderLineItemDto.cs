namespace APBD_Kolokwium.DTOs;

public class OrderLineItemDto
{
    public string Name { get; set; } = null!;
    
    public decimal Price { get; set; }
    
    public int Amount { get; set; }
    
}