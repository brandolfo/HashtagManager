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
		private readonly PostContext _postContext;
		public PostController(PostContext postcontext) 
		{
			_postContext = postcontext;
		}

		// GET: api/<PostController>
		[HttpGet]
		public IEnumerable<Post> Get()
		{
			return _postContext.Posts.OrderByDescending(x => x.DatePost);			
		}

		// GET api/<PostController>/5
		[HttpGet("{text}")] // cambie "{id}" por "{text}"
		public IEnumerable<Post> Get(string text)
		{
			return _postContext.Posts.Where(x => x.TextPost.Contains(text));
		}

		// POST api/<PostController>
		[HttpPost]
		public IActionResult Post(Post post)
		{
			_postContext.Posts.Add(post);
			_postContext.SaveChanges();

			return new CreatedResult(post.Id.ToString(), post);
		}

		// PUT api/<PostController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<PostController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
