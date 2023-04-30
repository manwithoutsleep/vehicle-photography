using VehiclePhotography.App.Models.Enums;
using VehiclePhotography.App.Models.Libraries;

namespace VehiclePhotography.Tests.Models.LibrariesTests.VehicleTypesTests
{
    [TestClass()]
    public class StringToVehicleTypeShould
    {
        [DataTestMethod()]
        [DataRow("Motorcycle", VehicleTypes.Motorcycle)]
        [DataRow("MOTORCYCLE", VehicleTypes.Motorcycle)]
        [DataRow("PassengerCar", VehicleTypes.PassengerCar)]
        [DataRow("Passenger Car", VehicleTypes.PassengerCar)]
        [DataRow("Truck", VehicleTypes.Truck)]
        [DataRow("Bus", VehicleTypes.Bus)]
        [DataRow("Trailer", VehicleTypes.Trailer)]
        [DataRow("MultipurposePassengerVehicle", VehicleTypes.MultipurposePassengerVehicle)]
        [DataRow("MultipurposePassengerVehicle (MPV)", VehicleTypes.MultipurposePassengerVehicle)]
        [DataRow("Multipurpose Passenger Vehicle", VehicleTypes.MultipurposePassengerVehicle)]
        [DataRow("Multipurpose Passenger Vehicle (MPV)", VehicleTypes.MultipurposePassengerVehicle)]
        [DataRow("LowSpeedVehicle", VehicleTypes.LowSpeedVehicle)]
        [DataRow("LowSpeedVehicle (LSV)", VehicleTypes.LowSpeedVehicle)]
        [DataRow("Low Speed Vehicle", VehicleTypes.LowSpeedVehicle)]
        [DataRow("Low Speed Vehicle (LSV)", VehicleTypes.LowSpeedVehicle)]
        [DataRow("IncompleteVehicle", VehicleTypes.IncompleteVehicle)]
        [DataRow("Incomplete Vehicle", VehicleTypes.IncompleteVehicle)]
        [DataRow("OffRoadVehicle", VehicleTypes.OffRoadVehicle)]
        [DataRow("Off Road Vehicle", VehicleTypes.OffRoadVehicle)]
        [DataRow("", VehicleTypes.Empty)]
        public void ReturnVehicleTypeEnumForValidValues(string vehicleType, VehicleTypes expected)
        {
            // Act
            var actual = StringConversions.StringToVehicleType(vehicleType);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ThrowArgumentExceptionForInvalidValues()
        {
            // Act & Assert
            var actualException = Assert.ThrowsException<ArgumentException>(() => StringConversions.StringToVehicleType("invalid value"));
            Assert.AreEqual(actualException.Message, "invalid value cannot be converted to VehicleTypes");
        }
    }
}
