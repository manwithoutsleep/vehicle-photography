﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using VehiclePhotography.App.Domain.Enums;
using VehiclePhotography.App.Domain.Values;

namespace VehiclePhotography.Tests.Domain.EnumsTests.VehicleTypesTests
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
            var sut = new VehicleInfo("irrelevant make", "irrelevant model", 1904, "irrelevant vin", vehicleType, "irrelevant/thumbnail/path.jpg");
            // Assert
            Assert.AreEqual(VehicleTypes.Motorcycle, sut.VehicleType);
        }
    }
}
