// Name: EditAnimalPage.razor.cs
// Author: Charles Clayton
// Description: Creates a form model of the selected/new animal

using System;
using Microsoft.AspNetCore.Components;
using MonitoringSystemBlazorServer.Services;
using MonitoringSystemBlazorShared;

namespace MonitoringSystemBlazorServer.Pages
{
	public partial class EditAnimalPage
	{
		[Inject] public IAnimalService AnimalService { get; set; }

		[Parameter] public string Id { get; set; }

        private Animal animal;

        protected override async Task OnInitializedAsync()
        {
            var success = int.TryParse(Id, out var id);

            if (!success)
            {
                // Creating a new Animal
                animal = new Animal();
            }
            else
            {
                // Use the parsed Id to get Animal
                animal = await AnimalService.GetAnimalDetails(id);
            }

            await base.OnInitializedAsync();
        }
    }
}

