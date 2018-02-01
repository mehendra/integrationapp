using System;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Xero.Api.NetCore.OAuth;
using Xero.Api.NetCore.OAuth.Core;
using Xero.Api.NetCore.OAuth.Core.SignatureBaseStringParts.Parameters;
using Xero.Api.NetCore.OAuth.Core.SignatureBaseStringParts.Parameters.Nonce;
using Xero.Api.NetCore.OAuth.Core.SignatureBaseStringParts.Parameters.Timestamp;
using Xero.Api.NetCore.OAuth.Http;

namespace Xero.Api.NetCore
{
    public class Xero : IXero
    {
        private readonly string _consumerKey;
        private readonly string _consumerSecret;
        private readonly string _signingCertificatePath;
        private readonly string _signingCertificatePassword;
        private readonly string _apiBaseUrl;

        public Xero(IConfiguration config)
        {
            _consumerKey = config["Settings:ConsumerKey"];
            _consumerSecret = config["Settings:ConsumerSecret"];
            _signingCertificatePath = config["Settings:SigningCertificate"];
            _signingCertificatePassword = config["Settings:SigningCertificatePassword"];
            _apiBaseUrl = config["Settings:ApiBaseUrl"];
        }

        public XeroResult Get(string endpoint)
        {
            var url = new Uri(_apiBaseUrl + endpoint);

            var header = BuildAuthorizationHeader(url, "GET");

            var client = new HttpClient();

            var responseStatus = string.Empty;
            var responseBody = string.Empty;

            client.DefaultRequestHeaders.Add("Authorization", header.Value);

            try
            {
                Task.Run(async () =>
                {
                    var response = await client.GetAsync(url.ToString());
                    responseStatus = response.StatusCode.ToString();
                    responseBody = await response.Content.ReadAsStringAsync();
                }).Wait();
            }
            catch (Exception ex)
            {
                responseStatus = "FAIL";
                responseBody = ex.Message;
            }

            return new XeroResult(responseStatus, responseBody);
        }

        public XeroResult Put(string endpoint, string content)
        {
            var url = new Uri(_apiBaseUrl + endpoint);

            var header = BuildAuthorizationHeader(url, "PUT");

            var client = new HttpClient();

            var responseStatus = string.Empty;
            var responseBody = string.Empty;

            client.DefaultRequestHeaders.Add("Authorization", header.Value);
            var body = new StringContent(content, Encoding.UTF8);

            try
            {
                Task.Run(async () =>
                {
                    var response = await client.PutAsync(url.ToString(), body);
                    responseStatus = response.StatusCode.ToString();
                    responseBody = await response.Content.ReadAsStringAsync();
                }).Wait();
            }
            catch (Exception ex)
            {
                responseStatus = "FAIL";
                responseBody = ex.Message;
            }

            return new XeroResult(responseStatus, responseBody);
        }

        public XeroResult Post(string endpoint, string content)
        {
            var url = new Uri(_apiBaseUrl + endpoint);

            var header = BuildAuthorizationHeader(url, "POST");

            var client = new HttpClient();

            var responseStatus = string.Empty;
            var responseBody = string.Empty;

            client.DefaultRequestHeaders.Add("Authorization", header.Value);
            var body = new StringContent(content, Encoding.UTF8);

            try
            {
                Task.Run(async () =>
                {
                    var response = await client.PostAsync(url.ToString(), body);
                    responseStatus = response.StatusCode.ToString();
                    responseBody = await response.Content.ReadAsStringAsync();
                }).Wait();
            }
            catch (Exception ex)
            {
                responseStatus = "FAIL";
                responseBody = ex.Message;
            }

            return new XeroResult(responseStatus, responseBody);
        }

        private AuthorizationHeader BuildAuthorizationHeader(Uri url, string verb)
        {
            var _consumer = new Consumer(new ConsumerKey(_consumerKey), _consumerSecret);
            var _certificate = XeroSigningCert;

            var oAuthParameters = new OAuthParameters(
                _consumer.ConsumerKey,
                new TokenKey(_consumer.ConsumerKey.Value),
                "RSA-SHA1",
                new DefaultTimestampSequence(),
                new DefaultNonceSequence(),
                string.Empty,
                "1.0"
            );

            var signatureBaseString =
                new SignatureBaseString(
                    new Request
                    {
                        Url = url,
                        Verb = verb
                    },
                    oAuthParameters
                );

            var signature = new RsaSha1(_certificate).Sign(signatureBaseString);

            oAuthParameters.SetSignature(signature);

            return new AuthorizationHeader(oAuthParameters, string.Empty);
        }

        public X509Certificate2 XeroSigningCert
        {
            get
            {
                var path = _signingCertificatePath;

                var fullPath = Path.GetFullPath(path);

                if (false == File.Exists(fullPath))
                    throw new FileNotFoundException("The cert file cannot be found.", fullPath);

                return new X509Certificate2(fullPath, _signingCertificatePassword);
            }
        }
    }
}
