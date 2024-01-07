﻿using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.ViewModels;

namespace Shop.Controllers;

public class HomeController : Controller
{
	private readonly IAllCars _carRep;

	public HomeController(IAllCars carRep)
	{
		_carRep = carRep;

	}

	public ViewResult Index ()
	{
		var homeCars = new HomeViewModel
		{
			favCars = _carRep.getFavCars
		};


        ViewBag.Title = "Главная";

        return View(homeCars);


	}

}
