using Microsoft.VisualStudio.TestTools.UnitTesting;
using VehiclePhotography.App.Domain.Values;

namespace VehiclePhotography.Tests.Domain.ValuesTests.VehicleInfoTests
{
    [TestClass()]
    public class EqualsShould
    {
        [TestMethod]
        public void GivenVehicleInfoWithSameVin_ReturnTrue()
        {
            // Arrange
            var first = new VehicleInfo("irrelevant make", "irrelevant model", 2020, "same vin", "irrelevant car", "irrelevant thumbnailPath");
            var second = new VehicleInfo("different make", "different model", 2021, "same vin", "different car", "different thumbnailPath");

            // Act
            var actual = first.Equals(second);

            // Assert
            Assert.IsTrue(actual);
        }
    }
}
