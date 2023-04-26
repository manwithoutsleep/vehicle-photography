using System.Net.Http;
using System.Threading.Tasks;
using VehiclePhotography.App.DAO.Interfaces;
using VehiclePhotography.App.Domain.Values;
using System.Text.Json;
using VehiclePhotography.App.DAO.DataTransferObjects;
using VehiclePhotography.App.DAO.Extensions;

namespace VehiclePhotography.App.DAO.Services
{
    public class NhtsaVehicleApiDao : IVehicleInfoDao
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public NhtsaVehicleApiDao(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<VehicleInfo> GetVehicleInfoAsync(string vin)
        {
            var httpClient = _httpClientFactory.CreateClient();

            var uri = $"https://vpic.nhtsa.dot.gov/api/vehicles/DecodeVinValues/{vin}?format=json";

            var responseString = await httpClient.GetStringAsync(uri);

            var response = JsonSerializer.Deserialize<NhtsaVehicleApiResponse>(responseString);

            return response.ToVehicleInfo();
        }
    }
}
