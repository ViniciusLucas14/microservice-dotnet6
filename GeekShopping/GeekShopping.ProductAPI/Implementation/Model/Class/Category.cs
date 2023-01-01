using GeekShopping.ProductAPI.Implementation.Model.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeekShopping.ProductAPI.Implementation.Model.Class
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public IList<Product> Products { get; set; }    
    }
    public class CategoryConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(100);
        }
    }
}
