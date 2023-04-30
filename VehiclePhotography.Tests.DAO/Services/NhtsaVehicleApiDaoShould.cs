using Moq;
using System.Net;
using VehiclePhotography.App.DAO.Services;
using VehiclePhotography.App.Models.Exceptions;
using VehiclePhotography.App.Models.Values;
using VehiclePhotography.Tests.Library.ExpectedResponses;

namespace VehiclePhotography.Tests.DAO
{
    [TestClass()]
    public class NhtsaVehicleApiDaoShould
    {
        [TestMethod()]
        public async Task GetVehicleInfoAsync_IntegrationTest()
        {
            // Arrange
            var givenVin = "JF2SJAEC1EH460860"; // 2014 Subaru Forester
            var sut = new NhtsaVehicleApiDao(CreateRealHttpClientFactory());

            // Act
            var actual = await sut.GetVehicleInfoAsync(givenVin);

            // Assert
            Assert.IsNotNull(actual);
            var expected = new VehicleInfo("SUBARU", "Forester", 2014, givenVin, "MULTIPURPOSE PASSENGER VEHICLE (MPV)");
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestMethod()]
        public async Task GivenValidAPIResponse_ReturnValidVehicleInfo()
        {
            // Arrange
            var givenVin = "JF2SJAEC1EH460860";
            var expectedVehicleInfo = new VehicleInfo("SUBARU", "Forester", 2014, givenVin, "MULTIPURPOSE PASSENGER VEHICLE (MPV)");
            var httpClientFactory = ExpectedResponses.CreateValidNhtsaVehicleApiMockHttpClientFactory(expectedVehicleInfo);
            var sut = new NhtsaVehicleApiDao(httpClientFactory);

            // Act
            var actual = await sut.GetVehicleInfoAsync(givenVin);

            // Assert
            var expected = string.Empty;
            Assert.AreEqual(expectedVehicleInfo.ToString(), actual.ToString());
        }

        [TestMethod()]
        public async Task GivenUnsuccessfulAPIResponse_ThrowNhtsaVehicleApiException()
        {
            // Arrange
            var givenVin = "irrelevant VIN";
            var httpClientFactory = ExpectedResponses.CreateInvalidNhtsaVehicleApiMockHttpClientFactory(givenVin, HttpStatusCode.InternalServerError);
            var sut = new NhtsaVehicleApiDao(httpClientFactory);

            // Act & Assert
            var actualException = await Assert.ThrowsExceptionAsync<NhtsaVehicleApiException>(async () => {
                await sut.GetVehicleInfoAsync(givenVin);
            });

            // Assert
            Assert.AreEqual($"Error getting vehicle info for VIN '{givenVin}'", actualException.Message);
        }

        [TestMethod()]
        public async Task GivenHttpRequestException_ThrowNhtsaVehicleApiException()
        {
            // Arrange
            var givenVin = "irrelevant VIN";
            var httpClientFactory = ExpectedResponses.CreateInvalidNhtsaVehicleApiMockHttpClientFactory(givenVin, HttpStatusCode.InternalServerError);
            var sut = new NhtsaVehicleApiDao(httpClientFactory);

            // Act & Assert
            var actualException = await Assert.ThrowsExceptionAsync<NhtsaVehicleApiException>(async () => { 
                await sut.GetVehicleInfoAsync(givenVin);
            });

            // Assert
            Assert.AreEqual($"Error getting vehicle info for VIN '{givenVin}'", actualException.Message);
        }

        private IHttpClientFactory CreateRealHttpClientFactory()
        {
            var httpClient = new HttpClient();
            var httpClientFactory = new Mock<IHttpClientFactory>();
            httpClientFactory
                .Setup(factory => factory.CreateClient(It.IsAny<string>()))
                .Returns(httpClient);
            return httpClientFactory.Object;
        }
    }
}