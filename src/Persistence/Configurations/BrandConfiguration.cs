using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
     public void Configure(EntityTypeBuilder<Brand> builder)
     {
          #region Configurations

          builder.Property(x => x.Name).HasMaxLength(20).IsRequired();

          #endregion

          #region ForeingKey

          //builder.HasMany(x => x.Products)
          //            .WithOne(x => x.Brand)
          //            .HasForeignKey(x => x.BrandId)
          //            .IsRequired(false)
          //            .OnDelete(DeleteBehavior.Restrict);

          #endregion

          #region SeedDatas

          Brand[] brandSeedDatas = {
               new(1, "Marka-1"),
               new(2, "Marka-2"),
               new(3, "Marka-3")
          };

          builder.HasData(brandSeedDatas);

          #endregion
     }
}
