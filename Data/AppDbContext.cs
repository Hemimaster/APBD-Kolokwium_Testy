using APBD_Kolokwium.Entities;
using Microsoft.EntityFrameworkCore;

namespace APBD_Kolokwium.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
       
    }
    
    public DbSet<Client> Clients { get; set; }
        
    public DbSet<Order>  Orders { get; set; }
        
    public DbSet<Status> Statuses { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<ProductOrder> ProductOrders { get; set; }
    
    
}