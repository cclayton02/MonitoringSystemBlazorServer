using MonitoringSystemBlazorShared;

namespace MonitoringSystemBlazorServer.Services
{
    public interface IAnimalService
    {
        /// <summary>
        /// Add a new Animal to the Repository
        /// </summary>
        /// <param name="animal"></param>
        /// <returns></returns>
        Task<Animal> AddAnimal(Animal animal);

        /// <summary>
        /// Locates an Animal by Id and removes it from the Repository
        /// </summary>
        /// <param name="animalId"></param>
        /// <returns></returns>
        Task DeleteAnimal(int animalId);

        /// <summary>
        /// Gets all Animals located in the Data Repository
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Animal>> GetAllAnimals();

        /// <summary>
        /// Locates an Animal by Id and returns it
        /// </summary>
        /// <param name="animalId"></param>
        /// <returns></returns>
        Task<Animal> GetAnimalDetails(int animalId);

        /// <summary>
        /// Updates the selected Animal data in the Repository, if it exists
        /// </summary>
        /// <param name="animal"></param>
        /// <returns></returns>
        Task UpdateAnimal(Animal animal);
    }
}