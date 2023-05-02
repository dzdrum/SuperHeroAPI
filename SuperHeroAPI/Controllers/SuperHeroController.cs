using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Data;
using SuperHeroAPI.Models;
using SuperHeroAPI.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    public class SuperHeroController : Controller
    {
        private readonly ISuperHeroService _superHeroService;

        public SuperHeroController(ISuperHeroService superHeroService)
        {
            //dependency injection
            _superHeroService = superHeroService;
        }

        //GetAllSuperHeroes

        [HttpGet]
        public ActionResult GetSuperHeroes()
        {
            var superHeroes = _superHeroService.GetAllSuperHeroes();
            return Ok(superHeroes);
        }

        [HttpGet("{id}")]
        public ActionResult GetSuperHeroes(int id)
        {
            var item = _superHeroService.GetById(id);
            if(item is null)
            {
                return new NotFoundResult();
            }

            return Ok(item);
        }

        //[HttpGet]
        //public async Task<ActionResult<List<SuperHero>>> GetSuperHeroes()
        //{
        //    using (var context = new SuperHeroDbContext())
        //    {
        //        return context.SuperHeroes.ToList();
        //    }

        //}
    }
}

