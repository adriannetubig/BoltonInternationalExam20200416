using InternalDomainCheckerBusiness.BusinessInterfaces;
using InternalDomainCheckerBusiness.DataInterfaces;
using InternalDomainCheckerBusiness.Entities;
using InternalDomainCheckerBusiness.Models;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace InternalDomainCheckerBusiness.BusinessServices
{
    public class BusinessServiceOpenPort : IBusinessServiceOpenPort
    {
        private readonly IDataServiceNetwork _iDataServiceNetwork;
        private readonly IDataServiceOpenPort _iDataServiceOpenPort;
        private readonly int[] _toCheckPorts;

        public BusinessServiceOpenPort(IDataServiceNetwork iDataServiceNetwork, IDataServiceOpenPort iDataServiceOpenPort, int[] toCheckPorts)
        {
            _iDataServiceNetwork = iDataServiceNetwork;
            _iDataServiceOpenPort = iDataServiceOpenPort;
            _toCheckPorts = toCheckPorts;
        }

        public List<int> CheckOpenPorts(DomainIpAddress domainIpAddress)
        {
            var openPorts = new List<int>();
            Parallel.ForEach(_toCheckPorts, async toCheckPort =>
            {
                using (TcpClient tcpClient = new TcpClient())
                {
                    if(_iDataServiceNetwork.PortAccessible(toCheckPort, domainIpAddress.IpAddress))
                    {
                        var entityOpenPort = new EntityOpenPort
                        {
                            DomainIpAddressId = domainIpAddress.DomainIpAddressId,
                            Port = toCheckPort
                        };
                        await _iDataServiceOpenPort.Create(entityOpenPort);
                        openPorts.Add(toCheckPort);
                    }
                }
            });
            return openPorts;
        }
    }
}
