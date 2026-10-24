using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Mathematics;
using Pro.Common.Nullability;
using Pro.Common.Utility;
using Pro.Editor;
using Pro.Editor.Canvas.Transforming;
using Pro.UI.Components;
using Pro.ssAPI.Devices;
using ProPresenter.DO;
using ProPresenter.DO.Cues;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.LiveVideo;
using ProPresenter.DO.Media;
using ProPresenter.DO.Repositories;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Custom.Elements.Fills;
using ProPresenter.DO.Slide.Custom.Elements.Strokes;
using ProPresenter.UI.SlideEditor.Inspectors;
using ProPresenter.UI.ViewModels.Editor;

namespace ProPresenter.ViewModels.Editor;

public class ShapeInspectorVM : LinkedNotifyPropertyChangedBase, IShapeInspectorVM, INotifyPropertyChanged
{
	[CompilerGenerated]
	private sealed class _003Cget_SelectedMedia_003Ed__131 : IEnumerable<MediaCue>, IEnumerable, IEnumerator<MediaCue>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private MediaCue _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public ShapeInspectorVM _003C_003E4__this;

		private IEnumerator<IFill> _003C_003E7__wrap1;

		MediaCue IEnumerator<MediaCue>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003Cget_SelectedMedia_003Ed__131(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = _003C_003E1__state;
			if (num == -3 || (uint)(num - 1) <= 1u)
			{
				try
				{
				}
				finally
				{
					_003C_003Em__Finally1();
				}
			}
			_003C_003E7__wrap1 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			try
			{
				int num = _003C_003E1__state;
				ShapeInspectorVM shapeInspectorVM = _003C_003E4__this;
				switch (num)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					_003C_003E7__wrap1 = (from p in shapeInspectorVM.SelectedElements.OfType<ClosedBezierPath>()
						select p.Fill).GetEnumerator();
					_003C_003E1__state = -3;
					break;
				case 1:
					_003C_003E1__state = -3;
					break;
				case 2:
					_003C_003E1__state = -3;
					break;
				}
				while (_003C_003E7__wrap1.MoveNext())
				{
					IFill current = _003C_003E7__wrap1.Current;
					if (!(current is MediaFill mediaFill))
					{
						if (!(current is LiveVideoFill liveVideoFill))
						{
							continue;
						}
						_003C_003E2__current = liveVideoFill.LiveVideo.ToCue(shapeInspectorVM._app, shapeInspectorVM._outputRepository.AvailableTransitions);
						_003C_003E1__state = 2;
						return true;
					}
					_003C_003E2__current = mediaFill.Media.ToCue(shapeInspectorVM._app, shapeInspectorVM._outputRepository.AvailableTransitions, supportsPlaybackMarkers: false);
					_003C_003E1__state = 1;
					return true;
				}
				_003C_003Em__Finally1();
				_003C_003E7__wrap1 = null;
				return false;
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void _003C_003Em__Finally1()
		{
			_003C_003E1__state = -1;
			if (_003C_003E7__wrap1 != null)
			{
				_003C_003E7__wrap1.Dispose();
			}
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<MediaCue> IEnumerable<MediaCue>.GetEnumerator()
		{
			_003Cget_SelectedMedia_003Ed__131 result;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				result = this;
			}
			else
			{
				result = new _003Cget_SelectedMedia_003Ed__131(0)
				{
					_003C_003E4__this = _003C_003E4__this
				};
			}
			return result;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<MediaCue>)this).GetEnumerator();
		}
	}

	private EditMode _editMode;

	private CustomSlide? _selectedSlide;

	private readonly ObservableCollection<ICanvasElement> _selectedCanvasElements;

	private readonly IMediaProvider _mediaProvider;

	private readonly IMediaFactory _mediaFactory;

	private IEnumerable<ICanvasElement> _previousSelectedElements;

	private readonly FillPropertyWrapper _fill;

	private readonly ShadowPropertyWrapper _shadow;

	private readonly IOutputRepository _outputRepository;

	private readonly IApp _app;

	private IEnumerable<BezierPath> SelectedElements => _selectedCanvasElements.OfType<BezierPath>();

	public bool CanElementArrange => SelectedElements.Any();

	private ClosedBezierPath? FirstElement => SelectedElements.FirstOrDefaultOf<ClosedBezierPath>();

	private UndoStack? UndoStack => SelectedSlide?.UndoStack;

	public IFillLinkVM FillLinkVM { get; }

	public IVisibilityLinkVM VisibilityLinkVM { get; }

	public CustomSlide? SelectedSlide
	{
		get
		{
			return _selectedSlide;
		}
		set
		{
			SetValue<CustomSlide>("SelectedSlide", ref _selectedSlide, value, delegate(CustomSlide o, CustomSlide n)
			{
				_fill.UndoStack = n?.UndoStack;
				_shadow.UndoStack = n?.UndoStack;
				FillLinkVM.SelectedSlide = n;
				VisibilityLinkVM.SelectedSlide = n;
			});
		}
	}

	public string ElementName
	{
		get
		{
			return SelectedElements.FirstOrDefault()?.Name ?? string.Empty;
		}
		set
		{
			SelectedElements.ForEach(delegate(BezierPath e)
			{
				e.Name = value;
			});
			OnPropertyChanged("ElementName");
		}
	}

	public bool ShowFullInspector => _selectedCanvasElements.AllOf<BezierPath>();

	public bool ShowStroke => ShowFullInspector;

	public bool ShowShadow
	{
		get
		{
			if (ShowFullInspector)
			{
				return EditMode != EditMode.Mask;
			}
			return false;
		}
	}

	public bool ShowFeatheringOption
	{
		get
		{
			if (ShowFullInspector)
			{
				return EditMode != EditMode.Stage;
			}
			return false;
		}
	}

	public bool ShowVisibility
	{
		get
		{
			if (ShowFullInspector)
			{
				return EditMode != EditMode.Mask;
			}
			return false;
		}
	}

	public bool IsRotationSupported => _selectedCanvasElements?.Any((ICanvasElement e) => e.SupportsRotation) ?? false;

	public Angle<double> Rotation
	{
		get
		{
			return _selectedCanvasElements.FirstOrDefault()?.Rotation ?? Angle<double>.Zero;
		}
		set
		{
			_selectedCanvasElements.ForEach(delegate(ICanvasElement e)
			{
				e.Rotation = value;
			});
			OnPropertyChanged("Rotation");
		}
	}

	public double Opacity
	{
		get
		{
			return SelectedElements.FirstOrDefault()?.Opacity ?? 1.0;
		}
		set
		{
			SelectedElements.ForEach(delegate(BezierPath e)
			{
				e.Opacity = value;
			});
			OnPropertyChanged("Opacity");
		}
	}

	public bool FeatherEnabled
	{
		get
		{
			return SelectedElements.FirstOrDefault()?.Feather.IsEnabled ?? false;
		}
		set
		{
			UndoStack?.BeginCommit(UndoActionTypes.ElementFeatherEnabled.ToAction());
			SelectedElements.ForEach(delegate(BezierPath e)
			{
				e.Feather.IsEnabled = value;
			});
			OnPropertyChanged("FeatherEnabled");
			UndoStack?.EndCommit(null, null, autoFinalize: true);
		}
	}

	public double FeatherRadius
	{
		get
		{
			return SelectedElements.FirstOrDefault()?.Feather.Radius ?? 0.05;
		}
		set
		{
			UndoStack?.BeginCommit(UndoActionTypes.ElementFeatherRadius.ToAction());
			SelectedElements.ForEach(delegate(BezierPath e)
			{
				e.Feather.Radius = value;
			});
			OnPropertyChanged("FeatherRadius");
			UndoStack?.EndCommit(null, null, autoFinalize: true);
		}
	}

	public double Left
	{
		get
		{
			return _selectedCanvasElements.FirstOrDefault()?.Position.X ?? 0.0;
		}
		set
		{
			_selectedCanvasElements.ForEach(delegate(ICanvasElement e)
			{
				e.Position = new Vector2<double>(value, e.Position.Y);
			});
			OnPropertyChanged("Left");
		}
	}

	public double Top
	{
		get
		{
			return _selectedCanvasElements.FirstOrDefault()?.Position.Y ?? 0.0;
		}
		set
		{
			_selectedCanvasElements.ForEach(delegate(ICanvasElement e)
			{
				e.Position = new Vector2<double>(e.Position.X, value);
			});
			OnPropertyChanged("Top");
		}
	}

	public double Width
	{
		get
		{
			return _selectedCanvasElements.FirstOrDefault()?.Size.X ?? 0.0;
		}
		set
		{
			_selectedCanvasElements.ForEach(delegate(ICanvasElement e)
			{
				ResizeElement(e, value, isWidth: true);
			});
			OnPropertyChanged("Width");
			OnPropertyChanged("Height");
		}
	}

	public bool IsWidthSupported => !_selectedCanvasElements.Any((ICanvasElement e) => e.SupportedCanvasHandles.AdjustsHeight());

	public double Height
	{
		get
		{
			return _selectedCanvasElements.FirstOrDefault()?.Size.Y ?? 0.0;
		}
		set
		{
			_selectedCanvasElements.ForEach(delegate(ICanvasElement e)
			{
				ResizeElement(e, value, isWidth: false);
			});
			OnPropertyChanged("Width");
			OnPropertyChanged("Height");
		}
	}

	public bool IsHeightSupported => !_selectedCanvasElements.Any((ICanvasElement e) => e.SupportedCanvasHandles.AdjustsWidth());

	public bool IsLockEnabled => SelectedElements.Any();

	public bool IsLocked
	{
		get
		{
			return _selectedCanvasElements.Any((ICanvasElement e) => e.IsLocked);
		}
		set
		{
			UndoStack?.BeginCommit(UndoActionTypes.ElementLocked.ToAction());
			_selectedCanvasElements.ForEach(delegate(ICanvasElement e)
			{
				e.IsLocked = value;
			});
			OnPropertyChanged("IsLocked");
			UndoStack?.EndCommit(null, null, autoFinalize: true);
		}
	}

	public bool IsHidden
	{
		get
		{
			return _selectedCanvasElements.Any((ICanvasElement e) => e.IsHidden);
		}
		set
		{
			UndoStack?.BeginCommit(UndoActionTypes.ElementHidden.ToAction());
			_selectedCanvasElements.ForEach(delegate(ICanvasElement e)
			{
				e.IsHidden = value;
			});
			OnPropertyChanged("IsHidden");
			UndoStack?.EndCommit(null, null, autoFinalize: true);
		}
	}

	public bool IsAspectRatioLocked
	{
		get
		{
			return _selectedCanvasElements.Any((ICanvasElement e) => e.IsAspectRatioLocked);
		}
		set
		{
			UndoStack?.BeginCommit(UndoActionTypes.ElementAspectRatioLocked.ToAction());
			_selectedCanvasElements.ForEach(delegate(ICanvasElement e)
			{
				e.IsAspectRatioLocked = value;
			});
			OnPropertyChanged("IsAspectRatioLocked");
			UndoStack?.EndCommit(null, null, autoFinalize: true);
		}
	}

	public bool IsAspectRatioLockForced => _selectedCanvasElements.Any((ICanvasElement e) => e.IsAspectRatioLockForced);

	public bool FlipHorizontally
	{
		get
		{
			BezierPath? bezierPath = SelectedElements.FirstOrDefault();
			if (bezierPath == null)
			{
				return false;
			}
			return bezierPath.FlipMode.HasFlag(ElementFlipMode.Horizontal);
		}
		set
		{
			UndoStack?.BeginCommit(UndoActionTypes.ElementFlip.ToAction());
			if (value)
			{
				SelectedElements.ForEach(delegate(BezierPath e)
				{
					e.FlipMode |= ElementFlipMode.Horizontal;
				});
			}
			else
			{
				SelectedElements.ForEach(delegate(BezierPath e)
				{
					e.FlipMode &= ~ElementFlipMode.Horizontal;
				});
			}
			OnPropertyChanged("FlipHorizontally");
			UndoStack?.EndCommit(null, null, autoFinalize: true);
		}
	}

	public bool FlipVertically
	{
		get
		{
			BezierPath? bezierPath = SelectedElements.FirstOrDefault();
			if (bezierPath == null)
			{
				return false;
			}
			return bezierPath.FlipMode.HasFlag(ElementFlipMode.Vertical);
		}
		set
		{
			UndoStack?.BeginCommit(UndoActionTypes.ElementFlip.ToAction());
			if (value)
			{
				SelectedElements.ForEach(delegate(BezierPath e)
				{
					e.FlipMode |= ElementFlipMode.Vertical;
				});
			}
			else
			{
				SelectedElements.ForEach(delegate(BezierPath e)
				{
					e.FlipMode &= ~ElementFlipMode.Vertical;
				});
			}
			OnPropertyChanged("FlipVertically");
			UndoStack?.EndCommit(null, null, autoFinalize: true);
		}
	}

	public bool IsStrokeSupported => SelectedElements.Any((BezierPath e) => e.SupportsStroke);

	public bool IsFillVisible
	{
		get
		{
			if (FirstElement == null)
			{
				return false;
			}
			if (IsFillSupported)
			{
				if (!FirstElement.FillLink.IsEnabled)
				{
					return FirstElement.Fill.IsEnabled;
				}
				return true;
			}
			return false;
		}
		set
		{
			UndoStack?.BeginCommit(UndoActionTypes.ElementFillEnabled.ToAction());
			SelectedElements.OfType<ClosedBezierPath>().ForEach(delegate(ClosedBezierPath e)
			{
				e.Fill.IsEnabled = value;
			});
			SelectedElements.OfType<ClosedBezierPath>().ForEach(delegate(ClosedBezierPath e)
			{
				e.FillLink.IsEnabled = value;
			});
			OnPropertyChanged("IsFillVisible");
			UndoStack?.EndCommit(null, null, autoFinalize: true);
		}
	}

	public bool IsStrokeVisible
	{
		get
		{
			return SelectedElements.FirstOrDefault()?.Stroke.IsEnabled ?? false;
		}
		set
		{
			UndoStack?.BeginCommit(UndoActionTypes.ElementStrokeEnabled.ToAction());
			SelectedElements.ForEach(delegate(BezierPath e)
			{
				e.Stroke.IsEnabled = value;
			});
			OnPropertyChanged("IsStrokeVisible");
			UndoStack?.EndCommit(null, null, autoFinalize: true);
		}
	}

	public bool IsShadowSupported => SelectedElements.Any((BezierPath e) => e.SupportsShadow);

	public bool IsShadowVisible
	{
		get
		{
			return SelectedElements.FirstOrDefault()?.Shadow.IsEnabled ?? false;
		}
		set
		{
			UndoStack?.BeginCommit(UndoActionTypes.ElementShadowEnabled.ToAction());
			SelectedElements.ForEach(delegate(BezierPath e)
			{
				e.Shadow.IsEnabled = value;
			});
			OnPropertyChanged("IsShadowVisible");
			UndoStack?.EndCommit(null, null, autoFinalize: true);
		}
	}

	public bool IsFillOptionVisible => !SelectedElements.Any((BezierPath e) => e is OpenBezierPath);

	public EditMode EditMode
	{
		get
		{
			return _editMode;
		}
		set
		{
			SetValue("EditMode", ref _editMode, value, delegate(EditMode o, EditMode n)
			{
				FillLinkVM.EditMode = n;
			});
		}
	}

	public FillType FillType
	{
		get
		{
			return FirstElement?.Fill.Type ?? FillType.Solid;
		}
		set
		{
			using (UndoStack?.Transaction(UndoActionTypes.ElementFill.ToAction()))
			{
				List<ITrackedMedia> mediaToRemove = new List<ITrackedMedia>();
				SelectedSlide.ThrowWhenNull("SelectedSlide");
				SelectedElements.OfType<ClosedBezierPath>().ForEach(delegate(ClosedBezierPath e)
				{
					e.FillLink.LinkedObject = null;
					IFill fill = value.GenerateFill(_mediaFactory, SelectedSlide.ContainerId);
					if (e.Fill is MediaFill mediaFill)
					{
						if (fill is LiveVideoFill liveVideoFill)
						{
							liveVideoFill.LiveVideo.TransposeProperties(mediaFill.Media?.Clone());
						}
						else if (fill is MediaFill mediaFill2)
						{
							mediaFill2.TransposeProperties(mediaFill);
						}
						ITrackedMedia media = mediaFill.Media;
						if (media != null)
						{
							mediaToRemove.Add(media);
						}
					}
					e.Fill = fill;
				});
				mediaToRemove.ForEach(delegate(ITrackedMedia x)
				{
					x.RemoveFromMediaService(deleteAssets: false);
				});
				UndoStack?.Commit(delegate
				{
					mediaToRemove.ForEach(delegate(ITrackedMedia x)
					{
						x.AddToMediaServiceAndApplyTransform(userInitiated: true);
					});
				}, delegate
				{
					mediaToRemove.ForEach(delegate(ITrackedMedia x)
					{
						x.RemoveFromMediaService(deleteAssets: false);
					});
				});
				OnPropertyChanged("Fill");
				OnPropertyChanged("FillType");
			}
		}
	}

	public IEnumerable<FillType> AvailableFillTypes => Enum.GetValues<FillType>().Except(new global::_003C_003Ez__ReadOnlyArray<FillType>(new FillType[3]
	{
		FillType.Bitmap,
		FillType.SlidePreview,
		FillType.PDF
	}));

	public StrokeStyle StrokeStyle
	{
		get
		{
			return (SelectedElements.FirstOrDefault()?.Stroke?.Style).GetValueOrDefault();
		}
		set
		{
			UndoStack?.BeginCommit(UndoActionTypes.ElementStrokeStyle.ToAction());
			SelectedElements.OfType<BezierPath>().ForEach(delegate(BezierPath e)
			{
				e.Stroke.Style = value;
			});
			OnPropertyChanged("StrokeStyle");
			UndoStack?.EndCommit(null, null, autoFinalize: true);
		}
	}

	public Color StrokeColor
	{
		get
		{
			return SelectedElements.FirstOrDefault()?.Stroke.StrokeColor ?? Colors.Transparent;
		}
		set
		{
			UndoStack?.BeginCommit(UndoActionTypes.ElementStrokeColor.ToAction());
			SelectedElements.OfType<BezierPath>().ForEach(delegate(BezierPath e)
			{
				e.Stroke.StrokeColor = value;
			});
			OnPropertyChanged("StrokeColor");
			UndoStack?.EndCommit(null, null, autoFinalize: true);
		}
	}

	public double StrokeThickness
	{
		get
		{
			return SelectedElements.FirstOrDefault()?.Stroke.StrokeThickness ?? 0.0;
		}
		set
		{
			UndoStack?.BeginCommit(UndoActionTypes.ElementStrokeThickness.ToAction());
			SelectedElements.OfType<BezierPath>().ForEach(delegate(BezierPath e)
			{
				e.Stroke.StrokeThickness = value;
			});
			OnPropertyChanged("StrokeThickness");
			UndoStack?.EndCommit(null, null, autoFinalize: true);
		}
	}

	public ShadowType ShadowType
	{
		get
		{
			return (SelectedElements.FirstOrDefault()?.Shadow?.Type).GetValueOrDefault();
		}
		set
		{
			SelectedElements.OfType<BezierPath>().ForEach(delegate(BezierPath e)
			{
				e.Shadow = value.GenerateShadow();
			});
			OnPropertyChanged("ShadowType");
		}
	}

	public VideoInputDeviceCollection AvailableVideoInputs => _outputRepository.VideoInputDeviceCollection;

	public AudioInputDeviceCollection AvailableAudioInputs => _outputRepository.AudioInputDeviceCollection;

	public ILiveVideoInputCollection AvailableInputs
	{
		get
		{
			ILiveVideoInputCollection? availableLiveVideoInputs = OutputVault.AvailableLiveVideoInputs;
			availableLiveVideoInputs.ThrowWhenNull("inputs");
			return availableLiveVideoInputs;
		}
	}

	public IEnumerable<MediaCue> SelectedMedia
	{
		[IteratorStateMachine(typeof(_003Cget_SelectedMedia_003Ed__131))]
		get
		{
			//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
			return new _003Cget_SelectedMedia_003Ed__131(-2)
			{
				_003C_003E4__this = this
			};
		}
	}

	public bool IsFillSupported => SelectedElements.OfType<ClosedBezierPath>().Any((ClosedBezierPath e) => e.SupportsFill);

	public dynamic Fill => _fill;

	public dynamic Shadow => _shadow;

	public bool ShowBackgroundEffects
	{
		get
		{
			if (EditMode != EditMode.Mask && EditMode != EditMode.CCLITemplate && EditMode != EditMode.Stage)
			{
				return EditMode != EditMode.Prop;
			}
			return false;
		}
	}

	public ICommand<ZOrderDirection> ChangeZOrderCommand => new RelayCommand<ZOrderDirection>(OnChangeZOrderCommand, (ZOrderDirection x) => SelectedElements.Any());

	public ICommand<AlignmentType> AlignCommand { get; }

	public ICommand<DistributionType> DistributeCommand { get; }

	public ICommand SwapGradientColorsCommand => new RelayCommand(OnSwapGradientColorsCommand);

	public ICommand CreateMediaFillCommand => new RelayCommand(SetMediaFill);

	public ICommand ShowInFileExplorerCommand => new RelayCommand(OnShowInFileExplorer, () => (FirstElement?.Fill as MediaFill)?.Media != null);

	public ICommand OpenSetupCommand => new RelayCommand(OnOpenSetupCommand);

	public ICommand HideCommand => new RelayCommand(delegate
	{
		SelectedElements.ForEach(delegate(BezierPath e)
		{
			e.IsHidden = true;
		});
	});

	public ICommand UnlockAllCommand => new RelayCommand(delegate
	{
		_selectedSlide.Elements.ForEach(delegate(SlideElementBase e)
		{
			e.IsLocked = false;
		});
	}, () => _selectedSlide?.Elements.Any((SlideElementBase e) => e.IsLocked) ?? false);

	public ICommand<FillType> UpdateFillCommand => new RelayCommand<FillType>(OnUpdateFillCommand, (FillType f) => IsFillSupported);

	public ICommand<SlideElementBase> UnlockCommand => new RelayCommand<SlideElementBase>(OnUnlockCommand, (SlideElementBase e) => e != null);

	public event Action<LiveVideoInput>? OpenLiveVideoSetup;

	public ShapeInspectorVM(IOutputRepository outputRepository, IApp app, ObservableCollection<ICanvasElement> selectedCanvasElements, IMediaProvider mediaProvider, IProPresenterDOFactoryProvider factoryProvider)
	{
		_outputRepository = outputRepository;
		_app = app;
		_selectedCanvasElements = selectedCanvasElements;
		_mediaProvider = mediaProvider;
		_mediaFactory = factoryProvider.MediaFactory;
		_previousSelectedElements = Enumerable.Empty<ICanvasElement>();
		AlignCommand = new RelayCommand<AlignmentType>(OnAlignCommand, (AlignmentType x) => SelectedElements.Any() && !IsLocked);
		DistributeCommand = new RelayCommand<DistributionType>(OnDistributeCommand, (DistributionType x) => SelectedElements.Count() >= 3 && !IsLocked);
		_selectedCanvasElements.CollectionChanged += delegate(object? s, NotifyCollectionChangedEventArgs e)
		{
			UndoStack?.StartIgnoring();
			OnPropertyChanged("ElementName");
			OnPropertyChanged("IsFillOptionVisible");
			OnPropertyChanged("FirstElement");
			OnPropertyChanged("FillType");
			OnPropertyChanged("Fill");
			OnPropertyChanged("IsStrokeVisible");
			OnPropertyChanged("StrokeStyle");
			OnPropertyChanged("StrokeColor");
			OnPropertyChanged("StrokeThickness");
			OnPropertyChanged("IsShadowVisible");
			OnPropertyChanged("ShadowType");
			OnPropertyChanged("Shadow");
			OnPropertyChanged("Top");
			OnPropertyChanged("Left");
			OnPropertyChanged("Width");
			OnPropertyChanged("Height");
			OnPropertyChanged("Rotation");
			OnPropertyChanged("IsLocked");
			OnPropertyChanged("IsAspectRatioLocked");
			OnPropertyChanged("IsAspectRatioLockForced");
			OnPropertyChanged("FlipHorizontally");
			OnPropertyChanged("FlipVertically");
			OnPropertyChanged("Opacity");
			OnPropertyChanged("FeatherEnabled");
			OnPropertyChanged("FeatherRadius");
			OnPropertyChanged("IsFillSupported");
			OnPropertyChanged("IsFillVisible");
			OnPropertyChanged("IsStrokeSupported");
			OnPropertyChanged("IsShadowSupported");
			OnPropertyChanged("IsWidthSupported");
			OnPropertyChanged("IsHeightSupported");
			OnPropertyChanged("IsRotationSupported");
			OnPropertyChanged("IsLockEnabled");
			OnPropertyChanged("ShowFullInspector");
			OnPropertyChanged("ShowStroke");
			OnPropertyChanged("ShowShadow");
			OnPropertyChanged("ShowFeatheringOption");
			OnPropertyChanged("ShowVisibility");
			OnPropertyChanged("ShowBackgroundEffects");
			((e.Action == NotifyCollectionChangedAction.Reset) ? _previousSelectedElements : e.OldItems?.Cast<ICanvasElement>())?.ForEach(TeardownElement);
			_previousSelectedElements = e.NewItems?.Cast<ICanvasElement>() ?? Enumerable.Empty<ICanvasElement>();
			_previousSelectedElements.ForEach(SetupElement);
			UndoStack?.StopIgnoring();
			(AlignCommand as RelayCommand<AlignmentType>)?.NotifyCanExecuteChanged();
			(DistributeCommand as RelayCommand<DistributionType>)?.NotifyCanExecuteChanged();
		};
		_fill = new FillPropertyWrapper(_selectedCanvasElements, _mediaFactory, () => SelectedSlide?.ContainerId ?? string.Empty);
		_shadow = new ShadowPropertyWrapper(_selectedCanvasElements);
		FillLinkVM = new FillLinkVM(factoryProvider.EntityFactory, selectedCanvasElements);
		VisibilityLinkVM = new VisibilityLinkVM(selectedCanvasElements);
		HookupLinkedProperties();
	}

	private void SetupElement(ICanvasElement element)
	{
		element.PropertyChanged += base.RaiseLinkedValues;
		if (element is BezierPath bezierPath)
		{
			bezierPath.Stroke.PropertyChanged += base.RaiseLinkedValues;
			bezierPath.Shadow.PropertyChanged += base.RaiseLinkedValues;
			if (bezierPath.PathType == BezierPathType.Closed)
			{
				((ClosedBezierPath)bezierPath).Fill.PropertyChanged += base.RaiseLinkedValues;
			}
		}
	}

	private void TeardownElement(ICanvasElement element)
	{
		element.PropertyChanged -= base.RaiseLinkedValues;
		if (element is BezierPath bezierPath)
		{
			bezierPath.Stroke.PropertyChanged -= base.RaiseLinkedValues;
			bezierPath.Shadow.PropertyChanged -= base.RaiseLinkedValues;
			if (bezierPath.PathType == BezierPathType.Closed)
			{
				((ClosedBezierPath)bezierPath).Fill.PropertyChanged -= base.RaiseLinkedValues;
			}
		}
	}

	private void HookupLinkedProperties()
	{
		LinkProperties("Position", new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "Top", "Left" }));
		LinkProperties("Size", new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "Width", "Height" }));
		LinkProperties("Rotation", "Rotation");
		LinkProperties("IsLocked", "IsLocked");
		LinkProperties("IsAspectRatioLocked", "IsAspectRatioLocked");
		LinkProperties("IsAspectRatioLockForced", "IsAspectRatioLockForced");
		LinkProperties("SupportedCanvasHandles", new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "IsHeightSupported", "IsWidthSupported" }));
		LinkProperties("Name", "ElementName");
		LinkProperties("Opacity", "Opacity");
		LinkProperties("FlipMode", new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "FlipHorizontally", "FlipVertically" }));
		LinkProperties("Fill", "FillType");
		LinkProperties("IsEnabled", "IsStrokeVisible");
		LinkProperties("IsEnabled", "IsShadowVisible");
		LinkProperties("IsEnabled", "FeatherEnabled");
		LinkProperties("IsEnabled", "IsFillVisible");
	}

	private void OnChangeZOrderCommand(ZOrderDirection direction)
	{
		IEnumerable<ICanvasElement> enumerable = SelectedSlide?.Elements;
		ElementOrdonnance.ChangeElementZOrder(enumerable ?? Enumerable.Empty<ICanvasElement>(), SelectedElements, direction);
	}

	private void OnAlignCommand(AlignmentType alignmentType)
	{
		if (SelectedElements.Count() == 1)
		{
			ElementOrdonnance.AlignElement(SelectedElements.First(), alignmentType);
		}
		else
		{
			ElementOrdonnance.AlignElements(SelectedElements, alignmentType);
		}
	}

	private void OnDistributeCommand(DistributionType distributionType)
	{
		ElementOrdonnance.DistributeElements(SelectedElements, distributionType);
	}

	private void OnSwapGradientColorsCommand()
	{
		IFill fill = FirstElement?.Fill;
		GradientColorFill gradientFill = fill as GradientColorFill;
		if (gradientFill != null)
		{
			UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ElementGradientFillSwapColors));
			gradientFill.SwapGradientColors();
			SelectedElements.OfType<ClosedBezierPath>().ForEach(delegate(ClosedBezierPath e)
			{
				e.Fill = gradientFill.Clone();
			});
			OnPropertyChanged("Fill");
			UndoStack?.EndCommit(null, null, autoFinalize: true);
		}
	}

	private static void ResizeElement(ICanvasElement element, double newValue, bool isWidth)
	{
		Vector2<double> size = element.Size;
		Vector2<double> vector = (isWidth ? new Vector2<double>(newValue - size.X, 0.0) : new Vector2<double>(0.0, newValue - size.Y));
		if (element.IsAspectRatioLocked || element.IsAspectRatioLockForced)
		{
			double num = (isWidth ? (size.Y / size.X) : (size.X / size.Y));
			vector *= num;
			element.Size = (isWidth ? new Vector2<double>(newValue, size.Y + vector.X) : new Vector2<double>(size.X + vector.Y, newValue));
		}
		else
		{
			element.Size += vector;
		}
	}

	private void OnShowInFileExplorer()
	{
		if (FirstElement?.Fill is MediaFill mediaFill && (object)mediaFill.Media?.SourceFile != null)
		{
			ProcessHelper.ShowFileInExplorer(mediaFill.Media.SourceFile);
		}
	}

	private void OnOpenSetupCommand()
	{
		this.OpenLiveVideoSetup?.Invoke(Fill?.LiveVideo?.LiveVideo?.Input);
	}

	private void OnUpdateFillCommand(FillType fillType)
	{
		if (fillType == FillType.Media)
		{
			SetMediaFill();
		}
		else
		{
			FillType = fillType;
		}
	}

	private void SetMediaFill()
	{
		SelectedSlide.ThrowWhenNull("SelectedSlide");
		MediaBase mediaBase = ((FillType == FillType.Media) ? (Fill.Media.Clone() as MediaBase) : null);
		if (mediaBase != null)
		{
			_mediaProvider?.GetMedia(mediaBase, MediaCallback);
		}
		else
		{
			_mediaProvider?.GetMedia(SelectedSlide.ContainerId, MediaCallback);
		}
		void MediaCallback(MediaBase? m)
		{
			if (m != null)
			{
				UndoStack?.BeginCommit(UndoActionTypes.ElementMediaFillMedia.ToAction());
				FillType = FillType.Media;
				List<ITrackedMedia> mediaToAdd = new List<ITrackedMedia>();
				List<ITrackedMedia> mediaToRemove = new List<ITrackedMedia>();
				IEnumerable<IFilledElement> source = SelectedElements.OfType<IFilledElement>();
				IFilledElement filledElement = source.First();
				if (filledElement.Fill is MediaFill mediaFill)
				{
					ITrackedMedia media = mediaFill.Media;
					if (media != null)
					{
						mediaToRemove.Add(media);
					}
				}
				(filledElement.Fill as MediaFill).Media = (VisualMedia)m;
				foreach (MediaFill item2 in (from x in source.Skip(1)
					select x.Fill).OfType<MediaFill>())
				{
					ITrackedMedia media2 = item2.Media;
					if (media2 != null)
					{
						mediaToRemove.Add(media2);
					}
					VisualMedia item = (item2.Media = m.Clone() as VisualMedia);
					mediaToAdd.Add(item);
				}
				mediaToRemove.ForEach(delegate(ITrackedMedia x)
				{
					x.RemoveFromMediaService(deleteAssets: false);
				});
				mediaToAdd.ForEach(delegate(ITrackedMedia x)
				{
					x.AddToMediaService(userInitiated: true);
				});
				mediaToAdd.Add((ITrackedMedia)m);
				UndoStack?.Commit(delegate
				{
					mediaToAdd.ForEach(delegate(ITrackedMedia x)
					{
						x.RemoveFromMediaService(deleteAssets: false);
					});
					mediaToRemove.ForEach(delegate(ITrackedMedia x)
					{
						x.AddToMediaServiceAndApplyTransform(userInitiated: true);
					});
				}, delegate
				{
					mediaToRemove.ForEach(delegate(ITrackedMedia x)
					{
						x.RemoveFromMediaService(deleteAssets: false);
					});
					mediaToAdd.ForEach(delegate(ITrackedMedia x)
					{
						x.AddToMediaServiceAndApplyTransform(userInitiated: true);
					});
				});
				OnPropertyChanged("Fill");
				UndoStack?.EndCommit(null, delegate
				{
					OnPropertyChanged("Fill");
				}, autoFinalize: true);
			}
		}
	}

	private void OnUnlockCommand(SlideElementBase element)
	{
		if (!_selectedCanvasElements.Contains(element))
		{
			_selectedCanvasElements.Add(element);
		}
		IsLocked = false;
	}
}
