using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Dispatcher;
using Pro.Common.Mathematics;
using Pro.Common.Nullability;
using Pro.DO;
using Pro.DO.Transitions;
using Pro.UI.Components;
using ProPresenter.Controller;
using ProPresenter.DO.Analytics;
using ProPresenter.DO.Cues;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Media;
using ProPresenter.DO.Props;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Slide.Custom.Elements.Fills;
using ProPresenter.DO.Slide.Custom.Elements.Shapes;
using ProPresenter.UI;
using ProPresenter.UI.PresentationView;
using ProPresenter.UI.Props;
using ProPresenter.UI.Transitions;
using ProPresenter.UI.ViewModels.Props;

namespace ProPresenter.ViewModels.Props;

public class PropGroupVM : LinkedNotifyPropertyChangedBase, IPropGroupVMInternal, IPropGroupVM, INotifyPropertyChanged
{
	private readonly IPropPrompts _propPrompts;

	private readonly IPropGroup _propGroup;

	private IPropCueVM? _selectedCue;

	private string _filterText = string.Empty;

	private readonly DragDropPairedCollection<IPropCue, IPropCueVM> _props;

	private readonly FilteredObservableCollection<IPropCueVM> _filteredProps;

	private readonly ITriggering _triggerService;

	private TransitionHandler? _transitionHandler;

	private readonly IMediaProvider _mediaProvider;

	private readonly IProPresenterDOFactoryProvider _factoryProvider;

	private bool _renameNextItem;

