using System.Data;
using Dapper;
using MinimalApiCrud.Factory;
using MinimalApiCrud.Interfaces;
using MinimalApiCrud.Models;

namespace MinimalApiCrud.Repositories;

public class CarRepository : ICarRepository
{
    private readonly IDbConnection _connection;
    public CarRepository()
    {
        _connection = new SqlFactory().SqlConnection();
    }

    public IEnumerable<CarModels> GetCars()
    {
        var cars = new List<CarModels>();
        var query = "SELECT * FROM [CarDataBase].[dbo].[Cars]";

        using (_connection)
        {
            cars = _connection.Query<CarModels>(query).ToList();
        }

        return cars;
    }
}
