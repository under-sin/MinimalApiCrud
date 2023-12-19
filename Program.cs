using Microsoft.AspNetCore.Mvc;
using MinimalApiCrud.Interfaces;
using MinimalApiCrud.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<ICarRepository, CarRepository>(); // Os builds devem ficar antes do builder.Build();

var app = builder.Build();

app.MapGet("/v1/car", ([FromServices]ICarRepository service) =>
{
    return service.GetCars();
});

app.Run();
