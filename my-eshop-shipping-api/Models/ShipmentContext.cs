using Microsoft.EntityFrameworkCore;

namespace my_eshop_api.Models
{
    public class ShipmentContext : DbContext
    {
        public ShipmentContext(DbContextOptions<ShipmentContext> options)
            : base(options)
        {
        }

        public DbSet<Shipment> Shipments { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Order>().Property(p => p.TotalPrice).HasColumnType("decimal(18,2)");
            // modelBuilder.Entity<OrderDetail>().Property(p => p.ItemUnitPrice).HasColumnType("decimal(18,2)");
            // modelBuilder.Entity<OrderDetail>().Property(p => p.Quantity).HasColumnType("decimal(18,2)");
            // modelBuilder.Entity<OrderDetail>().Property(p => p.TotalPrice).HasColumnType("decimal(18,2)");
            //modelBuilder.Entity<Shipping>().Property(s => s.Status).HasConversion<string>();
        }
    }
}