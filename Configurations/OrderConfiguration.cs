using APBD_Kolokwium.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace APBD_Kolokwium.Configurations;


public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Order");

        builder.HasKey(e => e.Id);

        builder.HasOne(e => e.Client)
            .WithMany(e => e.Orders)
            .HasForeignKey(e => e.ClientId);

        builder.HasOne(e => e.Status)
            .WithMany(e => e.Orders)
            .HasForeignKey(e => e.StatusId);
    }
}
