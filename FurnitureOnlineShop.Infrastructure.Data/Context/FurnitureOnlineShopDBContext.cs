using FurnitureOnlineShop.Domain.Entities;
using FurnitureOnlineShop.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace FurnitureOnlineShop.Persistence.Context;

public class FurnitureOnlineShopDBContext : DbContext
{
    public FurnitureOnlineShopDBContext(DbContextOptions<FurnitureOnlineShopDBContext> options) : base(options) {}

    public DbSet<Cart> Carts { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<CartItem> CartItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FurnitureOnlineShopDBContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        foreach (var entity in base.ChangeTracker.Entries<BaseEntity>().Where(e=> e.State == EntityState.Modified || e.State == EntityState.Added))
        {
            entity.Entity.LastModifiedDate = DateTime.Now;
            if(entity.State == EntityState.Added) 
            entity.Entity.CreatedDate = DateTime.Now;
        }
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }
}
