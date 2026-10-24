using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using Pro.Common.Collections;
using Pro.MIDI.Interop;

namespace Pro.MIDI;

public class InputDeviceCollection : ImmutableObservableCollection<InputDevice>
{
	private static readonly uint SizeOfCAPS = (uint)Marshal.SizeOf<MIDIINCAPS>();

	internal InputDeviceCollection()
	{
		uint num = MidiFunctions.InGetNumDevs();
		for (uint num2 = 0u; num2 < num; num2++)
		{
			if (MidiFunctions.InGetDevCapsW(num2, out var caps, SizeOfCAPS) == MMRESULT.NOERROR)
			{
				base.Collection.Add(new InputDevice(num2, caps));
			}
		}
	}

	public bool TryFindMatchingDevice(DeviceInfo deviceInfo, [NotNullWhen(true)] out InputDevice? device)
	{
		device = this.FirstOrDefault((InputDevice d) => d.Info == deviceInfo);
		return device != null;
	}
}
