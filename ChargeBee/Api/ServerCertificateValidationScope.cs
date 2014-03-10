using System;
using System.Net;
using System.Net.Security;

namespace ChargeBee.Api
{
	public class ServerCertificateValidationScope : IDisposable
	{
		private readonly RemoteCertificateValidationCallback _callback;
		
		public ServerCertificateValidationScope (object request,
		                                        RemoteCertificateValidationCallback callback)
		{
			var previous = ServicePointManager.ServerCertificateValidationCallback;
			_callback = (sender, certificate, chain, errors) =>
			{
				if (sender == request) {
					return callback (sender, certificate, chain, errors);
				}
				if (previous != null) {
					return previous (sender, certificate, chain, errors);
				}
				return errors == SslPolicyErrors.None;
			};
			ServicePointManager.ServerCertificateValidationCallback += _callback;
		}
		
		public void Dispose ()
		{
			ServicePointManager.ServerCertificateValidationCallback -= _callback;
		}
	}
}

