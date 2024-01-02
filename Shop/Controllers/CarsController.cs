using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
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


    public ViewResult List ()
    {
        ViewBag.Title = "Страница с Автомобилями";
        CarListViewModel obj = new CarListViewModel ();
        obj.AllCars = _allCars.AllCars;
        obj.currCategory = "Автомобили";

        return View(obj);
    }
}
