// Name: IHabitatRepository.cs
// Author: Charles Clayton
// Description: Habitat CRUD interface that interacts with API's DB sets

using MonitoringSystemBlazorShared;

namespace MonitoringSystemBlazorApi.Models
{
    public interface IHabitatRepository
    {
        /// <summary>
        /// Add a new Habitat to the Repository
        /// </summary>
        /// <param name="habitat"></param>
        /// <returns></returns>
        Habitat AddHabitat(Habitat habitat);

        /// <summary>
        /// Locates an Habitat by Id and removes it from the Repository
        /// </summary>
        /// <param name="habitatId"></param>
        /// <returns></returns>
        void DeleteHabitat(int habitatId);

        /// <summary>
        /// Gets all Habitats located in the Data Repository
        /// </summary>
        /// <returns></returns>
        IEnumerable<Habitat> GetAllHabitats();

        /// <summary>
        /// Locates an Habitat by Id and returns it
        /// </summary>
        /// <param name="habitatId"></param>
        /// <returns></returns>
        Habitat GetHabitatById(int habitatId);

        /// <summary>
        /// Updates the selected Habitat data in the Repository, if it exists
        /// </summary>
        /// <param name="habitat"></param>
        /// <returns></returns>
        Habitat UpdateHabitat(Habitat habitat);
    }
}