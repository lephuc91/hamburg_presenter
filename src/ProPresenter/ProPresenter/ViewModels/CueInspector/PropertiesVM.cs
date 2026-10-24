using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.Mathematics;
using Pro.Common.Time;
using Pro.Common.Utility;
using Pro.DO.Transitions;
using Pro.DO.Triggering;
using Pro.DO.Triggering.CompletionTargets;
using Pro.ssAPI;
using ProPresenter.Controller;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Media;
using ProPresenter.DO.Media.Properties;
using ProPresenter.UI;
using ProPresenter.UI.MediaLibrary;
using ProPresenter.UI.ViewModels.CueInspector;

namespace ProPresenter.ViewModels.CueInspector;

public class PropertiesVM : LinkedNotifyPropertyChangedBase, IPropertiesVM, INotifyPropertyChanged
{
	private const double MinCropSize = 10.0;

	private readonly ICIMediaControlVM _ciMediaControlVM;

	private readonly ICoreManager _manager;

	private readonly IUiDispatcher _dispatcher;

	private readonly IDebouncer _cropDebouncer;

	private MediaCue? _activeMediaCue;

	private bool _cropUpdateInProgress;

	private InlineType _activeInlineView;

	private bool _supportsAudioNextBehavior;

	private bool _showRetriggeringBehaviorField;

	private Vector2<double> _cropPosition;

	private Vector2<double> _cropSize;

	public InlineType ActiveInlineView
	{
		get
		{
			return _activeInlineView;
		}
		set
		{
			_activeInlineView = value;
			OnPropertyChanged("ActiveInlineView");
		}
	}

	public MediaCue? ActiveMediaCue
	{
		get
		{
			return _activeMediaCue;
		}
		set
		{
			SetValue<MediaCue>("ActiveMediaCue", ref _activeMediaCue, value, delegate(MediaCue o, MediaCue n)
			{
				if (o != null)
				{
					if (o.MediaAction?.Media is IDrawMedia drawMedia)
					{
						drawMedia.Drawing.PropertyChanged -= Drawing_PropertyChanged;
					}
					if (o.MediaAction?.Media is IVideoMedia videoMedia)
					{
						videoMedia.Video.PropertyChanged -= base.RaiseLinkedValues;
					}
					if (o.MediaAction?.Media is ITransportMedia transportMedia)
					{
						transportMedia.Transport.PropertyChanged -= Transport_PropertyChanged;
					}
					if (o.MediaAction != null)
					{
						o.MediaAction.PropertyChanged -= MediaActionPropertyChanged;
					}
					o.PropertyChanged -= MediaCuePropertyChanged;
				}
				if (n != null)
				{
					if (n.MediaAction?.Media is IDrawMedia drawMedia2)
					{
						drawMedia2.Drawing.PropertyChanged += Drawing_PropertyChanged;
					}
					if (n.MediaAction?.Media is IVideoMedia videoMedia2)
					{
						videoMedia2.Video.PropertyChanged += base.RaiseLinkedValues;
					}
					if (n.MediaAction?.Media is ITransportMedia transportMedia2)
					{
						transportMedia2.Transport.PropertyChanged += Transport_PropertyChanged;
					}
					if (n.MediaAction != null)
					{
						n.MediaAction.PropertyChanged += MediaActionPropertyChanged;
						TransitionHandler.ActivateTransition(n.MediaAction.SelectedTransition);
					}
					n.PropertyChanged += MediaCuePropertyChanged;
					UpdateProperties();
				}
				OnPropertyChanged("MediaSize");
				OnPropertyChanged("MediaType");
				OnPropertyChanged("InPoint");
				OnPropertyChanged("OutPoint");
				OnPropertyChanged("Duration");
				OnPropertyChanged("MediaAction");
				OnPropertyChanged("SelectedTransition");
				OnPropertyChanged("ScaleBehavior");
				OnPropertyChanged("ScaleAlignment");
				OnPropertyChanged("FlipHorizontally");
				OnPropertyChanged("FlipVertically");
				OnPropertyChanged("CropPosition");
				OnPropertyChanged("CropSize");
				OnPropertyChanged("CropLeftMax");
				OnPropertyChanged("CropRightMax");
				OnPropertyChanged("CropTopMax");
				OnPropertyChanged("CropBottomMax");
				OnPropertyChanged("CropTop");
				OnPropertyChanged("CropLeft");
				OnPropertyChanged("CropRight");
				OnPropertyChanged("CropBottom");
				OnPropertyChanged("CropEnable");
				OnPropertyChanged("SupportsPremultipliedAlphaSetting");
				OnPropertyChanged("AlphaType");
				OnPropertyChanged("Rotation");
				OnPropertyChanged("PlayRate");
				OnPropertyChanged("PlaybackBehavior");
				OnPropertyChanged("LoopCount");
				OnPropertyChanged("LoopTime");
				OnPropertyChanged("SoftLoop");
				OnPropertyChanged("SoftLoopDuration");
				OnPropertyChanged("EndBehavior");
				OnPropertyChanged("DelayTime");
				OnPropertyChanged("SupportsScaleAndBlur");
				OnPropertyChanged("SupportsCustomScale");
				OnPropertyChanged("SupportsScaleAlignment");
				OnPropertyChanged("RetriggerBehavior");
				OnPropertyChanged("ShowRetriggeringBehaviorField");
				OnPropertyChanged("FrameRate");
				OnPropertyChanged("HardwareDecodingBehavior");
			});
		}
	}

