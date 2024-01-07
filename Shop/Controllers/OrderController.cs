using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;

namespace Shop.Controllers;

public class OrderController : Controller
{
	private readonly IAllOrders _allOrders;
	private readonly ShopCart _shopCart;

	public OrderController(IAllOrders allOrders, ShopCart shopCart)
	{
		_allOrders = allOrders;
		_shopCart = shopCart;
	}

	public IActionResult Checkout()
	{
        ViewBag.Title = "Заказ";
        return View();
	}

	[HttpPost]
	public IActionResult Checkout(Order order)
	{
		_shopCart.listShopItems = _shopCart.getShopItems();

		ModelState.Remove("orderDetails");
		if (ModelState.IsValid)
		{
			_allOrders.CreateOrder(order);
			return RedirectToAction("Complete");
		}

        ViewBag.Title = "Заказ";

        return View(order);
	}

	public IActionResult Complete()
	{
		ViewBag.Message = "Заказ успешно отправлен";

        ViewBag.Title = "Заказ";


        return View();
	}
}
