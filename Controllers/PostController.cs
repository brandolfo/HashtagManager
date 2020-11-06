using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using HashtagManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HashtagManager.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PostController : ControllerBase
	{
		private readonly Context _context;
		private readonly IMapper _mapper;
		public PostController(Context context, IMapper mapper) 
		{
			_context = context;
			_mapper = mapper;

		}
		// GET: api/<PostController>
		/// <summary>
		/// Lista todos los posts existentes
		/// </summary>
		/// <returns>get a todos los post en la bd</returns>
		[HttpGet]
		public IEnumerable<PostDTO> Get()
		{
			return _mapper.Map<IEnumerable<PostDTO>>(_context.Posts.Include(x => x.user)
				.OrderByDescending(x => x.DatePost));			
		}

		// GET api/<PostController>/5
		/// <summary>
		/// filtra post por palabra clave
		/// </summary>
		/// <param name="keyWord"></param>
		/// <returns> devuelve una lista de post con la palabra clave</returns>
		[HttpGet("{keyWord}")] // cambie "{id}" por "{KeyWord}"
		public IActionResult Get(string keyWord)
		{
			var PostsWithKeyWord = _mapper.Map<IEnumerable<PostDTO>>(
				_context.Posts.Where(x => x.TextPost.Contains(keyWord)));
			return new OkObjectResult(PostsWithKeyWord);
		}

		// POST api/<PostController>
		/// <summary>
		/// Crea un post al usuario
		/// </summary>
		/// <param name="post"></param>
		/// <returns>agrega un post a la lista de post del usuario </returns>
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
		/// <summary>
		/// elimina un post por id
		/// </summary>
		/// <param name="id"></param>
		[HttpDelete("{id}")]
		public void Delete(Guid id)
		{
			var ToDelete = _context.Posts.Find(id); // hay que agregar mapping en un delete?? consultar a corvo-san
			_context.Posts.Remove(ToDelete);
			_context.SaveChanges();			
		}
	}
}