	private MediaAction? MediaAction => _activeMediaCue?.MediaAction;

	private DrawingProperties? Drawing => (MediaAction?.Media as IDrawMedia)?.Drawing;

	private TransportProperties? Transport => (MediaAction?.Media as ITransportMedia)?.Transport;

	private VideoProperties? Video => (MediaAction?.Media as IVideoMedia)?.Video;

	public TimeSlice SoftLoopDuration
	{
		get
		{
			return Video?.SoftLoopDuration ?? SoftLoopHelper.Durations.Max();
		}
		set
		{
			VideoProperties video = Video;
			if (video != null)
			{
				video.SoftLoopDuration = value;
				OnPropertyChanged("SoftLoopDuration");
			}
		}
	}

	public Vector2<double> MediaSize => Drawing?.EffectiveSize ?? Vector2<double>.Zero;

	public bool SupportsScaleAndBlur => (MediaAction?.Media as IDrawMedia)?.SupportsScaleAndBlur ?? false;

	public bool SupportsCustomScale => (MediaAction?.Media as IDrawMedia)?.SupportsCustomScale ?? false;

	public bool SupportsScaleAlignment
	{
		get
		{
			if (ScaleBehavior != 0)
			{
				return ScaleBehavior == ScaleBehavior.ScaleToFill;
			}
			return true;
		}
	}

	public ScaleBehavior ScaleBehavior
	{
		get
		{
			return Drawing?.ScaleBehavior ?? ScaleBehavior.ScaleToFit;
		}
		set
		{
			if (Drawing != null)
			{
				Drawing.ScaleBehavior = value;
				OnPropertyChanged("SupportsScaleAlignment");
			}
		}
	}

	public ScaleAlignment ScaleAlignment
	{
		get
		{
			return Drawing?.ScaleAlignment ?? ScaleAlignment.TopLeft;
		}
		set
		{
			if (Drawing != null)
			{
				Drawing.ScaleAlignment = value;
			}
		}
	}

	public bool FlipHorizontally
	{
		get
		{
			return Drawing?.FlipHorizontally ?? false;
		}
		set
		{
			if (Drawing != null)
			{
				Drawing.FlipHorizontally = value;
			}
		}
	}

	public bool FlipVertically
	{
		get
		{
			return Drawing?.FlipVertically ?? false;
		}
		set
		{
			if (Drawing != null)
			{
				Drawing.FlipVertically = value;
			}
		}
	}

