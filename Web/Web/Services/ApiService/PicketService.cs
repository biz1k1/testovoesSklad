using Domain.Model.Models.Input;
using Domain.Model.Models.Output;
using System.Reflection;
using System.Text.Json;
using System.Text;
using System.Collections.Generic;
using System.Net.Http;
using System;

namespace Web.Services
{
    public class PicketService
    {
        private IHttpClientFactory _httpClientFactory;
        public PicketService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        private HttpClient CreateClient()
        {
            return _httpClientFactory.CreateClient("ApiClient");
        }

        public async Task<IEnumerable<PicketOutput>> GetPicketsAsync()
        {
            var httpClient = CreateClient();

            var result = await httpClient.GetFromJsonAsync<IEnumerable<PicketOutput>>("https://localhost:7294/Picket/picket-lists");

            return result;
        }
        public async Task AddPicket(int platformId)
        {
            var httpClient = CreateClient();

            try
            {
                await httpClient.PostAsync($"https://localhost:7294/Picket/picket?platformId={platformId}", null);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public async Task<bool> DeletePicketAsync(int picketId)
        {
            var httpClient = CreateClient();
            try
            {
                var response=await httpClient.DeleteAsync($"https://localhost:7294/Picket/picket-delete?picketId={picketId}");

                var result = bool.Parse(await response.Content.ReadAsStringAsync());

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }

        }
    }
}
