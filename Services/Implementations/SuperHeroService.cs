using SuperHeroAPI.Models;
using SuperHeroAPI.Services.Interfaces;

namespace SuperHeroAPI.Services.Implementations
{
    public class SuperHeroService : ISuperHeroService
    {
        public SuperHero Add(SuperHero newItem)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SuperHero> GetAllSuperHeroes() => throw new NotImplementedException();

        public SuperHero GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
