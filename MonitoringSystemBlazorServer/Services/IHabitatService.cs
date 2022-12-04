using MonitoringSystemBlazorShared;

namespace MonitoringSystemBlazorServer.Services
{
    public interface IHabitatService
    {
        /// <summary>
        /// Add a new Habitat to the Repository
        /// </summary>
        /// <param name="habitat"></param>
        /// <returns></returns>
        Task<Habitat> AddHabitat(Habitat habitat);

        /// <summary>
        /// Locates an Habitat by Id and removes it from the Repository
        /// </summary>
        /// <param name="habitatId"></param>
        /// <returns></returns>
        Task DeleteHabitat(int habitatId);

        /// <summary>
        /// Gets all Habitats located in the Data Repository
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Habitat>> GetAllHabitats();

        /// <summary>
        /// Locates an Habitat by Id and returns it
        /// </summary>
        /// <param name="habitatId"></param>
        /// <returns></returns>
        Task<Habitat> GetHabitatDetails(int habitatId);

        /// <summary>
        /// Updates the selected Habitat data in the Repository, if it exists
        /// </summary>
        /// <param name="habitat"></param>
        /// <returns></returns>
        Task UpdateHabitat(Habitat habitat);
    }
}