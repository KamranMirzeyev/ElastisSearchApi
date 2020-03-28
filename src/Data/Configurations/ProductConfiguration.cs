using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
      
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.
                    HasKey(x => x.Id);


            builder
                .Property(c => c.Id)
                .UseNpgsqlIdentityColumn();

            builder
               .Property(m => m.Status)
               .IsRequired()
               .HasDefaultValue(true);

            builder
                .Property(x => x.ProductName).IsRequired().HasMaxLength(250);

            builder
                .Property(x => x.Quantity).IsRequired();
            builder
                .Property(x => x.Photo).IsRequired().HasMaxLength(150);
            builder
                .Property(x => x.Status).IsRequired();

            builder
                .Property(x => x.IsActive).IsRequired();

            builder
              .ToTable("Products");
        }
    }
}