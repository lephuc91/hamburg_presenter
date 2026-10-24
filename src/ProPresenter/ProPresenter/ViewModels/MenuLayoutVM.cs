using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Nullability;
using Pro.UI.Components;
using ProPresenter.Controller;
using ProPresenter.DO;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Capture;
using ProPresenter.DO.ClearGroups;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Export;
using ProPresenter.DO.InputActionMap;
using ProPresenter.DO.Looks;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Registration.State;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Timer;
using ProPresenter.UI;
using ProPresenter.UI.Commands;
using ProPresenter.UI.Export;
using ProPresenter.UI.PresentationView;
using ProPresenter.UI.ViewModels;
using ProPresenter.UI.ViewModels.Preview;
using ProPresenter.ViewModels.Presentation;
using ProPresenter.ViewModels.UserFeedback;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.ViewModels;

public class MenuLayoutVM : LinkedNotifyPropertyChangedBase, IMenuLayoutVM, INotifyPropertyChanged
{
	private readonly ICoreManager _manager;

	private readonly ITriggering _service;

	private readonly IApp _app;

	private readonly ICaptureService _captureService;

	private readonly IRegistrationStateProvider _registrationStateProvider;

	private readonly IInputActions _inputActions;

	private UndoStack? _activeUndoStack;

	private InlineType _activeInlineType;

	private bool _isCalendarVisible;

	private bool _isRecording;

	private bool _hiddenOptionsVisible;

	public bool ShowFeedbackMenu => false;

	public CommandTargetType EditorTextCommandTarget => ActiveInlineType switch
	{
		InlineType.TemplateEditor => CommandTargetType.TemplateTextInspector, 
		InlineType.MaskEditor => CommandTargetType.MaskTextInspector, 
		InlineType.PropsEditor => CommandTargetType.PropTextInspector, 
		_ => CommandTargetType.SlideTextInspector, 
	};

	public CommandTargetType EditorCommandTarget => ActiveInlineType switch
	{
		InlineType.TemplateEditor => CommandTargetType.TemplateEditor, 
		InlineType.MaskEditor => CommandTargetType.MaskEditor, 
		InlineType.PropsEditor => CommandTargetType.PropEditor, 
		_ => CommandTargetType.SlideEditor, 
	};

	public bool IsOutputVisible => _manager.AudienceEnable;

	public bool IsRulerVisible
	{
		get
		{
			return EditorPreferences.Settings.ShowRuler;
		}
		set
		{
			EditorPreferences.Settings.ShowRuler = value;
		}
	}

	public bool ShowTemplateGuides
	{
		get
		{
			return EditorPreferences.Settings.ShowTemplateGuidelines;
		}
		set
		{
			EditorPreferences.Settings.ShowTemplateGuidelines = value;
		}
	}

	public bool ShowSlidesGuides
	{
		get
		{
			return EditorPreferences.Settings.ShowSlideGuidelines;
		}
		set
		{
			EditorPreferences.Settings.ShowSlideGuidelines = value;
		}
	}

	public bool IsScaleToFitActive
	{
		get
		{
			return EditorPreferences.Settings.ScaleToFit;
		}
		set
		{
			EditorPreferences.Settings.ScaleToFit = value;
		}
	}

	public bool IsRegistered => _registrationStateProvider.Registration.ProPresenter.IsRegistered;

	public InlineType ActiveInlineType
	{
		get
		{
			return _activeInlineType;
		}
		set
		{
			SetValue("ActiveInlineType", ref _activeInlineType, value, (Action<InlineType, InlineType>?)delegate
			{
				OnPropertyChanged("IsEditorMenuVisible");
				OnPropertyChanged("IsReflowMenuVisible");
				OnPropertyChanged("EditorTextCommandTarget");
				OnPropertyChanged("EditorCommandTarget");
			}, (Predicate<InlineType>?)null, referenceComparison: false);
		}
	}

	public bool IsEditorMenuVisible => ActiveInlineType.IsAnyOf(InlineType.SlideEditor, InlineType.TemplateEditor, InlineType.MaskEditor, InlineType.StageEditor, InlineType.PropsEditor, InlineType.CCLITemplateEditor);

	public bool IsReflowMenuVisible => ActiveInlineType == InlineType.Reflow;

	public IEnumerable<ScreenArrangementBase> Screens => _manager.OutputConfiguration.AudienceArrangementScreens.Concat(_manager.OutputConfiguration.StageArrangementScreens);

	public IAudienceLookCollection AudienceLooks => _manager.OutputConfiguration.AudienceLooks;

