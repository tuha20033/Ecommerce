
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Persistences;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<InventoryItem> InventoryItems { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Warehouse> Warehouses { get; set; }
    public DbSet<StockMovement> StockMovements { get; set; }
    public DbSet<Shipment> Shipments { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Coupon> Coupons { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<CouponUsage> CouponUsages { get; set; }
    public DbSet<Address> Address { get; set; }
    public DbSet<ShippingCarrier> ShippingCarriers { get; set; }
    public DbSet<Promotion> Promotions { get; set; }
    public DbSet<ReviewMedia> ReviewMedias { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<CouponUsage>()
            .HasOne(c => c.Customer)
            .WithMany()
            .HasForeignKey(c => c.CustomerId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<CouponUsage>()
            .HasOne(c => c.Order)
            .WithMany(o => o.CouponUsages)
            .HasForeignKey(c => c.OrderId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Review>()
            .HasOne(r => r.Customer)
            .WithMany(c => c.Reviews)
            .HasForeignKey(r => r.CustomerId)
            .OnDelete(DeleteBehavior.NoAction);
    }

}
