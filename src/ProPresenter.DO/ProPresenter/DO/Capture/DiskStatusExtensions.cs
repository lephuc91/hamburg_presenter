using System;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.DO.Capture;

public static class DiskStatusExtensions
{
	public static DiskStatus ToStatus(this ProScreenCaptureDiskStatus status)
	{
		return status switch
		{
			ProScreenCaptureDiskStatus.OK => DiskStatus.OK, 
			ProScreenCaptureDiskStatus.Low => DiskStatus.Low, 
			ProScreenCaptureDiskStatus.Critical => DiskStatus.Critical, 
			_ => throw new NotSupportedException(), 
		};
	}
}
