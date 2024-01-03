using Shop.Data.Models;

namespace Shop.Data;

public class DBObjects
{
	public static void Intial(AppDBContext context)
	{

		if (!context.Category.Any())
		{
			context.Category.AddRange(Categories.Select(c => c.Value));
		}

		if (!context.Car.Any())
		{
			context.AddRange(
				 new Car
				 {
					 Name = "Tesla Model S",
					 shortDesc = "Быстрый Автомобиль",
					 longDesc = "Красивый, быстрый и очень тихий автомобиль компании Tesla",
					 Img = "/img/tesla.jpg",
					 Price = 45000,
					 isFavorite = true,
					 isAvailable = true,
					 Category = Categories["Электромобили"]
				 },
				  new Car
				  {
					  Name = "Tesla Model S",
					  shortDesc = "Быстрый Автомобиль",
					  longDesc = "Красивый, быстрый и очень тихий автомобиль компании Tesla",
					  Img = "/img/tesla.jpg",
					  Price = 45000,
					  isFavorite = true,
					  isAvailable = true,
					  Category = Categories["Электромобили"]
				  },
				   new Car
				   {
					   Name = "Tesla Model S",
					   shortDesc = "Быстрый Автомобиль",
					   longDesc = "Красивый, быстрый и очень тихий автомобиль компании Tesla",
					   Img = "/img/tesla.jpg",
					   Price = 45000,
					   isFavorite = true,
					   isAvailable = true,
					   Category = Categories["Электромобили"]
				   },
					new Car
					{
						Name = "Tesla Model S",
						shortDesc = "Быстрый Автомобиль",
						longDesc = "Красивый, быстрый и очень тихий автомобиль компании Tesla",
						Img = "/img/tesla.jpg",
						Price = 45000,
						isFavorite = true,
						isAvailable = true,
						Category = Categories["Электромобили"]
					},
					 new Car
					 {
						 Name = "Tesla Model S",
						 shortDesc = "Быстрый Автомобиль",
						 longDesc = "Красивый, быстрый и очень тихий автомобиль компании Tesla",
						 Img = "/img/tesla.jpg",
						 Price = 45000,
						 isFavorite = true,
						 isAvailable = true,
						 Category = Categories["Электромобили"]
					 }
				);	

		}
		context.SaveChanges();
	}

	private static Dictionary<string, Category> category;
	public static Dictionary<string, Category> Categories
	{

		get
		{
			if (category == null)
			{
				var list = new Category[] {

					new Category {categoryName="Электромобили", categoryDescription="Современный вид транспорта"},
					new Category {categoryName="Классические автомобили", categoryDescription="Машини с двигателем внутреннего згорания"},
				};

				category = new Dictionary<string, Category>();

				foreach (Category el in list)
				{
					category.Add(el.categoryName, el);
				}

			}

			return category;
		}
	}
}
