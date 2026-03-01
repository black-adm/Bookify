using Bookify.Application;
using Bookify.Infrastructure;
using Bookify.WebApi.Extensions;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddApplication();

builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.MapScalarApiReference();

    app.ApplyMigrations();

    app.SeedData();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
