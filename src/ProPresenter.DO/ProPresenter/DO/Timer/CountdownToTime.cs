using System;
using System.Linq;
using System.Reactive.Linq;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Time;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Migration.RVData;

namespace ProPresenter.DO.Timer;

public class CountdownToTime : TimerBase
{
	private TimeFormat _timeFormat;

	private TimeSlice _endTime;

	private bool _wasOverrun;

	public override TimerType TimerType => TimerType.CountdownToTime;

	public override TimeSlice RunningTime
	{
		get
		{
			TimeSlice timeSlice = base.Duration - base.Clock.ElapsedTime;
			if (timeSlice <= TimeSlice.Zero && base.IsTimerRunning)
			{
				if (!base.IsOverRunAllowed)
				{
					return TimeSlice.Zero;
				}
				if (base.State != TimerState.Paused)
				{
					if (base.State == TimerState.Started)
					{
						base.State = TimerState.Overrunning;
					}
					_wasOverrun = true;
				}
				else
				{
					base.State = TimerState.Overran;
				}
			}
			return timeSlice;
		}
	}

	public TimeFormat TimeFormat
	{
		get
		{
			return _timeFormat;
		}
		set
		{
			SetValue("TimeFormat", ref _timeFormat, value, delegate(TimeFormat o, TimeFormat n)
			{
				base.UndoStack?.Commit(UndoActionTypes.TimerTimeFormat.ToAction(), this, "TimeFormat", o, n, null, null, autoFinalize: true);
				TimeSlice endTime = EndTime;
				if (o == TimeFormat.TwentyFour)
				{
					switch (n)
					{
					case TimeFormat.AM:
						if (endTime.Hours >= 12)
						{
							endTime -= TimeSlice.FromHours(12.0);
						}
						break;
					case TimeFormat.PM:
						if (endTime.Hours < 12)
						{
							endTime += TimeSlice.FromHours(12.0);
						}
						break;
					}
				}
				if (n == TimeFormat.TwentyFour)
				{
					if (o == TimeFormat.PM && endTime.Hours < 12)
					{
						endTime += TimeSlice.FromHours(12.0);
					}
					else if (o == TimeFormat.AM && endTime.Hours == 12)
					{
						endTime -= TimeSlice.FromHours(12.0);
					}
				}
				UpdateEndTime(endTime);
				OnDataModified();
			});
		}
	}

	public override TimeSlice EndTime
	{
		get
		{
			return _endTime;
		}
		set
		{
			if (_endTime != value)
			{
				base.UndoStack?.Commit(UndoActionTypes.TimerEnd.ToAction(), this, "EndTime", EndTime, value, null, null, autoFinalize: true);
				UpdateEndTime(value);
			}
		}
	}

	public override bool IsForward => false;

	public override ObjectBinder<TimerBase, ITimer.Types.IConfiguration> Bind(IUiScheduler scheduler, IEntityFactory entityFactory, ITimer.Types.IConfiguration entity)
	{
		ITimer.Types.IConfiguration.Types.ITimerType.ICountdownToTime countdownToTime = entity.TimerType.Value as ITimer.Types.IConfiguration.Types.ITimerType.ICountdownToTime;
		if (countdownToTime == null)
		{
			countdownToTime = entityFactory.Create<ITimer.Types.IConfiguration.Types.ITimerType.ICountdownToTime>();
			entity.TimerType.Set(countdownToTime);
		}
		ObjectBinder<CountdownToTime, ITimer.Types.IConfiguration.Types.ITimerTypeCountdownToTime> countdownToTimeTimerBinder = new ObjectBinder<CountdownToTime, ITimer.Types.IConfiguration.Types.ITimerTypeCountdownToTime>(this, countdownToTime.Value).Bind((CountdownToTime l) => l.WhenPropertyChanges("EndTime").Merge(l.WhenPropertyChanges("TimeFormat")), (ITimer.Types.IConfiguration.Types.ITimerTypeCountdownToTime r) => r.TimeOfDay.WhenValueChanges.ToUnit().Merge(r.Period.WhenValueChanges.ToUnit()), delegate(CountdownToTime l, ITimer.Types.IConfiguration.Types.ITimerTypeCountdownToTime r)
		{
			TimeSlice endTime = l.EndTime;
			if (l.TimeFormat == TimeFormat.PM && endTime.Hours >= 12)
			{
				endTime -= TimeSlice.FromHours(12.0);
			}
			r.TimeOfDay.Set(endTime.TotalSeconds);
			r.Period.Set(l.TimeFormat.EntitySerialize());
		}, delegate(ITimer.Types.IConfiguration.Types.ITimerTypeCountdownToTime r, CountdownToTime l)
		{
			l.EndTime = TimeSlice.FromSeconds(r.TimeOfDay.Value);
			l.TimeFormat = r.Period.Value.Deserialize();
		});
		ObjectBinder<TimerBase, ITimer.Types.IConfiguration> objectBinder = base.Bind(scheduler, entityFactory, entity);
		objectBinder.DoOnInitializeRightFromLeft(countdownToTimeTimerBinder.InitializeRightFromLeft).DoOnInitializeLeftFromRight(countdownToTimeTimerBinder.InitializeLeftFromRight).RegisterChildDisposable(() => countdownToTimeTimerBinder);
		return objectBinder;
	}

