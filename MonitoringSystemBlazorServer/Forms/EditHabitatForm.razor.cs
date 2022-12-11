// Name: EditHabitatForm.razor.cs
// Author: Charles Clayton
// Description: Web page for creating/editing a habitat

using System;
using Microsoft.AspNetCore.Components;
using MonitoringSystemBlazorServer.Services;
using MonitoringSystemBlazorShared;

namespace MonitoringSystemBlazorServer.Forms
{
	public partial class EditHabitatForm
	{
        [Inject] public IHabitatService HabitatService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }

        [Parameter] public Habitat Habitat { get; set; }

        private bool isSaved;
        private string status = string.Empty;
        private string alertMessage = string.Empty;

        protected override Task OnInitializedAsync()
        {
            isSaved = false;

            return base.OnInitializedAsync();
        }

        private async Task HandleValidSubmit()
        {
            isSaved = false;

            if (Habitat.Id == 0)
            {
                // New Habitat Data
                var newHabitat = await HabitatService.AddHabitat(Habitat);

                if (newHabitat != null)
                {
                    status = "alert-success";
                    alertMessage = "Success! New habitat added.";
                    isSaved = true;
                }
                else
                {
                    status = "alert-danger";
                    alertMessage = "Something went wrong. Please try again.";
                    isSaved = false;
                }
            }
            else
            {
                await HabitatService.UpdateHabitat(Habitat);
                status = "alert-success";
                alertMessage = "Success! Habitat updated.";
                isSaved = true;
            }
        }

        private void HandleInvalidSubmit()
        {
            status = "alert-danger";
            alertMessage = "An error as occurred. Please try again.";
        }

        private async Task DeleteHabitat()
        {
            await HabitatService.DeleteHabitat(Habitat.Id);

            status = "alert-success";
            alertMessage = "Habitat deleted successfully.";

            isSaved = true;
        }

        private void NavigateToHabitats()
        {
            NavigationManager.NavigateTo("/habitats");
        }
    }
}

