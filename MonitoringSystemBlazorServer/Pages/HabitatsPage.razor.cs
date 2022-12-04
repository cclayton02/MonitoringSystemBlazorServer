using System;
using MonitoringSystemBlazorShared;

namespace MonitoringSystemBlazorServer.Pages
{
	public partial class HabitatsPage
	{
        HabitatService habitatService = new();
        List<Habitat> habitats = new();

        private void InitializeHabitats()
        {
            // Retrieve our list of habitats from the service
            habitats = habitatService.GetAll();
        }

        private void OnHabitatRemoved(Habitat item)
        {
            habitatService.Delete(item.Id);

            // Refresh the list after removal, or return nothing if empty
            habitats = habitatService.GetAll() ?? new();
        }

        protected override Task OnInitializedAsync()
        {
            InitializeHabitats();

            return base.OnInitializedAsync();
        }
    }
}

