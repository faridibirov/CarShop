using Microsoft.EntityFrameworkCore;
using Shop.Data.Models;

namespace Shop.Data;

public class AppDBContext : DbContext
{
	public AppDBContext(DbContextOptions<AppDBContext> optons) : base(optons)
	{

	}

	public DbSet<Car> Car { get; set; }
	public DbSet<Category> Category { get; set; }
}
