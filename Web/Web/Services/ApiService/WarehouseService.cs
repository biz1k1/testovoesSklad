﻿using Domain.Model.Models.Input;
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
                var result = await httpClient.GetFromJsonAsync<IEnumerable<WarehouseOutput>>("https://localhost:7294/warehouses/warehouse-list");

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
                var response = await httpClient.PostAsync("https://localhost:7294/warehouses/warehouse", null);

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
                var response = await httpClient.DeleteAsync($"https://localhost:7294/warehouses/{warehouseId}");

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

            using StringContent warehouseJson = new(
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
                await httpClient.PutAsync($"https://localhost:7294/platforms/platform-details", warehouseJson);

                //Обновление пикета у платформы, если Id не пустое
                if (updateWarehouseModel.PicketId is not null)
                {
                    using StringContent picketsJson = new(
                    JsonSerializer.Serialize(new UpdatePicketInput
                    {
                        PicketId=updateWarehouseModel.PicketId,
                        PlatformId=updateWarehouseModel.PlatformID,
                    }), Encoding.UTF8, "application/json");

                    await httpClient.PostAsync($"https://localhost:7294/pickets/picket-details", picketsJson);
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
