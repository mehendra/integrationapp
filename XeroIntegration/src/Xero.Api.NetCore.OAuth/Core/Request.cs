using System;

namespace Xero.Api.NetCore.OAuth.Core
{
    public class Request {
        public Uri Url { get; set; }
        public string Verb { get; set; }
    }
}