using System.Threading.Tasks;
using VehiclePhotography.App.Models.Entities;

namespace VehiclePhotography.App.DAO.Interfaces
{
    public interface IVehicleInfoDao
    {
        public Task<VehicleInfo> GetVehicleInfoAsync(string vin);
    }
}
