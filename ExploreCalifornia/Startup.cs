using ExploreCalifornia.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ExploreCalifornia
{
	public class Startup
	{
		private readonly IConfigurationRoot configuration;

		public Startup(IHostingEnvironment env)
		{
			configuration = new ConfigurationBuilder()
				.AddEnvironmentVariables()
				.AddJsonFile(env.ContentRootPath + "/config.json")
				.AddJsonFile(env.ContentRootPath + "/config.development.json", true)
				.Build();
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddTransient<SpecialsDataContext>();
			services.AddTransient<FormattingService>();

			services.AddDbContext<DatabaseContext>(options => {
				var connectionString = configuration.GetConnectionString("BlogDataContext");
				options.UseSqlServer(connectionString);
			});
			services.AddMvc();
			services.AddRouting();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (configuration.GetValue<bool>("FeatureToggles:EnableDeveloperExceptions"))
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/error.htm");
			}

			app.Use(async (context, next) =>
			{
				if (context.Request.Path.Value.Contains("invalid"))
				{
					throw new Exception("Error!");
				}

				await next();
			});
			app.UseStaticFiles();

			app.UseMvc(route =>
			{
				route.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
