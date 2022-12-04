using System;
using MonitoringSystemBlazorShared;

namespace MonitoringSystemBlazorServer.Pages
{
	public partial class AnimalsPage
	{
        AnimalService animalService = new();
        List<Animal> animals = new();

        private void InitializeAnimals()
        {
            // Retrieve our list of animals from the service
            animals = animalService.GetAll();
        }

        private void OnAnimalRemoved(Animal item)
        {
            animalService.Delete(item.Id);

            // Refresh the list after removal, or return nothing if empty
            animals = animalService.GetAll() ?? new();
        }

        protected override Task OnInitializedAsync()
        {
            InitializeAnimals();

            return base.OnInitializedAsync();
        }
    }
}

