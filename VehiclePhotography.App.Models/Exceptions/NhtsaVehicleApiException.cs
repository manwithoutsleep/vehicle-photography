namespace VehiclePhotography.App.Models.Exceptions
{
    public class NhtsaVehicleApiException : Exception
    {
        public NhtsaVehicleApiException() { }
        public NhtsaVehicleApiException(string message) : base(message) {}
        public NhtsaVehicleApiException(string message, Exception innerException) : base(message, innerException) { }
    }
}
