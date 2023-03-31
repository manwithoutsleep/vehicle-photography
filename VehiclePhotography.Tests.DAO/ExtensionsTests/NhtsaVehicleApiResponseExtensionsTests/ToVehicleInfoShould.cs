using Microsoft.VisualStudio.TestTools.UnitTesting;
using VehiclePhotography.App.DAO.DataTransferObjects;
using VehiclePhotography.App.DAO.Extensions;
using VehiclePhotography.App.Domain.Values;

namespace VehiclePhotography.Tests.DAO.ExtensionsTests.NhtsaVehicleApiResponseExtensionsTests
{
    [TestClass]
    public class ToVehicleInfoShould
    {
        [TestMethod]
        public void ReturnValidVehicleInfoGivenValidNhtsaVehicleApiResponseWithOnlyOneResult()
        {
            // Arrange
            var expected = new VehicleInfo("expected make", "expected model", 1942, null, "expected vin", "expected vehicle type");
            var source = new NhtsaVehicleApiResponse
            {
                Count = 1,
                Message = "message",
                SearchCriteria = "search criteria",
                Results = new List<NhtsaVehicleApiResponseResult>
                {
                    new NhtsaVehicleApiResponseResult
                    {
                        Make = "expected make",
                        Model = "expected model",
                        ModelYear = "1942",
                        VIN = "expected vin",
                        VehicleType = "expected vehicle type"
                    }
                }
            };

            // Act
            var actual = source.ToVehicleInfo();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
