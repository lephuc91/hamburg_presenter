using System.Windows.Threading;
using Pro.MIDI.Interop;

namespace Pro.MIDI;

public class OutputDevice
{
	private uint _id;

	private DeviceInfo _info;

	internal uint ID => _id;

	public DeviceInfo Info => _info;

	internal OutputDevice(uint id, MIDIOUTCAPS caps)
	{
		_id = id;
		_info = new DeviceInfo(caps);
	}

	public Output Open(Dispatcher? dispatcher = null)
	{
		return new Output(this, dispatcher ?? Dispatcher.CurrentDispatcher);
	}
}
