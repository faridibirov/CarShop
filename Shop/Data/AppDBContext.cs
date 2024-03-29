﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shop.Data.Models;

namespace Shop.Data;

public class AppDBContext : IdentityDbContext<DefaultUser>
{
	public AppDBContext(DbContextOptions<AppDBContext> optons) : base(optons)
	{

	}

	public DbSet<Car> Car { get; set; }
	public DbSet<Category> Category { get; set; }
	public DbSet<ShopCartItem> ShopCartItem { get; set; }
	public DbSet<Order> Order { get; set; }
	public DbSet<OrderDetail> OrderDetail { get; set; }
}
