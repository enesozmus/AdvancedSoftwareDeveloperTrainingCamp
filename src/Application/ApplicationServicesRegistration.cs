using Application.Features.BrandOperations;
using Application.Pipelines.Validation;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application;

public static class ApplicationServicesRegistration
{
     public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
     {
          // MediatR
          services.AddMediatR(Assembly.GetExecutingAssembly());

          // AutoMapper
          services.AddAutoMapper(Assembly.GetExecutingAssembly());

          // FluentValidation
          services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
          services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

          // BusinessRules
          services.AddScoped<BrandBusinessRules>();

          //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
          //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
          //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CacheRemovingBehavior<,>));
          //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
          //

          return services;
     }
}
