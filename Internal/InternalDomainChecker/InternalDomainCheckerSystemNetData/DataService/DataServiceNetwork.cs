using InternalDomainCheckerBusiness.DataInterfaces;
using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace InternalDomainCheckerSystemNetData.DataService
{
    public class DataServiceNetwork: IDataServiceNetwork
    {
        public bool DomainExists(string domain)
        {
            try
            {
                Ping ping = new Ping();
                PingReply reply = ping.Send(domain, 1000);
                return reply != null;
            }
            catch
            {
                return false;
            }
        }

        public bool PortAccessible(int port, string ipAddress)
        {
            using (TcpClient tcpClient = new TcpClient())
            {
                try
                {
                    tcpClient.Connect(ipAddress, port);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public IPAddress[] RetrieveIpAddress(string domain)
        {
            return Dns.GetHostAddresses(domain);
        }
    }
}
