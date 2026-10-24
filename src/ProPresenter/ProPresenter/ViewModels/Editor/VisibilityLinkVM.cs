using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Nullability;
using Pro.Editor;
using Pro.UI.Components;
using ProPresenter.DO;
using ProPresenter.DO.LiveVideo;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Links;
using ProPresenter.DO.Timer;
using ProPresenter.UI.ViewModels.Editor;

namespace ProPresenter.ViewModels.Editor;

public class VisibilityLinkVM : LinkedNotifyPropertyChangedBase, IVisibilityLinkVM, INotifyPropertyChanged
{
	private readonly ObservableCollection<ICanvasElement> _selectedElements;

	private CustomSlide? _selectedSlide;

	public TimerCollection AvailableTimerCollection => DataVault.TimerDocument.Timers;

	public IEnumerable<ClosedBezierPath> AvailableElementsCollection => SelectedSlide?.Elements?.OfType<ClosedBezierPath>() ?? Enumerable.Empty<ClosedBezierPath>();

	public ILiveVideoInputCollection AvailableLiveVideoInputs
	{
		get
		{
			ILiveVideoInputCollection? availableLiveVideoInputs = OutputVault.AvailableLiveVideoInputs;
			availableLiveVideoInputs.ThrowWhenNull("inputs");
			return availableLiveVideoInputs;
		}
	}

	public VisibilityCriterion Criterion
	{
		get
		{
			return FirstElement?.VisibilityLink.Criterion ?? VisibilityCriterion.All;
		}
		set
		{
			UndoStack?.BeginCommit(UndoActionTypes.VisibilityLinkCriterion.ToAction());
			SelectedElements.ForEach(delegate(ClosedBezierPath e)
			{
				e.VisibilityLink.Criterion = value;
			});
			OnPropertyChanged("IsVisibilityLinkEnabled");
			UndoStack?.EndCommit(null, delegate
			{
				OnPropertyChanged("Criterion");
			}, autoFinalize: true);
		}
	}

	public VisibilityConditionCollection? Conditions => FirstElement?.VisibilityLink.Conditions;

	public CustomSlide? SelectedSlide
	{
		get
		{
			return _selectedSlide;
		}
		set
		{
			SetValue("SelectedSlide", ref _selectedSlide, value, OnSelectedSlideChanged);
		}
	}

	public bool IsVisibilityLinkEnabled
	{
		get
		{
			return FirstElement?.VisibilityLink.IsEnabled ?? false;
		}
		set
		{
			UndoStack?.BeginCommit(UndoActionTypes.VisibilityLinkEnabled.ToAction());
			SelectedElements.ForEach(delegate(ClosedBezierPath e)
			{
				e.VisibilityLink.IsEnabled = value;
			});
			OnPropertyChanged("IsVisibilityLinkEnabled");
			UndoStack?.EndCommit(null, delegate
			{
				OnPropertyChanged("IsVisibilityLinkEnabled");
			}, autoFinalize: true);
		}
	}

	public bool CanRemoveCondition
	{
		get
		{
			if (Conditions != null)
			{
				return Conditions.Count() > 1;
			}
			return false;
		}
	}

	public ICommand<(VisibilityCondition, SlideElementBase)> SetElementVisibilityLinkCommand => new RelayCommand<(VisibilityCondition, SlideElementBase)>(OnSetElementVisibilityLinkCommand);

	public ICommand<(VisibilityCondition, TimerData)> SetTimerVisibilityLinkCommand => new RelayCommand<(VisibilityCondition, TimerData)>(OnSetTimerVisibilityLinkCommand);

	public ICommand<VisibilityCondition> SetVideoCountdownVisibilityLinkCommand => new RelayCommand<VisibilityCondition>(OnSetVideoCountdownVisibilityLinkCommand);

	public ICommand<VisibilityCondition> SetAudioCountdownVisibilityLinkCommand => new RelayCommand<VisibilityCondition>(OnSetAudioCountdownVisibilityLinkCommand);

	public ICommand<VisibilityCondition> SetCaptureSessionVisibilityLinkCommand => new RelayCommand<VisibilityCondition>(OnSetCaptureSessionVisibilityLinkCommand);

	public ICommand<VisibilityCondition> SetVideoInputVisibilityLinkCommand => new RelayCommand<VisibilityCondition>(OnSetVideoInputVisibilityLinkCommand);

	public ICommand AddConditionCommand => new RelayCommand(OnAddConditionCommand, () => Conditions != null);

	public ICommand<VisibilityCondition> RemoveConditionCommand => new RelayCommand<VisibilityCondition>(OnRemoveConditionCommand, (VisibilityCondition v) => CanRemoveCondition);

	private IEnumerable<ClosedBezierPath> SelectedElements => _selectedElements.OfType<ClosedBezierPath>();

	private ClosedBezierPath? FirstElement => SelectedElements.FirstOrDefault();

	private UndoStack? UndoStack => FirstElement?.UndoStack;

	public VisibilityLinkVM(ObservableCollection<ICanvasElement> selectedElements)
	{
		_selectedElements = selectedElements;
		_selectedElements.CollectionChanged += delegate
		{
			RaisePropertyChanges();
		};
	}

	private void RaisePropertyChanges()
	{
		OnPropertyChanged("AvailableElementsCollection");
		OnPropertyChanged("IsVisibilityLinkEnabled");
		OnPropertyChanged("Criterion");
		OnPropertyChanged("Conditions");
		OnPropertyChanged("CanRemoveCondition");
	}

	private void OnSelectedSlideChanged(CustomSlide oldValue, CustomSlide newValue)
	{
		if (oldValue != null)
		{
			oldValue.Elements.CollectionChanged -= OnElementsChanged;
		}
		if (newValue != null)
		{
			newValue.Elements.CollectionChanged += OnElementsChanged;
		}
		OnPropertyChanged("AvailableElementsCollection");
	}

	private void OnElementsChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		OnPropertyChanged("AvailableElementsCollection");
	}

	private void OnAddConditionCommand()
	{
		Conditions?.AddCondition();
	}

	private void OnRemoveConditionCommand(VisibilityCondition condition)
	{
		Conditions?.RemoveCondition(condition);
	}

	private static void OnSetElementVisibilityLinkCommand((VisibilityCondition condition, SlideElementBase element) p)
	{
		p.condition.LinkedObject = new ElementLinkedVisibilityObject(p.element);
	}

	private static void OnSetTimerVisibilityLinkCommand((VisibilityCondition condition, TimerData timer) p)
	{
		p.condition.LinkedObject = new TimerLinkedVisibilityObject(p.timer, () => DataVault.TimerDocument.Timers);
	}

	private static void OnSetVideoCountdownVisibilityLinkCommand(VisibilityCondition condition)
	{
		condition.LinkedObject = new VideoCountdownLinkedVisibilityObject();
	}

	private static void OnSetAudioCountdownVisibilityLinkCommand(VisibilityCondition condition)
	{
		condition.LinkedObject = new AudioCountdownLinkedVisibilityObject();
	}

	private static void OnSetCaptureSessionVisibilityLinkCommand(VisibilityCondition condition)
	{
		condition.LinkedObject = new CaptureSessionLinkedVisibilityObject();
	}

	private static void OnSetVideoInputVisibilityLinkCommand(VisibilityCondition condition)
	{
		condition.LinkedObject = new VideoInputLinkedVisibilityObject();
	}
}
