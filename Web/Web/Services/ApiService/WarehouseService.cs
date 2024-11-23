using Domain.Model.Models.Output;
using System.Net.Http.Json;
using Web.Model;

namespace Web.Services
{
    public class WarehouseService
    {
        private readonly ILogger<WarehouseService> _logger;
        private IHttpClientFactory _httpClientFactory;

        public WarehouseService(IHttpClientFactory httpClientFactory,
            ILogger<WarehouseService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }
        private HttpClient CreateClient()
        {
            return _httpClientFactory.CreateClient("ApiClient");
        }
        public async Task<IEnumerable<WarehouseOutput>> GetWarehousesAsync()
        {
            var httpClient = CreateClient();
            try
            {
                var result = await httpClient.GetFromJsonAsync<IEnumerable<WarehouseOutput>>("https://localhost:7294/Warehouse/Warehouse-list");

                return result;
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, ex.Message);

                throw new Exception();
            }
        }

        public async Task<bool> AddWarehouse()
        {
            var httpClient = CreateClient();
            try
            {
                var response=await httpClient.PostAsync("https://localhost:7294/Warehouse/Warehouse", null);

                var result = bool.Parse(await response.Content.ReadAsStringAsync());

                return result;
            }
            catch(Exception ex)
            {

                _logger.LogError(ex, ex.Message);

                return false;
            }
        }

        public async Task<bool> DeleteWarehouseAsync(int warehouseId)
        {
            var httpClient = CreateClient();
            try
            {
                var response = await httpClient.DeleteAsync($"https://localhost:7294/Warehouse/warehouse-delete?warehouseId={warehouseId}");

                var result = bool.Parse(await response.Content.ReadAsStringAsync());

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                return false;
            }

        }

        public async Task<bool> UpdateWarehouseAsync(UpdateWarehouseModel updateWarehouseModel)
        {
            var httpClient = CreateClient();
            try
            {
                var response = await httpClient.DeleteAsync($"");

                var result = bool.Parse(await response.Content.ReadAsStringAsync());

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                return false;
            }
        }
    }
}
