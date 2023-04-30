using System.Collections.Generic;
using VehiclePhotography.App.Domain.Values;

namespace VehiclePhotography.App.DAO.Interfaces
{
    public interface IFileSystemDao
    {
        List<VehicleInfo> GetVehicleList();
        List<ImageFileInfo> GetImagesForVehicle(string vin);
    }
}
