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
					  Name = "Nissan Leaf",
					  shortDesc = "Безшумный и экономный",
					  longDesc = "Удобный автомобиль для городской жизни",
					  Img = "/img/nissan.jpg",
					  Price = 14000,
					  isFavorite = false,
					  isAvailable = true,
					  Category = Categories["Электромобили"]
				  },
				   new Car
				   {
					   Name = "BMW M5",
					   shortDesc = "Дерзкий и стильный",
					   longDesc = "Удобный автомобиль для городской жизни",
					   Img = "/img/bmw.jpg",
					   Price = 65000,
					   isFavorite = true,
					   isAvailable = true,
					   Category = Categories["Классические автомобили"]
				   },
					new Car
					{
						Name = "Mercedes C63 AMG",
						shortDesc = "Уютный и большой",
						longDesc = "Удобный автомобиль для городской жизни",
						Img = "/img/mercedes.jpg",
						Price = 40000,
						isFavorite = true,
						isAvailable = true,
						Category = Categories["Классические автомобили"]
					},
					 new Car
					 {
						 Name = "Ford Mustang",
						 shortDesc = "Спортнивый автомобиль",
						 longDesc = "Удобный автомобиль для городской жизни",
						 Img = "/img/mustang.jpg",
						 Price = 35000,
						 isFavorite = true,
						 isAvailable = true,
						 Category = Categories["Классические автомобили"]
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
