// Name: EditAnimalForm.razor.cs
// Author: Charles Clayton
// Description: Web form for creating/editing an animal

using System;
using Microsoft.AspNetCore.Components;
using MonitoringSystemBlazorServer.Services;
using MonitoringSystemBlazorShared;

namespace MonitoringSystemBlazorServer.Forms
{
	public partial class EditAnimalForm
	{
        [Inject] public IAnimalService AnimalService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }

        [Parameter] public Animal Animal { get; set; }

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

            if (Animal.Id == 0)
            {
                // New Animal Data
                var newAnimal = await AnimalService.AddAnimal(Animal);

                if (newAnimal != null)
                {
                    status = "alert-success";
                    alertMessage = "Success! New animal added.";
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
                await AnimalService.UpdateAnimal(Animal);
                status = "alert-success";
                alertMessage = "Success! Animal updated.";
                isSaved = true;
            }
        }

        private void HandleInvalidSubmit()
        {
            status = "alert-danger";
            alertMessage = "An error as occurred. Please try again.";
        }

        private async Task DeleteAnimal()
        {
            await AnimalService.DeleteAnimal(Animal.Id);

            status = "alert-success";
            alertMessage = "Animal deleted successfully.";

            isSaved = true;
        }

        private void NavigateToAnimals()
        {
            NavigationManager.NavigateTo("/animals");
        }
    }
}

