using System;
using System.Linq;
using MonitoringSystemBlazorShared;

namespace MonitoringSystemBlazorApi.Models
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly AppDbContext _appDbContext;

        public AnimalRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        /// <inheritdoc/>
        public IEnumerable<Animal> GetAllAnimals()
        {
            return _appDbContext.Animals;
        }

        /// <inheritdoc/>
        public Animal GetAnimalById(int animalId)
        {
            return _appDbContext.Animals.FirstOrDefault(c => c.Id == animalId);
        }

        /// <inheritdoc/>
        public Animal AddAnimal(Animal animal)
        {
            var addedEntity = _appDbContext.Animals.Add(animal);
            _appDbContext.SaveChanges();
            return addedEntity.Entity;
        }

        /// <inheritdoc/>
        public Animal UpdateAnimal(Animal animal)
        {
            var foundAnimal = _appDbContext.Animals.FirstOrDefault(e => e.Id == animal.Id);

            if (foundAnimal != null)
            {
                foundAnimal.Type = animal.Type;
                foundAnimal.Name = animal.Name;
                foundAnimal.Age = animal.Age;
                foundAnimal.HealthConcerns = animal.HealthConcerns;
                foundAnimal.FeedingSchedule = animal.FeedingSchedule;

                _appDbContext.SaveChanges();

                return foundAnimal;
            }

            return null;
        }

        /// <inheritdoc/>
        public void DeleteAnimal(int animalId)
        {
            var foundAnimal = _appDbContext.Animals.FirstOrDefault(e => e.Id == animalId);
            if (foundAnimal == null) return;

            _appDbContext.Animals.Remove(foundAnimal);
            _appDbContext.SaveChanges();
        }
    }
}

