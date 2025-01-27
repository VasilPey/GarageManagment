using Microsoft.EntityFrameworkCore;
using GarageManagment.DBContext;
using Microsoft.Extensions.DependencyInjection;
using GarageManagment.Services;
using GarageManagment.Services.Impl;
using GarageManagment.Repositories.Impl;
using GarageManagment.Repositories;

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
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
