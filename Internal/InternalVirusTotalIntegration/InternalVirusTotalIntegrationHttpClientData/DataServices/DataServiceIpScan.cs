using InternalVirusTotalIntegrationBusiness.DataInterfaces;
using InternalVirusTotalIntegrationBusiness.Entities;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace InternalVirusTotalIntegrationHttpClientData.DataServices
{
    public class DataServiceIpScan : IDataServiceIpScan
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public DataServiceIpScan(string url, string apiKey)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(url);
            _apiKey = apiKey;
        }
        public async Task<EntityVirusTotalResult> Read(string ipAddress, CancellationToken cancellationToken)
        {
            //ToDo: Cross Cutting Concern
            _httpClient.DefaultRequestHeaders.Add("x-apikey", _apiKey);

            HttpResponseMessage response = await _httpClient.GetAsync($"api/v3/ip_addresses/{ipAddress}", cancellationToken);

            //Prevent error if domain is invalid
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return await response.Content.ReadAsAsync<EntityVirusTotalResult>();
            else
                return null;
        }
    }
}
