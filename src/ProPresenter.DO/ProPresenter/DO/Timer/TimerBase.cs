using System;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Time;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Migration.RVData;

namespace ProPresenter.DO.Timer;

public abstract class TimerBase : NotifyPropertyChangedBase, ICloneable<TimerBase>
{
	private bool _isOverRunAllowed;

	private TimeSlice _duration = TimeSlice.Zero;

	private TimerState _state;

	public abstract TimerType TimerType { get; }

	public abstract TimeSlice EndTime { get; set; }

	public virtual TimeSlice StartTime { get; set; } = TimeSlice.Zero;

	public abstract bool IsForward { get; }

	public bool IsTimerRunning => Clock.IsRunning;

	public abstract TimeSlice RunningTime { get; }

	public bool IsOverRunAllowed
	{
		get
		{
			return _isOverRunAllowed;
		}
		set
		{
			SetValue("IsOverRunAllowed", ref _isOverRunAllowed, value, delegate(bool o, bool n)
			{
				UndoStack?.Commit(UndoActionTypes.TimerOverrun.ToAction(), this, "IsOverRunAllowed", o, n, null, null, autoFinalize: true);
				OnDataModified();
			});
		}
	}

	public TimerFormatData Format { get; private set; } = new TimerFormatData();

	protected Pro.Common.Time.Clock Clock { get; } = new Pro.Common.Time.Clock();

	protected TimeSlice Duration
	{
		get
		{
			return _duration;
		}
		set
		{
			_duration = value;
			OnPropertyChanged("Duration");
			OnPropertyChanged("RunningTime");
		}
	}

	public TimerState State
	{
		get
		{
			return _state;
		}
		set
		{
			SetValue("State", ref _state, value);
		}
	}

	public UndoStack? UndoStack { get; set; }

	public event System.Action? DataModified;

	public event Action<TimerBase>? WasStarted;

	public event Action<TimerBase>? WasPaused;

	public event Action<TimerBase>? WasReset;

	public virtual ObjectBinder<TimerBase, ITimer.Types.IConfiguration> Bind(IUiScheduler scheduler, IEntityFactory entityFactory, ITimer.Types.IConfiguration entity)
	{
		ObjectBinder<TimerBase, ITimer.Types.IConfiguration> objectBinder = new ObjectBinder<TimerBase, ITimer.Types.IConfiguration>(this, entity);
		objectBinder.Bind((TimerBase l) => l.WhenPropertyChanges("IsOverRunAllowed"), (ITimer.Types.IConfiguration r) => r.AllowsOverrun.WhenValueChanges, delegate(TimerBase l, ITimer.Types.IConfiguration r)
		{
			r.AllowsOverrun.Set(l.IsOverRunAllowed);
		}, delegate(ITimer.Types.IConfiguration r, TimerBase l)
		{
			l.IsOverRunAllowed = r.AllowsOverrun.Value;
		});
		return objectBinder;
	}

	protected TimerBase()
	{
		Format.DataModified += OnDataModified;
	}

	public bool HasOverRun()
	{
		if (!IsOverRunAllowed)
		{
			return false;
		}
		if (IsForward)
		{
			return RunningTime.Seconds > EndTime.Seconds;
		}
		return RunningTime.Seconds < EndTime.Seconds;
	}

	public void Start()
	{
		State = TimerState.Started;
		OnStart();
		this.WasStarted?.Invoke(this);
		OnPropertyChanged("IsTimerRunning");
	}

	public void Pause()
	{
		if (State != 0)
		{
			State = TimerState.Paused;
		}
		OnPause();
		this.WasPaused?.Invoke(this);
		OnPropertyChanged("IsTimerRunning");
	}

	public void Reset()
	{
		State = TimerState.Reset;
		OnReset();
		this.WasReset?.Invoke(this);
		OnPropertyChanged("IsTimerRunning");
	}

	public void Increment(TimeSlice time)
	{
		OnIncrement(time);
	}

	public void Expire()
	{
		State = TimerState.Expired;
		OnExpire();
		this.WasReset?.Invoke(this);
		OnPropertyChanged("IsTimerRunning");
	}

	protected abstract void OnStart();

	protected abstract void OnPause();

	protected abstract void OnReset();

	protected abstract void OnIncrement(TimeSlice time);

	protected abstract void OnExpire();

	protected void OnDataModified()
	{
		this.DataModified?.Invoke();
	}

	public Pro.SerializationInterop.RVProtoData.Timer.Types.Configuration Serialize()
	{
		Pro.SerializationInterop.RVProtoData.Timer.Types.Configuration configuration = new Pro.SerializationInterop.RVProtoData.Timer.Types.Configuration
		{
			AllowsOverrun = IsOverRunAllowed
		};
		OnSerialize(configuration);
		return configuration;
	}

	protected abstract void OnSerialize(Pro.SerializationInterop.RVProtoData.Timer.Types.Configuration configuration);

	public void Deserialize(Pro.SerializationInterop.RVProtoData.Timer.Types.Configuration configuration)
	{
		if (configuration != null)
		{
			IsOverRunAllowed = configuration.AllowsOverrun;
			OnDeserialize(configuration);
		}
	}

	protected abstract void OnDeserialize(Pro.SerializationInterop.RVProtoData.Timer.Types.Configuration configuration);

	public void RVDeserialize(RVTimer rvTimer)
	{
		IsOverRunAllowed = rvTimer.OverRun;
		OnRVDeserialize(rvTimer);
	}

	protected abstract void OnRVDeserialize(RVTimer timer);

	public abstract TimerBase Clone();

	protected virtual TimerBase CopyProperties(TimerBase timer)
	{
		timer.StartTime = StartTime;
		timer.EndTime = EndTime;
		timer.IsOverRunAllowed = IsOverRunAllowed;
		timer.Format = Format.Clone();
		timer.Duration = Duration;
		return timer;
	}
}
