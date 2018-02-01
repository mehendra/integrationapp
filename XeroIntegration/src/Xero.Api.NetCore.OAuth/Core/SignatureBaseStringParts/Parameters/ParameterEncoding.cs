using System;

namespace Xero.Api.NetCore.OAuth.Core.SignatureBaseStringParts.Parameters
{
    internal class ParameterEncoding
    {
        internal string Escape(string what)
        {
            return Uri.EscapeDataString(what ?? "");
        }
    }
}