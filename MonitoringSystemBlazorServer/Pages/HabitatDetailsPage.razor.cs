using System;
using Microsoft.AspNetCore.Components;
using MonitoringSystemBlazorServer.Services;
using MonitoringSystemBlazorShared;

namespace MonitoringSystemBlazorServer.Pages
{
    public partial class HabitatDetailsPage
    {
        [Inject]
        public IHabitatService HabitatService { get; set; }

        [Parameter]
        public string? Id { get; set; }

        private Habitat? habitat;

        protected async override Task OnInitializedAsync()
        {
            var success = int.TryParse(Id, out var id);

            if (success)
            {
                // Retrieve the habitat using a valid id
                habitat = await HabitatService.GetHabitatDetails(id);
            }

            await base.OnInitializedAsync();
        }
    }
}
