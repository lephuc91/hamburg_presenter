using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Background;
using Pro.Common.Components;
using Pro.Common.Mathematics;
using Pro.Common.Nullability;
using Pro.Common.Time;
using Pro.Common.Time.Timer;
using Pro.Common.Utility;
using Pro.DO.Transitions;
using Pro.DO.Triggering;
using ProPresenter.Controller;
using ProPresenter.DO;
using ProPresenter.DO.PanelSourcing;
using ProPresenter.DO.Props;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.Rendering;
using ProPresenter.SendData.Props;
using ProPresenter.UI.ViewModels.Props;

namespace ProPresenter.ViewModels.Props;

public class PropCueVM : LinkedNotifyPropertyChangedBase, IPropCueVMInternal, IPropCueVM, INotifyPropertyChanged, IUniformViewSource, ITriggerable
{
	private readonly IPropCue _propCue;

	private IPropGroupVM _parentGroupVM;

	private readonly TransitionHandler _propTransitionHandler;

	private readonly ITriggering _triggerService;

	private readonly IPropAutoClearService _propAutoClearService;

	private readonly IAsyncExecutor _asyncExecutor;

	private bool _isSelected;

	private readonly ISlidePreviewService _slidePreviewService;

	private ImageSource? _previewImage;

	private Vector2<int> _thumbnailSize = Vector2<int>.One;

	private Vector2<double> _previewSize;

	private PropStatus? _propStatus;

	private readonly IPeriodicTimer _timer;

	public string Name
	{
		get
		{
			return _propCue.Name;
		}
		set
		{
			_propCue.Name = value;
		}
	}

	public bool AutoClearEnabled
	{
		get
		{
			return SlideAction?.AutoClearEnabled ?? false;
		}
		set
		{
			if (SlideAction != null)
			{
				SlideAction.AutoClearEnabled = value;
			}
		}
	}

	public double AutoClearDuration
	{
		get
		{
			return SlideAction?.AutoClearDuration ?? 0.0;
		}
		set
		{
			if (SlideAction != null)
			{
				SlideAction.AutoClearDuration = value;
			}
		}
	}

	public TransitionParameters? SelectedTransition
	{
		get
		{
			object obj = SlideAction?.Slide.SelectedTransition;
			if (obj == null)
			{
				TransitionBase? cutTransition = _propTransitionHandler.Set.CutTransition;
				if (cutTransition == null)
				{
					return null;
				}
				obj = cutTransition.Preset.Parameters;
			}
			return (TransitionParameters?)obj;
		}
		set
		{
			if (SlideAction != null)
			{
				SlideAction.Slide.SelectedTransition = value;
			}
		}
	}

	public IPropCue Source => _propCue;

	public TransitionHandler TransitionHandler => _propTransitionHandler;

	public PropSlideAction? SlideAction => _propCue.SlideAction;

	IPropCue IPropCueVMInternal.Source => _propCue;

	public IPropGroupVM Parent => _parentGroupVM;

	public double ThumbnailAspectRatio => 1.7777777777777777;

	public int Index => 0;

	public bool IsSelected
	{
		get
		{
			return _isSelected;
		}
		set
		{
			SetValue("IsSelected", ref _isSelected, value);
		}
	}

	public bool IsActive => _triggerService.ActiveProps.Contains(Source);

	public ImageSource? PreviewImage
	{
		get
		{
			return _previewImage;
		}
		private set
		{
			SetValue("PreviewImage", ref _previewImage, value);
		}
	}

	public Vector2<int> ThumbnailSize
	{
		get
		{
			return _thumbnailSize;
		}
		set
		{
			SetValue("ThumbnailSize", ref _thumbnailSize, value, Slide_VisualInvalidated);
		}
	}

	public Vector2<double> PreviewSize
	{
		get
		{
			return _previewSize;
		}
		set
		{
			SetValue("PreviewSize", ref _previewSize, value, Slide_VisualInvalidated);
		}
	}

	public bool IsPlaying
	{
		get
		{
			if ((object)_propStatus != null)
			{
				return !_propStatus.IsPaused;
			}
			return false;
		}
	}

	public double PlayProgress => _propStatus?.Progress ?? 0.0;

	public bool ShowProgress
	{
		get
		{
			if (IsActive)
			{
				return _timer.IsRunning();
			}
			return false;
		}
	}

	public ICommand TogglePropAutoClearCommand => new RelayCommand(TogglePropAutoClear);

