namespace VehiclePhotography.App.DAO.DataTransferObjects
{
    public class NhtsaVehicleApiResponse
    {
        public int Count { get; set; }
        public string? Message { get; set; }
        public string? SearchCriteria { get; set; }
        public List<NhtsaVehicleApiResponseResult>? Results { get; set; }
    }
}
