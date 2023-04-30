using System.Threading.Tasks;
using VehiclePhotography.App.Models.Values;

namespace VehiclePhotography.App.DAO.Interfaces
{
    public interface IVehicleInfoDao
    {
        public Task<VehicleInfo> GetVehicleInfoAsync(string vin);
    }
}
