using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Xero.Api.NetCore.OAuth
{
    public class RsaSha1
    {
        private readonly X509Certificate2 _certificate;

        public RsaSha1(X509Certificate2 certificate)
        {
            _certificate = certificate;
        }

        public string Sign(string signatureBaseString)
        {
            return SignCore(signatureBaseString);
        }

        string SignCore(string baseString)
        {
            var hash = Hash(baseString);

            return Base64Encode(Sign(hash));
        }

        private static string Base64Encode(byte[] signature)
        {
            return Convert.ToBase64String(signature);
        }

        byte[] Hash(string signatureBaseString)
        {
            var sha1 = SHA1.Create();

            return sha1.ComputeHash(Encoding.ASCII.GetBytes(signatureBaseString));
        }

        private byte[] Sign(byte[] hash)
        {
            using (var rsa = _certificate.GetRSAPrivateKey())
            {
                return rsa.SignHash(hash, HashAlgorithmName.SHA1, RSASignaturePadding.Pkcs1);
            }
        }
    }
}