	public Vector2<double> CropPosition
	{
		get
		{
			return _cropPosition;
		}
		set
		{
			SetValue("CropPosition", ref _cropPosition, value, (Action)delegate
			{
				_cropDebouncer.Invoke();
				NotifyDerivedCropProperties();
			}, (Predicate<Vector2<double>>?)null, referenceComparison: false);
		}
	}

	public Vector2<double> CropSize
	{
		get
		{
			return _cropSize;
		}
		set
		{
			SetValue("CropSize", ref _cropSize, value, (Action)delegate
			{
				_cropDebouncer.Invoke();
				NotifyDerivedCropProperties();
			}, (Predicate<Vector2<double>>?)null, referenceComparison: false);
		}
	}

	public bool CropEnable
	{
		get
		{
			return Drawing?.CropEnable ?? false;
		}
		set
		{
			if (Drawing != null)
			{
				Drawing.CropEnable = value;
			}
		}
	}

	public AlphaType AlphaType
	{
		get
		{
			return Drawing?.AlphaType ?? AlphaType.Unknown;
		}
		set
		{
			if (Drawing != null)
			{
				Drawing.AlphaType = value;
			}
		}
	}

	public bool SupportsPremultipliedAlphaSetting => (MediaAction?.Media as VisualMedia)?.Metadata?.SupportsAlphaChannel == true;

	public double CropLeftMax => CropPosition.X + CropSize.X - 10.0;

	public double CropRightMax => MediaSize.X - CropPosition.X - 10.0;

	public double CropTopMax => CropPosition.Y + CropSize.Y - 10.0;

	public double CropBottomMax => MediaSize.Y - CropPosition.Y - 10.0;

	public double CropTop
	{
		get
		{
			return CropPosition.Y;
		}
		set
		{
			if (Drawing != null && !_cropUpdateInProgress)
			{
				_cropUpdateInProgress = true;
				Vector2<double> vector = new Vector2<double>(0.0, (value - CropTop).Clamp(0.0 - CropTop, CropTopMax - CropTop));
				CropPosition += vector;
				CropSize -= vector;
				_cropUpdateInProgress = false;
			}
		}
	}

	public double CropBottom
	{
		get
		{
			return MediaSize.Y - (CropPosition.Y + CropSize.Y);
		}
		set
		{
			if (Drawing != null && !_cropUpdateInProgress)
			{
				_cropUpdateInProgress = true;
				Vector2<double> vector = new Vector2<double>(0.0, (value - CropBottom).Clamp(0.0 - CropBottom, CropBottomMax - CropBottom));
				CropSize -= vector;
				_cropUpdateInProgress = false;
			}
		}
	}

	public double CropLeft
	{
		get
		{
			return CropPosition.X;
		}
		set
		{
			if (Drawing != null && !_cropUpdateInProgress)
			{
				_cropUpdateInProgress = true;
				Vector2<double> vector = new Vector2<double>((value - CropLeft).Clamp(0.0 - CropLeft, CropLeftMax - CropLeft), 0.0);
				CropPosition += vector;
				CropSize -= vector;
				_cropUpdateInProgress = false;
			}
		}
	}

	public double CropRight
	{
		get
		{
			return MediaSize.X - (CropPosition.X + CropSize.X);
		}
		set
		{
			if (Drawing != null && !_cropUpdateInProgress)
			{
				_cropUpdateInProgress = true;
				Vector2<double> vector = new Vector2<double>((value - CropRight).Clamp(0.0 - CropRight, CropRightMax - CropRight), 0.0);
				CropSize -= vector;
				_cropUpdateInProgress = false;
			}
		}
	}

	public NativeRotation Rotation
	{
		get
		{
			return Drawing?.NativeRotation ?? NativeRotation.RotateStandard;
		}
		set
		{
			if (Drawing != null)
			{
				Drawing.NativeRotation = value;
			}
		}
	}

	public MediaType MediaType => MediaAction?.Media.MediaType ?? MediaType.Image;

