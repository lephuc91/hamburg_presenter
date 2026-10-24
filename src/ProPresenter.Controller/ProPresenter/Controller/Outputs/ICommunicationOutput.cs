using System.ComponentModel;
using ProPresenter.Controller.Outputs.Communication;
using ProPresenter.DO.Communication.MIDI;

namespace ProPresenter.Controller.Outputs;

public interface ICommunicationOutput : INotifyPropertyChanged
{
	DeviceCollection Devices { get; }

	IMIDIActionMap MIDIMappings { get; }

	int? LastMIDINote { get; }

	int? LastMIDIIntensity { get; }

	void AssignManager(ICoreManager manager);

	void AssignActionHandler(IMIDIActionHandler midiActionHandler);
}
