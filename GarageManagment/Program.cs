using Microsoft.EntityFrameworkCore;
using GarageManagment.DBContext;
using Microsoft.Extensions.DependencyInjection;
using GarageManagment.Services;
using GarageManagment.Services.Impl;
using GarageManagment.Repositories.Impl;
using GarageManagment.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using GarageManagment.Validators;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("MyInMemoryDb"));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICarRepository, CarRepositoryImpl>();
builder.Services.AddScoped<ICarService, CarServiceImpl>();
builder.Services.AddScoped<IGarageService, GarageServiceImpl>();
builder.Services.AddScoped<IGarageRepository, GarageRepositoryImpl>();
builder.Services
    .AddValidatorsFromAssemblyContaining<CarValidator>()
    .AddValidatorsFromAssemblyContaining<GarageValidators>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddHealthChecks();

var logger = new LoggerConfiguration()
               .Enrich.FromLogContext()
               .WriteTo.Console(theme:
                   AnsiConsoleTheme.Code)
               .CreateLogger();

builder.Logging.AddSerilog(logger);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapHealthChecks("/health");
app.UseAuthorization();

app.MapControllers();

app.Run();
