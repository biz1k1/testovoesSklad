using Domain.Model.Models.Input;
using Domain.Model.Models.Output;
using System.Text;
using System.Text.Json;
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
                var response = await httpClient.PostAsync("https://localhost:7294/Warehouse/Warehouse", null);

                var result = bool.Parse(await response.Content.ReadAsStringAsync());

                return result;
            }
            catch (Exception ex)
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

            using StringContent jsonContent = new(
            JsonSerializer.Serialize(new UpdatePlatformInput
            {
                WarehouseId = updateWarehouseModel.WarehouseId,
                PlatformId = updateWarehouseModel.PlatformID,
                Cargo = updateWarehouseModel.Cargo
            }),
            Encoding.UTF8,
            "application/json");

            try
            {
                await httpClient.PostAsync($"https://localhost:7294/Platform/Platform-details", jsonContent);

                //Обновление пикета у платформы, если Id пустое
                if (updateWarehouseModel.PicketId is not null)
                {
                    using StringContent jsonContent2 = new(
                    JsonSerializer.Serialize(new UpdatePicketInput
                    {

                    }), Encoding.UTF8, "application/json");

                    await httpClient.PostAsync($"https://localhost:7294/Picket/Picket-details", jsonContent2);
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                return false;
            }
        }
    }
}
