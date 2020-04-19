using InternalDomainCheckerBusiness.BusinessInterfaces;
using InternalDomainCheckerBusiness.BusinessServices;
using InternalDomainCheckerBusiness.DataInterfaces;
using Moq;
using Xunit;

namespace InternalDomainCheckerBusinessTest.BusinessServices
{
    public class UnitTestBusinessServiceDomain
    {
        private IBusinessServiceDomain _iBusinessServiceDomain;

        Mock<IDataServiceNetwork> _moqDataServiceNetwork;

        public UnitTestBusinessServiceDomain()
        {
            _moqDataServiceNetwork = new Mock<IDataServiceNetwork>();
        }

        [Theory]
        [InlineData(true, true, "localhost", "Happy Path")]
        [InlineData(true, false, "http://localhost", "Website Url should not work")]
        [InlineData(false, false, "localhost", "Valid domain will not work if unreachable")]
        public void ValidDomain(bool domainExists, bool expectedResult, string domain, string message)
        {
            _moqDataServiceNetwork.Setup(a => a.DomainExists(It.IsAny<string>())).Returns(domainExists);
            _iBusinessServiceDomain = new BusinessServiceDomain(null, null, _moqDataServiceNetwork.Object);

            Assert.True(_iBusinessServiceDomain.ValidDomain(domain) == expectedResult, message);
        }
    }
}
