using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Pro.Common.Collections;

namespace ProPresenter.DO.Communication.MIDI;

public interface IMIDIActionMap : INotifyEnumerableChanged<KeyValuePair<MIDIAction, int>>, IEnumerable<KeyValuePair<MIDIAction, int>>, IEnumerable, INotifyCollectionChanged
{
	void AutoFill(int start);

	void AutoFillBlocks();

	IEnumerable<MIDIAction> GetActions(int noteValue);

	void AssignNumberToMIDIAction(MIDIAction action, int number);

	void LoadMappings(IEnumerable<KeyValuePair<MIDIAction, int>> mappings);
}
