using SuperHeroAPI.Models;

namespace SuperHeroAPI.Services.Interfaces
{
    public interface ISuperHeroService
    {
        IEnumerable<SuperHero> GetAllSuperHeroes();
        SuperHero Add(SuperHero newItem);
        SuperHero GetById(int id);
        void Remove(int id);
    }
}
