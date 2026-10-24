using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Mathematics;
using Pro.Common.MessageService;
using Pro.Common.Time;
using Pro.DO.Analytics;
using Pro.DO.Label;
using Pro.DO.Transitions;
using Pro.DO.Triggering;
using Pro.Localization;
using Pro.UI.Components;
using Pro.UI.DialogService;
using ProPresenter.Controller.Outputs;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Analytics;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Hotkey;
using ProPresenter.DO.Import;
using ProPresenter.DO.Label;
using ProPresenter.DO.Media;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Slide;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Themes;
using ProPresenter.UI.Hotkeys;
using ProPresenter.UI.PresentationView.GoToNext;
using ProPresenter.UI.Thumbnails;
using ProPresenter.UI.Transitions;
using ProPresenter.UI.ViewModels;
using ProPresenter.ViewModels.ActionsMenu;

namespace ProPresenter.ViewModels;

public class CustomSlideMenuVM : NotifyPropertyChangedBase, ICustomSlideMenuVM, INotifyPropertyChanged, IAddActionInteractor
{
	private readonly ssAPIOutput _outputController;

	private ArrangedCue? _selectedSlide;

	private ProPresenterCue? _selectedCue;

	private bool _applyTemplateMediaAction;

	private readonly LabelEditorVM _labelEditorVM = new LabelEditorVM();

	private readonly PresentationMediaStrategy _mediaStrategy;

	public FrameworkElement? PlacementTarget { get; set; }

	public IActionsMenuVM ActionsMenuVM { get; }

	public bool HasGotoNextAction => SelectedSlides.Any((ArrangedCue s) => s.Source.GotoNext != null);

	public bool CanUngroup
	{
		get
		{
			if (IsMasterArrangement)
			{
				if (!MultipleGroupsPresent)
				{
					return OnlyGroupIsValid;
				}
				return true;
			}
			return false;
		}
	}

	private bool IsMasterArrangement => SelectedDocumentCue?.DocumentAction?.ActiveArrangement?.IsMaster == true;

	private bool MultipleGroupsPresent
	{
		get
		{
			IPresentation? selectedPresentation = SelectedPresentation;
			if (selectedPresentation == null)
			{
				return false;
			}
			return selectedPresentation.ArrangementGroups.Count > 1;
		}
	}

	private bool OnlyGroupIsValid => !string.IsNullOrEmpty(SelectedPresentation?.ArrangementGroups.FirstOrDefault()?.Label.Text);

	public bool IsGroupingEnabled => SelectedSlides.Count == 1;

	public string ToggleEnabledHeader
	{
		get
		{
			ArrangedCue? selectedSlide = SelectedSlide;
			return LocalizedStrings.Get((selectedSlide != null && !selectedSlide.Source.IsEnabled) ? "PRESENTATION_CONTEXT_MENU_ENABLE_title" : "PRESENTATION_CONTEXT_MENU_DISABLE_title");
		}
	}

	private IEnumerable<SlideCue> SelectedSlideCues => SelectedSlides.Select((ArrangedCue s) => s.Source).Distinct();

	public ArrangedCue? SelectedSlide
	{
		get
		{
			return _selectedSlide;
		}
		set
		{
			_selectedSlide = value;
			ActionsMenuVM.SelectedItem = value?.Source;
			_mediaStrategy.SelectedPresentation = SelectedPresentation;
			NotifyPropertyChanges();
		}
	}

	public ObservableCollection<ArrangedCue> SelectedSlides { get; }

	public ProPresenterCue? SelectedCue
	{
		get
		{
			return _selectedCue;
		}
		set
		{
			SetValue("SelectedCue", ref _selectedCue, value, null, false, "IsGroupingEnabled", "CanUngroup");
		}
	}

	private IDocumentCue? SelectedDocumentCue => SelectedCue as IDocumentCue;

	private IPresentation? SelectedPresentation => _selectedSlide?.Source.ParentPresentation;

	public TransitionHandler TransitionHandler { get; }

