using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Mathematics;

namespace ProPresenter.DO.Communication.MIDI;

public class MIDIActionMap : ImmutableObservableDictionary<MIDIAction, int>, IMIDIActionMap, INotifyEnumerableChanged<KeyValuePair<MIDIAction, int>>, IEnumerable<KeyValuePair<MIDIAction, int>>, IEnumerable, INotifyCollectionChanged
{
	private const int AvailableNoteCount = 128;

	public MIDIActionMap()
	{
		AutoFill(0);
	}

	public void AutoFill(int start)
	{
		MIDIActions.DefaultOrder.ForEach(delegate(MIDIAction a)
		{
			base.Dictionary[a] = start++.Mod(128);
		});
	}

	public void AutoFillBlocks()
	{
		int? num = null;
		MIDIAction[] blockOrder = MIDIActions.BlockOrder;
		foreach (MIDIAction mIDIAction in blockOrder)
		{
			if (MIDIActions.BlockHeaders.Contains(mIDIAction))
			{
				num = base.Dictionary[mIDIAction];
				continue;
			}
			if (!num.HasValue)
			{
				throw new InvalidProgramException();
			}
			IDictionary<MIDIAction, int> dictionary = base.Dictionary;
			num = num.Value + 1;
			int? num2 = num;
			dictionary[mIDIAction] = num2.Value.Mod(128);
		}
	}

	public IEnumerable<MIDIAction> GetActions(int noteValue)
	{
		return from a in this
			where a.Value == noteValue
			select a.Key;
	}

	public void AssignNumberToMIDIAction(MIDIAction action, int number)
	{
		base.Dictionary[action] = number.Mod(128);
	}

	public void LoadMappings(IEnumerable<KeyValuePair<MIDIAction, int>> mappings)
	{
		mappings.ForEach(delegate(KeyValuePair<MIDIAction, int> m)
		{
			AssignNumberToMIDIAction(m.Key, m.Value);
		});
	}
}
