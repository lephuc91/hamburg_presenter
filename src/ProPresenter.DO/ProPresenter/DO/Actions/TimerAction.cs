using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Application;
using Pro.DO.Triggering;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Timer;

namespace ProPresenter.DO.Actions;

public class TimerAction : ActionBase, IScrimSource, IActionDataIdentifier, ITimelineItem, ITriggerable, INotifyPropertyChanged
{
	private readonly ITimerCollection? _timers;

	private Guid _timerID = Guid.Empty;

	private string _timerName = string.Empty;

	private TimerBase _configuration;

	private TimerActionType _timerActionType;

	private bool _setConfiguration = true;

	private TimerActionType _actualTimerActionType = TimerActionType.ResetAndStart;

	public override ActionType ActionType => ActionType.Timer;

	public ScrimPosition Position => ScrimPosition.TopLeft;

	public DisplayMode DisplayMode => DisplayMode.Label;

	public bool IsEditable => true;

	public ListViewType ListViewType => ListViewType.Content;

	public Guid TimerID
	{
		get
		{
			return _timerID;
		}
		set
		{
			SetValue("TimerID", ref _timerID, value, delegate(Guid o, Guid n)
			{
				base.UndoStack?.Commit(UndoActionTypes.ActionSetTimer.ToAction(), this, "TimerID", o, n);
				OnDataModified();
			});
		}
	}

	public string? TimerName
	{
		get
		{
			return _timerName;
		}
		set
		{
			SetValue("TimerName", ref _timerName, value, delegate(string o, string n)
			{
				base.UndoStack?.Commit(UndoActionTypes.ActionSetTimer.ToAction(), this, "TimerName", o, n);
				base.Name = n;
				OnDataModified();
			});
		}
	}

	public TimerBase Configuration
	{
		get
		{
			return _configuration;
		}
		set
		{
			SetValue("Configuration", ref _configuration, value, delegate(TimerBase o, TimerBase n)
			{
				base.UndoStack?.Commit(UndoActionTypes.ActionSetTimerType.ToAction(), this, "Configuration", o, n);
				if (o != null)
				{
					o.DataModified -= base.OnDataModified;
				}
				if (n != null)
				{
					n.DataModified += base.OnDataModified;
					n.UndoStack = base.UndoStack;
				}
				OnDataModified();
				OnPropertyChanged("IsValid");
			});
		}
	}

	public TimerActionType TimerActionType
	{
		get
		{
			return _timerActionType;
		}
		set
		{
			SetValue("TimerActionType", ref _timerActionType, value, delegate(TimerActionType o, TimerActionType n)
			{
				using (base.UndoStack?.Transaction(UndoActionTypes.ActionTimerActionType.ToAction(), null, null, autoFinalize: true))
				{
					base.UndoStack?.Commit(this, "TimerActionType", o, n);
					_actualTimerActionType = n;
					if (_actualTimerActionType != 0 || _actualTimerActionType != TimerActionType.Stop)
					{
						SetConfiguration = false;
					}
					OnDataModified();
				}
			});
		}
	}

	public bool SetConfiguration
	{
		get
		{
			return _setConfiguration;
		}
		set
		{
			SetValue("SetConfiguration", ref _setConfiguration, value, delegate(bool o, bool n)
			{
				base.UndoStack?.Commit(UndoActionTypes.ActionTimerSetConfiguration.ToAction(), this, "SetConfiguration", o, n);
				if (n)
				{
					if (_actualTimerActionType == TimerActionType.Start)
					{
						_actualTimerActionType = TimerActionType.ResetAndStart;
					}
					else if (_actualTimerActionType == TimerActionType.Stop)
					{
						_actualTimerActionType = TimerActionType.ResetAndStop;
					}
					UpdateConfig();
				}
				else if (_actualTimerActionType == TimerActionType.ResetAndStart)
				{
					_actualTimerActionType = TimerActionType.Start;
				}
				else if (_actualTimerActionType == TimerActionType.ResetAndStop)
				{
					_actualTimerActionType = TimerActionType.Stop;
				}
				OnDataModified();
			});
		}
	}

	public override bool IsValid => _timers?.FirstOrDefaultBy((TimerData t) => t.ID == TimerID, (TimerData t) => t.Source != null && t.Name.Equals(TimerName)) != null;

	protected override string DefaultName => LocalizedStrings.Get("ACTION_TYPE_TIMER_title");

	public TimelineItemType TimelineItemType => TimelineItemType.Actions;

