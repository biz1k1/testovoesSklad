using Domain.Model.Models.Input;
using Domain.Model.Models.Output;
using System.Text.Json;
using System.Text;
using Web.Model;

namespace Web.Services
{
    public class PlatformService
    {

        private IHttpClientFactory _httpClientFactory;
        public PlatformService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        private HttpClient CreateClient()
        {
            return _httpClientFactory.CreateClient("ApiClient");
        }

        public async Task<IEnumerable<PlatformOutput>> GetPlatformAsync()
        {
            var httpClient = CreateClient();

            var result = await httpClient.GetFromJsonAsync<IEnumerable<PlatformOutput>>("https://localhost:7294/Platform/platform-lists");

            return result;
        }

        public async Task AddPlatform(CreatePlatformModel model,int warehouseId)
        {
            var httpClient = CreateClient();


            using StringContent jsonContent = new(
            JsonSerializer.Serialize(new AddPlatformInput
            {
                WarehouseId = warehouseId,
                Cargo = model.Cargo
            }),
            Encoding.UTF8,
            "application/json");

            try
            {
                await httpClient.PostAsync("https://localhost:7294/Platform/platform", null);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

        }
    }
}
