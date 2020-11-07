using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using HashtagManager.Domain.DTO.Model;
using HashtagManager.Domain.Entities.Model;
using HashtagManager.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HashtagManager.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PosteadorController : ControllerBase
	{
		private readonly Context _context;
		private readonly IMapper _mapper;
		public PosteadorController(Context context, IMapper mapper) 
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
		public IEnumerable<PosteadorDTO> Get()
		{
			return _mapper.Map<IEnumerable<PosteadorDTO>>(_context.Posts
				.OrderByDescending(x => x.DatePost));
			//return _mapper.Map<IEnumerable<PostDTO>>(_context.Posts.Include(x => x.user).OrderByDescending(x => x.DatePost));
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
			var PostsWithKeyWord = _mapper.Map<IEnumerable<PosteadorDTO>>(
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
		public IActionResult Post(PosteadorDTO post)
		{
			var MappedPost = _mapper.Map<Posteador>(post);
			_context.Posts.Add(MappedPost);
			_context.SaveChanges();

			return new CreatedResult(MappedPost.Id.ToString(), MappedPost);
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
			var ToDelete = _context.Posts.Find(id);
			_context.Posts.Remove(ToDelete);
			_context.SaveChanges();			
		}
	}
}
