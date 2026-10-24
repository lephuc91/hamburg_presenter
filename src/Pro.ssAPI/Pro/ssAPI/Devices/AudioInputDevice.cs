using System.ComponentModel;
using System.Diagnostics;
using ProPresenterCore.ProCore.Interop;

namespace Pro.ssAPI.Devices;

[DebuggerDisplay("{Name,nq}")]
internal class AudioInputDevice : AudioDevice, IAudioInputDevice, IAudioDevice, IDevice, INotifyPropertyChanged
{
	public bool ShouldAutoMap { get; set; } = true;

	internal AudioInputDevice(ProAudioDevice nativeDevice)
		: base(nativeDevice)
	{
	}
}