	public static ObjectBinder<Pro.DO.Triggering.IAction, Pro.Entity.IAction> CreateBinder(IUiScheduler scheduler, IEntityFactory entityFactory, TimerAction left, Pro.Entity.IAction right)
	{
		ObjectBinder<Pro.DO.Triggering.IAction, Pro.Entity.IAction> objectBinder = ActionBase.CreateBinder(scheduler, entityFactory, left, right, delegate
		{
		});
		Pro.Entity.IAction.Types.IActionTypeData.ITimer timer = right.ActionTypeData.Value as Pro.Entity.IAction.Types.IActionTypeData.ITimer;
		if (timer == null)
		{
			timer = entityFactory.Create<Pro.Entity.IAction.Types.IActionTypeData.ITimer>();
			right.ActionTypeData.Set(timer);
		}
		ObjectBinder<TimerAction, Pro.Entity.IAction.Types.ITimerType> timerActionBinder = new ObjectBinder<TimerAction, Pro.Entity.IAction.Types.ITimerType>(left, timer.Value).Bind((TimerAction l) => l.WhenPropertyChanges("TimerID").Merge(l.WhenPropertyChanges("TimerName")).ToUnit(), (Pro.Entity.IAction.Types.ITimerType r) => r.TimerIdentification.WhenValueChanges, delegate(TimerAction l, Pro.Entity.IAction.Types.ITimerType r)
		{
			ICollectionElementType collectionElementType = entityFactory.Create<ICollectionElementType>();
			collectionElementType.ParameterUuid.Set(l.TimerID);
			collectionElementType.ParameterName.Set(l.TimerName);
			r.TimerIdentification.Set(collectionElementType);
		}, delegate(Pro.Entity.IAction.Types.ITimerType r, TimerAction l)
		{
			l.SetIdentifier(r.TimerIdentification.Value.ParameterUuid.ToGuidOrEmpty(), r.TimerIdentification.Value.ParameterName.Value);
			l.UpdateConfig();
		}, null, scheduler.Scheduler).Bind((TimerAction l) => l.WhenPropertyChanges("TimerActionType").Merge(l.WhenPropertyChanges("SetConfiguration")), (Pro.Entity.IAction.Types.ITimerType r) => r.ActionType.WhenValueChanges, delegate(TimerAction l, Pro.Entity.IAction.Types.ITimerType r)
		{
			r.ActionType.Set(l._actualTimerActionType.ToEntityTimerActionType());
		}, delegate(Pro.Entity.IAction.Types.ITimerType r, TimerAction l)
		{
			l.TimerActionType = r.ActionType.Value.ToTimerActionType();
		}).Bind((TimerAction l) => l.WhenPropertyChanges("Configuration"), (Pro.Entity.IAction.Types.ITimerType r) => r.TimerConfiguration.WhenValueChanges, delegate(TimerAction l, Pro.Entity.IAction.Types.ITimerType r)
		{
			ITimer.Types.IConfiguration configuration = entityFactory.Create<ITimer.Types.IConfiguration>();
			r.TimerConfiguration.Set(configuration);
			ObjectBinder<TimerBase, ITimer.Types.IConfiguration> objectBinder2 = l.Configuration.Bind(scheduler, entityFactory, configuration);
			objectBinder2.InitializeRightFromLeft();
			configuration.RegisterLinkedDisposable(objectBinder2);
		}, delegate(Pro.Entity.IAction.Types.ITimerType r, TimerAction l)
		{
			ITimer.Types.IConfiguration.Types.ITimerType value = r.TimerConfiguration.Value.TimerType.Value;
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
			TimerBase timerBase3 = (l.Configuration = timerBase);
			ObjectBinder<TimerBase, ITimer.Types.IConfiguration> objectBinder3 = timerBase3.Bind(scheduler, entityFactory, r.TimerConfiguration.Value);
			objectBinder3.InitializeLeftFromRight();
			r.TimerConfiguration.Value.RegisterLinkedDisposable(objectBinder3);
		}, null, scheduler.Scheduler);
		objectBinder.DoOnInitializeRightFromLeft(timerActionBinder.InitializeRightFromLeft).DoOnInitializeLeftFromRight(timerActionBinder.InitializeLeftFromRight).RegisterChildDisposable(() => timerActionBinder);
		return objectBinder;
	}

	public TimerAction(ITimerCollection? timers, Guid id)
	{
		TimerAction @object = this;
		_configuration = new CountdownTimer();
		if (timers != null)
		{
			_timers = timers;
			TimerData timerData = timers.FirstOrDefault((TimerData t) => t.ID == id);
			if (timerData != null)
			{
				TimerID = timerData.ID;
				TimerName = timerData.Name;
				Configuration = timerData.Source.Clone();
				TimerActionType = TimerActionType.Start;
			}
			_timers.ForEach(delegate(TimerData t)
			{
				t.SourceNameChanged += @object.Timer_SourceNameChanged;
			});
			_timers.CollectionChanged += Timers_CollectionChanged;
		}
	}

	public TimerAction(Guid id)
		: this(DataVault.TimerDocument?.Timers, id)
	{
	}

