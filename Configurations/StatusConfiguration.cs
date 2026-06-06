using APBD_Kolokwium.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace APBD_Kolokwium.Configurations;

public class StatusConfiguration : IEntityTypeConfiguration<Status>
{
    public void Configure(EntityTypeBuilder<Status> builder)
    {
        builder.ToTable("Status");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(50);
    }

}