	public double PlayRate
	{
		get
		{
			return Transport?.PlayRate ?? 1.0;
		}
		set
		{
			if (Transport != null)
			{
				Transport.PlayRate = value;
			}
		}
	}

	public PlaybackBehaviorType PlaybackBehavior
	{
		get
		{
			return Transport?.PlaybackBehaviorType ?? PlaybackBehaviorType.Stop;
		}
		set
		{
			if (Transport != null)
			{
				Transport.PlaybackBehaviorType = value;
			}
		}
	}

	public RetriggerBehavior RetriggerBehavior
	{
		get
		{
			return Transport?.RetriggerBehavior ?? RetriggerBehavior.Automatic;
		}
		set
		{
			if (Transport != null)
			{
				Transport.RetriggerBehavior = value;
			}
		}
	}

	public AudioBehaviorType AudioBehaviorType
	{
		get
		{
			CompletionTargetType? completionTargetType = ActiveMediaCue?.CompletionTarget.Type;
			if (completionTargetType.HasValue && completionTargetType == CompletionTargetType.Next)
			{
				return AudioBehaviorType.Next;
			}
			PlaybackBehaviorType? playbackBehaviorType = Transport?.PlaybackBehaviorType;
			AudioBehaviorType result;
			if (playbackBehaviorType.HasValue)
			{
				PlaybackBehaviorType valueOrDefault = playbackBehaviorType.GetValueOrDefault();
				if (valueOrDefault != 0)
				{
					if (valueOrDefault == PlaybackBehaviorType.Loop)
					{
						MediaCue? activeMediaCue = ActiveMediaCue;
						if (activeMediaCue != null && activeMediaCue.CompletionTarget.Type == CompletionTargetType.None)
						{
							result = AudioBehaviorType.Loop;
							goto IL_00be;
						}
					}
				}
				else
				{
					MediaCue? activeMediaCue2 = ActiveMediaCue;
					if (activeMediaCue2 != null && activeMediaCue2.CompletionTarget.Type == CompletionTargetType.None)
					{
						result = AudioBehaviorType.Stop;
						goto IL_00be;
					}
				}
			}
			result = AudioBehaviorType.Stop;
			goto IL_00be;
			IL_00be:
			return result;
		}
		set
		{
			if (Transport != null)
			{
				switch (value)
				{
				case AudioBehaviorType.Stop:
					Transport.PlaybackBehaviorType = PlaybackBehaviorType.Stop;
					ActiveMediaCue.CompletionTarget = new NoTarget();
					break;
				case AudioBehaviorType.Loop:
					Transport.PlaybackBehaviorType = PlaybackBehaviorType.Loop;
					ActiveMediaCue.CompletionTarget = new NoTarget();
					break;
				case AudioBehaviorType.Next:
					Transport.PlaybackBehaviorType = PlaybackBehaviorType.Stop;
					ActiveMediaCue.CompletionTarget = new NextTarget();
					break;
				default:
					throw new NotSupportedException("This behavior type can't be set");
				}
				OnPropertyChanged("AudioBehaviorType");
			}
		}
	}

	public int LoopCount
	{
		get
		{
			return Transport?.LoopCount ?? 0;
		}
		set
		{
			if (Transport != null)
			{
				Transport.LoopCount = value;
			}
		}
	}

	public TimeSlice LoopTime
	{
		get
		{
			return Transport?.LoopTime ?? TimeSlice.Zero;
		}
		set
		{
			if (Transport != null)
			{
				Transport.LoopTime = value;
			}
		}
	}

	public bool SoftLoop
	{
		get
		{
			return Video?.SoftLoop ?? false;
		}
		set
		{
			if (Video != null)
			{
				Video.SoftLoop = value;
				OnPropertyChanged("SoftLoopDuration");
			}
		}
	}

	public EndBehaviorType EndBehavior
	{
		get
		{
			return Video?.EndBehavior ?? EndBehaviorType.HoldLastFrame;
		}
		set
		{
			if (Video != null)
			{
				Video.EndBehavior = value;
			}
		}
	}

