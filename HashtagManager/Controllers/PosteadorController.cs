using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using HashtagManager.Application.Service.Interface;
using HashtagManager.Domain.DTO.Model;
using HashtagManager.Domain.Entities.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HashtagManager.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PosteadorController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IBaseService<Posteador> _posteadorRepository;
		public PosteadorController(IMapper mapper, IBaseService<Posteador> posteadorRepository)
		{
			_mapper = mapper;
			_posteadorRepository = posteadorRepository;
		}
		// GET: api/<PostController>
		/// <summary>
		/// Lista todos los posts existentes
		/// </summary>
		/// <returns>get a todos los post en la bd</returns>
		[HttpGet]
		public IActionResult Get()
		{
			return new OkObjectResult(_mapper.Map<IEnumerable<PosteadorDTO>>(_posteadorRepository.GetAll()));
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
			return new OkObjectResult(_mapper.Map<IEnumerable<PosteadorDTO>>
				(_posteadorRepository.GetQuery(x => x.TextPost.Contains(keyWord))));
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
			_posteadorRepository.Add(MappedPost);
			_posteadorRepository.Save();
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
		public IActionResult Delete(Guid id)
		{
			_posteadorRepository.Delete(id);
			_posteadorRepository.Save();
			return new OkResult();
		}
	}
}
