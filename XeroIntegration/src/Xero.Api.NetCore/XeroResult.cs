namespace Xero.Api.NetCore
{
    public class XeroResult
    {
        public XeroResult(string statusCode, string body)
        {
            StatusCode = statusCode;
            Body = body;
        }

        public string StatusCode { get; set; }
        public string Body { get; set; }
    }
}