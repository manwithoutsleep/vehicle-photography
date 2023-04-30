using VehiclePhotography.App.Models.Enums;
using VehiclePhotography.App.Models.Values;

namespace VehiclePhotography.Tests.Models.ValuesTests.VehicleInfoTests
{
    [TestClass]
    public class VehicleInfoShould
    {
        [TestMethod]
        public void ReturnValidEnumWhenCreatedWithValidString()
        {
            // Arrange
            var vehicleType = "Motorcycle";
            // Act
            var sut = new VehicleInfo("irrelevant make", "irrelevant model", 1904, "irrelevant vin", vehicleType);
            // Assert
            Assert.AreEqual(VehicleTypes.Motorcycle, sut.VehicleType);
        }
    }
}
