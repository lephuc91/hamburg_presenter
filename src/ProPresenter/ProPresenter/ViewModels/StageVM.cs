using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Nullability;
using Pro.UI.Components;
using ProPresenter.Controller;
using ProPresenter.DO;
using ProPresenter.DO.Analytics;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Events;
using ProPresenter.DO.InputActionMap;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.UI.Commands;
using ProPresenter.UI.Stage;
using ProPresenter.UI.ViewModels;
using ProPresenter.UI.ViewModels.OutputConfiguration;

namespace ProPresenter.ViewModels;

public class StageVM : LinkedNotifyPropertyChangedBase, IStageVM, INotifyPropertyChanged, IApplicationEventHandler
{
	private readonly ICoreManager _manager;

	private readonly IApp _app;

	private readonly IInputActions _inputActions;

	private readonly ITriggering _service;

	private bool _messageShown;

	private ScreenArrangementBase? _selectedItem;

	private ScreenArrangementBase? _activeItem;

	public ScreenArrangementBase? SelectedItem
	{
		get
		{
			return _selectedItem;
		}
		set
		{
			SetValue("SelectedItem", ref _selectedItem, value);
		}
	}

	public ScreenArrangementBase? ActiveItem
	{
		get
		{
			return _activeItem;
		}
		set
		{
			SetValue("ActiveItem", ref _activeItem, value);
		}
	}

	public ObservableCollection<ScreenArrangementBase> SelectedItems { get; } = new ObservableCollection<ScreenArrangementBase>();

	public StageScreenArrangementCollection StageScreens { get; }

	public IEnumerable<SlideCue> StageLayouts => DataVault.StagePresentation.Layouts;

	public StageScreenLayoutMap ScreenLayoutMap => _manager.OutputConfiguration.StageScreenLayoutMap;

	public string StageMessage
	{
		get
		{
			return _app.StageMessage;
		}
		set
		{
			_app.StageMessage = value;
		}
	}

	public ICommand ShowMessageCommand => new RelayCommand(OnStageMessageSendCommand);

	public ICommand HideMessageCommand => new RelayCommand(OnStageMessageHideCommand);

	public ICommand<StageCueAssignmentParameter> ChangeLayoutCommand => new RelayCommand<StageCueAssignmentParameter>(OnChangeLayoutCommand);

	public ICommand ConfigureScreensCommand => new RelayCommand(OnConfigureScreensCommand);

	public ICommand<ScreenArrangementBase> EditLayoutsCommand => new RelayCommand<ScreenArrangementBase>(OnEditLayoutsCommand, (ScreenArrangementBase _) => StageScreens.Count > 0);

	public bool MessageShown
	{
		get
		{
			return _messageShown;
		}
		private set
		{
			SetValue("MessageShown", ref _messageShown, value);
		}
	}

	public IDeviceSelectorVM DeviceSelectorVM { get; }

	public ICommand DeleteStageScreenCommand => new RelayCommand(DeleteStageScreenCommandExecuted, () => SelectedItem != null);

	public StageVM(ICoreManager manager, StagePresentation stagePresentation, IApp app, IDeviceSelectorVM deviceSelectorVM, ITriggeringFactory triggeringFactory, IInputActions inputActions)
	{
		_manager = manager;
		DeviceSelectorVM = deviceSelectorVM;
		_inputActions = inputActions;
		_service = triggeringFactory.Create();
		StageScreens = _manager.OutputConfiguration.StageArrangementScreens;
		_app = app;
		stagePresentation.ArrangementGroups.DataModifed += delegate
		{
			if (StageLayouts.Any())
			{
				KeyValuePair<ScreenArrangementBase, SlideCue>[] array = ScreenLayoutMap.Where<KeyValuePair<ScreenArrangementBase, SlideCue>>((KeyValuePair<ScreenArrangementBase, SlideCue> kv) => !StageLayouts.Contains(kv.Value)).ToArray();
				foreach (KeyValuePair<ScreenArrangementBase, SlideCue> keyValuePair in array)
				{
					ScreenLayoutMap.AssignScreen(keyValuePair.Key, StageLayouts.First());
				}
				OnPropertyChanged("StageLayouts");
			}
		};
		StageScreens.CollectionChanged += delegate(object? s, NotifyCollectionChangedEventArgs e)
		{
			if (e.Action != NotifyCollectionChangedAction.Move)
			{
				e.OldItems?.Cast<ScreenArrangementBase>().ForEach(delegate(ScreenArrangementBase screen)
				{
					ScreenLayoutMap.RemoveEntry(screen);
				});
				e.NewItems?.Cast<ScreenArrangementBase>().ForEach(delegate(ScreenArrangementBase screen)
				{
					ScreenLayoutMap.AssignScreen(screen, StageLayouts.First());
				});
			}
		};
		LinkProperties("StageMessage", "StageMessage");
		_app.PropertyChanged += base.RaiseLinkedValues;
		ApplicationEventPublisher.AddHandler(this);
	}

	private void OnStageMessageSendCommand()
	{
		_service.SendStageMessage(StageMessage);
		StageMessageStateEvent.Publish(StageMessageStatus.Show);
	}

	private void OnStageMessageHideCommand()
	{
		_service.HideStageMessage();
		StageMessageStateEvent.Publish(StageMessageStatus.Clear);
	}

	private void OnChangeLayoutCommand(StageCueAssignmentParameter param)
	{
		param.StageCue.ThrowWhenNull("param.StageCue");
		ScreenLayoutMap.AssignScreen(param.ScreenArrangement, param.StageCue);
		StageChangeLayoutEvent.Publish();
	}

	private void OnConfigureScreensCommand()
	{
		_inputActions.ScreensMenu.ConfigureScreens.BindCommand.Execute(null);
		StageConfigureScreensEvent.Publish();
	}

	private void OnEditLayoutsCommand(ScreenArrangementBase? screenArrangement)
	{
		SlideCue value = null;
		if (screenArrangement != null)
		{
			ScreenLayoutMap.TryGetValue(screenArrangement, out value);
		}
		_inputActions.ScreensMenu.EditSelectedLayout.BindCommand.Execute(new EditStageLayoutCommandParameter(value?.SlideAction?.Slide as CustomSlide, ShowSource.LowerRight));
		StageEditLayoutsEvent.Publish();
	}

	public void Handle(IApplicationEvent @event)
	{
		if (@event is StageMessageState stageMessageState)
		{
			(MessageShown, _) = stageMessageState;
		}
		else if (@event is StageMessageStateRequest stageMessageStateRequest)
		{
			stageMessageStateRequest.Deconstruct(out Action<StageMessageState> Callback);
			Callback(new StageMessageState(MessageShown, StageMessage));
		}
	}

	private void DeleteStageScreenCommandExecuted()
	{
		SelectedItem.ThrowWhenNull("SelectedItem");
		StageScreens.RemoveScreen(SelectedItem);
	}
}
