using Shop.Data.Interfaces;
using Shop.Data.Models;

namespace Shop.Data.Mocks;

public class MockCars : IAllCars
{
    private readonly ICarsCategory _categoryCars = new MockCategory(); 
    public IEnumerable<Car> AllCars
    {
        get
        {
            return new List<Car>
            {
                new Car { Name = "Tesla", shortDesc = "", longDesc = "", Img = "", Price = 45000, isFavorite = true, isAvailable = true, Category= _categoryCars.Allcategories.First() },
            };
        }
    }
    public IEnumerable<Car> getFavCars { get; set; }

    public Car getObjectCar(int carId)
    {
        throw new NotImplementedException();
    }
}
