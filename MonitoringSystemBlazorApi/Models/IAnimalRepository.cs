using MonitoringSystemBlazorShared;

namespace MonitoringSystemBlazorApi.Models
{
    public interface IAnimalRepository
    {
        /// <summary>
        /// Add a new Animal to the Repository
        /// </summary>
        /// <param name="animal"></param>
        /// <returns></returns>
        Animal AddAnimal(Animal animal);

        /// <summary>
        /// Locates an Animal by Id and removes it from the Repository
        /// </summary>
        /// <param name="animalId"></param>
        /// <returns></returns>
        void DeleteAnimal(int animalId);

        /// <summary>
        /// Gets all Animals located in the Data Repository
        /// </summary>
        /// <returns></returns>
        IEnumerable<Animal> GetAllAnimals();

        /// <summary>
        /// Locates an Animal by Id and returns it
        /// </summary>
        /// <param name="animalId"></param>
        /// <returns></returns>
        Animal GetAnimalById(int animalId);

        /// <summary>
        /// Updates the selected Animal data in the Repository, if it exists
        /// </summary>
        /// <param name="animal"></param>
        /// <returns></returns>
        Animal UpdateAnimal(Animal animal);
    }
}