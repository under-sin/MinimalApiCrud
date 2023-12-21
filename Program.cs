using Microsoft.AspNetCore.Mvc;
using MinimalApiCrud.Interfaces;
using MinimalApiCrud.Model;
using MinimalApiCrud.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<ICarRepository, CarRepository>(); // Os builds devem ficar antes do builder.Build();

var app = builder.Build();

app.MapGet("/v1/car", ([FromServices] ICarRepository repository) =>
{
    return repository.GetCars();
});

app.MapPost("v1/car", ([FromServices] ICarRepository repository, CarModel car) =>
{
    var result = repository.InsertCar(car);

    return (result
        ? Results.Ok($"Carro {car.Modelo} inserido com sucesso")
        : Results.BadRequest("Não foi possível inserir o carro")
    );
});

app.MapPut("v1/car", ([FromServices] ICarRepository repository, int id, string cor) =>
{
    var result = repository.UpdateCarCor(id, cor);

    return (result
        ? Results.Ok($"Cor atualizada com sucesso")
        : Results.BadRequest("Não foi possível alterar a cor")
    );
});

app.MapDelete("v1/car", ([FromServices] ICarRepository repository, int id) =>
{
    var result = repository.Delete(id);

    return (result
        ? Results.Ok($"Carro removido com sucesso")
        : Results.BadRequest("Não foi possível remover o carro")
    );
});

app.Run();
