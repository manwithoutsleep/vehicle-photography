using System.Linq;
using VehiclePhotography.App.DAO.DataTransferObjects;
using VehiclePhotography.App.Domain.Values;

namespace VehiclePhotography.App.DAO.Extensions
{
    public static class NhtsaVehicleApiResponseExtensions
    {
        public static VehicleInfo ToVehicleInfo(this NhtsaVehicleApiResponse source)
        {
            var result = source.Results.First();
            return new VehicleInfo(result.Make, result.Model, int.Parse(result.ModelYear), null, result.VIN, result.VehicleType);
        }
    }
}
