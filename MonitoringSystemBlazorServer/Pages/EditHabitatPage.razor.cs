// Name: EditHabitatPage.razor.cs
// Author: Charles Clayton
// Description: Creates a form model of the selected/new habitat

using System;
using Microsoft.AspNetCore.Components;
using MonitoringSystemBlazorServer.Services;
using MonitoringSystemBlazorShared;

namespace MonitoringSystemBlazorServer.Pages
{
	public partial class EditHabitatPage
	{
		[Inject] public IHabitatService HabitatService { get; set; }

		[Parameter] public string Id { get; set; }

        private Habitat habitat;

        protected override async Task OnInitializedAsync()
        {
            var success = int.TryParse(Id, out var id);

            if (!success)
            {
                // Creating a new Habitat
                habitat = new Habitat();
            }
            else
            {
                // Use the parsed Id to get Habitat
                habitat = await HabitatService.GetHabitatDetails(id);
            }

            await base.OnInitializedAsync();
        }
    }
}

