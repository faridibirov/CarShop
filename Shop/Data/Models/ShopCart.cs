using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;

namespace Shop.Data.Models; 

public class ShopCart
{
	private readonly AppDBContext _dbContext;

	public ShopCart(AppDBContext dbContext)
	{
		_dbContext = dbContext;
	}

	public string ShopCartId { get; set; }

	public List<ShopCartItem> listShopItems { get; set; }

	public static ShopCart GetCart (IServiceProvider services)
	{
		ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

		var context = services.GetService<AppDBContext>();

		string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

		session.SetString("CartId", shopCartId);

		return new ShopCart (context) { ShopCartId = shopCartId, };
	}

	public void AddToCart(Car car)
	{
		_dbContext.ShopCartItem.Add(new ShopCartItem
		{
			ShopCartId = ShopCartId,
			Car = car,
			Price = car.Price
		}) ;

		_dbContext.SaveChanges();
	}

	public List<ShopCartItem> getShopItems ()
	{
		return _dbContext.ShopCartItem.Where(c=>c.ShopCartId== ShopCartId).Include(s=>s.Car).ToList();
	}
}