	public TimerAction()
		: this(Guid.Empty)
	{
	}

	public void SetIdentifier(Guid id, string? name)
	{
		if (id == TimerID)
		{
			return;
		}
		using (base.UndoStack?.Transaction(null, null, null, autoFinalize: true))
		{
			TimerID = id;
			TimerName = name;
			UpdateConfig();
		}
	}

	public void SetIdentifier(TimerData timer)
	{
		if (timer == null || timer.ID == TimerID)
		{
			return;
		}
		using (base.UndoStack?.Transaction(null, null, null, autoFinalize: true))
		{
			TimerID = timer.ID;
			TimerName = timer.Name;
			Configuration = timer.Source.Clone();
		}
	}

	private void UpdateConfig()
	{
		if (IsValid && _timers != null)
		{
			TimerData timerData = _timers.FirstOrDefaultBy((TimerData t) => t.ID == TimerID, (TimerData t) => t.Name.Equals(TimerName));
			if (timerData != null)
			{
				Configuration = timerData.Source.Clone();
			}
		}
	}

	private void Timers_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.OfType<TimerData>().ForEach(delegate(TimerData t)
		{
			t.SourceNameChanged -= Timer_SourceNameChanged;
		});
		e.NewItems?.OfType<TimerData>().ForEach(delegate(TimerData t)
		{
			t.SourceNameChanged += Timer_SourceNameChanged;
		});
		OnPropertyChanged("IsValid");
	}

	private void Timer_SourceNameChanged(TimerData timer)
	{
		if (timer.ID == TimerID)
		{
			TimerName = timer.Name;
		}
	}

	public override Pro.DO.Triggering.IAction Clone()
	{
		return CopyProperties(new TimerAction(_timers, TimerID));
	}

	protected override T CopyProperties<T>(T action)
	{
		if (action is TimerAction timerAction)
		{
			timerAction.TimerName = TimerName;
			timerAction.Configuration = Configuration.Clone();
			timerAction.TimerActionType = _timerActionType;
			timerAction.SetConfiguration = _setConfiguration;
			timerAction._actualTimerActionType = _actualTimerActionType;
		}
		return base.CopyProperties(action);
	}

	public override Pro.SerializationInterop.RVProtoData.Action Serialize()
	{
		Pro.SerializationInterop.RVProtoData.Action action = base.Serialize();
		action.Timer = new Pro.SerializationInterop.RVProtoData.Action.Types.TimerType
		{
			TimerIdentification = new CollectionElementType
			{
				ParameterUuid = TimerID.ToUUID(),
				ParameterName = (TimerName ?? string.Empty)
			},
			ActionType = _actualTimerActionType.ToProtoTimerActionType(),
			TimerConfiguration = ((!SetConfiguration) ? null : Configuration?.Serialize())
		};
		return action;
	}

	public override void Deserialize(Pro.SerializationInterop.RVProtoData.Action data, ApplicationData? applicationData, string containerId)
	{
		base.Deserialize(data, applicationData, containerId);
		if (data?.Timer != null)
		{
			Pro.SerializationInterop.RVProtoData.Action.Types.TimerType timer = data.Timer;
			_actualTimerActionType = timer.ActionType.ToTimerActionType();
			_timerActionType = ((_actualTimerActionType != 0 && _actualTimerActionType != TimerActionType.ResetAndStart) ? ((_actualTimerActionType == TimerActionType.Stop || _actualTimerActionType == TimerActionType.ResetAndStop) ? TimerActionType.Stop : _actualTimerActionType) : TimerActionType.Start);
			SetConfiguration = _actualTimerActionType == TimerActionType.ResetAndStart || _actualTimerActionType == TimerActionType.ResetAndStop;
			TimerID = timer.TimerIdentification.ParameterUuid.ToGuid();
			TimerName = timer.TimerIdentification.ParameterName;
			TimerBase timerBase = TimerFactory.CreateTimerSource(timer.TimerConfiguration?.TimerTypeCase);
			if (timerBase != null)
			{
				Configuration = timerBase;
			}
			if (timer.TimerConfiguration != null)
			{
				Configuration?.Deserialize(timer.TimerConfiguration);
			}
		}
	}

	protected override void OnUndoStackChanged(UndoStack undoStack)
	{
		base.OnUndoStackChanged(undoStack);
		if (Configuration != null)
		{
			Configuration.UndoStack = undoStack;
		}
	}

	public void ChangeTimerType(TimerType timerType)
	{
		Configuration = timerType switch
		{
			TimerType.Countdown => new CountdownTimer(), 
			TimerType.ElapsedTime => new ElapsedTime(), 
			TimerType.CountdownToTime => new CountdownToTime(), 
			_ => new CountdownTimer(), 
		};
	}
}
