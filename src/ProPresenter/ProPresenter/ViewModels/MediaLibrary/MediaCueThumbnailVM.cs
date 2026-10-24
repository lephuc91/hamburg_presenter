using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Time;
using Pro.DO.Label;
using Pro.DO.Triggering;
using Pro.DO.Triggering.CompletionTargets;
using Pro.ssAPI;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.DO.LiveVideo;
using ProPresenter.DO.Media;
using ProPresenter.DO.Media.Properties;
using ProPresenter.DO.PanelSourcing;
using ProPresenter.DO.Transition;
using ProPresenter.UI.ViewModels.MediaLibrary;
using ProPresenter.UI.ViewModels.Thumbnails;

namespace ProPresenter.ViewModels.MediaLibrary;

public class MediaCueThumbnailVM : LinkedObservableObjectBase, IMediaCueThumbnailVM, IThumbnailVM, IThumbnailSource, INotifyPropertyChanged, IUniformViewSource, ITriggerable
{
	[CompilerGenerated]
	private sealed class _003Cget_ScrimItems_003Ed__44 : IEnumerable<IScrimSource>, IEnumerable, IEnumerator<IScrimSource>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private IScrimSource _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public MediaCueThumbnailVM _003C_003E4__this;

		IScrimSource IEnumerator<IScrimSource>.Current
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
		public _003Cget_ScrimItems_003Ed__44(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			MediaCueThumbnailVM mediaCueThumbnailVM = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				if (mediaCueThumbnailVM.MediaAction == null)
				{
					return false;
				}
				if (mediaCueThumbnailVM.MediaCue.CompletionTarget != null && !(mediaCueThumbnailVM.MediaCue.CompletionTarget is NoTarget))
				{
					_003C_003E2__current = new NextCueScrimItem(mediaCueThumbnailVM.MediaCue.CompletionTarget.Type);
					_003C_003E1__state = 1;
					return true;
				}
				goto IL_0089;
			case 1:
				_003C_003E1__state = -1;
				goto IL_0089;
			case 2:
				_003C_003E1__state = -1;
				goto IL_0114;
			case 3:
				_003C_003E1__state = -1;
				if (mediaCueThumbnailVM.MediaAction.SelectedTransition != null)
				{
					_003C_003E2__current = new TransitionScrimItem(mediaCueThumbnailVM.MediaAction.SelectedTransition, isMediaTransition: true);
					_003C_003E1__state = 4;
					return true;
				}
				goto IL_0174;
			case 4:
				_003C_003E1__state = -1;
				goto IL_0174;
			case 5:
				{
					_003C_003E1__state = -1;
					break;
				}
				IL_0089:
				if (mediaCueThumbnailVM.MediaAction.Media is ITransportMedia transportMedia && mediaCueThumbnailVM.MediaAction.Media is IVideoMedia videoMedia && transportMedia.Transport.PlaybackBehaviorType != 0 && mediaCueThumbnailVM.MediaCue.CompletionTarget != null && mediaCueThumbnailVM.MediaCue.CompletionTarget.Type == CompletionTargetType.None)
				{
					IScrimSource scrimSource2;
					if (!videoMedia.Video.SoftLoop)
					{
						IScrimSource scrimSource = new PlaybackScrimItem();
						scrimSource2 = scrimSource;
					}
					else
					{
						IScrimSource scrimSource = new SoftLoopPlaybackScrimItem();
						scrimSource2 = scrimSource;
					}
					_003C_003E2__current = scrimSource2;
					_003C_003E1__state = 2;
					return true;
				}
				goto IL_0114;
				IL_0174:
				if (mediaCueThumbnailVM.MediaAction.MediaDuration > TimeSlice.Zero)
				{
					_003C_003E2__current = new VideoDurationScrimItem(mediaCueThumbnailVM.MediaAction.MediaDuration);
					_003C_003E1__state = 5;
					return true;
				}
				break;
				IL_0114:
				_003C_003E2__current = new MediaScrimItem(mediaCueThumbnailVM.MediaAction.TriggerLayer);
				_003C_003E1__state = 3;
				return true;
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<IScrimSource> IEnumerable<IScrimSource>.GetEnumerator()
		{
			_003Cget_ScrimItems_003Ed__44 result;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				result = this;
			}
			else
			{
				result = new _003Cget_ScrimItems_003Ed__44(0)
				{
					_003C_003E4__this = _003C_003E4__this
				};
			}
			return result;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<IScrimSource>)this).GetEnumerator();
		}
	}

	[ObservableProperty]
	private int _index;

	public MediaCue MediaCue { get; }

	private MediaAction? MediaAction => MediaCue.MediaAction;

	public string Name
	{
		get
		{
			return MediaCue.Name;
		}
		set
		{
			MediaCue.Name = value;
		}
	}

	public bool IsEnabled => MediaCue.IsEnabled;

	public bool IsMediaPending => (from x in MediaCue.Actions.OfType<MediaAction>()
		select x.Media).OfType<IFileMedia>().Any((IFileMedia x) => x.IsPending && x.IsValid);

	public bool IsValid => MediaCue.MediaAction?.IsValid ?? false;

	public Color BackgroundColor => Colors.Transparent;

	public LiveVideoInput? LiveVideoInput => MediaCue.LiveVideoInput;

	public string LabelName => string.Empty;

	public Color LabelColor => Colors.Transparent;

	public Brush LabelForeground => Brushes.Black;

	public GroupLabel? GroupLabel => null;

	public bool ShowGroupLabel => false;

	public bool ShowIndex => true;

	public int BuildCount => 0;

	public int BuildPosition => 0;

	public ScaleBehavior ScaleBehavior => (MediaAction?.Media as IDrawMedia)?.Drawing.ScaleBehavior ?? ScaleBehavior.ScaleToFit;

	public ScaleAlignment ScaleAlignment => (MediaAction?.Media as IDrawMedia)?.Drawing.EffectiveScaleAlignment ?? ScaleAlignment.MiddleCenter;

	public bool CanRename => true;

	public double ThumbnailAspectRatio => MediaCue.ThumbnailAspectRatio;

	public IEnumerable<IScrimSource> ScrimItems
	{
		[IteratorStateMachine(typeof(_003Cget_ScrimItems_003Ed__44))]
		get
		{
			//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
			return new _003Cget_ScrimItems_003Ed__44(-2)
			{
				_003C_003E4__this = this
			};
		}
	}

	public IMediaOverlayVM? MediaOverlayVM { get; }

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int Index
	{
		get
		{
			return _index;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_index, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Index);
				_index = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Index);
			}
		}
	}

	public event Action? VisualInvalidated;

	public MediaCueThumbnailVM(MediaCue mediaCue, IMediaCueThumbnailOverlayVM? overlayVM)
	{
		MediaCue = mediaCue;
		LinkProperties(new string[9] { "CompletionTarget", "PlaybackBehaviorType", "InOutDuration", "IsDeviceConnected", "SoftLoop", "SelectedTransition", "Duration", "TriggerLayer", "Metadata" }, "ScrimItems");
		LinkProperties("Name", "Name");
		LinkProperties("IsEnabled", "IsEnabled");
		LinkProperties("LiveVideoInput", "LiveVideoInput");
		LinkProperties("ScaleBehavior", "ScaleBehavior");
		LinkProperties("EffectiveScaleAlignment", "ScaleAlignment");
		LinkProperties(new string[2] { "SourceFile", "IsValid" }, "IsValid");
		LinkProperties(new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "IsPending", "IsValid" }), "IsMediaPending");
		MediaCue.PropertyChanged += base.RaiseLinkedValues;
		MediaCue.Actions.CollectionChanged += Actions_CollectionChanged;
		MediaCue.VisualInvalidated += OnVisualInvalidated;
		MediaCue.Actions.OfType<MediaAction>().ForEach(RegisterForMediaChanges);
		MediaOverlayVM = overlayVM;
	}

	private void Actions_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.OfType<MediaAction>().ForEach(UnRegisterForMediaChanges);
		e.NewItems?.OfType<MediaAction>().ForEach(RegisterForMediaChanges);
		OnPropertyChanged("ScrimItems");
	}

	private void UnRegisterForMediaChanges(MediaAction action)
	{
		MediaBase media = action.Media;
		TransportProperties transportProperties = (media as ITransportMedia)?.Transport;
		LiveVideoProperties liveVideoProperties = (media as ILiveVideoMedia)?.LiveVideo;
		VideoProperties videoProperties = (media as IVideoMedia)?.Video;
		DrawingProperties drawingProperties = (media as IDrawMedia)?.Drawing;
		action.PropertyChanged -= base.RaiseLinkedValues;
		media.PropertyChanged -= base.RaiseLinkedValues;
		if (transportProperties != null)
		{
			transportProperties.PropertyChanged -= base.RaiseLinkedValues;
		}
		if (liveVideoProperties != null)
		{
			liveVideoProperties.VideoInputChanged -= LiveVideo_VideoInputChanged;
		}
		if (videoProperties != null)
		{
			videoProperties.PropertyChanged -= base.RaiseLinkedValues;
		}
		if (drawingProperties != null)
		{
			drawingProperties.PropertyChanged -= base.RaiseLinkedValues;
		}
	}

	private void RegisterForMediaChanges(MediaAction action)
	{
		MediaBase media = action.Media;
		TransportProperties transportProperties = (media as ITransportMedia)?.Transport;
		LiveVideoProperties liveVideoProperties = (media as ILiveVideoMedia)?.LiveVideo;
		VideoProperties videoProperties = (media as IVideoMedia)?.Video;
		DrawingProperties drawingProperties = (media as IDrawMedia)?.Drawing;
		action.PropertyChanged += base.RaiseLinkedValues;
		media.PropertyChanged += base.RaiseLinkedValues;
		if (transportProperties != null)
		{
			transportProperties.PropertyChanged += base.RaiseLinkedValues;
		}
		if (liveVideoProperties != null)
		{
			liveVideoProperties.VideoInputChanged += LiveVideo_VideoInputChanged;
		}
		if (videoProperties != null)
		{
			videoProperties.PropertyChanged += base.RaiseLinkedValues;
		}
		if (drawingProperties != null)
		{
			drawingProperties.PropertyChanged += base.RaiseLinkedValues;
		}
	}

	private void LiveVideo_VideoInputChanged(LiveVideoInput? oldInput, LiveVideoInput? newInput)
	{
		if (oldInput != null)
		{
			oldInput.PropertyChanged -= base.RaiseLinkedValues;
		}
		if (newInput != null)
		{
			newInput.PropertyChanged += base.RaiseLinkedValues;
		}
		OnPropertyChanged("Name");
		OnPropertyChanged("ScrimItems");
		OnPropertyChanged("LiveVideoInput");
	}

	private void OnVisualInvalidated()
	{
		this.VisualInvalidated?.Invoke();
	}

	public void UpdateIndex(int index)
	{
		Index = index;
	}
}
