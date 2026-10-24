using System.Linq;
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

public class ElapsedTime : TimerBase
{
	private TimeSlice _startTime;

	private TimeSlice _endTime;

	private bool _hasEndTime;

	public override TimerType TimerType => TimerType.ElapsedTime;

	public override TimeSlice RunningTime
	{
		get
		{
			TimeSlice timeSlice = ((!IsForward) ? (base.Duration - base.Clock.ElapsedTime) : ((base.State == TimerState.Reset) ? StartTime : base.Clock.ElapsedTime));
			if (HasEndTime && (IsForward ? (timeSlice >= EndTime) : (timeSlice <= EndTime)) && base.IsTimerRunning)
			{
				if (!base.IsOverRunAllowed)
				{
					timeSlice = _endTime;
				}
				else if (base.State != TimerState.Paused)
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
				base.UndoStack?.Commit(UndoActionTypes.TimerStart.ToAction(), this, "StartTime", o, n, null, null, autoFinalize: true);
				if (base.State == TimerState.Reset)
				{
					ResetDuration();
				}
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
			SetValue("EndTime", ref _endTime, value, delegate(TimeSlice o, TimeSlice n)
			{
				base.UndoStack?.Commit(UndoActionTypes.TimerEnd.ToAction(), this, "EndTime", o, n, null, null, autoFinalize: true);
				OnDataModified();
				OnPropertyChanged("HasEndTime");
			});
		}
	}

	public bool HasEndTime
	{
		get
		{
			return _hasEndTime;
		}
		set
		{
			SetValue("HasEndTime", ref _hasEndTime, value, base.OnDataModified);
		}
	}

	public override bool IsForward
	{
		get
		{
			if (HasEndTime)
			{
				return StartTime <= EndTime;
			}
			return true;
		}
	}

	public override ObjectBinder<TimerBase, ITimer.Types.IConfiguration> Bind(IUiScheduler scheduler, IEntityFactory entityFactory, ITimer.Types.IConfiguration entity)
	{
		ITimer.Types.IConfiguration.Types.ITimerType.IElapsedTime elapsedTime = entity.TimerType.Value as ITimer.Types.IConfiguration.Types.ITimerType.IElapsedTime;
		if (elapsedTime == null)
		{
			elapsedTime = entityFactory.Create<ITimer.Types.IConfiguration.Types.ITimerType.IElapsedTime>();
			entity.TimerType.Set(elapsedTime);
		}
		ObjectBinder<ElapsedTime, ITimer.Types.IConfiguration.Types.ITimerTypeElapsedTime> elapsedTimerBinder = new ObjectBinder<ElapsedTime, ITimer.Types.IConfiguration.Types.ITimerTypeElapsedTime>(this, elapsedTime.Value).Bind((ElapsedTime l) => l.WhenPropertyChanges("StartTime"), (ITimer.Types.IConfiguration.Types.ITimerTypeElapsedTime r) => r.StartTime.WhenValueChanges, delegate(ElapsedTime l, ITimer.Types.IConfiguration.Types.ITimerTypeElapsedTime r)
		{
			r.StartTime.Set(l.StartTime.TotalSeconds);
		}, delegate(ITimer.Types.IConfiguration.Types.ITimerTypeElapsedTime r, ElapsedTime l)
		{
			l.StartTime = TimeSlice.FromSeconds(r.StartTime.Value);
		}).Bind((ElapsedTime l) => l.WhenPropertyChanges("EndTime"), (ITimer.Types.IConfiguration.Types.ITimerTypeElapsedTime r) => r.EndTime.WhenValueChanges, delegate(ElapsedTime l, ITimer.Types.IConfiguration.Types.ITimerTypeElapsedTime r)
		{
			r.EndTime.Set(l.EndTime.TotalSeconds);
		}, delegate(ITimer.Types.IConfiguration.Types.ITimerTypeElapsedTime r, ElapsedTime l)
		{
			l.EndTime = TimeSlice.FromSeconds(r.EndTime.Value);
		}).Bind((ElapsedTime l) => l.WhenPropertyChanges("HasEndTime"), (ITimer.Types.IConfiguration.Types.ITimerTypeElapsedTime r) => r.HasEndTime.WhenValueChanges, delegate(ElapsedTime l, ITimer.Types.IConfiguration.Types.ITimerTypeElapsedTime r)
		{
			r.HasEndTime.Set(l.HasEndTime);
		}, delegate(ITimer.Types.IConfiguration.Types.ITimerTypeElapsedTime r, ElapsedTime l)
		{
			l.HasEndTime = r.HasEndTime.Value;
		});
		ObjectBinder<TimerBase, ITimer.Types.IConfiguration> objectBinder = base.Bind(scheduler, entityFactory, entity);
		objectBinder.DoOnInitializeRightFromLeft(elapsedTimerBinder.InitializeRightFromLeft).DoOnInitializeLeftFromRight(elapsedTimerBinder.InitializeLeftFromRight).RegisterChildDisposable(() => elapsedTimerBinder);
		return objectBinder;
	}

	public void UpdateTimer(TimeSlice duration, bool hasEndTime, bool allowOverrun)
	{
		HasEndTime = hasEndTime;
		EndTime = duration;
		base.IsOverRunAllowed = allowOverrun;
	}

	protected override void OnStart()
	{
		if (IsForward && (base.Clock.ElapsedTime == TimeSlice.Zero || base.Clock.ElapsedTime == EndTime))
		{
			base.Clock.ElapsedTime = StartTime;
		}
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
		base.Clock.ElapsedTime += time;
	}

	private void ResetDuration()
	{
		if (IsForward)
		{
			base.Clock.ElapsedTime = StartTime;
			return;
		}
		base.Duration = StartTime;
		base.Clock.ElapsedTime = TimeSlice.Zero;
	}

	protected override void OnExpire()
	{
		base.Clock.Stop();
		if (!IsForward)
		{
			base.Duration = EndTime;
		}
		base.Clock.ElapsedTime = (IsForward ? _endTime : TimeSlice.Zero);
	}

	protected override void OnSerialize(Pro.SerializationInterop.RVProtoData.Timer.Types.Configuration configuration)
	{
		configuration.ElapsedTime = new Pro.SerializationInterop.RVProtoData.Timer.Types.Configuration.Types.TimerTypeElapsedTime
		{
			StartTime = StartTime.TotalSeconds,
			EndTime = EndTime.TotalSeconds,
			HasEndTime = HasEndTime
		};
	}

	protected override void OnRVDeserialize(RVTimer rvTimer)
	{
		EndTime = TimeSliceHelper.StringToTimeSlice(rvTimer.EndTime);
		KeyValueOfstringanyType keyValueOfstringanyType = rvTimer.TimerValueDictionary?.FirstOrDefault((KeyValueOfstringanyType kv) => kv.Key?.Equals("Value") ?? false);
		if (keyValueOfstringanyType != null)
		{
			StartTime = TimeSliceHelper.StringToTimeSlice(keyValueOfstringanyType.Value ?? string.Empty);
		}
	}

	protected override void OnDeserialize(Pro.SerializationInterop.RVProtoData.Timer.Types.Configuration configuration)
	{
		if (configuration != null && configuration.ElapsedTime != null)
		{
			StartTime = TimeSlice.FromSeconds(configuration.ElapsedTime.StartTime);
			EndTime = TimeSlice.FromSeconds(configuration.ElapsedTime.EndTime);
			HasEndTime = configuration.ElapsedTime.HasEndTime;
			ResetDuration();
		}
	}

	public override TimerBase Clone()
	{
		return CopyProperties(new ElapsedTime());
	}

	protected override TimerBase CopyProperties(TimerBase timer)
	{
		base.CopyProperties(timer);
		ElapsedTime obj = (ElapsedTime)timer;
		obj.HasEndTime = HasEndTime;
		return obj;
	}
}
