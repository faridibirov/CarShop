using Shop.Data.Interfaces;
using Shop.Data.Models;

namespace Shop.Data.Repository;

public class CategoryRepository : ICarsCategory
{
	private readonly AppDBContext _dbContext;

	public CategoryRepository(AppDBContext dbContext)
	{
		_dbContext = dbContext;
	}

	public IEnumerable<Category> Allcategories => _dbContext.Category;
}
