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

          builder.HasMany(x => x.Models)
                    .WithOne(x => x.Brand )
                    .HasForeignKey(x => x.BrandId)
                    .OnDelete(DeleteBehavior.Restrict);

          #endregion

          #region SeedDatas

          Brand[] brandSeedDatas = {
               new(1, new DateTime(2022, 09, 07), "Marka-1"),
               new(2, new DateTime(2022, 09, 07), "Marka-2"),
               new(3, new DateTime(2022, 09, 07), "Marka-3"),
               new(4, new DateTime(2022, 09, 07), "Marka-4"),
               new(5, new DateTime(2022, 09, 07), "Marka-5"),
               new(6, new DateTime(2022, 09, 07), "Marka-6"),
               new(7, new DateTime(2022, 09, 07), "Marka-7"),
               new(8, new DateTime(2022, 09, 07), "Marka-8"),
               new(9, new DateTime(2022, 09, 07), "Marka-9"),
               new(10, new DateTime(2022, 09, 07), "Marka-10"),
               new(11, new DateTime(2022, 09, 07), "Marka-11"),
               new(12, new DateTime(2022, 09, 07), "Marka-12"),
               new(13, new DateTime(2022, 09, 07), "Marka-13"),
               new(14, new DateTime(2022, 09, 07), "Marka-14"),
               new(15, new DateTime(2022, 09, 07), "Marka-15"),
               new(16, new DateTime(2022, 09, 07), "Marka-16"),
               new(17, new DateTime(2022, 09, 07), "Marka-17"),
               new(18, new DateTime(2022, 09, 07), "Marka-18"),
          };

          builder.HasData(brandSeedDatas);

          #endregion
     }
}
