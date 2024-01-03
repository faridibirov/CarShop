using Shop.Data.Models;

namespace Shop.Data.Interfaces;

public interface IAllCars
{
    IEnumerable<Car> AllCars { get; }
    IEnumerable<Car> getFavCars { get;}
    Car getObjectCar(int carId); 

}
