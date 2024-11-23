using Domain.Model.Models.Input;
using Domain.Model.Models.Output;
using System.Reflection;
using System.Text.Json;
using System.Text;
using System.Collections.Generic;

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
    }
}
