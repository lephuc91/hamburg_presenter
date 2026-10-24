using System.Windows.Threading;
using Pro.MIDI.Interop;

namespace Pro.MIDI;

public class InputDevice
{
	private uint _id;

	private DeviceInfo _info;

	internal uint ID => _id;

	public DeviceInfo Info => _info;

	internal InputDevice(uint id, MIDIINCAPS caps)
	{
		_id = id;
		_info = new DeviceInfo(caps);
	}

	public Input Open(Dispatcher? dispatcher = null)
	{
		return new Input(this, dispatcher ?? Dispatcher.CurrentDispatcher);
	}
}
