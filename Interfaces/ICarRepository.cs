using MinimalApiCrud.Models;

namespace MinimalApiCrud.Interfaces;

public interface ICarRepository
{
    IEnumerable<CarModels> GetCars();
}
