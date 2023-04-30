﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using VehiclePhotography.App.DAO.DataTransferObjects;
using VehiclePhotography.App.DAO.Extensions;
using VehiclePhotography.App.Domain.Values;

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
            var expected = new VehicleInfo("expected make", "expected model", 1942, "expected vin", "PassengerCar", "expected/thumbnail/path.jpg");
            Assert.AreEqual(expected.ToString(), actual.ToString());
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
            var expected = new VehicleInfo("expected make", "expected model", 1942, "expected vin", "PassengerCar", "expected/thumbnail/path.jpg");
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestMethod]
        public void GivenValidNhtsaVehicleApiResponseWithNoResults_ReturnNull()
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
    }
}
