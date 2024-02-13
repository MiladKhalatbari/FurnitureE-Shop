using FurnitureOnlineShop.Domain.Entities;
using FurnitureOnlineShop.Identity.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FurnitureOnlineShop.Identity.Context
{
    public class FurnitureOnlineShopIdentityDBContext : IdentityDbContext<ApplicationUser>
    {
        public FurnitureOnlineShopIdentityDBContext(DbContextOptions<FurnitureOnlineShopIdentityDBContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(FurnitureOnlineShopIdentityDBContext).Assembly);
        }
    }
}
