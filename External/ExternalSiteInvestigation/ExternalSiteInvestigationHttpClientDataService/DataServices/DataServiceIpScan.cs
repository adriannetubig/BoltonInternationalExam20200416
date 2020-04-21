using ExternalSiteInvestigationBusiness.DataInterfaces;
using ExternalSiteInvestigationBusiness.Entities;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace ExternalSiteInvestigationHttpClientDataService.DataServices
{
    public class DataServiceIpScan : IDataServiceIpScan
    {
        private readonly HttpClient _httpClient;

        public DataServiceIpScan(string url)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(url);
        }

        public async Task<EntityIpScan> Read(string ipAddress, CancellationToken cancellationToken)
        {
            //ToDo: Cross Cutting Concern
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await _httpClient.GetAsync($"api/v1/IpScan/{ipAddress}", cancellationToken);

            //Prevent error if IpScan is invalid
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return await response.Content.ReadAsAsync<EntityIpScan>();
            else
                return null;
        }
    }
}
