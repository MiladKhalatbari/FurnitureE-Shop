using FurnitureOnlineShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace FurnitureOnlineShop.Persistence.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p => p.Id).IsRequired();

        builder.HasData(
            new Product()
            {
                CreatedDate = DateTime.UtcNow,
                Id = 1,
                LastModifiedDate = DateTime.UtcNow,
                ImagePath = "/images/product-1.png",
                Description = "Nordic Chair, a timeless blend of minimalist design and unparalleled comfort. Crafted with meticulous attention to detail, this chair embodies the essence of Scandinavian elegance, making it a perfect addition to any modern living space.\r\n\r\nDesigned for both style and functionality, the Nordic Chair features clean lines, gentle curves, and a sleek silhouette that effortlessly complements any interior décor. Its minimalist frame is expertly crafted from high-quality wood, ensuring durability and stability for years to come.",
                Price = 50,
                QuantityInStock = 9,
                Title = "Nordic Chair",
            }, new Product()
            {
                CreatedDate = DateTime.UtcNow,
                Id = 2,
                LastModifiedDate = DateTime.UtcNow,
                ImagePath = "/images/product-2.png",
                Description = "Kruzo Aero Chair, where innovation meets sophistication in a seamless fusion of style and functionality. Engineered with cutting-edge design and premium materials, this chair redefines modern seating, offering unparalleled comfort and aesthetic appeal.\r\n\r\nCrafted with precision, the Kruzo Aero Chair features a sleek and aerodynamic silhouette that exudes contemporary elegance. Its distinctive design elements, including fluid lines and a curved backrest, create a sense of dynamic movement, making it a striking focal point in any space.",
                Price = 78,
                QuantityInStock = 14,
                Title = "Kruzo Aero Chair",
            }, new Product()
            {
                CreatedDate = DateTime.UtcNow,
                Id = 3,
                LastModifiedDate = DateTime.UtcNow,
                ImagePath = "/images/product-3.png",
                Description = "Ergonomic Chair, meticulously designed to prioritize your comfort, health, and productivity. Crafted with precision engineering and ergonomic principles, this chair offers exceptional support and adaptability for extended periods of sitting.\r\n\r\nThe Ergonomic Chair features an innovative design that contours to the natural curvature of your body, providing optimal lumbar support and promoting healthy posture. Its adjustable features, including lumbar support, seat depth, armrests, and height, ensure customizable comfort tailored to your individual needs.",
                Price = 43,
                QuantityInStock = 5,
                Title = "Ergonomic Chair",
            }, new Product()
            {
                CreatedDate = DateTime.UtcNow,
                Id = 4,
                LastModifiedDate = DateTime.UtcNow,
                ImagePath = "/images/sofa.png",
                Description = "luxurious Sofa, a masterpiece of comfort and style that transforms any living space into a haven of relaxation and elegance. Crafted with the finest materials and meticulous attention to detail, this sofa offers unparalleled comfort, durability, and timeless beauty.\r\n\r\nDesigned for both aesthetics and functionality, our Sofa boasts a timeless silhouette with clean lines and plush cushions, creating a harmonious balance of modern sophistication and inviting comfort. Its sturdy frame, crafted from high-quality hardwood, ensures stability and longevity, promising years of enjoyment for you and your loved ones.",
                Price = 57,
                QuantityInStock = 10,
                Title = "luxurious Sofa",
            }
        );
    }
}

public class CartConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.Property(p => p.Id).IsRequired();
        builder.Property(p => p.IdentityUserId).IsRequired();

        builder.HasOne(c => c.IdentityUser)
            .WithMany()
            .HasForeignKey(c => c.IdentityUserId);

        builder.HasData(new Cart()
        {
            Id = 1,
            CreatedDate = new DateTime(),
            LastModifiedDate = new DateTime(),
            IdentityUserId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
            IsFinaly = true,
        });
    }
}
public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.Property(p => p.Id).IsRequired();

        builder.HasData(
            new CartItem()
            {
                LastModifiedDate = new DateTime(),
                CartId = 1,
                ProductId = 1,
                Quantity = 2,
                Id = 1,
                CreatedDate = new DateTime(),

            },
             new CartItem()
             {
                 LastModifiedDate = new DateTime(),
                 CartId = 1,
                 ProductId = 2,
                 Quantity = 1,
                 Id = 2,
                 CreatedDate = new DateTime(),

             },
             new CartItem()
             {
                 LastModifiedDate = new DateTime(),
                 CartId = 1,
                 ProductId = 3,
                 Quantity = 3,
                 Id = 3,
                 CreatedDate = new DateTime(),

             }, new CartItem()
             {
                 LastModifiedDate = new DateTime(),
                 CartId = 1,
                 ProductId = 4,
                 Quantity = 3,
                 Id = 4,
                 CreatedDate = new DateTime(),

             }
        );
    }
}
