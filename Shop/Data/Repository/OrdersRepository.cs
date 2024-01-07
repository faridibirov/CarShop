using Shop.Data.Interfaces;
using Shop.Data.Models;

namespace Shop.Data.Repository;

public class OrdersRepository : IAllOrders
{
	private readonly AppDBContext _dbContext;
	private readonly ShopCart _shopCart;

	public OrdersRepository(AppDBContext dbContext, ShopCart shopCart)
	{
		_dbContext = dbContext;
		_shopCart = shopCart;
	}

	public void CreateOrder(Order order)
	{
		order.Ordertime = DateTime.Now;
		_dbContext.Order.Add(order);
		_dbContext.SaveChanges();
		var items = _shopCart.listShopItems;

		foreach (var el in items)
		{
			var orderDetail = new OrderDetail()
			{
				CarId = el.Car.Id,
				OrderId= order.Id,
				Price = el.Car.Price
			};
			_dbContext.OrderDetail.Add(orderDetail);
		}
		_dbContext.SaveChanges();
	}
}
