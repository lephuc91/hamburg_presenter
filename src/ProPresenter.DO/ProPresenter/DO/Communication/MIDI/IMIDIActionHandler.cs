namespace ProPresenter.DO.Communication.MIDI;

public interface IMIDIActionHandler
{
	void Handle(MIDIAction action, int index);
}
