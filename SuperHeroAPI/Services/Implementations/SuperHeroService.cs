using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;
using SuperHeroAPI.Models;
using SuperHeroAPI.Services.Interfaces;

namespace SuperHeroAPI.Services.Implementations
{
    public class SuperHeroService : ISuperHeroService
    {

        public SuperHeroService()
        {
        }

        public SuperHero Add(SuperHero newItem)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SuperHero> GetAllSuperHeroes()
        {

            var context = new SuperHeroDbContext();
            return context.SuperHeroes.ToList();
        }

        public SuperHero GetById(int id)
        {
            var context = new SuperHeroDbContext();
            return context.SuperHeroes.FirstOrDefault(a => a.Id == id);
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
