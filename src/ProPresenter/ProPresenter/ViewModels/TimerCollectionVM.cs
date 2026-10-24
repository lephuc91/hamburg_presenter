using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Strings;
using Pro.Common.Time;
using Pro.Localization;
using Pro.UI.Components;
using ProPresenter.Controller;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Analytics;
using ProPresenter.DO.Analytics.Events.Timer;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Timer;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.ViewModels;

public class TimerCollectionVM : NotifyPropertyChangedBase, ITimerCollectionVM, INotifyPropertyChanged
{
	private readonly ICoreManager _manager;

	private readonly ITriggering _service;

	private readonly DragDropPairedCollection<TimerData, ITimerVM> _timers;

	private ITimerCollection TimerCollection { get; }

	public INotifyEnumerableChanged<ITimerVM> Timers => _timers;

	public ICommand AddTimerItemCommand => new RelayCommand(OnAddTimerItemCommand);

	public ICommand<Guid> RemoveTimerCommand => new RelayCommand<Guid>(OnRemoveTimerCommand);

	public ICommand<Guid> StartCommand => new RelayCommand<Guid>(OnStartCommand);

	public ICommand<Guid> StopCommand => new RelayCommand<Guid>(OnStopCommand);

	public ICommand<Guid> ResetCommand => new RelayCommand<Guid>(OnResetCommand);

	public ICommand StartAllCommand => new RelayCommand(OnStartAllCommand);

	public ICommand StopAllCommand => new RelayCommand(OnStopAllCommand);

	public ICommand ResetAllCommand => new RelayCommand(OnResetAllCommand);

	public ICommand GotFocusCommand => new RelayCommand(delegate
	{
		this.StackChanged?.Invoke(TimerCollection.UndoStack);
	});

	public event Action<UndoStack?>? StackChanged;

	public TimerCollectionVM(ICoreManager manager, IApp app, ITriggeringFactory triggeringFactory, ITimerCollection timerCollection)
	{
		TimerCollectionVM @object = this;
		_manager = manager;
		_service = triggeringFactory.Create();
		TimerCollection = timerCollection;
		_timers = new DragDropPairedCollection<TimerData, ITimerVM>(TimerCollection, createVM);
		TimerCollection.CollectionChanged += OnTimersCollectionChanged;
		TimerCollection.ForEach(delegate(TimerData i)
		{
			i.PropertyChanged += @object.TimerPropertyChanged;
		});
		ITimerVM createVM(TimerData timer)
		{
			return timer.Source.TimerType switch
			{
				TimerType.Countdown => new CountdownTimerVM(timer, manager.NetworkCommandTrigger, app), 
				TimerType.CountdownToTime => new CountdownToTimeTimerVM(timer, manager.NetworkCommandTrigger, app), 
				TimerType.ElapsedTime => new ElapsedTimerVM(timer, manager.NetworkCommandTrigger, app), 
				_ => throw new NotSupportedException(), 
			};
		}
	}

	private void OnTimersCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		TimerData[] oldTimerDatas = e.OldItems?.Cast<TimerData>().ToArray();
		oldTimerDatas?.ForEach(delegate(TimerData i)
		{
			i.PropertyChanged -= TimerPropertyChanged;
		});
		e.NewItems?.Cast<TimerData>().ForEach(delegate(TimerData i)
		{
			i.PropertyChanged += TimerPropertyChanged;
			TimerData[] array = oldTimerDatas;
			if (array == null || !array.Contains(i))
			{
				Timers.First((ITimerVM x) => x.ID == i.ID).IsExpanded = true;
			}
		});
		_timers.Refresh();
	}

	private void TimerPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "Source" && sender is TimerData item)
		{
			_timers.Refresh(item);
		}
	}

	private void OnAddTimerItemCommand()
	{
		string name = LocalizedStrings.Get("TIMERS_WINDOW_NEW_TIMER_name").DuplicateName(TimerCollection, (TimerData t) => t.Name);
		TimerCollection.AddNewCountdownTimer(name, TimeSlice.Zero);
		TimersCreateEvent.Publish();
	}

	private void OnRemoveTimerCommand(Guid id)
	{
		TimerData timerData = FindTimer(id);
		if (timerData != null)
		{
			_manager.ClearTimer(timerData);
			TimerCollection.RemoveTimer(timerData);
			TimersDeleteEvent.Publish();
		}
	}

	private void OnStartAllCommand()
	{
		TimerCollection.ForEach(Start);
	}

	private void OnStopAllCommand()
	{
		TimerCollection.ForEach(Stop);
	}

	private void OnResetAllCommand()
	{
		TimerCollection.ForEach(Reset);
	}

	private void OnStartCommand(Guid id)
	{
		TimerData timerData = FindTimer(id);
		if (timerData != null)
		{
			Start(timerData);
		}
	}

	private void OnStopCommand(Guid id)
	{
		TimerData timerData = FindTimer(id);
		if (timerData != null)
		{
			Stop(timerData);
		}
	}

	private void OnResetCommand(Guid id)
	{
		TimerData timerData = FindTimer(id);
		if (timerData != null)
		{
			Reset(timerData);
		}
	}

	private void Start(TimerData timer)
	{
		ChangeTimerState(timer, TimerActionType.Start);
	}

	private void Stop(TimerData timer)
	{
		ChangeTimerState(timer, TimerActionType.Stop);
	}

	private void Reset(TimerData timer)
	{
		ChangeTimerState(timer, TimerActionType.Reset);
	}

	private void ChangeTimerState(TimerData timerData, TimerActionType state)
	{
		_service.TriggerTimerAction(timerData, state, null);
		TimersStateEvent.Publish(state.ToEventState());
	}

	private TimerData? FindTimer(Guid id)
	{
		return TimerCollection.FirstOrDefault((TimerData t) => t.ID == id);
	}
}
