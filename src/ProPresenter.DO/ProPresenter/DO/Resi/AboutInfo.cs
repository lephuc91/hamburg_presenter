using System;

namespace ProPresenter.DO.Resi;

public class AboutInfo : IAboutInfo
{
	public string CustomerName { get; }

	public string EncoderName { get; }

	public Version? EncoderVersion { get; }

	public string ManageUrl { get; }

	public AboutInfo(string customerName, string encoderName, Version? encoderVersion, string manageUrl)
	{
		CustomerName = customerName;
		EncoderName = encoderName;
		EncoderVersion = encoderVersion;
		ManageUrl = manageUrl;
	}
}
