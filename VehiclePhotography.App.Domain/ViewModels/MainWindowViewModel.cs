using System;
using System.Collections.ObjectModel;
using VehiclePhotography.App.Domain.Values;

namespace VehiclePhotography.App.Domain.ViewModels
{
    public class MainWindowViewModel
    {
        public string Vin { get; set; }

        public ObservableCollection<VehicleInfo> GetVehicleList()
        {
            throw new NotImplementedException();
        }
    }
}
