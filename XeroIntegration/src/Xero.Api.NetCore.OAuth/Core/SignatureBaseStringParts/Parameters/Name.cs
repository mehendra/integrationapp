namespace Xero.Api.NetCore.OAuth.Core.SignatureBaseStringParts.Parameters
{
    class Name
    {
        private readonly string _value;

        internal static Name Version = new Name("version");
        internal static Name ConsumerKey = new Name("consumer_key"); 
        internal static Name Token = new Name("token");
        internal static Name SignatureMethod = new Name("signature_method");
        internal static Name Timestamp = new Name("timestamp");
        public static Name Nonce = new Name("nonce");
        internal static Name Signature = new Name("signature");

        internal Name(string value)
        {
            _value = string.Format("oauth_{0}", value);
        }

        internal string Value
        {
            get { return _value; }
        }

        public static implicit operator string(Name what)
        {
            return what.Value;
        }
    }
}