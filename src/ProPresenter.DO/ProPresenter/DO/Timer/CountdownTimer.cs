using System.Linq;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Time;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Migration.RVData;

namespace ProPresenter.DO.Timer;

public class CountdownTimer : TimerBase
{
	private TimeSlice _startTime = TimeSlice.Zero;

	public override TimerType TimerType => TimerType.Countdown;

	public override TimeSlice StartTime
	{
		get
		{
			return _startTime;
		}
		set
		{
			SetValue("StartTime", ref _startTime, value, delegate(TimeSlice o, TimeSlice n)
			{
				ResetDuration(n);
				OnDataModified();
			});
		}
	}

	public override TimeSlice EndTime
	{
		get
		{
			return TimeSlice.Zero;
		}
		set
		{
		}
	}

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
				}
				else
				{
					base.State = TimerState.Overran;
				}
			}
			return timeSlice;
		}
	}

	public override bool IsForward => false;

	public override ObjectBinder<TimerBase, ITimer.Types.IConfiguration> Bind(IUiScheduler scheduler, IEntityFactory entityFactory, ITimer.Types.IConfiguration entity)
	{
		ITimer.Types.IConfiguration.Types.ITimerType.ICountdown countdown = entity.TimerType.Value as ITimer.Types.IConfiguration.Types.ITimerType.ICountdown;
		if (countdown == null)
		{
			countdown = entityFactory.Create<ITimer.Types.IConfiguration.Types.ITimerType.ICountdown>();
			entity.TimerType.Set(countdown);
		}
		ObjectBinder<CountdownTimer, ITimer.Types.IConfiguration.Types.ITimerTypeCountdown> countdownTimerBinder = new ObjectBinder<CountdownTimer, ITimer.Types.IConfiguration.Types.ITimerTypeCountdown>(this, countdown.Value).Bind((CountdownTimer l) => l.WhenPropertyChanges("Duration"), (ITimer.Types.IConfiguration.Types.ITimerTypeCountdown r) => r.Duration.WhenValueChanges, delegate(CountdownTimer l, ITimer.Types.IConfiguration.Types.ITimerTypeCountdown r)
		{
			r.Duration.Set(l.StartTime.TotalSeconds);
		}, delegate(ITimer.Types.IConfiguration.Types.ITimerTypeCountdown r, CountdownTimer l)
		{
			l.StartTime = TimeSlice.FromSeconds(r.Duration.Value);
			l.Duration = l.StartTime;
		});
		ObjectBinder<TimerBase, ITimer.Types.IConfiguration> objectBinder = base.Bind(scheduler, entityFactory, entity);
		objectBinder.DoOnInitializeRightFromLeft(countdownTimerBinder.InitializeRightFromLeft).DoOnInitializeLeftFromRight(countdownTimerBinder.InitializeLeftFromRight).RegisterChildDisposable(() => countdownTimerBinder);
		return objectBinder;
	}

	public CountdownTimer(TimeSlice defaultDuration)
	{
		_startTime = defaultDuration;
		base.Duration = defaultDuration;
	}

	public CountdownTimer()
		: this(TimeSlice.Zero)
	{
	}

	public void UpdateTimer(TimeSlice defaultDuration, bool allowsOverrun)
	{
		StartTime = defaultDuration;
		base.Duration = defaultDuration;
		base.IsOverRunAllowed = allowsOverrun;
	}

	protected override void OnStart()
	{
		base.Clock.Start();
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
		configuration.Countdown = new Pro.SerializationInterop.RVProtoData.Timer.Types.Configuration.Types.TimerTypeCountdown
		{
			Duration = StartTime.TotalSeconds
		};
	}

	protected override void OnDeserialize(Pro.SerializationInterop.RVProtoData.Timer.Types.Configuration configuration)
	{
		if (configuration != null && configuration.Countdown != null)
		{
			StartTime = TimeSlice.FromSeconds(configuration.Countdown.Duration);
			base.Duration = StartTime;
		}
	}

	protected override void OnRVDeserialize(RVTimer timer)
	{
		KeyValueOfstringanyType keyValueOfstringanyType = timer.TimerValueDictionary?.FirstOrDefault((KeyValueOfstringanyType kv) => kv.Key?.Equals("Value") ?? false);
		if (keyValueOfstringanyType != null)
		{
			StartTime = TimeSliceHelper.StringToTimeSlice(keyValueOfstringanyType.Value);
		}
	}

	public override TimerBase Clone()
	{
		return CopyProperties(new CountdownTimer());
	}

	private void ResetDuration(TimeSlice duration)
	{
		if (base.State == TimerState.Reset)
		{
			base.Duration = duration;
		}
	}
}
