using ExternalSiteInvestigationBusiness.DataInterfaces;
using ExternalSiteInvestigationBusiness.Entities;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace ExternalSiteInvestigationHttpClientDataService.DataServices
{
    public class DataServiceOrder : IDataServiceOrder
    {
        private readonly HttpClient _httpClient;

        public DataServiceOrder(string url)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(url);
        }

        public async Task<EntityOrder> Create(EntityOrder entityOrder, CancellationToken cancellationToken)
        {
            //ToDo: Cross Cutting Concern
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await _httpClient.PutAsJsonAsync("api/v1/orders", entityOrder, cancellationToken);
            return await response.Content.ReadAsAsync<EntityOrder>();
        }
    }
}
