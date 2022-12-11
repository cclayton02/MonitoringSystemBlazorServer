// Name: HabitatRepository.cs
// Author: Charles Clayton
// Description: Habitat CRUD model that interacts with API's DB sets

using System;
using System.Linq;
using MonitoringSystemBlazorShared;

namespace MonitoringSystemBlazorApi.Models
{
    public class HabitatRepository : IHabitatRepository
    {
        private readonly AppDbContext _appDbContext;

        public HabitatRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        /// <inheritdoc/>
        public IEnumerable<Habitat> GetAllHabitats()
        {
            return _appDbContext.Habitats;
        }

        /// <inheritdoc/>
        public Habitat GetHabitatById(int habitatId)
        {
            return _appDbContext.Habitats.FirstOrDefault(c => c.Id == habitatId);
        }

        /// <inheritdoc/>
        public Habitat AddHabitat(Habitat habitat)
        {
            var addedEntity = _appDbContext.Habitats.Add(habitat);
            _appDbContext.SaveChanges();
            return addedEntity.Entity;
        }

        /// <inheritdoc/>
        public Habitat UpdateHabitat(Habitat habitat)
        {
            var foundHabitat = _appDbContext.Habitats.FirstOrDefault(e => e.Id == habitat.Id);

            if (foundHabitat != null)
            {
                foundHabitat.Name = habitat.Name;
                foundHabitat.Temp = habitat.Temp;
                foundHabitat.FoodSource = habitat.FoodSource;
                foundHabitat.IsClean = habitat.IsClean;

                _appDbContext.SaveChanges();

                return foundHabitat;
            }

            return null;
        }

        /// <inheritdoc/>
        public void DeleteHabitat(int habitatId)
        {
            var foundHabitat = _appDbContext.Habitats.FirstOrDefault(e => e.Id == habitatId);
            if (foundHabitat == null) return;

            _appDbContext.Habitats.Remove(foundHabitat);
            _appDbContext.SaveChanges();
        }
    }
}