	public string Name
	{
		get
		{
			return _propGroup.Name;
		}
		set
		{
			if (_propGroup.Name != value)
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					_propPrompts.AlertEmptyGroupName();
				}
				else
				{
					_propGroup.Name = value;
				}
				OnPropertyChanged("Name");
			}
		}
	}

	public bool SingleMode
	{
		get
		{
			return _propGroup.SingleMode;
		}
		set
		{
			_propGroup.SingleMode = value;
		}
	}

	public string FilterText
	{
		get
		{
			return _filterText;
		}
		set
		{
			SetValue("FilterText", ref _filterText, value, _filteredProps.Refresh);
		}
	}

	public bool IsReadyToEdit
	{
		get
		{
			if (string.IsNullOrEmpty(FilterText))
			{
				return _props.Any();
			}
			return true;
		}
	}

	public IPropGroupCollectionVM Parent { get; }

	public IPropCueVM? SelectedCue
	{
		get
		{
			return _selectedCue;
		}
		set
		{
			SetValue("SelectedCue", ref _selectedCue, value);
		}
	}

	public bool RenameNextItem
	{
		get
		{
			return _renameNextItem;
		}
		set
		{
			SetValue("RenameNextItem", ref _renameNextItem, value);
		}
	}

	public ObservableCollection<IPropCueVM> SelectedCues { get; } = new ObservableCollection<IPropCueVM>();

	public ObservableCollection<IPropCueVM> ActiveCues { get; } = new ObservableCollection<IPropCueVM>();

	public INotifyEnumerableChanged<IPropCueVM> PropCues => _filteredProps;

	public IDragDropNotifyEnumerableChanged<IPropCueVM> DragDropSource => _props;

	public ICommand AddPropCommand => new RelayCommand(OnAddPropCommand);

	public ICommand<IPropCueVM?> RemovePropCommand => new RelayCommand<IPropCueVM>(OnRemovePropCommaneExecuted);

	public ICommand<IPropCueVM?> TogglePropCommand => new RelayCommand<IPropCueVM>(delegate(IPropCueVM? cueVM)
	{
		DoTriggerAction(cueVM, delegate(IPropCue propCue, PropTrigger? propTrigger)
		{
			_triggerService.ToggleProp(propCue, propTrigger);
		}, null);
	});

	public ICommand<IPropCueVM?> TriggerPropCommand => new RelayCommand<IPropCueVM>(delegate(IPropCueVM? cueVM)
	{
		DoTriggerAction(cueVM, delegate(IPropCue propCue, PropTrigger? propTrigger)
		{
			_triggerService.TriggerProp(propCue);
		}, PropsState.Show);
	});

	public ICommand<IPropCueVM?> ClearPropCommand => new RelayCommand<IPropCueVM>(delegate(IPropCueVM? cueVM)
	{
		DoTriggerAction(cueVM, delegate(IPropCue propCue, PropTrigger? propTrigger)
		{
			_triggerService.ClearProp(propCue);
		}, PropsState.Clear);
	});

	public ICommand ToggleSingleModeCommand => new RelayCommand(delegate
	{
		SingleMode = !SingleMode;
	});

	public ICommand<IPropCueVM?> EditPropsCommand => new RelayCommand<IPropCueVM>(OnEditPropsCommandExecuted);

	public IPropGroup Source => _propGroup;

	public ICommand CopyCommand => new RelayCommand(OnCopyCommand, () => SelectedCues.Any());

	public ICommand CutCommand => new RelayCommand(OnCutCommand, () => SelectedCues.Any());

	public ICommand PasteCommand => new RelayCommand(OnPasteCommand, () => ClipboardManagerHelper.CanPasteIntoCollection<IPropCue>());

	public ICommand DuplicateCommand => new RelayCommand(OnDuplicateMacroCommand, () => SelectedCues.Any());

	public ICommand DeleteCommand => new RelayCommand(OnDeleteCommand, () => SelectedCues.Any());

	public ICommand<UIElement> TransitionCommand => new RelayCommand<UIElement>(OnTransitionCommandExecuted, (UIElement e) => e != null && SelectedCues.Any());

	public ICommand<IPropGroupVM> AddPropToGroupCommand => new RelayCommand<IPropGroupVM>(OnAddPropToGroupCommand);

	public ICommand<IPropGroupVM> MoveToGroupCommand => new RelayCommand<IPropGroupVM>(OnMoveToGroupCommand);

	public ICommand<IEnumerable<IPropCueVM>> AddPropsCommand => new RelayCommand<IEnumerable<IPropCueVM>>(delegate(IEnumerable<IPropCueVM> items)
	{
		_propGroup.AddProps(from i in items.OfType<IPropCueVMInternal>()
			select i.Source);
	});

	public ICommand<IEnumerable<IPropCueVM>> RemovePropsCommand => new RelayCommand<IEnumerable<IPropCueVM>>(delegate(IEnumerable<IPropCueVM> items)
	{
		_propGroup.RemoveProps(from i in items.OfType<IPropCueVMInternal>()
			select i.Source);
	});

	public ICommand<double> SetAutoClearCommand => new RelayCommand<double>(OnSetAutoClearCommandExecute);

	public ICommand PopupAutoClearCustomCommand => new RelayCommand(OnPopupAutoClearCustomCommandExecute);

	public ICommand<PropsDropParameter> DropActionCommand => new RelayCommand<PropsDropParameter>(OnDropActionCommand);

	public event Action<IPropCueVM>? NewItemAdded;

	public PropGroupVM(IPropGroupCollectionFactoryVM propGroupCollectionFactoryVM, IPropGroupCollectionVM propGroupCollectionVM, IPropGroup propGroup, IPropPrompts propPrompts, ITriggering triggerService, IMediaProvider mediaProvider, IProPresenterDOFactoryProvider factoryProvider, IUiDispatcher uiDispatcher)
	{
		PropGroupVM propGroupVM = this;
		_propPrompts = propPrompts;
		_propGroup = propGroup;
		Parent = propGroupCollectionVM;
		_props = new DragDropPairedCollection<IPropCue, IPropCueVM>(_propGroup, (IPropCue a) => propGroupCollectionFactoryVM.CreatePropCueVM(a, propGroupVM));
		_filteredProps = new UpdatingFilteredObservableCollection<IPropCueVM>(_props, FilterCues, uiDispatcher, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Name"));
		_triggerService = triggerService;
		_mediaProvider = mediaProvider;
		_factoryProvider = factoryProvider;
		LinkProperties("Name", "Name");
		LinkProperties("SingleMode", "SingleMode");
		LinkProperties("FilterText", "IsReadyToEdit");
		_propGroup.PropertyChanged += base.RaiseLinkedValues;
		_propGroup.CollectionChanged += delegate(object? sender, NotifyCollectionChangedEventArgs args)
		{
			propGroupVM.SelectedCues.Clear();
			IList? newItems = args.NewItems;
			if (newItems != null && newItems.Count > 0)
			{
				(from IPropCue a in args.NewItems
					select propGroupVM._props.FirstOrDefault((IPropCueVM b) => ((IPropCueVMInternal)b).Source.Equals(a))).NotNull().ForEach(delegate(IPropCueVM item)
				{
					propGroupVM.NewItemAdded?.Invoke(item);
				});
			}
		};
		SelectedCues.CollectionChanged += delegate
		{
			propGroupVM._props.Where((IPropCueVM m) => m.IsSelected).ForEach(delegate(IPropCueVM m)
			{
				m.IsSelected = false;
			});
			propGroupVM.SelectedCues.Where((IPropCueVM m) => !m.IsSelected).ForEach(delegate(IPropCueVM m)
			{
				m.IsSelected = true;
			});
			propGroupVM.OnPropertyChanged("IsReadyToEdit");
		};
	}

	private void OnAddPropCommand()
	{
		RenameNextItem = true;
		_propGroup.AddProp();
	}

	private void OnDropActionCommand(PropsDropParameter parameter)
	{
		if (parameter.DroppedItems.AllOf<MediaCue>())
		{
			(from MediaCue c in parameter.DroppedItems
				select c.MediaAction?.Media).NotNull().ForEach(delegate(MediaBase m)
			{
				DropMedia(m.Clone(), parameter);
			});
		}
		else if (parameter.DroppedItems.AllOf<FileInfo>())
		{
			_mediaProvider.GetMedia(MediaContainerIds.Prop(Parent.CollectionId), from FileInfo i in parameter.DroppedItems
				select i.FullName, delegate(MediaBase m)
			{
				DropMedia(m, parameter);
			});
		}
		parameter.Target?.InvalidateVisual();
	}

	private void DropMedia(MediaBase media, PropsDropParameter parameters)
	{
		IPropCue propCue;
		if (!parameters.DropOutside && parameters.Target?.DataContext is IPropCueVMInternal propCueVMInternal)
		{
			propCue = propCueVMInternal.Source;
		}
		else
		{
			propCue = _propGroup.AddProp();
			_propGroup.MoveTo(propCue.ToEnumerable(), parameters.DropIndex.Clamp(0, _propGroup.Count - 1));
		}
		if (propCue?.SlideAction != null)
		{
			Vector2<double> size = (parameters.DropOutside ? new Vector2<double>(1920.0, 1080.0) : propCue.SlideAction.Slide.Size);
			propCue.SlideAction.Slide.ChangeSize(size);
			RectangleShape rectangleShape = new RectangleShape(_factoryProvider, MediaContainerIds.Prop(Parent.CollectionId))
			{
				Size = size
			};
			(propCue.SlideAction.Slide as CustomSlide)?.AddElement(rectangleShape, userInitiated: false);
			rectangleShape.Fill = new MediaFill(_factoryProvider.MediaFactory, MediaContainerIds.Prop(Parent.CollectionId))
			{
				Media = (media as VisualMedia)
			};
			rectangleShape.Position = Vector2<double>.Zero;
		}
	}

	private void OnPopupAutoClearCustomCommandExecute()
	{
		double? customTime = _propPrompts.ShowDialogAutoClearCustomTimePrompt(SelectedCue?.AutoClearDuration ?? SelectedCues.FirstOrDefault()?.AutoClearDuration ?? 0.0);
		if (customTime.HasValue && customTime >= 0.0)
		{
			if (SelectedCue != null)
			{
				SelectedCue.AutoClearDuration = customTime.Value;
			}
			SelectedCues.ForEach(delegate(IPropCueVM m)
			{
				m.AutoClearDuration = Math.Round(customTime.Value, 1, MidpointRounding.AwayFromZero);
				m.AutoClearEnabled = true;
			});
		}
	}

	private void OnSetAutoClearCommandExecute(double numOfSeconds)
	{
		SelectedCues.ForEach(delegate(IPropCueVM m)
		{
			m.AutoClearDuration = numOfSeconds;
			m.AutoClearEnabled = numOfSeconds > 0.0;
		});
	}

	private void OnRemovePropCommaneExecuted(IPropCueVM? cueVM)
	{
		if (cueVM is IPropCueVMInternal propCueVMInternal)
		{
			_propGroup.RemoveProp(propCueVMInternal.Source);
		}
	}

	private void DoTriggerAction(IPropCueVM? cueVM, Action<IPropCue, PropTrigger?> triggerAction, PropsState? state)
	{
		IPropCue propCue = ((IPropCueVMInternal)cueVM)?.Source;
		if (propCue != null)
		{
			if (!state.HasValue)
			{
				state = (_triggerService.ActiveProps.Contains(propCue) ? PropsState.Clear : PropsState.Show);
			}
			triggerAction(propCue, (state == PropsState.Clear) ? PropTrigger.Clear : PropTrigger.Trigger);
			PropsStateEvent.Publish(state.Value);
			SelectedCue = null;
			SelectedCues.Clear();
		}
	}

	private void OnEditPropsCommandExecuted(IPropCueVM? cueVM)
	{
		IPropCueVM cueVM2 = cueVM ?? SelectedCue;
		Parent.OnEditProps(this, cueVM2);
	}

	private bool FilterCues(IPropCueVM cue)
	{
		if (!string.IsNullOrWhiteSpace(FilterText))
		{
			return cue.Name.ToLowerInvariant().Contains(FilterText.ToLowerInvariant());
		}
		return true;
	}

	private void OnCopyCommand()
	{
		IPropCue[] array = (from s in (from m in SelectedCues.OfType<IPropCueVMInternal>()
				select m.Source.Clone()).ToArray()
			orderby ((IImmutableObservableCollection<IPropCue>)_propGroup).IndexOf(s)
			select s).ToArray();
		if (array.Any())
		{
			ClipboardManagerHelper.CopyFromCollection(array);
		}
	}

	private void OnCutCommand()
	{
		OnCopyCommand();
		OnDeleteCommand();
	}

	private void OnPasteCommand()
	{
		int index = (SelectedCues.Any() ? (SelectedCues.Max((IPropCueVM m) => _props.IndexOf(m)) + 1) : _props.Count());
		IPropGroup propGroup = ((IPropGroupVMInternal)Parent.ActiveGroup)?.Source;
		propGroup.ThrowWhenNull("currentGroup");
		IEnumerable<IPropCue> pastedItems = ClipboardManagerHelper.PasteIntoCollection<IPropGroup, IPropCue>(propGroup, index);
		SelectedCues.Clear();
		SelectedCues.AddRange(from m in _props.OfType<IPropCueVMInternal>()
			where pastedItems.Contains(m.Source)
			select m);
	}

	private void OnDeleteCommand()
	{
		_propGroup.RemoveProps((from m in SelectedCues.OfType<IPropCueVMInternal>()
			select m.Source).ToArray());
		SelectedCues.Clear();
		PropsDeleteEvent.Publish();
		if (!string.IsNullOrEmpty(FilterText) && !_filteredProps.Any())
		{
			FilterText = string.Empty;
		}
	}

	private void OnDuplicateMacroCommand()
	{
		OnCopyCommand();
		OnPasteCommand();
	}

	private void OnAddPropToGroupCommand(IPropGroupVM groupDestination)
	{
		if (SelectedCues.Any())
		{
			IEnumerable<IPropCue> cues = from a in SelectedCues.OfType<IPropCueVMInternal>()
				select a.Source.Clone();
			((IPropGroupVMInternal)groupDestination).Source.AddProps(cues);
			SelectedCues.Clear();
		}
	}

	private void OnMoveToGroupCommand(IPropGroupVM groupDestination)
	{
		if (!SelectedCues.Any())
		{
			return;
		}
		IPropCue[] cues = (from i in SelectedCues.OfType<IPropCueVMInternal>()
			select i.Source).ToArray();
		foreach (IPropCueVM selectedCue in SelectedCues)
		{
			selectedCue.MoveToGroup(groupDestination);
		}
		((IPropGroupVMInternal)groupDestination).Source.AddProps(cues);
		OnDeleteCommand();
	}

	private void PropTransitioUpdated(TransitionParameters? transitionParameters)
	{
		if (SelectedCue?.SlideAction != null)
		{
			SelectedCue.SlideAction.Slide.SelectedTransition = transitionParameters;
		}
		SelectedCues.ForEach(delegate(IPropCueVM c)
		{
			if (c.SlideAction != null)
			{
				c.SlideAction.Slide.SelectedTransition = transitionParameters;
			}
		});
		if (_transitionHandler != null)
		{
			_transitionHandler.TransitionFinalized -= PropTransitioUpdated;
		}
	}

	private void OnTransitionCommandExecuted(UIElement placementTarget)
	{
		if (SelectedCues.Any() || SelectedCue != null)
		{
			TransitionParameters selectedTransition = SelectedCue?.SlideAction?.Slide.SelectedTransition ?? SelectedCues.FirstOrDefault()?.SlideAction?.Slide.SelectedTransition;
			_transitionHandler = new TransitionHandler(((ITransitionControl)Parent).TransitionHandler.Set);
			_transitionHandler.TransitionFinalized += PropTransitioUpdated;
			new SelectorPopup
			{
				OutputController = Parent.OutputController,
				SelectedTransition = selectedTransition,
				TransitionHandler = _transitionHandler,
				PlacementTarget = placementTarget,
				IsGlobalAllowed = true,
				StaysOpen = false,
				IsOpen = true
			};
		}
	}
}
