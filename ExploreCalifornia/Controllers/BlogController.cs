using System;
using System.Linq;
using ExploreCalifornia.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExploreCalifornia.Controllers
{
	[Route("blog")]
	public class BlogController : Controller
	{
		private readonly DatabaseContext _database;

		public BlogController(DatabaseContext database)
		{
			_database = database;
		}

		[Route("")]
		public IActionResult Index()
		{
			var posts = _database.Posts.OrderByDescending(x => x.Posted).Take(5).ToArray();

			return View(posts);
		}

		[Route("{year:min(2000)}/{month:range(1,12)}/{key}")]
		public IActionResult Post(int year, int month, string key)
		{
			var post = _database.Posts.FirstOrDefault(x => x.Key == key);
			return View(post);
		}

		[HttpGet, Route("create")]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost, Route("create")]
		public IActionResult Create(Post post)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}
			post.Author = User.Identity.Name;
			post.Posted = DateTime.Now;

			_database.Posts.Add(post);
			_database.SaveChanges();

			return RedirectToAction("Post", "Blog", new
			{
				year = post.Posted.Year,
				month = post.Posted.Month,
				key = post.Key
			});

		}
	}
}