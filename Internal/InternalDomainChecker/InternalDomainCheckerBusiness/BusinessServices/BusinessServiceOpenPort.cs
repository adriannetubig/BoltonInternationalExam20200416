using InternalDomainCheckerBusiness.BusinessInterfaces;
using InternalDomainCheckerBusiness.DataInterfaces;
using InternalDomainCheckerBusiness.Entities;
using InternalDomainCheckerBusiness.Models;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace InternalDomainCheckerBusiness.BusinessServices
{
    public class BusinessServiceOpenPort : IBusinessServiceOpenPort
    {
        private readonly IDataServiceOpenPort _iDataServiceOpenPort;
        private readonly int[] _toCheckPorts;

        public BusinessServiceOpenPort(IDataServiceOpenPort iDataServiceOpenPort, int[] toCheckPorts)
        {
            _iDataServiceOpenPort = iDataServiceOpenPort;
            _toCheckPorts = toCheckPorts;
        }

        public async Task<List<int>> CheckOpenPorts(DomainIpAddress domainIpAddress)
        {
            var openPorts = new List<int>();
            Parallel.ForEach(_toCheckPorts, async toCheckPort =>
            {
                using (TcpClient tcpClient = new TcpClient())
                {
                    try
                    {
                        tcpClient.Connect(domainIpAddress.IpAddress, toCheckPort); //ToDo: make this testable
                        var entityOpenPort = new EntityOpenPort
                        {
                            DomainIpAddressId = domainIpAddress.DomainIpAddressId,
                            Port = toCheckPort
                        };
                        await _iDataServiceOpenPort.Create(entityOpenPort);
                        openPorts.Add(toCheckPort);
                    }
                    catch (Exception ex)
                    {
                    }
                }
            });
            return openPorts;
        }
    }
}