	public TransitionParameters? SelectedTransition
	{
		get
		{
			return SelectedSlide?.Source.SlideAction?.Slide.SelectedTransition;
		}
		set
		{
			if (SelectedTransition != value)
			{
				SelectedSlide?.Source.UndoStack?.BeginCommit(UndoActionTypes.ChangeSlideTransition.ToAction());
				SelectedSlides.Select((ArrangedCue s) => s.Source.SlideAction?.Slide).Distinct().NonNull()
					.ForEach(delegate(SlideBase s)
					{
						s.SelectedTransition = value;
					});
				OnPropertyChanged("SelectedTransition");
				SelectedSlide?.Source.UndoStack?.EndCommit(null, delegate
				{
					OnPropertyChanged("SelectedTransition");
				}, autoFinalize: true);
			}
		}
	}

	public ITemplateVM? TemplateVM { get; set; }

	public IQuickEditVM? QuickEditVM { get; set; }

	public IEnumerable<ActionLabel> SlideLabels => DataVault.SlideLabels;

	public IEnumerable<GroupLabel> GroupLabels => DataVault.GroupLabels;

	public ICommand EditSlideCommand => new RelayCommand(EditSlideCue, CanEditSlide);

	public ICommand ShowQuickEditCommand => new RelayCommand(OnShowQuickEditCommand, CanQuickEdit);

	public ICommand ToggleEnabledCommand => new RelayCommand(ToggleEnabled);

	public ICommand OpenTranstionsCommand => new RelayCommand(OnOpenTranstionsCommand);

	public ICommand ShowHotkeyDialogCommand => new RelayCommand(OnShowHotkeyDialogCommand);

	public ICommand EditGoToNextCommand => new RelayCommand(OnEditGoToNextCommand);

	public ICommand<ActionLabel> AssignSlideLabelCommand => new RelayCommand<ActionLabel>(OnAssignSlideLabelCommand);

	public ICommand NewSlideLabelCommand => new RelayCommand(OnNewSlideLabelCommand);

	public ICommand<GroupLabel> AssignGroupLabelCommand => new RelayCommand<GroupLabel>(OnAssignGroupLabelCommand);

	public ICommand UngroupCommand => new RelayCommand(OnUngroupCommand);

	public ICommand NewGroupLabelCommand => new RelayCommand(OnNewGroupLabelCommand);

	public ICommand<TemplateSlide> SelectTemplateCommand => new RelayCommand<TemplateSlide>(SelectTemplateCommandExecuted);

	public ICommand RemoveGotoNextTimerCommand => new RelayCommand(OnRemoveGotoNextTimerCommand, delegate
	{
		ObservableCollection<ArrangedCue> selectedSlides = SelectedSlides;
		return selectedSlides != null && selectedSlides.Count > 0;
	});

	public event Action<ArrangedCue?, IPresentation?>? EditCue;

	public event Action<FrameworkElement?, IAction?, IActionRepository?, IEnumerable<IActionRepository>>? ShowActionDialog;

	public CustomSlideMenuVM(ssAPIOutput outputController, ObservableCollection<ArrangedCue> selectedSlides, IMessageService messageService, IApp app, IImportProcessFactory importProcessFactory, IActionsMenuVMFactory actionsMenuVMFactory, IMediaFactory mediaFactory, ITransitionDescriptionCollection transitionDescriptions)
	{
		_mediaStrategy = new PresentationMediaStrategy(app, importProcessFactory, mediaFactory, transitionDescriptions, selectedSlides);
		ActionsMenuVM = actionsMenuVMFactory.Create(this, _mediaStrategy);
		messageService?.SubscribeToMessage<ThemePickerSettingsUpdatedMessage>(HandleSettingsUpdated);
		ActionsMenuVM.ShowActionDialog += delegate(IAction? a, IActionRepository? i, IEnumerable<IActionRepository> c)
		{
			this.ShowActionDialog?.Invoke(PlacementTarget, a, i, c);
		};
		_outputController = outputController;
		SelectedSlides = selectedSlides;
		SelectedSlides.CollectionChanged += delegate
		{
			ActionsMenuVM.Select(SelectedSlides.Select((ArrangedCue i) => i.Source).ToArray());
		};
		TransitionHandler = new TransitionHandler(DataVault.Transitions);
		TransitionHandler.TransitionFinalized += TransitionFinalized;
	}

