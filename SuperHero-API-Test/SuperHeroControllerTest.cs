using System;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Controllers;
using SuperHeroAPI.Models;
using SuperHeroAPI.Services.Interfaces;

namespace SuperHero_API_Test
{
	public class SuperHeroControllerTest
	{
		private readonly SuperHeroController _controller;
		private readonly ISuperHeroService _superHeroService;

		public SuperHeroControllerTest()
		{
			_superHeroService = new SuperHeroServiceFake();
			_controller = new SuperHeroController(_superHeroService);
		}

		[Fact]
		public void Get_WhenCalled_ReturnsOkResult()
		{
			//Act
			var okResult = _controller.GetSuperHeroes();

			//Assert
			Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
		}

		[Fact]
		public void Get_WhenCalled_ReturnsAllHeroes()
		{
			//Act
			var okResult = _controller.GetSuperHeroes() as OkObjectResult;

			//Assert
			//number of entries
			//type of entries
			var items = Assert.IsType<List<SuperHero>>(okResult.Value);
			Assert.Equal(4, items.Count);
		}

		[Fact]
		public void GetID_WhenCAlled_withExistingID_Returns200StatusCode()
		{
			//Act
			var okResult = _controller.GetSuperHeroes(1);

			//Assert
			Assert.IsType<OkObjectResult>(okResult);
		}

		[Fact]
		public void GetID_WhenCalled_withExistingID_ReturnsCorrectHero()
		{

			//Act
			var okResult = _controller.GetSuperHeroes(1) as OkObjectResult;
			var resultHero = Assert.IsType<SuperHero>(okResult.Value);

			//Assert
			Assert.Equal("Super Man", resultHero.Name);
        }

		[Fact]
		public void GetID_WhenCalled_withNonExistantID_Returns404NotFound()
		{
			//Act
			var notfoundResult = _controller.GetSuperHeroes(500);

			//Assert
			Assert.IsType<NotFoundResult>(notfoundResult);
		}
	}
}

