using System.Linq;
using ExploreCalifornia.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExploreCalifornia.ViewComponents
{
	public class MonthlySpecials : ViewComponent
	{
		private readonly DatabaseContext _databse;

		public MonthlySpecials(DatabaseContext database)
		{
			_databse = database;
		}

		public IViewComponentResult Invoke()
		{
			System.Collections.Generic.IEnumerable<Special> specials = _databse.Specials.ToArray();
			return View(specials);
		}
	}
}
