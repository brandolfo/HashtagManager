using System;
using System.Collections.Generic;
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
	public class UserController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IBaseService<User> _userRepository;
		public UserController(IMapper mapper, IBaseService<User> userRepository)
		{
			_mapper = mapper;
			_userRepository = userRepository;
		}
		// GET: api/<UserController>
		/// <summary>
		/// Lista todos los usuarios existentes
		/// </summary>
		/// <returns>Lista de todos los usuarios en la db</returns>
		[HttpGet]
		public IActionResult Get()
		{
			return new OkObjectResult(_mapper.Map<IEnumerable<UserDTO>>(_userRepository.GetAll()));
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
			var filtereduser = _mapper.Map<UserDTO>(_userRepository.GetOne(id));
			if (filtereduser == null) return NotFound();
			return new OkObjectResult(filtereduser);
		}

		// POST api/<UserController>
		/// <summary>
		/// Crea un nuevo usuario
		/// </summary>
		/// <param name="user"></param>
		/// <returns>genera un nuevo usuario en la bd</returns>
		[HttpPost]
		public IActionResult Post(User user)
		{
			var MappedUser = _mapper.Map<User>(_userRepository.Add(user));
			_userRepository.Save();
			return new CreatedResult(MappedUser.Id.ToString(), user);
		}
		
		// PUT api/<UserController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		/// <summary>
		/// elimina un usuario
		/// </summary>
		/// <param name="id"></param>
		/// <returns>elimina un usuario de la bd</returns>
		// DELETE api/<UserController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(Guid id)
		{
			_userRepository.Delete(id);
			_userRepository.Save();
			return new OkResult();
		}
	}
}
