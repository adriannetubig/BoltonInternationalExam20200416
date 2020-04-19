using ExternalSiteInvestigationBusiness.DataInterfaces;
using ExternalSiteInvestigationBusiness.Entities;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace ExternalSiteInvestigationHttpClientDataService.DataServices
{
    public class DataServiceDomainCheck : IDataServiceDomainCheck
    {
        private readonly HttpClient _httpClient;

        public DataServiceDomainCheck(string url)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(url);
        }

        public async Task<EntityDomainCheck> Read(int orderId, string domainName, CancellationToken cancellationToken)
        {
            //ToDo: Cross Cutting Concern
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await _httpClient.GetAsync($"api/v1/domains/{orderId}/{domainName}", cancellationToken);

            //Prevent error if domain is invalid
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return await response.Content.ReadAsAsync<EntityDomainCheck>();
            else
                return null;
        }
    }
}
