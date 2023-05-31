using VehiclePhotography.App.Models.Entities;

namespace VehiclePhotography.Tests.Models.EntitiesTests.VehicleInfoTests
{
    [TestClass()]
    public class ToStringShould
    {
        [TestMethod]
        public void ReturnSerializedObject()
        {
            // Arrange
            var sut = new VehicleInfo("irrelevant make", "irrelevant model", 1904, "irrelevant vin", "Motorcycle");

            // Act
            var actual = sut.ToString();

            // Assert
            var expected = "Make: irrelevant make, Model: irrelevant model, Year: 1904, Vin: irrelevant vin, VehicleType: Motorcycle";
            Assert.AreEqual(expected, actual);
        }
    }
}
