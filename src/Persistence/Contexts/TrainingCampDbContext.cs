using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Persistence.Configurations;

namespace Persistence.Contexts;

public class AdvancedSoftwareDeveloperTrainingCampDbContext : DbContext
{
     #region Ctor

     protected IConfiguration Configuration { get; set; }

     public AdvancedSoftwareDeveloperTrainingCampDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
          => Configuration = configuration;

     #endregion

     #region Entities

     public DbSet<Brand> Brands { get; set; }
     public DbSet<Model> Models { get; set; }

     #endregion

     #region SaveChangesAsync

     public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
     {
          foreach (var entry in ChangeTracker.Entries<BaseEntity>())
          {
               switch (entry.State)
               {
                    case EntityState.Added:
                         entry.Entity.CreatedDate = DateTime.Now;

                         break;
                    case EntityState.Modified:
                         entry.Entity.LastModifiedDate = DateTime.Now;
                         break;
               }
          }
          return base.SaveChangesAsync(cancellationToken);
     }

     #endregion

     #region Configurations

     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
     {
          //if (!optionsBuilder.IsConfigured)
          //    base.OnConfiguring(
          //        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SomeConnectionString")));
     }

     protected override void OnModelCreating(ModelBuilder modelBuilder)
     {
          modelBuilder.ApplyConfiguration(new BrandConfiguration());
          modelBuilder.ApplyConfiguration(new ModelConfiguration());

          base.OnModelCreating(modelBuilder);
     }

     #endregion
}