	private void HandleSettingsUpdated(IMessage message)
	{
		if (message is ThemePickerSettingsUpdatedMessage themePickerSettingsUpdatedMessage && themePickerSettingsUpdatedMessage.Model.ContextualGroup == ThemePickerGroup.Presentation)
		{
			_applyTemplateMediaAction = themePickerSettingsUpdatedMessage.Model.MediaActionEnabled;
		}
	}

	private void NotifyPropertyChanges()
	{
		new string[6] { "SelectedSlide", "CanUngroup", "IsGroupingEnabled", "ToggleEnabledHeader", "SelectedTransition", "HasGotoNextAction" }.ForEach(base.OnPropertyChanged);
	}

	private void TransitionFinalized(TransitionParameters? newTransition)
	{
		SelectedTransition = newTransition;
	}

	private void OnAssignSlideLabelCommand(ActionLabel label)
	{
		if (SelectedPresentation != null)
		{
			SelectedPresentation.AssignSlideLabel(label, SelectedSlideCues);
			EventPublisher.Publish(new SlideLabelChangedEvent(SelectedSlideCues.Count(), SlideLabelChangeSource.ContextMenu));
		}
	}

	private void OnNewSlideLabelCommand()
	{
		_labelEditorVM.ShowPopover(PlacementTarget, new SlideLabelInteractor(new MultiTargetSlideLabelContext(SelectedSlides, SelectedSlide), DataVault.SlideLabels, new MultiLabelPrompt()));
	}

	private void OnAssignGroupLabelCommand(GroupLabel label)
	{
		SelectedPresentation?.AssignGroupLabel(label, SelectedSlides);
	}

	private void OnUngroupCommand()
	{
		SelectedPresentation?.UngroupCues(SelectedSlides, SelectedDocumentCue?.DocumentAction?.ActiveArrangement);
	}

	private void OnNewGroupLabelCommand()
	{
		_labelEditorVM.ShowPopover(PlacementTarget, new GroupLabelInteractor(new GroupLabelContext(SelectedSlides, SelectedSlide)));
	}

