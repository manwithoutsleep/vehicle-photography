using System;
using System.Net.Http;
using System.Threading.Tasks;
using VehiclePhotography.App.DAO.Interfaces;
using VehiclePhotography.App.Domain.Values;
using System.Text.Json;
using VehiclePhotography.App.DAO.DataTransferObjects;

namespace VehiclePhotography.App.DAO.Services
{
    public class NhtsaVehicleApiDao : IVehicleInfoDao
    {
        private readonly HttpClient _httpClient;

        public NhtsaVehicleApiDao(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<VehicleInfo> GetVehicleInfoAsync(string vin)
        {
            var uri = $"https://vpic.nhtsa.dot.gov/api/vehicles/DecodeVinValues/{vin}?format=json";

            var responseString = await _httpClient.GetStringAsync(uri);

            var response = JsonSerializer.Deserialize<NhtsaVehicleApiResponse>(responseString);



            var catalog = JsonConvert.DeserializeObject<Catalog>(responseString);
            return catalog;
            throw new NotImplementedException();
        }
    }
}
