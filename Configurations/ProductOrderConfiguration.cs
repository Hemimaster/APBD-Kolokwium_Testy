using APBD_Kolokwium.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace APBD_Kolokwium.Configurations;

public class ProductOrderConfiguration : IEntityTypeConfiguration<ProductOrder>
{
    public void Configure(EntityTypeBuilder<ProductOrder> builder)
    {
        builder.ToTable("Product_Order");
        
        builder.HasKey(e => new { e.ProductId, e.OrderId });
        
        builder.HasOne(e => e.Product)
            .WithMany(e => e.ProductOrders)
            .HasForeignKey(e => e.ProductId);
        
        builder.HasOne(e => e.Order)
            .WithMany(e => e.ProductOrders)
            .HasForeignKey(e => e.OrderId);

    }
    
}