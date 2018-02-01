using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;

namespace Xero.Api.NetCore.OAuth.Core.SignatureBaseStringParts.Parameters
{
    internal class RequestParameters : IEnumerable<Parameter>
    {
        private readonly IDictionary<string, StringValues> _values;
        private readonly Parameters _parameters;

        public RequestParameters(Request request)
        {
            _values = QueryHelpers.ParseQuery(request.Url.Query);

            _parameters = new Parameters(MapAll());
        }

        private Parameter[] MapAll() {
            return _values.Keys.SelectMany<string,Parameter>(Map).ToArray();
        }

        private IEnumerable<Parameter> Map(string key)
        {
            return ValueFor(key).Split(',').Select(v => new Parameter(key, v));
        }

        private string ValueFor(string key) {
            return _values[key];
        }

        #region Implementation of IEnumerable

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        public IEnumerator<Parameter> GetEnumerator() {
            return _parameters.GetEnumerator();
        }

        #endregion

        internal void Add(Parameters what) {
            _parameters.Add(what);
        }

        public override string ToString() {
            return _parameters.ToString();
        }
    }
}