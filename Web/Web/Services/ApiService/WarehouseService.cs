using Domain.Model.Models.Output;
using System.Net.Http.Json;

namespace Web.Services
{
    public class WarehouseService
    {
        private IHttpClientFactory _httpClientFactory;
        public WarehouseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        private HttpClient CreateClient()
        {
            return _httpClientFactory.CreateClient("ApiClient");
        }
        public async Task<IEnumerable<WarehouseOutput>> GetWarehousesAsync()
        {
            var httpClient = CreateClient();

            var result = await httpClient.GetFromJsonAsync<IEnumerable<WarehouseOutput>>("https://localhost:7294/Warehouse/Warehouse-list");

            return result;
        }

        public async Task AddWarehouse()
        {
            var httpClient = CreateClient();

            await httpClient.PostAsync("https://localhost:7294/Warehouse/Warehouse", null);
        }
    }
}
