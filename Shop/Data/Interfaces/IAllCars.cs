using Shop.Data.Models;

namespace Shop.Data.Interfaces;

public interface IAllCars
{
    IEnumerable<Car> AllCars { get; }
    IEnumerable<Car> getFavCars { get; set; }
    Car getObjectCar(int carId); 

}
