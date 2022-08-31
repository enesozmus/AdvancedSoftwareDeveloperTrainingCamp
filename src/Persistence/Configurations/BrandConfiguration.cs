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
               new(3, "Marka-3"),
               new(4, "Marka-4"),
               new(5, "Marka-5"),
               new(6, "Marka-6"),
               new(7, "Marka-7"),
               new(8, "Marka-8"),
               new(9, "Marka-9"),
               new(10, "Marka-10"),
               new(11, "Marka-11"),
               new(12, "Marka-12"),
               new(13, "Marka-13"),
               new(14, "Marka-14"),
               new(15, "Marka-15"),
               new(16, "Marka-16"),
               new(17, "Marka-17"),
               new(18, "Marka-18"),
          };

          builder.HasData(brandSeedDatas);

          #endregion
     }
}
