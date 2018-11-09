using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreCalifornia.Models
{
	public class Special
	{
		public string Key { get; set; }
		public string Name { get; set; }
		public string Type { get; set; }
		public int Price { get; set; }
	}

	public class SpecialsDataContext
	{
		public IEnumerable<Special> GetMonthlySpecials()
		{
			return new[]
			{
				new Special
				{
					Key = "calm",
					Name = "California Calm",
					Type = "Day Spa Package",
					Price = 250
				},

				new Special
				{
					Key = "desert",
					Name = "From Desert to Sea",
					Type = "2 Day Salton Sea",
					Price = 350
				},

				new Special
				{
					Key = "back",
					Name = "Backpack Cali",
					Type = "Bis Sur Retreat",
					Price = 620
				},

				new Special
				{
					Key = "taste",
					Name = "Taste of California",
					Type = "Tapas & Groves",
					Price = 150
				}
			};
		}
	}
}
