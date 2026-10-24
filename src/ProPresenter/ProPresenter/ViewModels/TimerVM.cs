using System;
using System.ComponentModel;
using Pro.Common.Components;
using Pro.Common.Time;
using Pro.DO.Analytics;
using Pro.DO.Triggering;
using ProPresenter.Controller.NetworkAPI.Transmit;
using ProPresenter.DO.Analytics;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Timer;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.ViewModels;

public abstract class TimerVM : LinkedNotifyPropertyChangedBase, ITimerVM, ITriggerable, INotifyPropertyChanged
{
	private bool _isExpanded;

	private readonly IApp _app;

	protected TimerData TimerData { get; }

	protected INetworkCommandTrigger LinkTrigger { get; }

	public Guid ID => TimerData.ID;

	public ITimerTypeSelectorVM TimerTypeSelectorVM { get; }

	public TimerType TimerType => TimerData.Source.TimerType;

	public TimerFormatData Format { get; }

	public string Name
	{
		get
		{
			return TimerData.Name;
		}
		set
		{
			if (TimerData.Name != value)
			{
				TimerData.Name = value;
				TimersEditEvent.Publish(EditField.Name);
				LinkTrigger?.OnConfigureTimer(TimerData);
			}
		}
	}

	public bool Overrun
	{
		get
		{
			return TimerData.Source.IsOverRunAllowed;
		}
		set
		{
			if (TimerData.Source.IsOverRunAllowed != value)
			{
				TimerData.Source.IsOverRunAllowed = value;
				TimersEditEvent.Publish(EditField.Overrun);
				LinkTrigger?.OnConfigureTimer(TimerData);
			}
		}
	}

	public TimeSlice StartTime
	{
		get
		{
			return TimerData.Source.StartTime;
		}
		set
		{
			if (TimerData.Source.StartTime != value)
			{
				TimerData.Source.StartTime = value;
				if (TimerData.Active.State == TimerState.Reset)
				{
					TimerData.Active.StartTime = value;
				}
				TimersEditEvent.Publish(EditField.Value);
				LinkTrigger?.OnConfigureTimer(TimerData);
			}
		}
	}

	public TimeSlice EndTime
	{
		get
		{
			return TimerData.Source.EndTime;
		}
		set
		{
			if (TimerData.Source.EndTime != value)
			{
				TimerData.Source.EndTime = value;
				if (TimerData.Active.State == TimerState.Reset)
				{
					TimerData.Active.EndTime = value;
				}
				TimersEditEvent.Publish(EditField.Value);
				LinkTrigger?.OnConfigureTimer(TimerData);
			}
		}
	}

	public virtual string RunningTime => TimeSliceHelper.TimeSliceToString(TimerData.Active.RunningTime);

	public TimerState State
	{
		get
		{
			return TimerData.Active.State;
		}
		set
		{
			TimerData.Active.State = value;
		}
	}

	public bool IsExpanded
	{
		get
		{
			return _isExpanded;
		}
		set
		{
			SetValue("IsExpanded", ref _isExpanded, value, OnIsExpandedChanged);
		}
	}

	protected TimerVM(TimerData timerData, INetworkCommandTrigger linkTrigger, IApp app)
	{
		TimerData = timerData;
		LinkTrigger = linkTrigger;
		_app = app;
		Format = new TimerFormatData();
		TimerTypeSelectorVM = new UtilityViewTimerTypeSelectorVM(timerData, linkTrigger);
		HookupLinkedProperties();
		UpdateIsExpanded();
	}

	private void HookupLinkedProperties()
	{
		LinkProperties("Name", "Name");
		LinkProperties("TimerType", "TimerType");
		LinkProperties("IsOverRunAllowed", "Overrun");
		LinkProperties("StartTime", "StartTime");
		LinkProperties("EndTime", "EndTime");
		LinkProperties("State", new string[2] { "State", "RunningTime" });
		LinkProperties("Source", "TimerType");
		TimerData.Active.PropertyChanged += base.RaiseLinkedValues;
		TimerData.Source.PropertyChanged += base.RaiseLinkedValues;
		TimerData.PropertyChanged += base.RaiseLinkedValues;
		TimerData.SourceChanged += OnTimerChanged;
		TimerData.ActiveChanged += OnTimerChanged;
	}

	private void OnTimerChanged(TimerBase oldValue, TimerBase newValue)
	{
		if (oldValue != null)
		{
			oldValue.PropertyChanged -= base.RaiseLinkedValues;
		}
		if (newValue != null)
		{
			newValue.PropertyChanged += base.RaiseLinkedValues;
		}
		OnPropertyChanged("Name");
		OnPropertyChanged("TimerType");
		OnPropertyChanged("Overrun");
		OnPropertyChanged("StartTime");
		OnPropertyChanged("EndTime");
		OnPropertyChanged("State");
		OnPropertyChanged("RunningTime");
	}

	private void UpdateIsExpanded()
	{
		if (_app.TimerViewStates.TryGetValue(TimerData.ID, out var value))
		{
			_isExpanded = value;
			OnPropertyChanged("IsExpanded");
		}
	}

	private void OnIsExpandedChanged(bool _, bool newValue)
	{
		_app.TimerViewStates[TimerData.ID] = newValue;
		EventPublisher.Publish(new TimersCollapsedEvent(newValue.ToCollapseState()));
	}
}
