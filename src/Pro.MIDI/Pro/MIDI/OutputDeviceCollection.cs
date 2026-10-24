using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using Pro.Common.Collections;
using Pro.MIDI.Interop;

namespace Pro.MIDI;

public class OutputDeviceCollection : ImmutableObservableCollection<OutputDevice>
{
	private static readonly uint SizeOfCAPS = (uint)Marshal.SizeOf<MIDIOUTCAPS>();

	internal OutputDeviceCollection()
	{
		uint num = MidiFunctions.OutGetNumDevs();
		for (uint num2 = 0u; num2 < num; num2++)
		{
			if (MidiFunctions.OutGetDevCapsW(num2, out var caps, SizeOfCAPS) == MMRESULT.NOERROR)
			{
				base.Collection.Add(new OutputDevice(num2, caps));
			}
		}
	}

	public bool TryFindMatchingDevice(DeviceInfo deviceInfo, [NotNullWhen(true)] out OutputDevice? device)
	{
		device = this.FirstOrDefault((OutputDevice d) => d.Info == deviceInfo);
		return device != null;
	}
}
