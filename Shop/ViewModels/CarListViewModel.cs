using Shop.Data.Models;

namespace Shop.ViewModels;

public class CarListViewModel
{
	public IEnumerable<Car> AllCars { get; set; }

	public string currCategory { get; set; }	

}
