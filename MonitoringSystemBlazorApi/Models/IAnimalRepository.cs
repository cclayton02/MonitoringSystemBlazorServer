using MonitoringSystemBlazorShared;

namespace MonitoringSystemBlazorApi.Models
{
    public interface IAnimalRepository
    {
        Animal AddAnimal(Animal animal);
        void DeleteAnimal(int animalId);
        IEnumerable<Animal> GetAllAnimals();
        Animal GetAnimalById(int animalId);
        Animal UpdateAnimal(Animal animal);
    }
}