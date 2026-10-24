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
using Pro.Common.Dispatcher;
using Pro.Common.Mathematics;
using Pro.Common.Nullability;
using Pro.DO;
using Pro.DO.Transitions;
using Pro.DO.Triggering;
using Pro.UI.Components;
using ProPresenter.Controller;
using ProPresenter.Controller.Outputs;
using ProPresenter.DO;
using ProPresenter.DO.Analytics;
using ProPresenter.DO.Cues;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Media;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Props;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Slide.Custom.Elements.Fills;
using ProPresenter.DO.Slide.Custom.Elements.Shapes;
using ProPresenter.UI;
using ProPresenter.UI.Commands;
using ProPresenter.UI.Props;
using ProPresenter.UI.Thumbnails;
using ProPresenter.UI.Transitions;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.ViewModels;

public class PropsVM : LinkedNotifyPropertyChangedBase, IPropsVM, INotifyPropertyChanged, IDragDropCollection<IPropCue>
{
	private readonly ICoreManager _manager;

	private readonly IApp _app;

	private readonly ITriggering _service;

	private IPropCue? _selectedItem;

	private IPropCue? _activeItem;

	private int _rowCapacity;

	private string _filterText = string.Empty;

	private bool _renameNextItem;

	private readonly IPropCueCollection _propCueCollection;

	private readonly TransitionHandler _propTransitionHandler;

	private readonly IMediaProvider _mediaProvider;

	private readonly IProPresenterDOFactoryProvider _factoryProvider;

	public IEnumerable<IPropCue> ActiveProps => _service.ActiveProps.Reverse();

	public ObservableCollection<IPropCue> SelectedItems { get; } = new ObservableCollection<IPropCue>();

	public IPropCue? SelectedItem
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

	public IPropCue? ActiveItem
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

	public ssAPIOutput OutputController { get; }

	public TransitionHandler TransitionHandler { get; }

	public TransitionParameters? SelectedTransition
	{
		get
		{
			TransitionParameters? transitionParameters = _propCueCollection.SelectedTransition;
			if ((object)transitionParameters == null)
			{
				TransitionBase? cutTransition = TransitionHandler.Set.CutTransition;
				if (cutTransition == null)
				{
					return null;
				}
				transitionParameters = cutTransition.Preset.Parameters;
			}
			return transitionParameters;
		}
		set
		{
			_propCueCollection.SelectedTransition = value;
			_manager.PropsTransition = value;
		}
	}

	public int RowCapacity
	{
		get
		{
			return _rowCapacity;
		}
		set
		{
			SetValue("RowCapacity", ref _rowCapacity, value, delegate(int o, int n)
			{
				_app.PropsViewerRowCapacity = n;
			});
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
			SetValue("FilterText", ref _filterText, value, FilteredProps.Refresh);
			OnPropertyChanged("FooterVisibilty");
		}
	}

	private INotifyEnumerableChanged<IPropCue> Props => _propCueCollection;

	public FilteredObservableCollection<IPropCue> FilteredProps { get; }

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

	public Visibility FooterVisibilty
	{
		get
		{
			if (FilterText.Length <= 0 && FilteredProps.Count <= 0)
			{
				return Visibility.Collapsed;
			}
			return Visibility.Visible;
		}
	}

	public ICommand<ShowSource> EditPropsCommand => new RelayCommand<ShowSource>(OnEditPropsCommand);

	public ICommand CopyCommand => new RelayCommand(OnCopyCommand, () => SelectedItems.Any());

	public ICommand CutCommand => new RelayCommand(OnCutCommand, () => SelectedItems.Any());

	public ICommand PasteCommand => new RelayCommand(OnPasteCommand, CanPasteSlide);

	public ICommand DuplicateCommand => new RelayCommand(OnDuplicateCommand, () => SelectedItems.Any());

	public ICommand DeleteCommand => new RelayCommand(OnDeleteCommand, () => SelectedItems.Any());

	public ICommand AddSlideCommand => new RelayCommand(OnAddSlideCommand);

	public ICommand<DragDropCommandParameters<IPropCue, IPropCueCollection>> MoveToCommand => new RelayCommand<DragDropCommandParameters<IPropCue, IPropCueCollection>>(OnMoveToCommand);

	public ICommand<IPropCue?> TogglePropCommand => new RelayCommand<IPropCue>(OnTogglePropCommand, (IPropCue? c) => c != null);

	public ICommand<UIElement> TransitionCommand => new RelayCommand<UIElement>(OnTransitionCommand, (UIElement e) => e != null && SelectedItems.Any());

	public ICommand<DropMediaCommandParameters> DropFilesCommand => new RelayCommand<DropMediaCommandParameters>(OnDropFilesCommand, (DropMediaCommandParameters p) => p != null);

	public ICommand<DropMediaCommandParameters> DropMediaCueCommand => new RelayCommand<DropMediaCommandParameters>(OnDropMediaCueCommand, (DropMediaCommandParameters p) => p != null);

