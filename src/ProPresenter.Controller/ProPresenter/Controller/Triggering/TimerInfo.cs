using System;
using Pro.Common.Time;
using Pro.SerializationInterop.RVProtoData;
using ProPresenterCore.ProCore.Interop;
using ProPresenterCore.ProCore.Interop.Triggering.Types;

namespace ProPresenter.Controller.Triggering;

public class TimerInfo
{
	public Guid TimerID { get; }

	public Guid TriggeredTimerID { get; }

	public TriggerHandle TriggerHandle { get; }

	public string TimerName { get; }

	public Timer.Types.Configuration Configuration { get; }

	public TimeSlice IncrementAmount { get; }

	public ProTimerActionType ActionType { get; }

	public TimerInfo(Guid timerID, Guid triggeredTimerID, TriggerHandle triggerHandle, string timerName, Timer.Types.Configuration configuration, TimeSlice incrementTime, ProTimerActionType actionType)
	{
		TimerID = timerID;
		TriggeredTimerID = triggeredTimerID;
		TriggerHandle = triggerHandle;
		TimerName = timerName;
		Configuration = configuration;
		IncrementAmount = incrementTime;
		ActionType = actionType;
	}
}
