using ExploreCalifornia.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ExploreCalifornia.Controllers
{
	public class BlogController : Controller
	{
		//private readonly DatabaseContext _database;

		//public BlogController(DatabaseContext database)
		//{
		//	_database = database;
		//}

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

		//[Route("Blog/{year:min(2000)}/{month:range(1,12)}/{key}")]
		public IActionResult Post(int year, int month, string key)
		{
			return View();
		}

		public IActionResult Create()
		{
			return View();
		}


		//public IActionResult Create(Post post)
		//{
		//	if (!ModelState.IsValid)
		//	{
		//		return View();
		//	}
		//	post.Author = User.Identity.Name;
		//	post.Posted = DateTime.Now;

		//	_database.Posts.Add(post);
		//	_database.SaveChanges();

		//	return View();

		//}
	}
}