	public event Action<IPropGroup, IPropCue>? EditProps;

	public PropsVM(IProPresenterResourceService resourceService, ICoreManager manager, ssAPIOutput outputController, IApp app, ITriggeringFactory triggeringFactory, IMediaProvider mediaProvider, IProPresenterDOFactoryProvider factoryProvider, IUiDispatcher uiDispatcher)
	{
		_propCueCollection = resourceService.PropCueCollection;
		_manager = manager;
		_service = triggeringFactory.Create();
		OutputController = outputController;
		_app = app;
		_mediaProvider = mediaProvider;
		_factoryProvider = factoryProvider;
		TransitionHandler = new TransitionHandler(resourceService.Transitions);
		TransitionHandler.ActivateTransition(SelectedTransition);
		TransitionHandler.TransitionFinalized += TransitionUpdated;
		_propTransitionHandler = new TransitionHandler(resourceService.Transitions);
		_propTransitionHandler.TransitionFinalized += PropTransitioUpdated;
		LinkProperties("SelectedTransition", "SelectedTransition");
		DataVault.PropCueCollection.PropertyChanged += base.RaiseLinkedValues;
		FilteredProps = new UpdatingFilteredObservableCollection<IPropCue>(Props, FilterCues, uiDispatcher, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Name"));
		_manager.ActiveProps.CollectionChanged += delegate
		{
			OnPropertyChanged("ActiveProps");
		};
		_manager.PropsTransition = SelectedTransition;
		_rowCapacity = _app.PropsViewerRowCapacity;
	}

	private bool FilterCues(IPropCue cue)
	{
		if (!string.IsNullOrWhiteSpace(FilterText))
		{
			return cue.Name.ToLowerInvariant().Contains(FilterText.ToLowerInvariant());
		}
		return true;
	}

	private void TransitionUpdated(TransitionParameters? newTransition)
	{
		SelectedTransition = newTransition;
		PropsTransitionEvent.Publish();
	}

	private void OnEditPropsCommand(ShowSource source)
	{
		if (!_propCueCollection.Any())
		{
			_propCueCollection.AddProp();
		}
		SelectedItem.ThrowWhenNull("SelectedItem");
		this.EditProps?.Invoke(_propCueCollection, SelectedItem);
		switch (source)
		{
		case ShowSource.Toolbar:
			MainViewPropsEditorEvent.Publish(MainViewSource.Toolbar);
			break;
		case ShowSource.LowerRight:
			MainViewPropsEditorEvent.Publish(MainViewSource.LowerRight);
			break;
		}
	}

	private void OnCopyCommand()
	{
		IOrderedEnumerable<IPropCue> orderedEnumerable = SelectedItems.OrderBy((IPropCue s) => Props.IndexOf(s));
		if (orderedEnumerable.Any())
		{
			ClipboardManagerHelper.CopyFromCollection(orderedEnumerable);
			ClipboardManagerHelper.CopyFromCollection(GetSlidesData(orderedEnumerable));
		}
	}

	private IEnumerable<SlidesCopyData> GetSlidesData(IEnumerable<IPropCue> cues)
	{
		List<SlidesCopyData> list = new List<SlidesCopyData>();
		foreach (IPropCue item in cues.Where((IPropCue c) => c.SlideAction != null))
		{
			IEnumerable<SlideCue> slides = new SlideCue(_factoryProvider, item.SlideAction).ToEnumerable();
			list.Add(new SlidesCopyData(null, slides, createGroup: false, null, string.Empty));
		}
		return list;
	}

	private void OnCutCommand()
	{
		OnCopyCommand();
		OnDeleteCommand();
	}

	private void OnPasteCommand()
	{
		IPropCue value = SelectedItems.OrderBy((IPropCue s) => Props.IndexOf(s)).LastOrDefault() ?? ActiveProps.LastOrDefault();
		IEnumerable<IPropCue> items = ClipboardManagerHelper.PasteIntoCollection<IPropCueCollection, IPropCue>(_propCueCollection, _propCueCollection.ToArray().IndexOf(value));
		SelectedItems.Clear();
		SelectedItems.AddRange(items);
	}

	private void OnDuplicateCommand()
	{
		_propCueCollection.UndoStack?.BeginCommit(UndoActionTypes.DuplicateSlide.ToAction());
		OnCopyCommand();
		OnPasteCommand();
		_propCueCollection.UndoStack?.EndCommit(null, null, autoFinalize: true);
	}

	private void OnDeleteCommand()
	{
		IPropCue[] array = SelectedItems.ToArray();
		_propCueCollection.RemoveProps(array);
		SelectedItems.RemoveRange(array);
		PropsDeleteEvent.Publish();
	}

	private void OnAddSlideCommand()
	{
		RenameNextItem = true;
		_propCueCollection.AddProp();
		PropsCreateEvent.Publish();
	}

	private void OnMoveToCommand(DragDropCommandParameters<IPropCue, IPropCueCollection> e)
	{
		int num = 0;
		if (e.TargetItem == null)
		{
			num = _propCueCollection.Count;
		}
		else
		{
			num = ((IImmutableObservableCollection<IPropCue>)_propCueCollection).IndexOf(e.TargetItem);
			num = ((!e.DroppedBefore) ? (num + 1) : num);
		}
		e.Items.ThrowWhenNull("e.Items");
		_propCueCollection.MoveTo(e.Items, num);
	}

	private void OnTogglePropCommand(IPropCue? slideCue)
	{
		slideCue.ThrowWhenNull("slideCue");
		IPropCue propCue = _propCueCollection.FirstOrDefault((IPropCue a) => a.ID == slideCue.ID);
		IPropCue propCue2 = ActiveProps.FirstOrDefault((IPropCue a) => a.ID == slideCue.ID);
		if (propCue != null)
		{
			if (propCue2 != null)
			{
				_service.ClearProp(propCue);
				PropsStateEvent.Publish(PropsState.Clear);
			}
			else
			{
				_service.TriggerProp(propCue);
				PropsStateEvent.Publish(PropsState.Show);
			}
			ActiveItem = null;
			SelectedItem = null;
			SelectedItems.Clear();
		}
	}

	public int IndexOf(IPropCue item)
	{
		return Props.IndexOf(item);
	}

	public void DraggedFrom(IEnumerable<IPropCue> items)
	{
	}

	public void DroppedInto(IEnumerable<IPropCue> items, int index, bool isCopy)
	{
	}

	public void MoveTo(IEnumerable<IPropCue> items, int index)
	{
		_propCueCollection.MoveTo(items, index);
	}

	private void OnTransitionCommand(UIElement placementTarget)
	{
		new SelectorPopup
		{
			OutputController = OutputController,
			SelectedTransition = SelectedItem?.SlideAction?.Slide.SelectedTransition,
			TransitionHandler = _propTransitionHandler,
			PlacementTarget = placementTarget,
			IsGlobalAllowed = true,
			StaysOpen = false,
			IsOpen = true
		};
	}

	private void PropTransitioUpdated(TransitionParameters? transitionParameters)
	{
		SelectedItems.ForEach(delegate(IPropCue c)
		{
			if (c.SlideAction != null)
			{
				c.SlideAction.Slide.SelectedTransition = transitionParameters;
			}
		});
	}

	private void OnDropFilesCommand(DropMediaCommandParameters parameters)
	{
		_mediaProvider.GetMedia(MediaContainerIds.Prop(_propCueCollection.ID), parameters.Files, delegate(MediaBase m)
		{
			OnDropMedia(m, parameters);
		});
	}

	private void OnDropMediaCueCommand(DropMediaCommandParameters parameters)
	{
		parameters.MediaCues?.ForEach(delegate(MediaCue c)
		{
			OnDropMedia(c.MediaAction?.Media.Clone(), parameters);
		});
	}

	private void OnDropMedia(MediaBase? media, DropMediaCommandParameters parameters)
	{
		IPropCue propCue;
		if (parameters.IsDropInside)
		{
			propCue = parameters.TargetProp;
		}
		else
		{
			propCue = _propCueCollection.AddProp();
			_propCueCollection.MoveTo(propCue.ToEnumerable(), parameters.DropIndex.Clamp(0, _propCueCollection.Count - 1));
		}
		if (propCue?.SlideAction != null)
		{
			Vector2<double> size = (parameters.IsDropInside ? propCue.SlideAction.Slide.Size : (_manager.OutputConfiguration.AudienceArrangementScreens.FirstOrDefault()?.TotalSize ?? new Vector2<double>(1920.0, 1080.0)));
			propCue.SlideAction.Slide.ChangeSize(size);
			RectangleShape rectangleShape = new RectangleShape(_factoryProvider, MediaContainerIds.Prop(_propCueCollection.ID))
			{
				Size = size
			};
			(propCue.SlideAction.Slide as CustomSlide)?.AddElement(rectangleShape, userInitiated: false);
			rectangleShape.Fill = new MediaFill(_factoryProvider.MediaFactory, MediaContainerIds.Prop(_propCueCollection.ID))
			{
				Media = (media as VisualMedia)
			};
			rectangleShape.Position = Vector2<double>.Zero;
		}
	}

	private static bool CanPasteSlide()
	{
		if (ClipboardManagerHelper.CanPasteIntoCollection<SlidesCopyData>())
		{
			return ClipboardManagerHelper.GetPasteableItems<SlidesCopyData>()?.SelectMany((SlidesCopyData s) => s.Slides).All((SlideCue s) => s.SlideAction?.ActionType.IsAnyOf(ActionType.PropSlide, ActionType.Prop) ?? false) ?? false;
		}
		return false;
	}
}
