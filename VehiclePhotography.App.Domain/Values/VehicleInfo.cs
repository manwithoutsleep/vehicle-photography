using System;
using VehiclePhotography.App.Domain.Enums;
using VehiclePhotography.App.Domain.Libraries;

namespace VehiclePhotography.App.Domain.Values
{
    public class VehicleInfo : IEquatable<VehicleInfo>
    {
        public string Make { get; }
        public string Model { get; }
        public int Year { get; }
        public string Vin { get; }
        public VehicleTypes VehicleType { get; }
        public string ThumbnailPath { get; }

        public VehicleInfo(string make, string model, int year, string vin, string vehicleType, string thumbnailPath)
        {
            Make = make;
            Model = model;
            Year = year;
            Vin = vin;
            VehicleType = StringConversions.StringToVehicleType(vehicleType);
            this.ThumbnailPath = thumbnailPath;
        }

        public override string ToString()
        {
            return $"Make: {Make}, Model: {Model}, Year: {Year}, Vin: {Vin}, VehicleType: {VehicleType}";
        }

        public override bool Equals(object obj)
        {
            if (obj is VehicleInfo vehicleInfo)
            {
                return Equals(vehicleInfo);
            }
            return false;
        }

        public override int GetHashCode()
        {
            throw new System.NotImplementedException();
        }

        public bool Equals(VehicleInfo other)
        {
            return Vin == other.Vin;
        }
    }
}
