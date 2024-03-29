﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.Data.Repository;

namespace Shop
{

	public class Startup
	{

		private IConfigurationRoot _confString;

		public Startup(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostEnv)
		{
			_confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
		}

		public void ConfigureServices(IServiceCollection services)
		{
			
			services.AddDbContext<AppDBContext>(options => options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));
			services.AddDefaultIdentity<DefaultUser>().AddEntityFrameworkStores<AppDBContext>();
			services.AddTransient<IAllCars, CarRepository>();
			services.AddTransient<ICarsCategory, CategoryRepository>();
			services.AddTransient<IAllOrders, OrdersRepository>();

			services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
			services.AddScoped(sp => ShopCart.GetCart(sp));

			//services.AddAuthentication();
			//services.AddAuthorization();

			services.AddMvc(option => option.EnableEndpointRouting = false);
			services.AddMemoryCache();
			services.AddSession();
		}

		public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
		{
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseDeveloperExceptionPage();
			app.UseStatusCodePages();
			app.UseStaticFiles();
			app.UseSession();
			//app.UseMvcWithDefaultRoute();
			app.UseMvc(routes =>
			{
				routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
				routes.MapRoute(name: "categoryFilter", template: "Car/{action}/{category?}", defaults: new {Controller="Car", action="List"});
			});

			

			using (var scope = app.ApplicationServices.CreateScope())
			{
				AppDBContext context = scope.ServiceProvider.GetRequiredService<AppDBContext>();
				DBObjects.Intial(context);
			}
		}
	}
}

