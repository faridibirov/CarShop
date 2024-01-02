using Shop.Data.Models;

namespace Shop.Data.Interfaces;

public interface IAllCars
{
    IEnumerable<Car> AllCars { get; set; }
    IEnumerable<Car> getFavCars { get; set; }
    Car getObjectCar(int carId); 

}
