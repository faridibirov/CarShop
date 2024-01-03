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
                new Car { 
                    Name = "Tesla Model S",
                    shortDesc = "Быстрый Автомобиль", 
                    longDesc = "Красивый, быстрый и очень тихий автомобиль компании Tesla", 
                    Img = "/img/tesla.jpg", 
                    Price = 45000, 
                    isFavorite = true, 
                    isAvailable = true, 
                    Category= _categoryCars.Allcategories.First() 
                },
					 new Car {
					Name = "Tesla Model S",
					shortDesc = "Быстрый Автомобиль",
					longDesc = "Красивый, быстрый и очень тихий автомобиль компании Tesla",
					Img = "/img/tesla.jpg",
					Price = 45000,
					isFavorite = true,
					isAvailable = true,
					Category= _categoryCars.Allcategories.First()
				},
				    new Car {
					Name = "Tesla Model S",
					shortDesc = "Быстрый Автомобиль",
					longDesc = "Красивый, быстрый и очень тихий автомобиль компании Tesla",
					Img = "/img/tesla.jpg",
					Price = 45000,
					isFavorite = true,
					isAvailable = true,
					Category= _categoryCars.Allcategories.First()
				},
					 new Car {
					Name = "Tesla Model S",
					shortDesc = "Быстрый Автомобиль",
					longDesc = "Красивый, быстрый и очень тихий автомобиль компании Tesla",
					Img = "/img/tesla.jpg",
					Price = 45000,
					isFavorite = true,
					isAvailable = true,
					Category= _categoryCars.Allcategories.First()
				},
					 new Car {
					Name = "Tesla Model S",
					shortDesc = "Быстрый Автомобиль",
					longDesc = "Красивый, быстрый и очень тихий автомобиль компании Tesla",
					Img = "/img/tesla.jpg",
					Price = 45000,
					isFavorite = true,
					isAvailable = true,
					Category= _categoryCars.Allcategories.First()
				},
			};
        }
    }
    public IEnumerable<Car> getFavCars { get; set; }

    public Car getObjectCar(int carId)
    {
        throw new NotImplementedException();
    }
}
