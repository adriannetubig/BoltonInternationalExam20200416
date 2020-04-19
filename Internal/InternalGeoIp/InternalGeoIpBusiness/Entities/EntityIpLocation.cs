namespace InternalGeoIpBusiness.Entities
{
    public class EntityIpLocation
    {
        public string IpAddress { get; set; }
        public string CountryIsoCode { get; set; }
        public string CountryName { get; set; }
        public string SubdivisionIsoCode { get; set; }
        public string SubdivisionName { get; set; }
        public string CityName { get; set; }
        public string PostalCode { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
