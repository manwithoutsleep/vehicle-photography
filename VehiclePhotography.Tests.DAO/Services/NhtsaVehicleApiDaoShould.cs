using Microsoft.VisualStudio.TestTools.UnitTesting;
using VehiclePhotography.App.DAO.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclePhotography.App.Domain.Values;

namespace VehiclePhotography.Tests.DAO
{
    [TestClass()]
    public class NhtsaVehicleApiDaoShould
    {
        [TestMethod()]
        public async Task GetVehicleInfoTest()
        {
            // Arrange
            var givenVin = "given vin";
            var expected = new VehicleInfo("expected make", "expected model", 1942, "expected color", givenVin, "expected vehicle type");
            var sut = new NhtsaVehicleApiDao();

            // Act
            var actual = await sut.GetVehicleInfoAsync(givenVin);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}