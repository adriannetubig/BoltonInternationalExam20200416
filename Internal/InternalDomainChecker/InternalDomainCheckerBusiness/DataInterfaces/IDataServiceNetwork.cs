using System.Net;

namespace InternalDomainCheckerBusiness.DataInterfaces
{
    public interface IDataServiceNetwork
    {
        bool DomainExists(string domain);
        bool PortAccessible(int port, string ipAddress);
        IPAddress[] RetrieveIpAddress(string domain);
    }
}
