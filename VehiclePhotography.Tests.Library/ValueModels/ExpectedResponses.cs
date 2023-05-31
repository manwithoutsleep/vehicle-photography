using Moq;
using System.Net;
using VehiclePhotography.App.Models.Entities;
using VehiclePhotography.Tests.Library.ValueModels;

namespace VehiclePhotography.Tests.Library.ExpectedResponses
{
    public static class ExpectedResponses
    {

        public static IHttpClientFactory CreateValidNhtsaVehicleApiMockHttpClientFactory(VehicleInfo vehicleInfo)
        {
            var apiResponse = GetValidNhtsaVehicleApiResponse(vehicleInfo);
            var mockHttpMessageHandler = new MockHttpMessageHandler(apiResponse, HttpStatusCode.OK);
            return CreateNhtsaVehicleApiMockHttpClientFactory(mockHttpMessageHandler);
        }

        public static IHttpClientFactory CreateInvalidNhtsaVehicleApiMockHttpClientFactory(string vin, HttpStatusCode httpStatusCode)
        {
            var apiResponse = GetInvalidVinNhtsaVehicleApiResponse(vin);
            var mockHttpMessageHandler = new MockHttpMessageHandler(apiResponse, httpStatusCode);
            return CreateNhtsaVehicleApiMockHttpClientFactory(mockHttpMessageHandler);
        }

        private static IHttpClientFactory CreateNhtsaVehicleApiMockHttpClientFactory(HttpMessageHandler mockHttpMessageHandler)
        {
            var realHttpClient = new HttpClient(mockHttpMessageHandler);
            var mockHttpClientFactory = new Mock<IHttpClientFactory>();
            mockHttpClientFactory
                .Setup(factory => factory.CreateClient(It.IsAny<string>()))
                .Returns(realHttpClient);
            return mockHttpClientFactory.Object;
        }

        private static string GetValidNhtsaVehicleApiResponse(VehicleInfo expectedVehicleInfo)
        {
            return GetValidNhtsaVehicleApiResponse(
                expectedVehicleInfo.Make,
                expectedVehicleInfo.Model,
                expectedVehicleInfo.Year.ToString(),
                expectedVehicleInfo.Vin,
                expectedVehicleInfo.VehicleType.ToString());
        }

        private static string GetInvalidVinNhtsaVehicleApiResponse(string vin)
        {
            return GetValidNhtsaVehicleApiResponse(
                string.Empty,
                string.Empty,
                string.Empty,
                vin,
                string.Empty);
        }

        private static string GetEmptyNhtsaVehicleApiResponse(string vin)
        {
            return $@"
{{
    ""Count"": 1,
    ""Message"": ""Results returned successfully. NOTE: Any missing decoded values should be interpreted as NHTSA does not have data on the specific variable. Missing value should NOT be interpreted as an indication that a feature or technology is unavailable for a vehicle."",
    ""SearchCriteria"": ""VIN(s): {vin}"",
    ""Results"": []
}}";
        }

        private static string GetValidNhtsaVehicleApiResponse(
            string make,
            string model,
            string year,
            string vin,
            string vehicleType
        )
        {
            return $@"
{{
    ""Count"": 1,
    ""Message"": ""Results returned successfully. NOTE: Any missing decoded values should be interpreted as NHTSA does not have data on the specific variable. Missing value should NOT be interpreted as an indication that a feature or technology is unavailable for a vehicle."",
    ""SearchCriteria"": ""VIN(s): {vin}"",
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
            ""Make"": ""{make}"",
            ""MakeID"": ""523"",
            ""Manufacturer"": ""SUBARU CORPORATION"",
            ""ManufacturerId"": ""19109"",
            ""Model"": ""{model}"",
            ""ModelID"": ""2234"",
            ""ModelYear"": ""{year}"",
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
            ""VIN"": ""{vin}"",
            ""ValveTrainDesign"": """",
            ""VehicleDescriptor"": ""JF2SJAEC*EH"",
            ""VehicleType"": ""{vehicleType}"",
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
        }
    }
}
