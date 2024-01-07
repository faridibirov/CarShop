using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.ViewModels;

namespace Shop.Controllers;

public class CarsController : Controller
{
    private readonly IAllCars _allCars;
    private readonly ICarsCategory _allCategories;

    public CarsController (IAllCars allCars, ICarsCategory allCategories)
    {
        _allCars = allCars;
        _allCategories = allCategories;
    }

    [Route("Cars/List")]
    [Route("Cars/List/{category}")]
    public ViewResult List (string category)
    {
        string _category = category;
        IEnumerable<Car> cars = null ;
        string currCategory = "";
        if(string.IsNullOrEmpty(category))
        {
            cars = _allCars.AllCars.OrderBy(i => i.Id);
            ViewBag.Title = "Все Автомобили";
        }
        else
        {
            if (string.Equals("electro", category, StringComparison.OrdinalIgnoreCase))
            {
                cars = _allCars.AllCars.Where(i => i.Category.categoryName.Equals("Электромобили")).OrderBy(i => i.Id);
				currCategory = "Электромобили";
                ViewBag.Title = "Электромобили";
            }

            else if (string.Equals("fuel", category, StringComparison.OrdinalIgnoreCase))
			{
				cars = _allCars.AllCars.Where(i => i.Category.categoryName.Equals("Классические автомобили")).OrderBy(i => i.Id);
				currCategory = "Классические Автомобили";
                ViewBag.Title = "Классические Автомобили";
            }

          
		}

        var carObj = new CarListViewModel
        {
            AllCars = cars,
            currCategory = currCategory,
        };

        

        return View(carObj);
    }
}
