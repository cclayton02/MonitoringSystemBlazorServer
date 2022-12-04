using System;
using Microsoft.AspNetCore.Components;
using MonitoringSystemBlazorServer.Services;
using MonitoringSystemBlazorShared;

namespace MonitoringSystemBlazorServer.Pages
{
    public partial class HabitatsPage
    {
        [Inject]
        public IHabitatService HabitatService { get; set; }

        public IEnumerable<Habitat> habitats;

        protected override async Task OnInitializedAsync()
        {
            // Retrieve our list of habitats from the service
            habitats = await HabitatService.GetAllHabitats();

            await base.OnInitializedAsync();
        }
    }
}

