using System;
using Microsoft.AspNetCore.Components;
using MonitoringSystemBlazorServer.Data;

namespace MonitoringSystemBlazorServer.Pages
{
    public partial class AnimalDetailsPage
    {
        [Parameter]
        public string? Id { get; set; }

        private List<Animal> animals = new();
        private Animal? animal;
        private AnimalService animalService = new();

        protected override Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(Id))
            {
                animal = animalService.Get(Int32.Parse(Id));
            }

            return base.OnInitializedAsync();
        }
    }
}

