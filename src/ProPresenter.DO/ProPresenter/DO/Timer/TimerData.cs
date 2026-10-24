using System;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Time;
using Pro.Common.Utility;
using Pro.DO.Triggering;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.Entity.Merged.Entities;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Migration.RVData;

namespace ProPresenter.DO.Timer;

public class TimerData : TimerSourceBase<TimerBase>, ICloneable<TimerData>, IIdentifiable, ITriggerable
{
	private string _name = string.Empty;

	private TimeSlice _resetIncrement = TimeSlice.Zero;

	public Guid ID { get; private set; }

	public string Name
	{
		get
		{
			return _name;
		}
		set
		{
			SetValue("Name", ref _name, value, delegate(string o, string n)
			{
				base.UndoStack?.Commit(UndoActionTypes.TimerName.ToAction(), this, "Name", o, n, null, null, autoFinalize: true);
				this.SourceNameChanged?.Invoke(this);
				OnDataModified();
			});
		}
	}

	public event Action<TimerData>? SourceNameChanged;

	public IReadOnlyObjectBinder<TimerData, IMergedTimer> Bind(IUiScheduler scheduler, IEntityFactory entityFactory, IMergedTimer entity)
	{
		ObjectBinder<TimerData, IMergedTimer> objectBinder = new ObjectBinder<TimerData, IMergedTimer>(this, entity);
		objectBinder.Bind((TimerData l) => l.WhenPropertyChanges("ID"), (IMergedTimer r) => r.Uuid.WhenValueChanges, delegate(TimerData l, IMergedTimer r)
		{
			r.Uuid.Set(l.ID);
		}, delegate(IMergedTimer r, TimerData l)
		{
			l.ID = r.Uuid.Value;
		}).Bind((TimerData l) => l.WhenPropertyChanges("Name"), (IMergedTimer r) => r.Name.WhenValueChanges, delegate(TimerData l, IMergedTimer r)
		{
			r.Name.Set(l.Name);
		}, delegate(IMergedTimer r, TimerData l)
		{
			l.SetValue("Name", ref l._name, r.Name.Value, (Action<string, string>?)delegate
			{
				l.SourceNameChanged?.Invoke(l);
				l.OnDataModified();
			}, (Predicate<string>?)null, referenceComparison: false);
		}).Bind((TimerData l) => l.WhenPropertyChanges("Source"), (IMergedTimer r) => r.Configuration.WhenValueChanges, delegate(TimerData l, IMergedTimer r)
		{
			ITimer.Types.IConfiguration configuration = entityFactory.Create<ITimer.Types.IConfiguration>();
			r.Configuration.Set(configuration);
			ObjectBinder<TimerBase, ITimer.Types.IConfiguration> objectBinder2 = l.Source.Bind(scheduler, entityFactory, configuration);
			objectBinder2.InitializeRightFromLeft();
			configuration.RegisterLinkedDisposable(objectBinder2);
		}, delegate(IMergedTimer r, TimerData l)
		{
			ITimer.Types.IConfiguration.Types.ITimerType value = r.Configuration.Value.TimerType.Value;
			TimerBase timerBase;
			if (!(value is ITimer.Types.IConfiguration.Types.ITimerType.ICountdown))
			{
				if (!(value is ITimer.Types.IConfiguration.Types.ITimerType.ICountdownToTime))
				{
					if (!(value is ITimer.Types.IConfiguration.Types.ITimerType.IElapsedTime))
					{
						throw new NotSupportedException();
					}
					timerBase = new ElapsedTime();
				}
				else
				{
					timerBase = new CountdownToTime();
				}
			}
			else
			{
				timerBase = new CountdownTimer();
			}
			TimerBase timerBase3 = (l.Source = timerBase);
			ObjectBinder<TimerBase, ITimer.Types.IConfiguration> objectBinder3 = timerBase3.Bind(scheduler, entityFactory, r.Configuration.Value);
			objectBinder3.InitializeLeftFromRight();
			r.Configuration.Value.RegisterLinkedDisposable(objectBinder3);
		});
		return objectBinder;
	}

	public TimerData()
		: this(new CountdownTimer(), null)
	{
	}

	public TimerData(TimerBase source, Guid? id = null)
		: base(source)
	{
		ID = id ?? Guid.NewGuid();
	}

	public Pro.SerializationInterop.RVProtoData.Timer Serialize()
	{
		return new Pro.SerializationInterop.RVProtoData.Timer
		{
			Uuid = ID.ToUUID(),
			Name = Name,
			Configuration = base.Source?.Serialize()
		};
	}

	public void Deserialize(Pro.SerializationInterop.RVProtoData.Timer timer)
	{
		Deserialize(timer.Name, timer.Configuration, timer.Uuid.ToGuid());
	}

