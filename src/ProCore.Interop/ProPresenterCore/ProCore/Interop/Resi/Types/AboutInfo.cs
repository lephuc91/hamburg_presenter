using ProPresenterCore.ProCore.Interop.Utility;

namespace ProPresenterCore.ProCore.Interop.Resi.Types;

public class AboutInfo
{
	public string CustomerName { get; }

	public string EncoderName { get; }

	public string EncoderVersion { get; }

	public string ManageUrl { get; }

	public AboutInfo(ProResiAboutInfo.__Internal aboutInfo)
	{
		CustomerName = StringMarshalling.StringFromCString(aboutInfo.customerName);
		EncoderName = StringMarshalling.StringFromCString(aboutInfo.encoderName);
		EncoderVersion = StringMarshalling.StringFromCString(aboutInfo.encoderVersion);
		ManageUrl = StringMarshalling.StringFromCString(aboutInfo.manageURL);
	}
}
