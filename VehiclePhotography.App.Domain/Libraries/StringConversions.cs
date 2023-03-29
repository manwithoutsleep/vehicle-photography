using System;
using VehiclePhotography.App.Domain.Enums;

namespace VehiclePhotography.App.Domain.Libraries
{
    public static class StringConversions
    {
        public static VehicleTypes StringToVehicleType(string value)
        {
            switch (value)
            {
                case "Motorcycle":
                    return VehicleTypes.Motorcycle;
                case "PassengerCar":
                case "Passenger Car":
                    return VehicleTypes.PassengerCar;
                case "Truck":
                    return VehicleTypes.Truck;
                case "Bus":
                    return VehicleTypes.Bus;
                case "Trailer":
                    return VehicleTypes.Trailer;
                case "MultipurposePassengerVehicle":
                case "MultipurposePassengerVehicle (MPV)":
                case "Multipurpose Passenger Vehicle":
                case "Multipurpose Passenger Vehicle (MPV":
                    return VehicleTypes.MultipurposePassengerVehicle;
                case "LowSpeedVehicle":
                case "LowSpeedVehicle (LSV)":
                case "Low Speed Vehicle":
                case "Low Speed Vehicle (LSV)":
                    return VehicleTypes.LowSpeedVehicle;
                case "IncompleteVehicle":
                case "Incomplete Vehicle":
                    return VehicleTypes.IncompleteVehicle;
                case "OffRoadVehicle":
                case "Off Road Vehicle":
                    return VehicleTypes.OffRoadVehicle;
                default:
                    throw new ArgumentException($"{value} cannot be converted to VehicleTypes");
            }
        }
    }
}
