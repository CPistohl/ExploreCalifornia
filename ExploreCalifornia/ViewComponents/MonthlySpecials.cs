using ExploreCalifornia.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExploreCalifornia.ViewComponents
{
	public class MonthlySpecials : ViewComponent
	{
		private readonly SpecialsDataContext _specials;

		public MonthlySpecials(SpecialsDataContext specials)
		{
			_specials = specials;
		}

		public IViewComponentResult Invoke()
		{
			var specials = _specials.GetMonthlySpecials();
			return View(specials);
		}
	}
}
