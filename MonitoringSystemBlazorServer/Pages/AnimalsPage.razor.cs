using System;
using Microsoft.AspNetCore.Components;
using MonitoringSystemBlazorServer.Services;
using MonitoringSystemBlazorShared;

namespace MonitoringSystemBlazorServer.Pages
{
	public partial class AnimalsPage
	{
        [Inject]
        public IAnimalService AnimalService { get; set; }

        public IEnumerable<Animal> animals;

        protected override async Task OnInitializedAsync()
        {
            // Retrieve our list of animals from the service
            animals = await AnimalService.GetAllAnimals();

            await base.OnInitializedAsync();
        }
    }
}

