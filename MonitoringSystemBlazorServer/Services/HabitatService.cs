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
    public class HabitatService : IHabitatService
    {
        private readonly HttpClient _httpClient;

        // Injects HTTP client into the service
        public HabitatService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <inheritdoc />
        public async Task<Habitat> AddHabitat(Habitat habitat)
        {
            // Serialize the new Habitat
            var habitatJson =
                new StringContent(JsonSerializer.Serialize(habitat), Encoding.UTF8, "application/json");

            // Send request using the Json data
            var response = await _httpClient.PostAsync("api/habitat", habitatJson);

            if (response.IsSuccessStatusCode)
            {
                // Deserialize the response into a new Habitat object
                return await JsonSerializer.DeserializeAsync<Habitat>(await response.Content.ReadAsStreamAsync());
            }

            // Unable to post the new record
            return null;
        }

        /// <inheritdoc />
        public async Task UpdateHabitat(Habitat habitat)
        {
            var habitatJson =
                new StringContent(JsonSerializer.Serialize(habitat), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync("api/habitat", habitatJson);
        }

        /// <inheritdoc />
        public async Task DeleteHabitat(int habitatId)
        {
            await _httpClient.DeleteAsync($"api/habitat/{habitatId}");
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Habitat>> GetAllHabitats()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Habitat>>
                    (await _httpClient.GetStreamAsync($"api/habitat"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        /// <inheritdoc />
        public async Task<Habitat> GetHabitatDetails(int habitatId)
        {
            return await JsonSerializer.DeserializeAsync<Habitat>
                (await _httpClient.GetStreamAsync($"api/habitat/{habitatId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
