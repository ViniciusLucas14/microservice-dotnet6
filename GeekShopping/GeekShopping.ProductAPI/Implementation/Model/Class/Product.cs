using GeekShopping.ProductAPI.Implementation.Model.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeekShopping.ProductAPI.Implementation.Model.Class
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public IList<Category> Categories { get; set; }
    }

    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(120);
            builder.Property(x => x.Price).HasPrecision(19, 4);
            builder.Property(x => x.Description).HasMaxLength(300);
            builder.Property(x => x.ImageUrl).HasMaxLength(300);
        }
    }
}
