using Application.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence;

public static class PersistenceServiceRegistration
{
     public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services,
          IConfiguration configuration)
     {
          #region Microsoft SQL Server

          services.AddDbContext<AdvancedSoftwareDeveloperTrainingCampDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("TrainingCampConnection")));

          #endregion

          #region Repositories

          // Biri senden Interface'i isterse ona şu Class'ı ver
          services.AddScoped<IBrandReadRepository, BrandReadRepository>();
          services.AddScoped<IBrandWriteRepository, BrandWriteRepository>();

          #endregion

          return services;
     }
}
