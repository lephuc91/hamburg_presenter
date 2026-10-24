using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Pro.Common.Logging;
using Pro.Common.Utility;

namespace ProPresenter;

internal static class SignatureHelper
{
	private const string CERTIFICATE_SUBJECT = "CN=Renewed Vision, O=Renewed Vision, S=Georgia, C=US";

	public static SigningState Check(Assembly assembly)
	{
		X509Certificate2 x509Certificate;
		try
		{
			x509Certificate = X509CertificateLoader.LoadCertificateFromFile(assembly.Location);
		}
		catch (CryptographicException ex)
		{
			Log.Info("Assembly {0} has an invalid digital signature: {1}", assembly.FullName, ex.Message);
			return SigningState.Unsigned;
		}
		try
		{
			X509Chain x509Chain = new X509Chain();
			if (!InternetAccessCheck.IsInternetAvailable())
			{
				x509Chain.ChainPolicy.RevocationMode = X509RevocationMode.Offline;
			}
			if (x509Chain.Build(x509Certificate) && x509Certificate.Subject == "CN=Renewed Vision, O=Renewed Vision, S=Georgia, C=US")
			{
				return SigningState.Signed;
			}
			bool flag = true;
			foreach (X509ChainElement chainElement in x509Chain.ChainElements)
			{
				if (chainElement.Certificate.Verify())
				{
					continue;
				}
				X509ChainStatus[] chainElementStatus = chainElement.ChainElementStatus;
				for (int i = 0; i < chainElementStatus.Length; i++)
				{
					X509ChainStatus x509ChainStatus = chainElementStatus[i];
					if (x509ChainStatus.Status != X509ChainStatusFlags.OfflineRevocation && x509ChainStatus.Status != X509ChainStatusFlags.RevocationStatusUnknown && x509ChainStatus.Status != (X509ChainStatusFlags.RevocationStatusUnknown | X509ChainStatusFlags.OfflineRevocation) && x509ChainStatus.Status != X509ChainStatusFlags.NotTimeValid)
					{
						flag = false;
						Log.Info("Certificate \"{0}\" is invalid: {1}", chainElement.Certificate.Subject, x509ChainStatus.StatusInformation);
					}
				}
			}
			if (flag)
			{
				return SigningState.Signed;
			}
			Log.Info("Assembly {0} has an invalid digital signature", assembly.FullName);
			return SigningState.InvalidCertificate;
		}
		catch (CryptographicException ex2)
		{
			Log.Info("Assembly {0} has an invalid digital signature: {1}", assembly.FullName, ex2.Message);
			return SigningState.InvalidCertificate;
		}
	}

	public static SigningState Check<T>()
	{
		Assembly assembly = Assembly.GetAssembly(typeof(T));
		if ((object)assembly != null)
		{
			return Check(assembly);
		}
		return SigningState.Unsigned;
	}
}
