using Domain.Model.Models.Input;
using Domain.Model.Models.Output;
using System;
using System.Text;
using System.Text.Json;
using Web.Model;

namespace Web.Services
{
    public class PlatformService
    {

        private IHttpClientFactory _httpClientFactory;
        private readonly ILogger<WarehouseService> _logger;
        public PlatformService(IHttpClientFactory httpClientFactory,
            ILogger<WarehouseService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }
        private HttpClient CreateClient()
        {
            return _httpClientFactory.CreateClient("ApiClient");
        }

        public async Task<IEnumerable<PlatformOutput>> GetPlatformAsync()
        {
            var httpClient = CreateClient();
            try
            {
                var result = await httpClient.GetFromJsonAsync<IEnumerable<PlatformOutput>>("https://localhost:7294/Platform/platform-lists");
                return result;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                throw new Exception();
            }
        }

        public async Task AddPlatform(CreatePlatformModel model)
        {
            var httpClient = CreateClient();


            using StringContent jsonContent = new(
            JsonSerializer.Serialize(new AddPlatformInput
            {
                WarehouseId = model.WarehouseId,
                Cargo = model.Cargo
            }),
            Encoding.UTF8,
            "application/json");

            try
            {
                await httpClient.PostAsync("https://localhost:7294/Platform/platform", jsonContent);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                throw new Exception();
            }

        }

        public async Task<bool> DeletePlatformAsync(int platformId)
        {
            var httpClient = CreateClient();
            try
            {
                var response = await httpClient.DeleteAsync($"https://localhost:7294/Platform/platform-delete?platformId={platformId}");

                var result = bool.Parse(await response.Content.ReadAsStringAsync());

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                throw new Exception();
            }

        }
    }
}
