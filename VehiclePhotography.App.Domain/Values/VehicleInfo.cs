using VehiclePhotography.App.Domain.Enums;
using VehiclePhotography.App.Domain.Libraries;

namespace VehiclePhotography.App.Domain.Values
{
    public class VehicleInfo
    {
        public string Make { get; private set; }
        public string Model { get; private set; }
        public int Year { get; private set; }
        public string Color { get; private set; }
        public string Vin { get; private set; }
        public VehicleTypes VehicleType { get; private set; }

        public VehicleInfo(string make, string model, int year, string color, string vin, string vehicleType)
        {
            Make = make;
            Model = model;
            Year = year;
            Color = color;
            Vin = vin;
            VehicleType = StringConversions.StringToVehicleType(vehicleType);
        }
    }
}
