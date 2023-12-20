using MinimalApiCrud.Model;

namespace MinimalApiCrud.Interfaces;

public interface ICarRepository
{
    IEnumerable<CarModel> GetCars();
    bool InsertCar(CarModel car);
    bool UpdateCarCor(int id, string cor);
    bool Delete(int id);
}