	public LiveAudienceLook LiveAudienceLook => _manager.OutputConfiguration.LiveLook;

	public bool AudienceEnable
	{
		get
		{
			return _manager.AudienceEnable;
		}
		set
		{
			if (value)
			{
				_manager.ShowAudienceScreens();
			}
			else
			{
				_manager.HideAudienceScreens();
			}
		}
	}

	public bool StageEnable
	{
		get
		{
			return _manager.StageEnable;
		}
		set
		{
			if (value)
			{
				_manager.ShowStageScreens();
			}
			else
			{
				_manager.HideStageScreens();
			}
		}
	}

	public IEnumerable<SlideCue> StageLayouts => DataVault.StagePresentation.ArrangementGroups.SelectMany((CueGroup g) => g.Cues).ToArray();

	public ImageSource? LogoImageSource => _manager.Logo?.VisualMedia?.Drawing.PreviewImage;

	public TimerCollection Timers => DataVault.TimerDocument.Timers;

	public bool SlideOnStageDisplayOnly => _manager.SlideOnStageDisplayOnly;

	public UndoStack? ActiveUndoStack
	{
		get
		{
			return _activeUndoStack;
		}
		set
		{
			SetValue("ActiveUndoStack", ref _activeUndoStack, value);
		}
	}

	public bool CalendarEnabled => DataVault.Calendar.IsActive;

	public bool IsCalendarVisible
	{
		get
		{
			return _isCalendarVisible;
		}
		set
		{
			SetValue("IsCalendarVisible", ref _isCalendarVisible, value);
		}
	}

	public AudienceScreenArrangementCollection AudienceScreens
	{
		get
		{
			AudienceScreenArrangementCollection? audienceScreenArrangementCollection = OutputVault.AudienceScreenArrangementCollection;
			audienceScreenArrangementCollection.ThrowWhenNull("value");
			return audienceScreenArrangementCollection;
		}
	}

	public StageScreenArrangementCollection StageScreens
	{
		get
		{
			StageScreenArrangementCollection? stageScreenArrangementCollection = OutputVault.StageScreenArrangementCollection;
			stageScreenArrangementCollection.ThrowWhenNull("screens");
			return stageScreenArrangementCollection;
		}
	}

	public bool IsRecording
	{
		get
		{
			return _isRecording;
		}
		set
		{
			SetValue("IsRecording", ref _isRecording, value);
		}
	}

	public string StartStopButtonLabel => _captureService.StartStopButtonLabel;

	public bool ShowAdvancedOnScreenStats => _app.ShowAdvancedOnScreenStats;

	public bool HiddenOptionsVisible
	{
		get
		{
			return _hiddenOptionsVisible;
		}
		set
		{
			SetValue("HiddenOptionsVisible", ref _hiddenOptionsVisible, value);
		}
	}

	public ClearGroupCollection ClearGroups => DataVault.ClearGroups;

	public ICommand UndoCommand => new RelayCommand(delegate
	{
		ActiveUndoStack?.Undo();
	});

	public ICommand RedoCommand => new RelayCommand(delegate
	{
		ActiveUndoStack?.Redo();
	});

	public ICommand<IOutputScreenVM> SetScreenPreviewCommand => new RelayCommand<IOutputScreenVM>(OnSetScreenPreviewCommand, (IOutputScreenVM c) => c != null);

	public ICommand<ClearGroup> TriggerClearGroupCommand => new RelayCommand<ClearGroup>(_service.TriggerClearGroup, (ClearGroup c) => c != null);

	public ICommand<SlideCue> EditSelectedLayoutCommand => new RelayCommand<SlideCue>(delegate(SlideCue slideCue)
	{
		_inputActions.ScreensMenu.EditSelectedLayout.BindCommand.Execute(new EditStageLayoutCommandParameter(slideCue.SlideAction?.Slide as CustomSlide, ShowSource.ApplicationMenu));
	});

	public IAttachmentUploadVM AttachmentUploadVM { get; }

	public PresentationViewType PresentationViewType => _app.PresentationPanelViewType.ToPresentationViewType();

