using System;

namespace Pro.Common.Time.Timer;

public interface ITimerFactory
{
	IPeriodicTimer CreatePeriodic(TimeSlice period, Action callback);

	IOneShotTimer CreateOneShot(TimeSlice timeout, Action callback);

	IPeriodicTimer CreatePeriodicDispatched(TimeSlice period, Action callback);

	IOneShotTimer CreateOneShotDispatched(TimeSlice timeout, Action callback);
}
