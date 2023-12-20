﻿using System.Data;
using Dapper;
using MinimalApiCrud.Factory;
using MinimalApiCrud.Interfaces;
using MinimalApiCrud.Model;

namespace MinimalApiCrud.Repositories;

public class CarRepository : ICarRepository
{
    private readonly IDbConnection _connection;
    public CarRepository()
    {
        _connection = new SqlFactory().SqlConnection();
    }

    public IEnumerable<CarModel> GetCars()
    {
        var cars = new List<CarModel>();
        var query = "SELECT * FROM [CarDataBase].[dbo].[Cars]";

        using (_connection)
        {
            cars = _connection.Query<CarModel>(query).ToList();
        }

        return cars;
    }

    public bool InsertCar(CarModel car)
    {
        var query = @"INSERT INTO [CarDataBase].[dbo].[Cars]
        VALUES
        (
            @modelo,
            @fabricante,
            @motor,
            @cor
        )";
        var parameters = new
        {
            modelo = car.Modelo,
            fabrincante = car.Fabricante,
            motor = car.Motor,
            cor = car.Cor
        };
        var result = 0;

        using (_connection)
        {
            result = _connection.Execute(query, parameters);
        }

        return (result != 0 ? true : false);
    }

    public bool UpdateCarCor(int id, string cor)
    {
        var query = @"UPDATE [CarDataBase].[dbo].[Cars]
        SET [Cor] = @corCarro
        WHERE [Id] = @carId";
        var parameters = new
        {
            carId = id,
            corCarro = cor
        };
        var result = 0;

        using (_connection)
        {
            result = _connection.Execute(query, parameters);
        }

        return (result != 0 ? true : false);
    }

    public bool Delete(int id)
    {
        var query = "DELETE [CarDataBase].[dbo].[Cars] WHERE [Id] = @carId";
        var parameters = new { carId = id };
        int result = 0;

        using (_connection)
        {
            result = _connection.Execute(query, parameters);
        }

        return (result != 0 ? true : false);
    }
}
