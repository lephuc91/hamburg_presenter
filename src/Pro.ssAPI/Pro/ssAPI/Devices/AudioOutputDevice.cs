using System.ComponentModel;
using System.Diagnostics;
using ProPresenterCore.ProCore.Interop;

namespace Pro.ssAPI.Devices;

[DebuggerDisplay("{Name,nq}")]
internal class AudioOutputDevice : AudioDevice, IAudioOutputDevice, IAudioDevice, IDevice, INotifyPropertyChanged
{
	public bool ShouldAutoMap { get; set; } = true;

	internal AudioOutputDevice(ProAudioDevice nativeDevice)
		: base(nativeDevice)
	{
	}
}