	public PropCueVM(IPropCue propCue, IPropGroupVM parentGroupVM, IProPresenterResourceService proPresenterResourceService, ISlidePreviewService slidePreviewService, ITriggering triggerService, IPropAutoClearService propAutoClearService, ITimerFactory timerFactory, IAsyncExecutor asyncExecutor)
	{
		_propCue = propCue;
		_parentGroupVM = parentGroupVM;
		_slidePreviewService = slidePreviewService;
		_propTransitionHandler = new TransitionHandler(proPresenterResourceService.Transitions);
		_triggerService = triggerService;
		_propAutoClearService = propAutoClearService;
		_asyncExecutor = asyncExecutor;
		_timer = timerFactory.CreatePeriodic(TimeSlice.FromMilliseconds(10.0), OnGetStatus);
		_propTransitionHandler.ActivateTransition(SelectedTransition);
		_propTransitionHandler.TransitionFinalized += PropTransitionUpdated;
		LinkProperties("AutoClearEnabled", new string[2] { "AutoClearEnabled", "ShowProgress" });
		LinkProperties("AutoClearDuration", "AutoClearDuration");
		LinkProperties("Name", "Name");
		LinkProperties("SelectedTransition", "SelectedTransition");
		propCue.PropertyChanged += base.RaiseLinkedValues;
		if (propCue.SlideAction != null)
		{
			propCue.SlideAction.PropertyChanged += Slide_PropertyChanged;
			propCue.SlideAction.Slide.PropertyChanged += base.RaiseLinkedValues;
			propCue.SlideAction.Slide.VisualInvalidated += Slide_VisualInvalidated;
		}
		_triggerService.ActiveProps.CollectionChanged += OnActivePropsChanged;
		_propAutoClearService.WhenPropStatusChangedSubject.Subscribe(OnPropStatusChanged);
	}

	private void OnPropStatusChanged(PropStatus status)
	{
		if (status.PropID == _propCue.ID)
		{
			_propStatus = status;
			OnPropertyChanged("IsPlaying");
			OnPropertyChanged("PlayProgress");
		}
	}

	private void TogglePropAutoClear()
	{
		if (IsPlaying)
		{
			_propAutoClearService.Pause(_propCue.ID);
		}
		else
		{
			_propAutoClearService.Play(_propCue.ID);
		}
	}

	private void OnActivePropsChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		if (IsActive && AutoClearEnabled)
		{
			_timer.Start();
		}
		else
		{
			OnPropStatusChanged(new PropStatus(Source.ID, AutoClearDuration, IsPaused: false, 0.0));
			_timer.Stop();
		}
		OnPropertyChanged("IsActive");
		OnPropertyChanged("ShowProgress");
	}

	private void Slide_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "Size")
		{
			_asyncExecutor.ExecuteAsync(InvalidatePreviewImageAsync);
		}
		RaiseLinkedValues(sender, e);
	}

	public void MoveToGroup(IPropGroupVM parentGroupVM)
	{
		_parentGroupVM = parentGroupVM;
		OnPropertyChanged("Parent");
	}

	private void Slide_VisualInvalidated()
	{
		_asyncExecutor.ExecuteAsync(InvalidatePreviewImageAsync);
	}

	private async Task InvalidatePreviewImageAsync()
	{
		Vector2<double> previewSize = SlideAction?.Slide.Size.ScaleToFitSize(ThumbnailSize.Cast<double>()) ?? default(Vector2<double>);
		Vector2<int> previewSize2 = new Vector2<int>(Math.Max(1, (int)previewSize.X), Math.Max(1, (int)previewSize.Y));
		PreviewSize = previewSize;
		Color secondaryBackground = ((SlideAction?.Slide.UseBackgroundColor ?? false) ? SlideAction.Slide.BackgroundColor : Colors.Transparent);
		SlidePreviewRenderParams renderParams = new SlidePreviewRenderParams(previewSize2, IncludeBackground: true, IncludeBackgroundMedia: false, secondaryBackground, ElementsRenderOption.None, null, IncludeTextPlaceholder: false, UseFullSizeMedia: false, UseScreenScalar: true, IncludeLinkIndicator: true, ForceBackgroundColorDraw: true);
		CustomSlide customSlide = SlideAction?.Slide as CustomSlide;
		customSlide.ThrowWhenNull("slideForPreview");
		using IBitmapHandle bitmapHandle = await _slidePreviewService.RenderSlidePreviewAsync(customSlide, renderParams);
		PreviewImage = bitmapHandle?.BitmapSource;
	}

	private void PropTransitionUpdated(TransitionParameters? transitionParameters)
	{
		if (SlideAction != null)
		{
			SlideAction.Slide.SelectedTransition = transitionParameters;
		}
	}

	private void OnGetStatus()
	{
		_propAutoClearService.GetStatus(_propCue.ID);
	}
}
