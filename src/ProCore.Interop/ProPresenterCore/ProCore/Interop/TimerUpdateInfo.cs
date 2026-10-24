using ProPresenterCore.ProCore.Interop.Triggering.Types;

namespace ProPresenterCore.ProCore.Interop;

public class TimerUpdateInfo : ResourceUpdateInfo
{
	public TriggerAddress Trigger { get; }

	internal unsafe TimerUpdateInfo(ProTimerUpdateInfo.__Internal* native)
	{
		Trigger = new TriggerAddress(native->updatingTrigger);
	}
}
