using System;
using Pro.Common.DataStore;
using Pro.Common.Time;

namespace Pro.Common.Logging;

internal class LogSettings : StoreBase
{
	private const int MaxLogsDefault = 10;

	private static readonly TimeSlice RotateTimeDefault = TimeSlice.FromDays(7.0);

	private static readonly DateTime LastRotationDefault = DateTime.MinValue;

	public int MaxLogs
	{
		get
		{
			return GetValue("MaxLogs", 10);
		}
		set
		{
			SetValue("MaxLogs", value);
		}
	}

	public TimeSlice RotateTime
	{
		get
		{
			return GetValue("RotateTime", RotateTimeDefault);
		}
		set
		{
			SetValue("RotateTime", value);
		}
	}

	public DateTime LastRotation
	{
		get
		{
			return GetValue("LastRotation", LastRotationDefault);
		}
		set
		{
			SetValue("LastRotation", value);
		}
	}

	public LogSettings(string settingsFile)
		: base(settingsFile)
	{
	}
}
