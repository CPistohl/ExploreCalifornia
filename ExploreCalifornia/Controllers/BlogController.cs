using ExploreCalifornia.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ExploreCalifornia.Controllers
{
	public class BlogController : Controller
	{
		public IActionResult Index()
		{
			Post[] model = new[]
			   {
				new Post
				{
					Title = "My blog post",
					Posted = DateTime.Now,
					Author = "Connor Pistohl",
					Body = "This is a great blog post"
				},

				new Post
				{
					Title = "My second blog post",
					Posted = DateTime.Now,
					Author = "Connor Pistohl",
					Body = "This is ANOTHER great blog post"
				}
			};

			return View(model);
		}

		[Route("blog/{year:min(2000)}/{month:range(1,12)}/{key}")]
		public IActionResult Post(int year, int month, string key)
		{
			return View();
		}
	}
}