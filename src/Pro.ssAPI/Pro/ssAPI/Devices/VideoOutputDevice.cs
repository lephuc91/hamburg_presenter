using System.ComponentModel;
using System.Diagnostics;
using Pro.Common.Mathematics;
using ProPresenterCore.ProCore.Interop;

namespace Pro.ssAPI.Devices;

[DebuggerDisplay("{Name,nq} | Mode {ActiveMode}: {Modes[ActiveMode].Size.X}x{Modes[ActiveMode].Size.Y}")]
internal class VideoOutputDevice : VideoDevice, IVideoOutputDevice, IDevice, INotifyPropertyChanged
{
	public VideoOutputDeviceType DeviceType { get; }

	public string Model => base.ModelName;

	public string Vendor => base.VendorID;

	public int ActiveMode { get; }

	public VideoModeCollection Modes { get; }

	public bool IsPrimaryMonitor { get; }

	public Rect<double> SystemFrame { get; }

	public bool SupportsAlphaKey { get; }

	public bool SupportsInternalAlphaKey { get; }

	public bool SupportsExternalAlphaKey { get; }

	public bool SupportsHdrOutput { get; }

	internal VideoOutputDevice(ProVideoOutputDevice nativeDevice)
		: base(nativeDevice.DeviceID, nativeDevice.Name, nativeDevice.DeviceName, nativeDevice.VendorID, nativeDevice.ModelName)
	{
		DeviceType = (VideoOutputDeviceType)nativeDevice.VideoDeviceType;
		ActiveMode = nativeDevice.CurrentMode;
		Modes = new VideoModeCollection(nativeDevice.Modes, nativeDevice.ModeCount);
		IsPrimaryMonitor = nativeDevice.IsPrimaryMonitor;
		SystemFrame = new Rect<double>(new Vector2<double>(nativeDevice.SystemFrame.Origin.X, nativeDevice.SystemFrame.Origin.Y), new Vector2<double>(nativeDevice.SystemFrame.Size.Width, nativeDevice.SystemFrame.Size.Height));
		SupportsAlphaKey = nativeDevice.SupportsAlphaKey;
		SupportsInternalAlphaKey = nativeDevice.SupportsInternalAlphaKey;
		SupportsExternalAlphaKey = nativeDevice.SupportsExternalAlphaKey;
		SupportsHdrOutput = nativeDevice.SupportsHdrOutput;
	}
}
