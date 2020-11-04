using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HashtagManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HashtagManager.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly Context _context;
		public UserController(Context context)
		{
			_context = context;
		}
		// GET: api/<UserController>
		[HttpGet]
		public IEnumerable<UserDTO> Get()
		{
			return _context.Users;
		}

		// GET api/<UserController>/5
		[HttpGet("{id}")]
		public IUserDTO Get(Guid id)
		{
			return _context.Users.FirstOrDefault(x => x.Id == id);
		}

		// POST api/<UserController>
		[HttpPost]
		public IActionResult Post(User user)
		{
			_context.Users.Add(user);
			_context.SaveChanges();
			return new CreatedResult(user.Id.ToString(), user);
		}

		// PUT api/<UserController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<UserController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
