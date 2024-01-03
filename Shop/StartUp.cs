using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Data.Interfaces;
using Shop.Data.Mocks;
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
			services.AddTransient<IAllCars, CarRepository>();
			services.AddTransient<ICarsCategory, CategoryRepository>();
			services.AddMvc(option => option.EnableEndpointRouting = false);
		}

		public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
		{
			app.UseDeveloperExceptionPage();
			app.UseStatusCodePages();
			app.UseStaticFiles();
			app.UseMvcWithDefaultRoute();


			using (var scope = app.ApplicationServices.CreateScope())
			{
				AppDBContext context = scope.ServiceProvider.GetRequiredService<AppDBContext>();
				DBObjects.Intial(context);
			}
		}
	}
}