	public TimeSlice InPoint
	{
		get
		{
			return Transport?.InPoint ?? TimeSlice.Zero;
		}
		set
		{
			if (Transport != null && MediaAction != null && value != Transport.InPoint)
			{
				Transport.UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.MediaInPoint));
				TimeSlice timeSlice = MediaAction.FileMedia?.Metadata?.Duration ?? TimeSlice.Zero;
				TimeSlice timeSlice2 = value.Clamp(TimeSlice.Zero, timeSlice);
				if (timeSlice2 > Transport.OutPoint)
				{
					Transport.OutPoint = timeSlice;
				}
				Transport.InPoint = timeSlice2;
				Transport.UndoStack?.EndCommit(null, null, autoFinalize: true);
			}
		}
	}

	public TimeSlice OutPoint
	{
		get
		{
			return Transport?.OutPoint ?? TimeSlice.Zero;
		}
		set
		{
			if (Transport != null && MediaAction != null && value != Transport.OutPoint)
			{
				Transport.UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.MediaOutPoint));
				TimeSlice max = MediaAction.FileMedia?.Metadata?.Duration ?? TimeSlice.Zero;
				TimeSlice timeSlice = value.Clamp(TimeSlice.Zero, max);
				if (timeSlice < Transport.InPoint)
				{
					Transport.InPoint = TimeSlice.Zero;
				}
				Transport.OutPoint = timeSlice;
				Transport.UndoStack?.EndCommit(null, null, autoFinalize: true);
			}
		}
	}

	public TimeSlice Duration
	{
		get
		{
			return Transport?.InOutDuration ?? MediaAction?.Duration ?? TimeSlice.Zero;
		}
		set
		{
			if (Transport == null && MediaAction != null)
			{
				MediaAction.Duration = value;
			}
			OnPropertyChanged("Duration");
		}
	}

	public TimeSlice DelayTime
	{
		get
		{
			return MediaAction?.DelayTime ?? TimeSlice.Zero;
		}
		set
		{
			if (MediaAction != null)
			{
				MediaAction.DelayTime = value;
			}
		}
	}

	public TransitionHandler TransitionHandler { get; }

	public TransitionParameters? SelectedTransition
	{
		get
		{
			return MediaAction?.SelectedTransition;
		}
		set
		{
			if (MediaAction != null)
			{
				MediaAction.SelectedTransition = value;
				OnPropertyChanged("SelectedTransition");
			}
		}
	}

	public IEnumerable<AudioBehaviorType> AudioBehaviors => from d in Enum.GetValues<AudioBehaviorType>()
		where d != AudioBehaviorType.Next || SupportsAudioNextBehavior
		select d;

	public bool SupportsAudioNextBehavior
	{
		get
		{
			return _supportsAudioNextBehavior;
		}
		set
		{
			SetValue("SupportsAudioNextBehavior", ref _supportsAudioNextBehavior, value, null, false, "AudioBehaviors", "AudioBehaviorType");
		}
	}

	public bool ShowRetriggeringBehaviorField
	{
		get
		{
			return _showRetriggeringBehaviorField;
		}
		set
		{
			SetValue("ShowRetriggeringBehaviorField", ref _showRetriggeringBehaviorField, value);
		}
	}

	public ICommand SetMediaInPointCommand => _ciMediaControlVM.SetMediaInPointCommand;

	public ICommand SetMediaOutPointCommand => _ciMediaControlVM.SetMediaOutPointCommand;

	public double FrameRate => Video?.FrameRate ?? 0.0;

	public HardwareDecodingBehaviorType HardwareDecodingBehavior
	{
		get
		{
			return Video?.HardwareDecodingBehavior ?? HardwareDecodingBehaviorType.Automatic;
		}
		set
		{
			VideoProperties video = Video;
			if (video != null)
			{
				video.HardwareDecodingBehavior = value;
			}
		}
	}

	public PropertiesVM(ICIMediaControlVM ciMediaControlVM, ICoreManager manager, IUiDispatcher dispatcher, IDebouncerFactory debouncerFactory)
	{
		_ciMediaControlVM = ciMediaControlVM;
		_manager = manager;
		_dispatcher = dispatcher;
		_cropDebouncer = debouncerFactory.Create(delegate
		{
			_dispatcher.Invoke(delegate
			{
				if (Drawing != null)
				{
					Drawing.UpdateCrop(CropPosition, CropSize);
				}
			});
		}, 1000.0);
		LinkProperties("InPoint", "InPoint");
		LinkProperties("OutPoint", "OutPoint");
		LinkProperties("InOutDuration", "Duration");
		_manager.PropertyChanged += base.RaiseLinkedValues;
		LinkProperties("CropSize", new global::_003C_003Ez__ReadOnlyArray<string>(new string[4] { "CropLeftMax", "CropRightMax", "CropTopMax", "CropBottomMax" }));
		TransitionHandler = new TransitionHandler(DataVault.Transitions);
		TransitionHandler.TransitionFinalized += TransitionUpdated;
		LinkProperties("ScaleBehavior", "ScaleBehavior");
		LinkProperties("ScaleAlignment", "ScaleAlignment");
		LinkProperties("FlipHorizontally", "FlipHorizontally");
		LinkProperties("FlipVertically", "FlipVertically");
		LinkProperties("NativeRotation", "Rotation");
		LinkProperties("CropEnable", "CropEnable");
		LinkProperties("EffectiveSize", "MediaSize");
		LinkProperties(new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "CropPosition", "CropSize" }), new global::_003C_003Ez__ReadOnlyArray<string>(new string[10] { "CropSize", "CropPosition", "CropLeft", "CropTop", "CropBottom", "CropRight", "CropLeftMax", "CropRightMax", "CropTopMax", "CropBottomMax" }));
		LinkProperties("PlayRate", "PlayRate");
		LinkProperties("PlaybackBehaviorType", "PlaybackBehavior");
		LinkProperties("LoopCount", "LoopCount");
		LinkProperties("LoopTime", "LoopTime");
		LinkProperties("RetriggerBehavior", "RetriggerBehavior");
		LinkProperties("SoftLoop", "SoftLoop");
		LinkProperties("EndBehavior", "EndBehavior");
		LinkProperties("SoftLoopDuration", "SoftLoopDuration");
		LinkProperties("HardwareDecodingBehavior", "HardwareDecodingBehavior");
		LinkProperties("DelayTime", "DelayTime");
	}

	private void TransitionUpdated(TransitionParameters? newTransition)
	{
		SelectedTransition = newTransition;
	}

	private void UpdateProperties()
	{
		ScaleBehavior = Drawing?.ScaleBehavior ?? ScaleBehavior.ScaleToFit;
		ScaleAlignment = Drawing?.ScaleAlignment ?? ScaleAlignment.TopLeft;
		CropEnable = Drawing?.CropEnable ?? false;
		_cropPosition = Drawing?.CropPosition ?? Vector2<double>.Zero;
		_cropSize = Drawing?.CropSize ?? Vector2<double>.Zero;
		Rotation = Drawing?.NativeRotation ?? NativeRotation.RotateStandard;
		FlipHorizontally = Drawing?.FlipHorizontally ?? false;
		FlipVertically = Drawing?.FlipVertically ?? false;
		PlayRate = Transport?.PlayRate ?? 0.0;
		PlaybackBehavior = Transport?.PlaybackBehaviorType ?? PlaybackBehaviorType.Stop;
		RetriggerBehavior = Transport?.RetriggerBehavior ?? RetriggerBehavior.Automatic;
		AudioBehaviorType audioBehaviorType;
		AudioBehaviorType audioBehaviorType2;
		if (MediaType == MediaType.Audio)
		{
			CompletionTargetType? completionTargetType = ActiveMediaCue?.CompletionTarget.Type;
			if (completionTargetType.HasValue && completionTargetType == CompletionTargetType.Next)
			{
				audioBehaviorType = AudioBehaviorType.Next;
				goto IL_01e4;
			}
			PlaybackBehaviorType? playbackBehaviorType = Transport?.PlaybackBehaviorType;
			if (playbackBehaviorType.HasValue)
			{
				PlaybackBehaviorType valueOrDefault = playbackBehaviorType.GetValueOrDefault();
				if (valueOrDefault != 0)
				{
					if (valueOrDefault == PlaybackBehaviorType.Loop)
					{
						MediaCue? activeMediaCue = ActiveMediaCue;
						if (activeMediaCue != null && activeMediaCue.CompletionTarget.Type == CompletionTargetType.None)
						{
							audioBehaviorType2 = AudioBehaviorType.Loop;
							goto IL_01e2;
						}
					}
				}
				else
				{
					MediaCue? activeMediaCue2 = ActiveMediaCue;
					if (activeMediaCue2 != null && activeMediaCue2.CompletionTarget.Type == CompletionTargetType.None)
					{
						audioBehaviorType2 = AudioBehaviorType.Stop;
						goto IL_01e2;
					}
				}
			}
			audioBehaviorType2 = AudioBehaviorType.Stop;
			goto IL_01e2;
		}
		goto IL_01eb;
		IL_01e4:
		AudioBehaviorType = audioBehaviorType;
		goto IL_01eb;
		IL_01eb:
		LoopCount = Transport?.LoopCount ?? 0;
		LoopTime = Transport?.LoopTime ?? TimeSlice.Zero;
		SoftLoop = Video?.SoftLoop ?? false;
		EndBehavior = Video?.EndBehavior ?? EndBehaviorType.HoldLastFrame;
		DelayTime = MediaAction?.DelayTime ?? TimeSlice.Zero;
		return;
		IL_01e2:
		audioBehaviorType = audioBehaviorType2;
		goto IL_01e4;
	}

	private void MediaActionPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		RaiseLinkedValues(sender, e);
		if (e.PropertyName == "SelectedTransition")
		{
			TransitionHandler.ActivateTransition(SelectedTransition);
		}
	}

	private void MediaCuePropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "CompletionTarget")
		{
			OnPropertyChanged("AudioBehaviorType");
		}
	}

	private void Drawing_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		RaiseLinkedValues(sender, e);
		if (Drawing != null)
		{
			switch (e.PropertyName)
			{
			case "ScaleAlignment":
				_manager.UpdateCIScaleMode(Drawing.ScaleBehavior, Drawing.ScaleAlignment);
				break;
			case "ScaleBehavior":
				_manager.UpdateCIScaleMode(Drawing.ScaleBehavior, Drawing.ScaleAlignment);
				OnPropertyChanged("SupportsScaleAlignment");
				break;
			case "FlipHorizontally":
			case "FlipVertically":
				_manager.UpdateCIFlipMode(Drawing.FlipHorizontally, Drawing.FlipVertically);
				break;
			case "NativeRotation":
				_manager.UpdateCINativeRotation(Drawing.NativeRotation);
				break;
			case "AlphaType":
				_manager.UpdateCIPremultipliedAlpha(Drawing.AlphaType);
				OnPropertyChanged("AlphaType");
				break;
			}
		}
	}

	private void Transport_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		RaiseLinkedValues(sender, e);
		if (Transport != null && e.PropertyName == "PlayRate")
		{
			_manager.UpdateCIPlayRate(Transport.PlayRate);
		}
	}

	private void NotifyDerivedCropProperties()
	{
		OnPropertyChanged("CropLeftMax");
		OnPropertyChanged("CropTopMax");
		OnPropertyChanged("CropRightMax");
		OnPropertyChanged("CropBottomMax");
		OnPropertyChanged("CropLeft");
		OnPropertyChanged("CropTop");
		OnPropertyChanged("CropRight");
		OnPropertyChanged("CropBottom");
	}
}
