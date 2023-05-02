using System;
using System.Linq;
using SuperHeroAPI.Models;
using SuperHeroAPI.Services.Interfaces;

namespace SuperHero_API_Test
{
	public class SuperHeroServiceFake : ISuperHeroService
	{
        private readonly List<SuperHero> _superHeroes;

        public SuperHeroServiceFake()
		{
            _superHeroes = new List<SuperHero>()
            {
                new SuperHero ()
                {
                    Id = 0,
                    Name = "Spider Man",
                    FirstName = "Peter",
                    LastName = "Parker",
                    Place = "New York City"
                },
                new SuperHero()
                {
                    Id = 1,
                    Name = "Super Man",
                    FirstName = "Clark",
                    LastName = "Kent",
                    Place = "Metropolis"
                },
                new SuperHero()
                {
                    Id = 2,
                    Name = "Batman",
                    FirstName = "Bruce",
                    LastName = "Wayne",
                    Place = "Gotham City"
                },
                new SuperHero()
                {
                    Id = 3,
                    Name = "Prince Diana",
                    FirstName = "Diana",
                    LastName = "Prince",
                    Place = "Themyscira"
                }
            };

        }

        public SuperHero Add(SuperHero newItem)
        {
            _superHeroes.Add(newItem);
            return newItem;
        }

        public IEnumerable<SuperHero> GetAllSuperHeroes()
        {
            return _superHeroes;
        }

        public SuperHero GetById(int id)
        {
            return _superHeroes.Where(a => a.Id == id).FirstOrDefault();
        }

        public void Remove(int id)
        {
            var itemToRemove = _superHeroes.First(a => a.Id == id);
            _superHeroes.Remove(itemToRemove);
        }

        public SuperHero Edit(SuperHero newSuperHero)
        {
            var itemToUpdate = _superHeroes.FirstOrDefault(a => a.Id == newSuperHero.Id);
            if(itemToUpdate is null)
            {
                return null;
            }

            itemToUpdate.Name = newSuperHero.Name;
            itemToUpdate.FirstName = newSuperHero.FirstName;
            itemToUpdate.LastName = newSuperHero.LastName;
            itemToUpdate.Place = newSuperHero.Place;
            return itemToUpdate;

        }
    }
}

