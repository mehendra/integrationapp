using System;

namespace Xero.Api.NetCore.OAuth.Core.SignatureBaseStringParts.Parameters.Nonce {
	public class DefaultNonceSequence : NonceSequence {
		public string Next() {
			return Guid.NewGuid().ToString();
		}
	}
}