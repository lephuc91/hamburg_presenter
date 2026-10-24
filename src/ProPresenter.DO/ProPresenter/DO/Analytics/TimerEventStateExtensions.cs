using System;
using ProPresenter.DO.Actions;

namespace ProPresenter.DO.Analytics;

public static class TimerEventStateExtensions
{
	public static TimerEventState ToEventState(this TimerActionType state)
	{
		switch (state)
		{
		case TimerActionType.Start:
		case TimerActionType.ResetAndStart:
			return TimerEventState.Start;
		case TimerActionType.Stop:
			return TimerEventState.Stop;
		case TimerActionType.Reset:
			return TimerEventState.Reset;
		default:
			throw new NotSupportedException();
		}
	}
}
