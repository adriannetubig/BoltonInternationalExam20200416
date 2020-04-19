using ExternalSiteInvestigationApi.Dto;
using ExternalSiteInvestigationApi.Interfaces;
using ExternalSiteInvestigationApi.Services;
using ExternalSiteInvestigationBusiness.BusinessInterfaces;
using ExternalSiteInvestigationBusiness.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ExternalSiteInvestigationTest.AppServices
{
    public class UnitTestAppServiceSiteInvestigationRequest
    {
        private IAppServiceSiteInvestigationRequest _iAppServiceSiteInvestigationRequest;
        private DomainCheck _domainCheck;
        private Order _order;
        private SiteInvestigationRequest _siteInvestigationRequest;

        Mock<IBusinessServiceDomainCheck> _moqBusinessServiceDomainCheck;
        Mock<IBusinessServiceOrder> _moqBusinessServiceOrder;

        public UnitTestAppServiceSiteInvestigationRequest()
        {
            _moqBusinessServiceDomainCheck = new Mock<IBusinessServiceDomainCheck>();
            _moqBusinessServiceOrder = new Mock<IBusinessServiceOrder>();

            _order = new Order
            {
                OrderId = 0,
                CustomerName = "UnitTest"
            };

            _domainCheck = new DomainCheck
            {
                Domain ="UnitTestDomain",
                IpAddresses = new List<IpAddressCheck>()
                {
                    new IpAddressCheck
                    {
                        IpAddress = "0:0:0:1",
                        Ports = new List<int>()
                        {
                            80
                        }
                    }
                }
            };

            _siteInvestigationRequest = new SiteInvestigationRequest
            {
                Domain = "UnitTestDomain",
                CustomerName = "UnitTestCustomer"
            };
        }

        [Fact]
        public async Task TestCreateWithValidDomain()
        {
            _moqBusinessServiceDomainCheck.Setup(a => a.Read(It.IsAny<int>(), It.IsAny<string>(), default)).Returns(Task.FromResult(_domainCheck));
            _moqBusinessServiceOrder.Setup(a => a.Create(It.IsAny<Order>(), default)).Returns(Task.FromResult(_order));

            _iAppServiceSiteInvestigationRequest = new AppServiceSiteInvestigationRequest(_moqBusinessServiceDomainCheck.Object, _moqBusinessServiceOrder.Object);

            var result = await _iAppServiceSiteInvestigationRequest.Create(_siteInvestigationRequest, default);
            var objectResponse = result as ObjectResult;
            var value = objectResponse.Value as InvestigationResult;
            Assert.True(value.IsDomainValid);
        }

        [Fact]
        public async Task TestCreateWithInValidDomain()
        {
            _moqBusinessServiceDomainCheck.Setup(a => a.Read(It.IsAny<int>(), It.IsAny<string>(), default)).Returns(Task.FromResult<DomainCheck>(null));
            _moqBusinessServiceOrder.Setup(a => a.Create(It.IsAny<Order>(), default)).Returns(Task.FromResult(_order));

            _iAppServiceSiteInvestigationRequest = new AppServiceSiteInvestigationRequest(_moqBusinessServiceDomainCheck.Object, _moqBusinessServiceOrder.Object);

            var result = await _iAppServiceSiteInvestigationRequest.Create(_siteInvestigationRequest, default);
            var objectResponse = result as ObjectResult;
            var value = objectResponse.Value as InvestigationResult;
            Assert.True(!value.IsDomainValid);
        }
    }
}
