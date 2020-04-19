using InternalGeoIpBusiness.DataInterfaces;
using InternalGeoIpBusiness.Entities;
using MaxMind.GeoIP2;
using System;
using System.Threading.Tasks;

namespace InternalGeoIpMaxMindData.DataServices
{
    public class DataServiceIpLocation : IDataServiceIpLocation
    {
        private readonly int _accountId;
        private readonly string _licenseKey;

        public DataServiceIpLocation(int accountId, string licenseKey)
        {
            _accountId = accountId;
            _licenseKey = licenseKey;
        }

        public async Task<EntityIpLocation> Read(string ipAddress)
        {
            using (var client = new WebServiceClient(_accountId, _licenseKey))
            {
                try
                {
                    var response = await client.InsightsAsync(ipAddress);

                    return new EntityIpLocation
                    {
                        IpAddress = ipAddress,
                        CountryIsoCode = response.Country.IsoCode,
                        CountryName = response.Country.Name,
                        SubdivisionIsoCode = response.MostSpecificSubdivision.Name,
                        SubdivisionName = response.MostSpecificSubdivision.IsoCode,
                        CityName = response.City.Name,
                        PostalCode = response.Postal.Code,
                        Latitude = response.Location.Latitude.Value,
                        Longitude = response.Location.Longitude.Value,
                    };
                }
                catch(Exception ex)
                {
                    //ToDo: check what will happen if invalid ip
                    return null;
                }
            }
        }
    }
}
