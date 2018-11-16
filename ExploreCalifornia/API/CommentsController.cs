using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExploreCalifornia.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExploreCalifornia.API
{
	[Route("api/posts/{postKey}/comments")]
	public class CommentsController : Controller
	{
		private readonly DatabaseContext _database;

		public CommentsController(DatabaseContext database)
		{
			_database = database;
		}

		// GET: api/<controller>
		[HttpGet]
		public IQueryable<Comment> Get(string postKey)
		{
			return _database.Comments.Where(x => x.Post.Key == postKey);
		}

		// GET api/<controller>/5
		[HttpGet("{id}")]
		public Comment Get(long id)
		{
			var comment = _database.Comments.FirstOrDefault(x => x.Id == id);
			return comment;
		}

		// POST api/<controller>
		[HttpPost]
		public Comment Post(string postKey, [FromBody]Comment comment)
		{
			var post = _database.Posts.FirstOrDefault(x => x.Key == postKey);

			if (post == null)
				return null;

			comment.Post = post;
			comment.Posted = DateTime.Now;
			comment.Author = User.Identity.Name;

			_database.Comments.Add(comment);
			_database.SaveChanges();

			return comment;
		}

		// PUT api/<controller>/5
		[HttpPut("{id}")]
		public IActionResult Put(long id, [FromBody]Comment updated)
		{
			var comment = _database.Comments.FirstOrDefault(x => x.Id == id);

			if (comment == null)
				return NotFound();

			comment.Body = updated.Body;
			_database.SaveChanges();
			return Ok();

		}

		// DELETE api/<controller>/5
		[HttpDelete("{id}")]
		public void Delete(long id)
		{
			var comment = _database.Comments.FirstOrDefault(x => x.Id == id);

			if (comment != null)
			{
				_database.Comments.Remove(comment);
				_database.SaveChanges();
			}
		}
	}
}
