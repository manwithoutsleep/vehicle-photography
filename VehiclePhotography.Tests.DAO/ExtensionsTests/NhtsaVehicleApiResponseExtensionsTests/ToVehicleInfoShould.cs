using Microsoft.VisualStudio.TestTools.UnitTesting;
using VehiclePhotography.App.DAO.DataTransferObjects;
using VehiclePhotography.App.DAO.Extensions;
using VehiclePhotography.App.Models.Enums;
using VehiclePhotography.App.Models.Values;

namespace VehiclePhotography.Tests.DAO.ExtensionsTests.NhtsaVehicleApiResponseExtensionsTests
{
    [TestClass]
    public class ToVehicleInfoShould
    {
        [TestMethod]
        public void GivenValidNhtsaVehicleApiResponseWithOnlyOneResult_ReturnValidVehicleInfo()
        {
            // Arrange
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
                        VehicleType = "PassengerCar"
                    }
                }
            };

            // Act
            var actual = source.ToVehicleInfo();

            // Assert
            var expected = new VehicleInfo("expected make", "expected model", 1942, "expected vin", "PassengerCar");
            Assert.AreEqual(expected.ToString(), actual!.ToString());
        }

        [TestMethod]
        public void GivenValidNhtsaVehicleApiResponseWithMultipleResults_ReturnTheFirstValidVehicleInfo()
        {
            // Arrange
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
                        VehicleType = "PassengerCar"
                    },
                    new NhtsaVehicleApiResponseResult
                    {
                        Make = "incorrect make",
                        Model = "incorrect model",
                        ModelYear = "1946",
                        VIN = "incorrect vin",
                        VehicleType = "Motorcycle"
                    }
                }
            };

            // Act
            var actual = source.ToVehicleInfo();

            // Assert
            var expected = new VehicleInfo("expected make", "expected model", 1942, "expected vin", "PassengerCar");
            Assert.AreEqual(expected.ToString(), actual!.ToString());
        }

        [TestMethod]
        public void GivenValidNhtsaVehicleApiResponseWithEmptyResults_ReturnNull()
        {
            // Arrange
            var source = new NhtsaVehicleApiResponse
            {
                Count = 0,
                Message = "message",
                SearchCriteria = "search criteria",
                Results = new List<NhtsaVehicleApiResponseResult>{ }
            };

            // Act
            var actual = source.ToVehicleInfo();

            // Assert
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void GivenValidNhtsaVehicleApiResponseWithNullResults_ReturnNull()
        {
            // Arrange
            var source = new NhtsaVehicleApiResponse
            {
                Count = 0,
                Message = "message",
                SearchCriteria = "search criteria",
                Results = null
            };

            // Act
            var actual = source.ToVehicleInfo();

            // Assert
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void GivenValidNhtsaVehicleResponseWithNullValues_ReturnValidResultWithProperDefaults()
        {
            // Arrange
            var source = new NhtsaVehicleApiResponse
            {
                Count = 1,
                Message = "message",
                SearchCriteria = "search criteria",
                Results = new List<NhtsaVehicleApiResponseResult>
                {
                    new NhtsaVehicleApiResponseResult {
                        VehicleType = "Motorcycle"
                    }
                }
            };

            // Act
            var actual = source.ToVehicleInfo();

            // Assert
            var expected = new VehicleInfo(string.Empty, string.Empty, 0, string.Empty, "Motorcycle");
            Assert.AreEqual(expected.ToString(), actual!.ToString());
        }
    }
}
