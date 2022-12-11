// Name: AnimalService.cs
// Author: Charles Clayton
// Description: Class that performs client CRUD operations on Animal table

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MonitoringSystemBlazorShared;

namespace MonitoringSystemBlazorServer.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly HttpClient _httpClient;

        // Injects HTTP client into the service
        public AnimalService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <inheritdoc />
        public async Task<Animal> AddAnimal(Animal animal)
        {
            // Serialize the new Animal
            var animalJson =
                new StringContent(JsonSerializer.Serialize(animal), Encoding.UTF8, "application/json");

            // Send request using the Json data
            var response = await _httpClient.PostAsync("api/animal", animalJson);

            if (response.IsSuccessStatusCode)
            {
                // Deserialize the response into a new Animal object
                return await JsonSerializer.DeserializeAsync<Animal>(await response.Content.ReadAsStreamAsync());
            }

            // Unable to post the new record
            return null;
        }

        /// <inheritdoc />
        public async Task UpdateAnimal(Animal animal)
        {
            var animalJson =
                new StringContent(JsonSerializer.Serialize(animal), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync("api/animal", animalJson);
        }

        /// <inheritdoc />
        public async Task DeleteAnimal(int animalId)
        {
            await _httpClient.DeleteAsync($"api/animal/{animalId}");
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Animal>> GetAllAnimals()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Animal>>
                    (await _httpClient.GetStreamAsync($"api/animal"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        /// <inheritdoc />
        public async Task<Animal> GetAnimalDetails(int animalId)
        {
            return await JsonSerializer.DeserializeAsync<Animal>
                (await _httpClient.GetStreamAsync($"api/animal/{animalId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
