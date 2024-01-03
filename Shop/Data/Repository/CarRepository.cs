using Microsoft.EntityFrameworkCore;
using Shop.Data.Interfaces;
using Shop.Data.Models;

namespace Shop.Data.Repository;

public class CarRepository : IAllCars
{
	private readonly AppDBContext _dbContext;

	public CarRepository(AppDBContext dbContext)
	{
		_dbContext = dbContext;
	}

	public IEnumerable<Car> AllCars => _dbContext.Car.Include(c => c.Category);

	public IEnumerable<Car> getFavCars => _dbContext.Car.Where(p => p.isFavorite).Include(c => c.Category);


	public Car getObjectCar(int carId) => _dbContext.Car.FirstOrDefault(p=>p.Id==carId);

}
