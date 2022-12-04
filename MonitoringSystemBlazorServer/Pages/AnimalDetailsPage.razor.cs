using System;
using Microsoft.AspNetCore.Components;
using MonitoringSystemBlazorServer.Services;
using MonitoringSystemBlazorShared;

namespace MonitoringSystemBlazorServer.Pages
{
    public partial class AnimalDetailsPage
    {
        [Parameter]
        public string? Id { get; set; }

        [Inject]
        public IAnimalService AnimalService { get; set; }

        private List<Animal> animals = new();
        private Animal? animal;

        protected async override Task OnInitializedAsync()
        {
            var animalId = Int32.Parse(Id);

            if (animalId <= 0)
            {
                // Retrieve the animal using a valid id
                animal = await AnimalService.GetAnimalDetails(animalId);
            }

            await base.OnInitializedAsync();
        }
    }
}
