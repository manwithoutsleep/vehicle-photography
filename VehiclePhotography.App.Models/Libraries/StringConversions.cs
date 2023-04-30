using VehiclePhotography.App.Models.Enums;

namespace VehiclePhotography.App.Models.Libraries
{
    public static class StringConversions
    {
        public static VehicleTypes StringToVehicleType(string value)
        {
            switch (value.ToLower())
            {
                case "motorcycle":
                    return VehicleTypes.Motorcycle;
                case "passengercar":
                case "passenger car":
                    return VehicleTypes.PassengerCar;
                case "truck":
                    return VehicleTypes.Truck;
                case "bus":
                    return VehicleTypes.Bus;
                case "trailer":
                    return VehicleTypes.Trailer;
                case "multipurposepassengervehicle":
                case "multipurposepassengervehicle (mpv)":
                case "multipurpose passenger vehicle":
                case "multipurpose passenger vehicle (mpv)":
                    return VehicleTypes.MultipurposePassengerVehicle;
                case "lowspeedvehicle":
                case "lowspeedvehicle (lsv)":
                case "low speed vehicle":
                case "low speed vehicle (lsv)":
                    return VehicleTypes.LowSpeedVehicle;
                case "incompletevehicle":
                case "incomplete vehicle":
                    return VehicleTypes.IncompleteVehicle;
                case "offroadvehicle":
                case "off road vehicle":
                    return VehicleTypes.OffRoadVehicle;
                case "":
                    return VehicleTypes.Empty;
                default:
                    throw new ArgumentException($"{value} cannot be converted to VehicleTypes");
            }
        }
    }
}
