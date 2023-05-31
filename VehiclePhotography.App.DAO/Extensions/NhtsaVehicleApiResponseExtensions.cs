using VehiclePhotography.App.DAO.DataTransferObjects;
using VehiclePhotography.App.Models.Entities;

namespace VehiclePhotography.App.DAO.Extensions
{
    public static class NhtsaVehicleApiResponseExtensions
    {
        public static VehicleInfo? ToVehicleInfo(this NhtsaVehicleApiResponse source)
        {
            var result = source.Results?.FirstOrDefault();
            if (result == null)
            {
                return null;
            }
            _ = int.TryParse(result.ModelYear, out var modelYear);
            return new VehicleInfo(
                result.Make ?? string.Empty,
                result.Model ?? string.Empty,
                modelYear,
                result.VIN ?? string.Empty,
                result.VehicleType ?? string.Empty
            );
        }
    }
}
