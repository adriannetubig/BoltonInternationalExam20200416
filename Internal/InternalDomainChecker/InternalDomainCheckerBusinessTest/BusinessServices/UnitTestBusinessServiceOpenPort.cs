using InternalDomainCheckerBusiness.BusinessInterfaces;
using InternalDomainCheckerBusiness.BusinessServices;
using InternalDomainCheckerBusiness.DataInterfaces;
using InternalDomainCheckerBusiness.Entities;
using InternalDomainCheckerBusiness.Models;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace InternalDomainCheckerBusinessTest.BusinessServices
{
    public class UnitTestBusinessServiceOpenPort
    {
        private IBusinessServiceOpenPort _iBusinessServiceOpenPort;

        Mock<IDataServiceNetwork> _moqDataServiceNetwork;
        Mock<IDataServiceOpenPort> _moqDataServiceOpenPort;

        public UnitTestBusinessServiceOpenPort()
        {
            _moqDataServiceNetwork = new Mock<IDataServiceNetwork>();
            _moqDataServiceOpenPort = new Mock<IDataServiceOpenPort>();
        }

        [Theory]
        [InlineData(true, true, "Happy Path")]
        [InlineData(false, false, "Port not available")]
        public void CheckOpenPorts(bool portAccessible, bool portInResult, string message)
        {
            _moqDataServiceNetwork.Setup(a => a.PortAccessible(It.IsAny<int>(), It.IsAny<string>())).Returns(portAccessible);
            _moqDataServiceOpenPort.Setup(a => a.Create(It.IsAny<EntityOpenPort>())).Returns(Task.FromResult(default(object)));
            var toCheckPorts = new int[] { 80 };
            _iBusinessServiceOpenPort = new BusinessServiceOpenPort(_moqDataServiceNetwork.Object, _moqDataServiceOpenPort.Object, toCheckPorts);

            var domainIpAddress = new DomainIpAddress();
            var notInResultPorts = toCheckPorts.Except(_iBusinessServiceOpenPort.CheckOpenPorts(domainIpAddress));

            Assert.True((notInResultPorts.Count() == 0) == portInResult, message);
        }
    }
}
