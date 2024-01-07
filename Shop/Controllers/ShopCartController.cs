﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.ViewModels;

namespace Shop.Controllers;

[Authorize]
public class ShopCartController : Controller
{
	private readonly IAllCars _carRep;
	private readonly ShopCart _shopCart;

	public ShopCartController(IAllCars carRep, ShopCart shopCart)
	{
		_carRep = carRep;
		_shopCart = shopCart;
	}

	public ViewResult Index()
	{
		var items = _shopCart.getShopItems();

		_shopCart.listShopItems = items;

		var obj = new ShopCartViewModel
		{
			shopCart = _shopCart,
		};
        ViewBag.Title = "Корзина";
        return View(obj);
	}

	public RedirectToActionResult addToCart(int id)
	{
		var item = _carRep.AllCars.FirstOrDefault(x => x.Id == id);

		if (item != null)
		{
			_shopCart.AddToCart(item);
		}
        

        return RedirectToAction("Index");
	}

}
