using System;
using Microsoft.AspNetCore.Components;
using MonitoringSystemBlazorServer.Services;
using MonitoringSystemBlazorShared;

namespace MonitoringSystemBlazorServer.Pages
{
    public partial class HabitatDetailsPage
    {
        [Parameter]
        public string? Id { get; set; }

        [Inject]
        public IHabitatService HabitatService { get; set; }

        private List<Habitat> habitats = new();
        private Habitat? habitat;

        protected async override Task OnInitializedAsync()
        {
            var habitatId = Int32.Parse(Id);

            if (habitatId <= 0)
            {
                // Retrieve the habitat using a valid id
                habitat = await HabitatService.GetHabitatDetails(habitatId);
            }

            await base.OnInitializedAsync();
        }
    }
}
