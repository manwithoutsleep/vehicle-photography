using VehiclePhotography.App.Models.Enums;
using VehiclePhotography.App.Models.Libraries;

namespace VehiclePhotography.App.Models.Values
{
    public class VehicleInfo
    {
        public string Make { get; }
        public string Model { get; }
        public int Year { get; }
        public string Vin { get; }
        public VehicleTypes VehicleType { get; }
        public string? ThumbnailPath { get; }

        public VehicleInfo(string make, string model, int year, string vin, string vehicleType)
        {
            Make = make;
            Model = model;
            Year = year;
            Vin = vin;
            VehicleType = StringConversions.StringToVehicleType(vehicleType);
        }

        public override string ToString()
        {
            return $"Make: {Make}, Model: {Model}, Year: {Year}, Vin: {Vin}, VehicleType: {VehicleType}";
        }
    }
}
