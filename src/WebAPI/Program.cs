using Application;
using CrossCuttingConcerns.Exceptions;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

#region Layers

builder.Services.ConfigurePersistenceServices(builder.Configuration);
builder.Services.ConfigureApplicationServices();

#endregion

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
     app.UseSwagger();
     app.UseSwaggerUI();
}

//if (app.Environment.IsProduction())
//     app.ConfigureCustomExceptionMiddleware();

app.ConfigureCustomExceptionMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
