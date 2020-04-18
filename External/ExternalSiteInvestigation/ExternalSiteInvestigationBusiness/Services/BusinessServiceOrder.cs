using ExternalSiteInvestigationBusiness.Interfaces;
using ExternalSiteInvestigationBusiness.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace ExternalSiteInvestigationBusiness.Services
{
    public class BusinessServiceOrder: IBusinessServiceOrder
    {
        private readonly HttpClient _httpClient;

        public BusinessServiceOrder(string url)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(url);
        }

        public async Task<Order> Create(Order order, CancellationToken cancellationToken)
        {
            //ToDo: Cross Cutting Concern
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await _httpClient.PutAsJsonAsync("api/v1/orders", order, cancellationToken);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<Order>();
        }
    }
}
