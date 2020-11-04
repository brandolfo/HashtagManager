using System;
using System.Collections.Generic;
using System.Linq;
using HashtagManager.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HashtagManager.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PostController : ControllerBase
	{
		private readonly Context _context;
		public PostController(Context context) 
		{
			_context = context;
		}

		// GET: api/<PostController>
		[HttpGet]
		public IEnumerable<Post> Get()
		{
			return _context.Posts.OrderByDescending(x => x.DatePost);			
		}

		// GET api/<PostController>/5
		/// <summary>
		/// filtra post por palabra clave
		/// </summary>
		/// <param name="keyWord"></param>
		/// <returns> devuelve una lista de post con la palabra clave</returns>
		[HttpGet("{keyWord}")] // cambie "{id}" por "{KeyWord}"
		public IEnumerable<Post> Get(string keyWord)
		{
			return _context.Posts.Where(x => x.TextPost.Contains(keyWord));
		}

		// POST api/<PostController>
		[HttpPost]
		public IActionResult Post(Post post)
		{
			_context.Posts.Add(post);
			_context.SaveChanges();

			return new CreatedResult(post.Id.ToString(), post);
		}

		// PUT api/<PostController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<PostController>/5
		[HttpDelete("{id}")]
		public void Delete(Guid id)
		{
			
		}
	}
}
