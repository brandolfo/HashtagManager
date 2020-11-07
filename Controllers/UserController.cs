﻿using System;
using System.Collections.Generic;
using AutoMapper;
using HashtagManager.Domain.Dto;
using HashtagManager.Domain.Entity;
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
		[HttpGet]
		public IEnumerable<UserDTO> Get()
		{
			return _mapper.Map<IEnumerable<UserDTO>>(_context.Users.Include(x=> x.PostList));
		}

		// GET api/<UserController>/5
		[HttpGet("{id}")]
		public IActionResult Get(Guid id)
		{
			var user = _context.Users.Find(id);
			return new OkObjectResult(user);
		}

		// POST api/<UserController>
		[HttpPost]
		public IActionResult Post(User user)
		{
			_context.Users.Add(user);
			_context.SaveChanges();
			return new CreatedResult(user.Id.ToString(), user);
		}
		// POST api/<UserController>
		[HttpPost]
		public IActionResult SetPassword(Guid user, string password)
		{
			//acá seteas una password
			return Ok();
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
