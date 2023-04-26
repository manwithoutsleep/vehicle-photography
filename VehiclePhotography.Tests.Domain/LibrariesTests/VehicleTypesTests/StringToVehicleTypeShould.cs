using Microsoft.VisualStudio.TestTools.UnitTesting;
using VehiclePhotography.App.Domain.Enums;
using VehiclePhotography.App.Domain.Libraries;

namespace VehiclePhotography.Tests.Domain.LibrariesTests.VehicleTypesTests
{
    [TestClass]
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
            Exception? expectedException = null;
            try
            {
                StringConversions.StringToVehicleType("invalid value");
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }

            Assert.IsNotNull(expectedException);
            Assert.IsInstanceOfType(expectedException, typeof(ArgumentException));
            Assert.AreEqual(expectedException.Message, "invalid value cannot be converted to VehicleTypes");
        }
    }
}