	public void Deserialize(string timerName, Pro.SerializationInterop.RVProtoData.Timer.Types.Configuration? configuration, Guid timerID)
	{
		ID = timerID;
		if (configuration != null)
		{
			UpdateSource(configuration.TimerTypeCase.ToTimerType());
			if (base.Source != null)
			{
				base.Active = base.Source.Clone();
				Name = timerName;
				base.Source.Deserialize(configuration);
				base.Active?.Deserialize(configuration);
			}
		}
	}

	public void RVDeserialize(RVTimer rvTimer)
	{
		ID = rvTimer.FieldId;
		base.Source?.RVDeserialize(rvTimer);
		base.Active?.RVDeserialize(rvTimer);
	}

	public void UpdateSource(TimerType timerType)
	{
		TimerBase source = base.Source;
		if (source == null || source.TimerType != timerType)
		{
			TimerBase timerBase;
			switch (timerType)
			{
			default:
				return;
			case TimerType.Countdown:
				timerBase = new CountdownTimer();
				break;
			case TimerType.CountdownToTime:
				timerBase = new CountdownToTime();
				break;
			case TimerType.ElapsedTime:
				timerBase = new ElapsedTime();
				break;
			}
			timerBase.IsOverRunAllowed = base.Source?.IsOverRunAllowed ?? false;
			base.Source = timerBase;
			TimerBase active = base.Active;
			if (active != null && active.State == TimerState.Reset)
			{
				base.Active = base.Source;
			}
		}
	}

	public void UpdateSource(Pro.SerializationInterop.RVProtoData.Timer.Types.Configuration configuration)
	{
		TimerType timerType = configuration.TimerTypeCase.ToTimerType();
		UpdateSource(timerType);
		switch (timerType)
		{
		case TimerType.Countdown:
			if (base.Source is CountdownTimer countdownTimer && configuration.Countdown != null)
			{
				countdownTimer.StartTime = TimeSlice.FromSeconds(configuration.Countdown.Duration);
				if (base.Active is CountdownTimer { State: TimerState.Reset } countdownTimer2)
				{
					countdownTimer2.StartTime = countdownTimer.StartTime;
				}
			}
			break;
		case TimerType.CountdownToTime:
			if (base.Source is CountdownToTime countdownToTime && configuration.CountdownToTime != null)
			{
				countdownToTime.EndTime = TimeSlice.FromSeconds(configuration.CountdownToTime.TimeOfDay);
				countdownToTime.TimeFormat = configuration.CountdownToTime.Period.ToTimeFormat();
				if (base.Active is CountdownToTime { State: TimerState.Reset } countdownToTime2)
				{
					countdownToTime2.EndTime = countdownToTime.EndTime;
					countdownToTime2.TimeFormat = countdownToTime.TimeFormat;
				}
			}
			break;
		case TimerType.ElapsedTime:
			if (base.Source is ElapsedTime elapsedTime && configuration.ElapsedTime != null)
			{
				elapsedTime.StartTime = TimeSlice.FromSeconds(configuration.ElapsedTime.StartTime);
				elapsedTime.EndTime = TimeSlice.FromSeconds(configuration.ElapsedTime.EndTime);
				elapsedTime.HasEndTime = configuration.ElapsedTime.HasEndTime;
				if (base.Active is ElapsedTime { State: TimerState.Reset } elapsedTime2)
				{
					elapsedTime2.StartTime = elapsedTime.StartTime;
					elapsedTime2.EndTime = elapsedTime.EndTime;
					elapsedTime2.HasEndTime = elapsedTime.HasEndTime;
				}
			}
			break;
		}
		if (base.Source != null)
		{
			base.Source.IsOverRunAllowed = configuration.AllowsOverrun;
		}
	}

	public TimerData Clone()
	{
		TimerBase timerBase = base.Source?.Clone();
		if (timerBase != null)
		{
			return new TimerData(timerBase, null)
			{
				Name = Name
			};
		}
		return new TimerData();
	}

	public void Start()
	{
		base.Active?.Start();
		_resetIncrement = TimeSlice.Zero;
	}

	public void Pause()
	{
		base.Active?.Pause();
	}

	public void Reset(Pro.SerializationInterop.RVProtoData.Timer.Types.Configuration protoTimerConfiguration)
	{
		Pro.SerializationInterop.RVProtoData.Timer timer = Serialize();
		timer.Configuration = protoTimerConfiguration;
		Deserialize(timer);
		base.Active?.Reset();
		if (_resetIncrement != TimeSlice.Zero)
		{
			base.Active?.Increment(_resetIncrement);
		}
	}

	public void ResetAndStart(Pro.SerializationInterop.RVProtoData.Timer.Types.Configuration protoTimerConfiguration)
	{
		Reset(protoTimerConfiguration);
		Start();
	}

	public void Increment(TimeSlice time)
	{
		base.Active?.Increment(time);
		TimerBase active = base.Active;
		if (active != null && active.State == TimerState.Reset)
		{
			_resetIncrement += time;
		}
	}

	public void Expire()
	{
		base.Active?.Expire();
	}
}
