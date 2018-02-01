using System.Security.Cryptography.X509Certificates;

namespace Xero.Api.NetCore
{
    public interface IXero
    {
        X509Certificate2 XeroSigningCert { get; }

        XeroResult Get(string endpoint);
        XeroResult Put(string endpoint, string content);

        XeroResult Post(string endpoint, string content);
    }
}