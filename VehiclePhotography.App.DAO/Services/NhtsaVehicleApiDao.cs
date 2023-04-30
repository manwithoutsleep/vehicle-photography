using VehiclePhotography.App.DAO.Interfaces;
using VehiclePhotography.App.Models.Values;
using System.Text.Json;
using VehiclePhotography.App.DAO.DataTransferObjects;
using VehiclePhotography.App.DAO.Extensions;
using VehiclePhotography.App.Models.Exceptions;

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

            try
            {
                var responseString = await httpClient.GetStringAsync(uri);

                var response = JsonSerializer.Deserialize<NhtsaVehicleApiResponse>(responseString);

                return response.ToVehicleInfo();
            }
            catch (HttpRequestException ex)
            {
                throw new NhtsaVehicleApiException($"Error getting vehicle info for VIN '{vin}'", ex);
            }

        }
    }
}
