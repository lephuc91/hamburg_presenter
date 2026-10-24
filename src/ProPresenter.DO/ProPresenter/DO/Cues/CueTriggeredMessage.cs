using Pro.Common.MessageService;
using Pro.DO.Triggering;
using ProPresenter.DO.Props;

namespace ProPresenter.DO.Cues;

public class CueTriggeredMessage : IMessage
{
	public ITriggerable TriggeredCue { get; }

	public PropTrigger PropTrigger { get; }

	public CueTriggeredMessage(ITriggerable triggeredCue)
	{
		TriggeredCue = triggeredCue;
		PropTrigger = PropTrigger.Trigger;
	}

	public CueTriggeredMessage(ITriggerable triggeredCue, PropTrigger? propTrigger)
	{
		TriggeredCue = triggeredCue;
		PropTrigger = propTrigger.GetValueOrDefault();
	}
}
