using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using HashtagManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HashtagManager.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly Context _context;
		private readonly IMapper _mapper;
		public UserController(Context context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}
		// GET: api/<UserController>
		/// <summary>
		/// Lista todos los usuarios existentes
		/// </summary>
		/// <returns>Lista de todos los usuarios en la db</returns>
		[HttpGet]
		public IEnumerable<UserDTO> Get()
		{
			return _mapper.Map<IEnumerable<UserDTO>>(_context.Users.Include(x => x.PostList));
		}

		// GET api/<UserController>/5
		/// <summary>
		/// Buscar usuario por id
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Nos filtra un usuario por id o retorna null de no haber uno con dicho id</returns>
		[HttpGet("{id}")]
		public IActionResult Get(Guid id)
		{
			var user = _mapper.Map<UserDTO>(_context.Users.Find(id));
			return new OkObjectResult(user);
		}

		// POST api/<UserController>
		[HttpPost]
		public IActionResult Post(User user)
		{
			var MappedUser = _mapper.Map<User>(user);
			_context.Users.Add(MappedUser);
			_context.SaveChanges();
			return new CreatedResult(MappedUser.Id.ToString(), user);
		}

		// PUT api/<UserController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<UserController>/5
		[HttpDelete("{id}")]
		public void Delete(Guid id)
		{
			var ToDelete = _context.Users.Find(id);

			_context.Users.Remove(ToDelete);
			_context.SaveChanges();
		}
	}
}
