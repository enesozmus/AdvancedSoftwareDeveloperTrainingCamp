using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;

namespace Persistence;

public static class PersistenceServiceRegistration
{
     public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services,
          IConfiguration configuration)
     {
          #region Microsoft SQL Server

          services.AddDbContext<TrainingCampDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("TrainingCampConnection")));

          #endregion

          #region Repositories

          // Biri senden Interface'i isterse ona şu Class'ı ver
          //services.AddScoped<IBrandRepository, BrandRepository>();

          #endregion

          return services;
     }
}
