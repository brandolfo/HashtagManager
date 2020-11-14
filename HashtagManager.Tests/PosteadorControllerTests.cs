using System;
using AutoMapper;
using HashtagManager.Application.Service.Interface;
using HashtagManager.Controllers;
using HashtagManager.Domain.DTO.Model;
using HashtagManager.Domain.Entities.Model;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace HashtagManager.Tests
{
	public class PosteadorControllerTests
	{
		private readonly Mock<IMapper> _mapper;
		private readonly Mock<IBaseService<Posteador>> _posteador;
		private readonly PosteadorController _posteadorController;
		public PosteadorControllerTests()
		{
			_mapper = new Mock<IMapper>();
			_posteador = new Mock<IBaseService<Posteador>>(); 
			_posteadorController = new PosteadorController(_mapper.Object, _posteador.Object);
		}

		[Fact]
		public void TestPost_WorkAsExpected()
		{
			// Arrange
			PosteadorDTO testPosteadorDTO = new PosteadorDTO();
			Posteador testPosteador = new Posteador();

			_mapper.Setup(x => x.Map<Posteador>(It.IsAny<PosteadorDTO>())).Returns(testPosteador); //
			//Act
			var result = _posteadorController.Post(testPosteadorDTO);
			//Assert
			Assert.IsType<CreatedResult>(result);
			_mapper.Verify(x => x.Map<Posteador>(It.IsAny<PosteadorDTO>()), Times.Once);
			_posteador.Verify(x => x.Add(It.IsAny<Posteador>()), Times.Once);
			_posteador.Verify(x => x.Save(), Times.Once);
		}
	}
}
