using Domain.Model.Models.Output;
using System.Text;
using System.Text.Json;
using Web.Model;

namespace Web.Services
{
    public class PicketService
    {
        private IHttpClientFactory _httpClientFactory;
        private readonly ILogger<WarehouseService> _logger;
        public PicketService(IHttpClientFactory httpClientFactory,
             ILogger<WarehouseService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;

        }
        private HttpClient CreateClient()
        {
            return _httpClientFactory.CreateClient("ApiClient");
        }

        public async Task<IEnumerable<PicketOutput>> GetPicketsAsync()
        {
            var httpClient = CreateClient();
            try
            {
                var result = await httpClient.GetFromJsonAsync<IEnumerable<PicketOutput>>("https://localhost:7294/pickets/picket-lists");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                throw new Exception();
            }

        }
        public async Task AddPicket(int platformId)
        {
            var httpClient = CreateClient();

            try
            {
                await httpClient.PostAsync($"https://localhost:7294/pickets/{platformId}", null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                throw new Exception();
            }
        }

        public async Task<bool> DeletePicketAsync(int picketId)
        {
            var httpClient = CreateClient();
            try
            {
                var response = await httpClient.DeleteAsync($"https://localhost:7294/pickets/{picketId}");

                var result = bool.Parse(await response.Content.ReadAsStringAsync());

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                throw new Exception();
            }

        }
        public async Task<bool> MergePicketAsync(MergePlatformModel mergePlatformModel)
        {
            var httpClient = CreateClient();

            using StringContent platformJson = new(
            JsonSerializer.Serialize(new MergePlatformModel
            {
                WarehouseId = mergePlatformModel.WarehouseId,
                picketIds = mergePlatformModel.picketIds
            }),
            Encoding.UTF8,
            "application/json");

            try
            {
                await httpClient.PutAsync($"https://localhost:7294/pickets/merge", platformJson);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                throw new Exception();
            }
        }
    }
}
