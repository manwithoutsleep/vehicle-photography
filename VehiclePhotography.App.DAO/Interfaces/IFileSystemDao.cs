using System.Collections.Generic;
using VehiclePhotography.App.Models.Entities;
using VehiclePhotography.App.Models.Values;

namespace VehiclePhotography.App.DAO.Interfaces
{
    public interface IFileSystemDao
    {
        List<VehicleInfo> GetVehicleList();
        List<ImageFileInfo> GetImagesForVehicle(string vin);
    }
}
