using System;

namespace ProPresenter.DO.Capture;

public static class RtmpDestionationExtensions
{
	public static bool IsValidAddress(this string url)
	{
		if (!string.IsNullOrEmpty(url))
		{
			try
			{
				Uri result;
				return Uri.TryCreate(url, UriKind.Absolute, out result) && (result.Scheme == RtmpDestination.RtmpScheme || result.Scheme == RtmpDestination.RtmpsScheme);
			}
			catch
			{
				return false;
			}
		}
		return false;
	}
}
