using System;
using Microsoft.AspNetCore.Components;
using MonitoringSystemBlazorServer.Services;
using MonitoringSystemBlazorShared;

namespace MonitoringSystemBlazorServer.Pages
{
    public partial class AnimalDetailsPage
    {
        [Inject]
        public IAnimalService AnimalService { get; set; }

        [Parameter]
        public string? Id { get; set; }

        private Animal? animal;

        protected async override Task OnInitializedAsync()
        {
            var success = int.TryParse(Id, out var id);

            if (success)
            {
                // Retrieve the animal using a valid id
                animal = await AnimalService.GetAnimalDetails(id);
            }

            await base.OnInitializedAsync();
        }
    }
}
