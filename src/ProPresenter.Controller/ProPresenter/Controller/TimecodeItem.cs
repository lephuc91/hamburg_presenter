using System;
using ProPresenter.DO;

namespace ProPresenter.Controller;

public class TimecodeItem
{
	public ITimeTriggerable Item { get; }

	public double Offset { get; }

	public Guid SequenceID { get; }

	public TimecodeItem(ITimeTriggerable item, double offset, Guid sequenceID)
	{
		Item = item;
		Offset = offset;
		SequenceID = sequenceID;
	}
}
