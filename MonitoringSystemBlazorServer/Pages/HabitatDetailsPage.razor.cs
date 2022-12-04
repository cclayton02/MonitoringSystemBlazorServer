using System;
using Microsoft.AspNetCore.Components;
using MonitoringSystemBlazorShared;

namespace MonitoringSystemBlazorServer.Pages
{
    public partial class HabitatDetailsPage
    {
        [Parameter]
        public string? Id { get; set; }

        private List<Habitat> habitats = new();
        private Habitat? habitat;
        private HabitatService habitatService = new();

        protected override Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(Id))
            {
                habitat = habitatService.Get(Int32.Parse(Id));
            }

            return base.OnInitializedAsync();
        }
    }
}

