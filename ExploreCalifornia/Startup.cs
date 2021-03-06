﻿using System;
using ExploreCalifornia.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddTransient<FormattingService>();

			services.AddTransient(x => new FeatureToggles
			{
				EnableDeveloperExceptions =
					configuration.GetValue<bool>("FeatureToggles:EnableDeveloperExceptions")
			});

			services.AddDbContext<DatabaseContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("DataBaseContext")));

			services.AddDbContext<IdentityDataContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("IdentityDataContext")));

			services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<IdentityDataContext>();

			services.AddMvc();
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env, FeatureToggles features)
		{
			app.UseExceptionHandler("/error.html");

			// configuration.GetValue<bool>("FeatureToggles:EnableDeveloperExceptions")
			if (features.EnableDeveloperExceptions)
			{
				app.UseDeveloperExceptionPage();
			}

			app.Use(async (context, next) =>
			{
				if (context.Request.Path.Value.Contains("invalid"))
				{
					throw new Exception("Error!");
				}

				await next();
			});

			app.UseIdentity();

			app.UseMvc(route =>
			{
				route.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");
			});

			app.UseFileServer();
		}
	}
}