	public CountdownToTime()
		: this(TimeSlice.Zero)
	{
	}

	public CountdownToTime(TimeSlice defaultTargetTime)
	{
		ResetDuration();
		base.Duration = defaultTargetTime;
		UpdateEndTime(defaultTargetTime);
	}

	public void UpdateTimer(TimeSlice defaultTargetTime, TimeFormat timeFormat, bool allowOverrun)
	{
		EndTime = defaultTargetTime;
		base.Duration = defaultTargetTime;
		TimeFormat = timeFormat;
		base.IsOverRunAllowed = allowOverrun;
	}

	private void UpdateEndTime(TimeSlice value)
	{
		long num = value.Hours;
		switch (TimeFormat)
		{
		case TimeFormat.TwentyFour:
			num %= 24;
			break;
		case TimeFormat.AM:
		case TimeFormat.PM:
			if (num == 0L)
			{
				num = 12L;
			}
			if (num > 12)
			{
				num %= 12;
			}
			break;
		}
		_endTime = TimeSlice.FromHours(num) + TimeSlice.FromMinutes(value.Minutes) + TimeSlice.FromSeconds(value.Seconds);
		if (base.State == TimerState.Reset)
		{
			ResetDuration();
		}
		OnPropertyChanged("EndTime");
		OnDataModified();
	}

	protected override void OnStart()
	{
		ResetDuration();
		base.Clock.Restart();
	}

	private void ResetDuration()
	{
		TimeZoneInfo.ClearCachedData();
		TimeSlice endTime = EndTime;
		DateTime now = DateTime.Now;
		int num = (int)endTime.Hours;
		int minute = (int)endTime.Minutes;
		int second = (int)endTime.Seconds;
		switch (TimeFormat)
		{
		case TimeFormat.AM:
			num %= 12;
			break;
		case TimeFormat.PM:
			if (num < 12)
			{
				num += 12;
			}
			break;
		}
		TimeSpan timeSpan = new DateTime(now.Year, now.Month, now.Day, num, minute, second) - now;
		if (!_wasOverrun)
		{
			while (timeSpan.Ticks <= 0)
			{
				timeSpan = timeSpan.Add(TimeSpan.FromDays(1));
			}
		}
		base.Duration = TimeSlice.FromMilliseconds(timeSpan.TotalMilliseconds);
	}

	protected override void OnPause()
	{
		base.Clock.Pause();
	}

	protected override void OnReset()
	{
		base.Clock.Stop();
	}

	protected override void OnIncrement(TimeSlice time)
	{
		base.Clock.ElapsedTime -= time;
	}

	protected override void OnExpire()
	{
		OnReset();
		base.Duration = TimeSlice.Zero;
	}

	protected override void OnSerialize(Pro.SerializationInterop.RVProtoData.Timer.Types.Configuration configuration)
	{
		TimeSlice endTime = EndTime;
		if (TimeFormat == TimeFormat.PM && endTime.Hours >= 12)
		{
			endTime -= TimeSlice.FromHours(12.0);
		}
		configuration.CountdownToTime = new Pro.SerializationInterop.RVProtoData.Timer.Types.Configuration.Types.TimerTypeCountdownToTime
		{
			TimeOfDay = endTime.TotalSeconds,
			Period = TimeFormat.ToProtoTimerPeriod()
		};
	}

	protected override void OnDeserialize(Pro.SerializationInterop.RVProtoData.Timer.Types.Configuration configuration)
	{
		if (configuration != null && configuration.CountdownToTime != null)
		{
			_timeFormat = configuration.CountdownToTime.Period.ToTimeFormat();
			EndTime = TimeSlice.FromSeconds(configuration.CountdownToTime.TimeOfDay);
		}
	}

	protected override void OnRVDeserialize(RVTimer rvTimer)
	{
		switch (rvTimer.Meridiem)
		{
		case "PM":
			TimeFormat = TimeFormat.PM;
			break;
		case "HRS":
			TimeFormat = TimeFormat.TwentyFour;
			break;
		default:
			TimeFormat = TimeFormat.AM;
			break;
		}
		KeyValueOfstringanyType keyValueOfstringanyType = rvTimer.TimerValueDictionary?.FirstOrDefault((KeyValueOfstringanyType kv) => kv.Key?.Equals("Value") ?? false);
		if (keyValueOfstringanyType != null)
		{
			EndTime = TimeSliceHelper.StringToTimeSlice(keyValueOfstringanyType.Value);
		}
	}

	public override TimerBase Clone()
	{
		CountdownToTime timer = new CountdownToTime();
		return CopyProperties(timer);
	}

	protected override TimerBase CopyProperties(TimerBase timer)
	{
		CountdownToTime obj = (CountdownToTime)timer;
		obj.TimeFormat = TimeFormat;
		base.CopyProperties(timer);
		return obj;
	}
}