	public MenuLayoutVM(ICoreManager manager, ICaptureService captureService, InlineType activeInlineType, IRegistrationStateProvider registrationStateProvider, IApp app, IAttachmentUploadVM attachmentUploadVM, ITriggeringFactory triggeringFactory, IInputActions inputActions)
	{
		MenuLayoutVM menuLayoutVM = this;
		_manager = manager;
		_service = triggeringFactory.Create();
		_activeInlineType = activeInlineType;
		_app = app;
		_captureService = captureService;
		_registrationStateProvider = registrationStateProvider;
		AttachmentUploadVM = attachmentUploadVM;
		LinkProperties("SlideOnStageDisplayOnly", "SlideOnStageDisplayOnly");
		LinkProperties("AudienceEnable", new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "IsOutputVisible", "AudienceEnable" }));
		LinkProperties("StageEnable", "StageEnable");
		LinkProperties("Logo", "LogoImageSource");
		LinkProperties("ShowRuler", "IsRulerVisible");
		LinkProperties("ShowTemplateGuidelines", "ShowTemplateGuides");
		LinkProperties("ShowSlideGuidelines", "ShowSlidesGuides");
		LinkProperties("ScaleToFit", "IsScaleToFitActive");
		LinkProperties("IsActive", "CalendarEnabled");
		LinkProperties("ShowAdvancedOnScreenStats", "ShowAdvancedOnScreenStats");
		LinkProperties("Registration", "IsRegistered");
		LinkProperties("PresentationPanelViewType", "PresentationViewType");
		_manager.PropertyChanged += base.RaiseLinkedValues;
		EditorPreferences.Settings.PropertyChanged += base.RaiseLinkedValues;
		if (DataVault.Calendar != null)
		{
			DataVault.Calendar.PropertyChanged += base.RaiseLinkedValues;
		}
		_app.PropertyChanged += base.RaiseLinkedValues;
		registrationStateProvider.PropertyChanged += base.RaiseLinkedValues;
		_manager.ActivePlaylistItemChanged += OnActivePlaylistItemChanged;
		_inputActions = inputActions;
		ExportPrompt.SetExportStarted(OnExportStarted);
		if (DataVault.StagePresentation != null)
		{
			DataVault.StagePresentation.ArrangementGroups.CollectionChanged += ArrangementGroups_CollectionChanged;
			DataVault.StagePresentation.ArrangementGroups.OfType<CueGroup>().ForEach(delegate(CueGroup g)
			{
				g.Cues.CollectionChanged += menuLayoutVM.Cues_CollectionChanged;
			});
		}
		LinkAction("StartStopButtonLabel", delegate
		{
			ScreensMenuGroup screensMenu = inputActions.ScreensMenu;
			(screensMenu.StartCapture.BindCommand as RelayCommand)?.NotifyCanExecuteChanged();
			(screensMenu.StartCapture.BindCommand as RelayCommand)?.NotifyCanExecuteChanged();
			menuLayoutVM.OnPropertyChanged("StartStopButtonLabel");
		});
		_captureService.ScreenCaptureStatusChanged += Coremanager_OutputRecordingStatusChanged;
		_captureService.PropertyChanged += base.RaiseLinkedValues;
	}

	private void Coremanager_OutputRecordingStatusChanged(object? sender, ScreenCaptureStatusEventArgs e)
	{
		ProScreenCaptureStatus proScreenCaptureStatus = e?.ScreenCaptureStatus;
		if (proScreenCaptureStatus != null)
		{
			IsRecording = proScreenCaptureStatus.State != ProScreenCaptureState.Inactive;
		}
	}

	private void OnActivePlaylistItemChanged(ProPresenterCue? oldItem, ProPresenterCue? newItem)
	{
		if (newItem != null)
		{
			newItem.PropertyChanged += base.RaiseLinkedValues;
		}
		if (oldItem != null)
		{
			oldItem.PropertyChanged -= base.RaiseLinkedValues;
		}
	}

	private void OnExportStarted(IExportProcess process)
	{
		ExportProgressWindow exportProgressWindow = new ExportProgressWindow
		{
			ExportProcess = process
		};
		process.ExportComplete += exportProgressWindow.Close;
		exportProgressWindow.ShowDialog();
	}

	private void OnSetScreenPreviewCommand(IOutputScreenVM selectedScreen)
	{
		Guid id = selectedScreen.Id;
		_manager.SetPreviewScreenID(id);
		_app.SelectedPreviewScreenID = id;
	}

	private void ArrangementGroups_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.OfType<CueGroup>().ForEach(delegate(CueGroup g)
		{
			g.Cues.CollectionChanged -= Cues_CollectionChanged;
		});
		e.NewItems?.OfType<CueGroup>().ForEach(delegate(CueGroup g)
		{
			g.Cues.CollectionChanged += Cues_CollectionChanged;
		});
		OnPropertyChanged("StageLayouts");
	}

	private void Cues_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		OnPropertyChanged("StageLayouts");
	}
}
