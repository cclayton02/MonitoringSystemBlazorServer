using MonitoringSystemBlazorShared;

namespace MonitoringSystemBlazorApi.Models
{
    public interface IHabitatRepository
    {
        Habitat AddHabitat(Habitat habitat);
        void DeleteHabitat(int habitatId);
        IEnumerable<Habitat> GetAllHabitats();
        Habitat GetHabitatById(int habitatId);
        Habitat UpdateHabitat(Habitat habitat);
    }
}