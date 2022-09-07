using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class ModelConfiguration : IEntityTypeConfiguration<Model>
{
     public void Configure(EntityTypeBuilder<Model> builder)
     {
          #region Configurations

          builder.Property(x => x.Name).HasMaxLength(20).IsRequired();
          builder.Property(x => x.DailyPrice).IsRequired();

          #endregion

          #region ForeingKey

          #endregion

          #region SeedDatas

          Model[] modelSeedDatas = {
               new(1, 2, new DateTime(2022, 09, 07), "Model-1", 200),
               new(2, 2, new DateTime(2022, 09, 07), "Model-2", 200),
               new(3, 2, new DateTime(2022, 09, 07), "Model-3", 700),
               new(4, 2, new DateTime(2022, 09, 07), "Model-4", 200),
               new(5, 5, new DateTime(2022, 09, 07), "Model-5", 200),
               new(6, 5, new DateTime(2022, 09, 07), "Model-6", 500),
               new(7, 6, new DateTime(2022, 09, 07), "Model-7", 500),
               new(8, 6, new DateTime(2022, 09, 07), "Model-8", 900),
               new(9, 7, new DateTime(2022, 09, 07), "Model-9", 200),
               new(10, 8, new DateTime(2022, 09, 07), "Model-10", 300),
               new(11, 8, new DateTime(2022, 09, 07), "Model-11", 300),
               new(12, 3, new DateTime(2022, 09, 07), "Model-12", 300),
               new(13, 3, new DateTime(2022, 09, 07), "Model-13", 300),
               new(14, 3, new DateTime(2022, 09, 07), "Model-14", 400),
               new(15, 4, new DateTime(2022, 09, 07), "Model-15", 400),
               new(16, 4, new DateTime(2022, 09, 07), "Model-16", 400),
               new(17, 4, new DateTime(2022, 09, 07), "Model-17", 300),
               new(18, 4, new DateTime(2022, 09, 07), "Model-18", 300),
          };

          builder.HasData(modelSeedDatas);

          #endregion
     }
}
