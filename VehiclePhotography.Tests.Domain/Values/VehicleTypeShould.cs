using Microsoft.VisualStudio.TestTools.UnitTesting;
using VehiclePhotography.App.Domain.Enums;
using VehiclePhotography.App.Domain.Values;

namespace VehiclePhotography.Tests.Domain.Values
{
    [TestClass]
    public class VehicleTypeShould
    {
        [TestMethod]
        public void ReturnValidEnumWhenCreatedWithValidString()
        {
            // Arrange
            var vehicleType = "Motorcycle";
            // Act
            var sut = new VehicleInfo("irrelevant make", "irrelevant model", 1904, "irrelevant color", "irrelevant vin", vehicleType);
            // Assert
            Assert.AreEqual(VehicleTypes.Motorcycle, sut.VehicleType);
        }
    }
}