	private void OnShowQuickEditCommand()
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		if (PlacementTarget is Thumbnail thumbnail)
		{
			QuickEditVM?.Edit(thumbnail.Source as ArrangedCue, (Vector2<double>)thumbnail.PointToScreen(Vector2<double>.Zero), thumbnail.ContainerSize, (Vector2<double>)thumbnail.RenderSize);
		}
	}

	private void ToggleEnabled()
	{
		IPresentation? selectedPresentation = SelectedPresentation;
		if (selectedPresentation != null)
		{
			ObservableCollection<ArrangedCue> selectedSlides = SelectedSlides;
			ArrangedCue? selectedSlide = SelectedSlide;
			selectedPresentation.ToggleCues(selectedSlides, selectedSlide == null || !selectedSlide.IsEnabled);
		}
	}

	private void SelectTemplateCommandExecuted(TemplateSlide template)
	{
		(SelectedPresentation as CustomPresentation)?.ApplyTemplateToSlides(template, SelectedSlideCues, _applyTemplateMediaAction);
	}

	private void OnOpenTranstionsCommand()
	{
		new SelectorPopup
		{
			OutputController = _outputController,
			SelectedTransition = SelectedSlide?.Source.SlideAction?.Slide.SelectedTransition,
			TransitionHandler = TransitionHandler,
			PlacementTarget = PlacementTarget,
			IsGlobalAllowed = true,
			StaysOpen = false,
			IsOpen = true
		};
	}

	private void OnShowHotkeyDialogCommand()
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		HotkeyDialog hotkeyDialog = new HotkeyDialog
		{
			Key = (SelectedSlide?.Source.Hotkey?.Key).GetValueOrDefault()
		};
		HotkeyDialogButtons? hotkeyDialogButtons = MessageDialogService.ShowDialog(string.Empty, (DependencyObject)(object)hotkeyDialog, HotkeyDialogButtons.OK | HotkeyDialogButtons.CLEAR | HotkeyDialogButtons.CANCEL, HotkeyDialogButtons.OK, null, new HotkeyDialogButtons[3]
		{
			HotkeyDialogButtons.CANCEL,
			HotkeyDialogButtons.CLEAR,
			HotkeyDialogButtons.OK
		});
		if (hotkeyDialogButtons == HotkeyDialogButtons.OK)
		{
			HotkeyHelper.AssignHotkey(SelectedSlide?.Source, new SlideHotkey(hotkeyDialog.Key));
		}
		else if (hotkeyDialogButtons == HotkeyDialogButtons.CLEAR)
		{
			HotkeyHelper.AssignHotkey(SelectedSlide?.Source, new SlideHotkey((Key)0));
		}
	}

	private void EditSlideCue()
	{
		this.EditCue?.Invoke(SelectedSlide, SelectedPresentation);
	}

	private bool CanEditSlide()
	{
		return SelectedSlides.Count == 1;
	}

	private bool CanQuickEdit()
	{
		if (PlacementTarget is Thumbnail)
		{
			return QuickEditVM?.CanEdit(SelectedSlide?.Source.SlideAction?.Slide as CustomSlide) ?? false;
		}
		return false;
	}

	private void OnEditGoToNextCommand()
	{
		IEnumerable<ArrangedCue> enumerable = SelectedPresentation?.ActiveArrangement?.ArrangedCues;
		object obj = enumerable;
		if (obj == null)
		{
			enumerable = SelectedPresentation?.DefaultArrangement.ArrangedCues;
			obj = enumerable ?? Enumerable.Empty<ArrangedCue>();
		}
		IEnumerable<ArrangedCue> currentCues = (IEnumerable<ArrangedCue>)obj;
		ArrangedCue[] array = SelectedSlides.OrderBy((ArrangedCue s) => currentCues?.IndexOf(s)).ToArray();
		IEnumerable<SlideCue> targetCues = array.Select((ArrangedCue s) => s.Source);
		SlideTimerCueDialog slideTimerCueDialog = new SlideTimerCueDialog
		{
			Duration = (SelectedSlide?.Source.GotoNext?.Time.TotalSeconds ?? 5.0),
			LoopToBeginning = (SelectedSlide?.Source.GotoNext?.LoopToBeginning == true),
			LoopToBeginningAvailable = (currentCues.IndexOf(array[^1]) - currentCues.IndexOf(array[0]) + 1 == array.Count())
		};
		string header = LocalizedStrings.Get("ACTION_PALETTE_GO_TO_NEXT_TIMER_WINDOW_title");
		if (targetCues.Any((SlideCue c) => c.GotoNext != null))
		{
			GTNTDialogButtons? gTNTDialogButtons = MessageDialogService.ShowDialog(header, (DependencyObject)(object)slideTimerCueDialog, GTNTDialogButtons.REMOVE | GTNTDialogButtons.DONE | GTNTDialogButtons.CANCEL, GTNTDialogButtons.DONE);
			if (gTNTDialogButtons == GTNTDialogButtons.DONE)
			{
				addGTNT(slideTimerCueDialog);
			}
			else if (gTNTDialogButtons == GTNTDialogButtons.REMOVE)
			{
				targetCues.ForEach(delegate(SlideCue c)
				{
					c.GotoNext = null;
				});
			}
		}
		else if (MessageDialogService.ShowSimpleContent(header, (DependencyObject)(object)slideTimerCueDialog))
		{
			addGTNT(slideTimerCueDialog);
		}
		void addGTNT(SlideTimerCueDialog dialog)
		{
			SelectedPresentation?.AddGoToNextTimer(targetCues, TimeSlice.FromSeconds(dialog.Duration), dialog.LoopToBeginning);
		}
	}

	private void OnRemoveGotoNextTimerCommand()
	{
		foreach (ArrangedCue selectedSlide in SelectedSlides)
		{
			selectedSlide.Source.GotoNext = null;
		}
		NotifyPropertyChanges();
	}

	public IAction? Execute(IAction? action)
	{
		if (action == null)
		{
			return action;
		}
		return SelectedPresentation?.AddSlideAction(SelectedSlideCues, action, cloneAction: true, SelectedSlide);
	}
}
