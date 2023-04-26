using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net;
using System.Text.Json;
using VehiclePhotography.App.DAO.Services;
using VehiclePhotography.App.Domain.Values;
using VehiclePhotography.Tests.DAO.ValueModels;

namespace VehiclePhotography.Tests.DAO
{
    [TestClass()]
    public class NhtsaVehicleApiDaoShould
    {
        [TestMethod()]
        public async Task GetVehicleInfoTest()
        {
            // Arrange
            var givenVin = "JF2SJAEC1EH460860";
            var expectedVehicleInfo = new VehicleInfo("SUBARU", "Forester", 2014, givenVin, "MULTIPURPOSE PASSENGER VEHICLE (MPV)");
            var httpClientFactory = CreateMockHttpClientFactory(expectedVehicleInfo);
            var sut = new NhtsaVehicleApiDao(httpClientFactory);

            // Act
            var actual = await sut.GetVehicleInfoAsync(givenVin);

            // Assert
            var expected = string.Empty;
            Assert.AreEqual(expectedVehicleInfo.ToString(), actual.ToString());
        }

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

        private IHttpClientFactory CreateMockHttpClientFactory(VehicleInfo vehicleInfo)
        {
            var apiResponse = GetApiResponse(vehicleInfo);
            var httpMessageHandler = new MockHttpMessageHandler(apiResponse, HttpStatusCode.OK);
            var realHttpClient = new HttpClient(httpMessageHandler);
            var httpClientFactory = new Mock<IHttpClientFactory>();
            httpClientFactory
                .Setup(factory => factory.CreateClient(It.IsAny<string>()))
                .Returns(realHttpClient);
            return httpClientFactory.Object;
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

        private string GetApiResponse(VehicleInfo expectedVehicleInfo)
        {
            var result = $@"
{{
    ""Count"": 1,
    ""Message"": ""Results returned successfully. NOTE: Any missing decoded values should be interpreted as NHTSA does not have data on the specific variable. Missing value should NOT be interpreted as an indication that a feature or technology is unavailable for a vehicle."",
    ""SearchCriteria"": ""VIN(s): {expectedVehicleInfo.Vin}"",
    ""Results"": [
        {{
            ""ABS"": """",
            ""ActiveSafetySysNote"": """",
            ""AdaptiveCruiseControl"": """",
            ""AdaptiveDrivingBeam"": """",
            ""AdaptiveHeadlights"": """",
            ""AdditionalErrorText"": """",
            ""AirBagLocCurtain"": ""1st and 2nd Rows"",
            ""AirBagLocFront"": ""1st Row (Driver and Passenger)"",
            ""AirBagLocKnee"": ""Driver Seat Only"",
            ""AirBagLocSeatCushion"": """",
            ""AirBagLocSide"": ""1st Row (Driver and Passenger)"",
            ""AutoReverseSystem"": """",
            ""AutomaticPedestrianAlertingSound"": """",
            ""AxleConfiguration"": """",
            ""Axles"": """",
            ""BasePrice"": """",
            ""BatteryA"": """",
            ""BatteryA_to"": """",
            ""BatteryCells"": """",
            ""BatteryInfo"": """",
            ""BatteryKWh"": """",
            ""BatteryKWh_to"": """",
            ""BatteryModules"": """",
            ""BatteryPacks"": """",
            ""BatteryType"": """",
            ""BatteryV"": """",
            ""BatteryV_to"": """",
            ""BedLengthIN"": """",
            ""BedType"": """",
            ""BlindSpotIntervention"": """",
            ""BlindSpotMon"": """",
            ""BodyCabType"": """",
            ""BodyClass"": ""Sport Utility Vehicle (SUV)\/Multi-Purpose Vehicle (MPV)"",
            ""BrakeSystemDesc"": """",
            ""BrakeSystemType"": """",
            ""BusFloorConfigType"": ""Not Applicable"",
            ""BusLength"": """",
            ""BusType"": ""Not Applicable"",
            ""CAN_AACN"": """",
            ""CIB"": """",
            ""CashForClunkers"": """",
            ""ChargerLevel"": """",
            ""ChargerPowerKW"": """",
            ""CoolingType"": """",
            ""CurbWeightLB"": """",
            ""CustomMotorcycleType"": ""Not Applicable"",
            ""DaytimeRunningLight"": """",
            ""DestinationMarket"": """",
            ""DisplacementCC"": ""2500.0"",
            ""DisplacementCI"": ""152.55936023683"",
            ""DisplacementL"": ""2.5"",
            ""Doors"": ""4"",
            ""DriveType"": ""AWD\/All-Wheel Drive"",
            ""DriverAssist"": """",
            ""DynamicBrakeSupport"": """",
            ""EDR"": """",
            ""ESC"": """",
            ""EVDriveUnit"": """",
            ""ElectrificationLevel"": """",
            ""EngineConfiguration"": ""Horizontally opposed (boxer)"",
            ""EngineCycles"": """",
            ""EngineCylinders"": ""4"",
            ""EngineHP"": """",
            ""EngineHP_to"": """",
            ""EngineKW"": """",
            ""EngineManufacturer"": ""Subaru"",
            ""EngineModel"": ""2.5NA U5"",
            ""EntertainmentSystem"": """",
            ""ErrorCode"": ""0"",
            ""ErrorText"": ""0 - VIN decoded clean. Check Digit (9th position) is correct"",
            ""ForwardCollisionWarning"": """",
            ""FuelInjectionType"": """",
            ""FuelTypePrimary"": ""Gasoline"",
            ""FuelTypeSecondary"": """",
            ""GCWR"": """",
            ""GCWR_to"": """",
            ""GVWR"": ""Class 1C: 4,001 - 5,000 lb (1,814 - 2,268 kg)"",
            ""GVWR_to"": """",
            ""KeylessIgnition"": """",
            ""LaneCenteringAssistance"": """",
            ""LaneDepartureWarning"": """",
            ""LaneKeepSystem"": """",
            ""LowerBeamHeadlampLightSource"": """",
            ""Make"": ""{expectedVehicleInfo.Make}"",
            ""MakeID"": ""523"",
            ""Manufacturer"": ""SUBARU CORPORATION"",
            ""ManufacturerId"": ""19109"",
            ""Model"": ""{expectedVehicleInfo.Model}"",
            ""ModelID"": ""2234"",
            ""ModelYear"": ""{expectedVehicleInfo.Year}"",
            ""MotorcycleChassisType"": ""Not Applicable"",
            ""MotorcycleSuspensionType"": ""Not Applicable"",
            ""NCSABodyType"": """",
            ""NCSAMake"": """",
            ""NCSAMapExcApprovedBy"": """",
            ""NCSAMapExcApprovedOn"": """",
            ""NCSAMappingException"": """",
            ""NCSAModel"": """",
            ""NCSANote"": """",
            ""NonLandUse"": """",
            ""Note"": """",
            ""OtherBusInfo"": """",
            ""OtherEngineInfo"": """",
            ""OtherMotorcycleInfo"": """",
            ""OtherRestraintSystemInfo"": """",
            ""OtherTrailerInfo"": """",
            ""ParkAssist"": """",
            ""PedestrianAutomaticEmergencyBraking"": """",
            ""PlantCity"": ""OTA"",
            ""PlantCompanyName"": ""FHI(Yajima Plant)"",
            ""PlantCountry"": ""JAPAN"",
            ""PlantState"": ""GUNMA"",
            ""PossibleValues"": """",
            ""Pretensioner"": """",
            ""RearAutomaticEmergencyBraking"": """",
            ""RearCrossTrafficAlert"": """",
            ""RearVisibilitySystem"": """",
            ""SAEAutomationLevel"": """",
            ""SAEAutomationLevel_to"": """",
            ""SeatBeltsAll"": ""Manual"",
            ""SeatRows"": """",
            ""Seats"": """",
            ""SemiautomaticHeadlampBeamSwitching"": """",
            ""Series"": """",
            ""Series2"": ""Wagon Body Type"",
            ""SteeringLocation"": """",
            ""SuggestedVIN"": """",
            ""TPMS"": ""Direct"",
            ""TopSpeedMPH"": """",
            ""TrackWidth"": """",
            ""TractionControl"": """",
            ""TrailerBodyType"": ""Not Applicable"",
            ""TrailerLength"": """",
            ""TrailerType"": ""Not Applicable"",
            ""TransmissionSpeeds"": """",
            ""TransmissionStyle"": ""Continuously Variable Transmission (CVT)"",
            ""Trim"": ""Premium+AWP+M\/R"",
            ""Trim2"": """",
            ""Turbo"": ""No"",
            ""VIN"": ""{expectedVehicleInfo.Vin}"",
            ""ValveTrainDesign"": """",
            ""VehicleDescriptor"": ""JF2SJAEC*EH"",
            ""VehicleType"": ""MULTIPURPOSE PASSENGER VEHICLE (MPV)"",
            ""WheelBaseLong"": """",
            ""WheelBaseShort"": """",
            ""WheelBaseType"": """",
            ""WheelSizeFront"": """",
            ""WheelSizeRear"": """",
            ""Wheels"": """",
            ""Windows"": """"
        }}
    ]
}}";
            return result;
        }
    }
}