using InternalDomainCheckerApi.Interfaces;
using InternalDomainCheckerApi.Services;
using InternalDomainCheckerBusiness.BusinessInterfaces;
using InternalDomainCheckerBusiness.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace InternalDomainCheckerApiTest.Services
{
    public class UnitTestAppServiceDomain
    {
        private IAppServiceDomain _iAppServiceDomain;

        private Domain _domain;
        private List<DomainIpAddress> _domainIpAddresses;


        Mock<IBusinessServiceDomain> _moqBusinessServiceDomain;
        Mock<IBusinessServiceDomainIpAddress> _moqBusinessServiceDomainIpAddress;
        Mock<IBusinessServiceOpenPort> _moqBusinessServiceOpenPort;

        public UnitTestAppServiceDomain()
        {
            _moqBusinessServiceDomain = new Mock<IBusinessServiceDomain>();
            _moqBusinessServiceDomainIpAddress = new Mock<IBusinessServiceDomainIpAddress>();
            _moqBusinessServiceOpenPort = new Mock<IBusinessServiceOpenPort>();
            _domain = new Domain
            {
                DomainId = 0,
                DomainName = "DomainName",
                OrderId = 0
            };
            _domainIpAddresses = new List<DomainIpAddress>();
        }

        [Fact]
        public async Task TestDomainCheckDomainValid()
        {
            _moqBusinessServiceDomain.Setup(a => a.Create(It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(_domain));
            _moqBusinessServiceDomain.Setup(a => a.ValidDomain(It.IsAny<string>())).Returns(true);
            _moqBusinessServiceDomainIpAddress.Setup(a => a.RetrieveIpAddressOfDomain(It.IsAny<Domain>())).Returns(Task.FromResult(_domainIpAddresses));

            _iAppServiceDomain = new AppServiceDomain(_moqBusinessServiceDomain.Object, _moqBusinessServiceDomainIpAddress.Object, _moqBusinessServiceOpenPort.Object);

            var result = await _iAppServiceDomain.DomainCheck(0, string.Empty);
            var objectResponse = result as ObjectResult;
            Assert.Equal(200, objectResponse.StatusCode);
        }

        [Fact]
        public async Task TestDomainCheckDomainInValid()
        {
            _moqBusinessServiceDomain.Setup(a => a.Create(It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(_domain));
            _moqBusinessServiceDomain.Setup(a => a.ValidDomain(It.IsAny<string>())).Returns(false);

            _iAppServiceDomain = new AppServiceDomain(_moqBusinessServiceDomain.Object, _moqBusinessServiceDomainIpAddress.Object, _moqBusinessServiceOpenPort.Object);

            var result = await _iAppServiceDomain.DomainCheck(0, string.Empty);
            var objectResponse = result as ObjectResult;
            Assert.Equal(404, objectResponse.StatusCode);
        }
    }
}
