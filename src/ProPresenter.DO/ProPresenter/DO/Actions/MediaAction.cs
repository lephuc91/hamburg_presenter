using System;
using System.ComponentModel;
using System.Reactive;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.Nullability;
using Pro.Common.ObjectBinding;
using Pro.Common.Time;
using Pro.Common.Utility;
using Pro.DO.Application;
using Pro.DO.Transitions;
using Pro.DO.Triggering;
using Pro.Entity;
using Pro.Entity.Collections;
using Pro.Entity.Extensions;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Media;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Transitions;

namespace ProPresenter.DO.Actions;

public class MediaAction : ActionBase, IScrimSource, ITimelineItem, ITriggerable, INotifyPropertyChanged, ICanReceiveMediaContainerIdUpdates
{
	private readonly IApp _app;

	private readonly ITransitionDescriptionCollection _transitionDescriptions;

	private TransitionParameters? _selectedTransition;

	private TriggerLayer _triggerLayer;

	public override ActionType ActionType => ActionType.Media;

	public ScrimPosition Position => ScrimPosition.TopLeft;

	public DisplayMode DisplayMode => DisplayMode.Label;

	public bool IsEditable => true;

	public ListViewType ListViewType => ListViewType.Content;

	public bool IsGraphicMedia
	{
		get
		{
			MediaBase media = Media;
			if (media != null)
			{
				MediaType mediaType = media.MediaType;
				if ((uint)mediaType <= 1u)
				{
					return true;
				}
			}
			return false;
		}
	}

	public bool IsAudioMedia
	{
		get
		{
			MediaBase media = Media;
			if (media != null)
			{
				return media.MediaType == MediaType.Audio;
			}
			return false;
		}
	}

	public bool IsVideoMedia
	{
		get
		{
			MediaBase media = Media;
			if (media != null)
			{
				return media.MediaType == MediaType.Video;
			}
			return false;
		}
	}

	public bool HasDuration
	{
		get
		{
			if (!IsAudioMedia)
			{
				return IsVideoMedia;
			}
			return true;
		}
	}

	public MediaBase Media { get; }

	public FileMediaBase? FileMedia => Media as FileMediaBase;

	public AudioMedia? AudioMedia => Media as AudioMedia;

	public VisualMedia? VisualMedia => Media as VisualMedia;

	public VideoMedia? VideoMedia => Media as VideoMedia;

	public LiveVideoMedia? LiveVideo => Media as LiveVideoMedia;

	public WebMedia? WebMedia => Media as WebMedia;

	public override bool IsValid => Media.IsValid;

	public bool IsTransitionSupported
	{
		get
		{
			MediaBase media = Media;
			if (media != null)
			{
				MediaType mediaType = media.MediaType;
				if ((uint)mediaType <= 2u)
				{
					return true;
				}
			}
			return false;
		}
	}

	protected override string DefaultName
	{
		get
		{
			MediaBase media = Media;
			if (media == null || media.MediaType != MediaType.LiveVideo)
			{
				return string.Empty;
			}
			return LocalizedStrings.Get(ActionType.LiveVideo);
		}
	}

	public TransitionParameters? SelectedTransition
	{
		get
		{
			return _selectedTransition;
		}
		set
		{
			if ((object)_selectedTransition != value && ((object)_selectedTransition == null || (object)value == null || ((object)_selectedTransition != null && !_selectedTransition.Equals(value, ignoreDuration: false, ignoreName: false))))
			{
				TransitionParameters selectedTransition = _selectedTransition;
				_selectedTransition = value;
				base.UndoStack?.Commit(UndoActionTypes.MediaTransition.ToAction(), this, "SelectedTransition", selectedTransition, value, null, null, autoFinalize: true);
				OnPropertyChanged("SelectedTransition");
				OnDataModified();
			}
		}
	}

	public TriggerLayer TriggerLayer
	{
		get
		{
			return _triggerLayer;
		}
		set
		{
			if (Media.MediaType == MediaType.Audio)
			{
				throw new InvalidOperationException();
			}
			SetValue("TriggerLayer", ref _triggerLayer, value, delegate(TriggerLayer o, TriggerLayer n)
			{
				base.UndoStack?.Commit(UndoActionTypes.TriggerLayer.ToAction(), this, "TriggerLayer", o, n, null, null, autoFinalize: true);
				OnDataModified();
			});
		}
	}

	public PlaybackMarkerCollection PlaybackMarkers { get; }

	public TimeSlice MediaDuration => (Media as ITransportMedia)?.Transport.InOutDuration ?? base.Duration;

	public TimelineItemType TimelineItemType
	{
		get
		{
			if (Media.MediaType != MediaType.Audio)
			{
				if (Media.MediaType != 0 && Media.MediaType != MediaType.Video)
				{
					return TimelineItemType.Actions;
				}
				return TimelineItemType.VisualMedia;
			}
			return TimelineItemType.AudioMedia;
		}
	}

	public sealed override string ContainerId => (Media as FileMediaBase)?.ContainerId ?? "";

	public event System.Action? VisualInvalidated;

	public static ObjectBinder<Pro.DO.Triggering.IAction, Pro.Entity.IAction> CreateBinder(IUiScheduler scheduler, IEntityFactory entityFactory, IActionBinderFactory actionBinderFactory, MediaAction left, Pro.Entity.IAction right)
	{
		ObjectBinder<Pro.DO.Triggering.IAction, Pro.Entity.IAction> objectBinder = ActionBase.CreateBinder(scheduler, entityFactory, left, right, delegate
		{
		});
		Pro.Entity.IAction.Types.IActionTypeData.IMedia media = right.ActionTypeData.Value as Pro.Entity.IAction.Types.IActionTypeData.IMedia;
		if (media == null)
		{
			media = entityFactory.Create<Pro.Entity.IAction.Types.IActionTypeData.IMedia>();
			right.ActionTypeData.Set(media);
		}
		ObjectBinder<PlaybackMarkerCollection, IComplexCollection<Pro.Entity.IAction.Types.IMediaType.Types.IPlaybackMarker>> playbackMarkerBinders = PlaybackMarkerCollection.CreateBinder(scheduler, entityFactory, actionBinderFactory, left.PlaybackMarkers, media.Value.Markers);
		ObjectBinder<MediaAction, Pro.Entity.IAction.Types.IMediaType> binder = new ObjectBinder<MediaAction, Pro.Entity.IAction.Types.IMediaType>(left, media.Value);
		binder.Bind((MediaAction l) => l.WhenPropertyChanges("Media"), (Pro.Entity.IAction.Types.IMediaType r) => r.Element.WhenValueChanges, delegate(MediaAction l, Pro.Entity.IAction.Types.IMediaType r)
		{
			IMedia media2 = entityFactory.Create<IMedia>();
			r.Element.Set(media2);
			ObjectBinder<MediaBase, IMedia> objectBinder2 = left.Media.CreateBinder(scheduler, entityFactory, media2);
			objectBinder2.InitializeRightFromLeft();
			media2.RegisterLinkedDisposable(objectBinder2);
		}, delegate(Pro.Entity.IAction.Types.IMediaType r, MediaAction l)
		{
			ObjectBinder<MediaBase, IMedia> objectBinder3 = left.Media.CreateBinder(scheduler, entityFactory, r.Element.Value);
			objectBinder3.InitializeLeftFromRight();
			r.Element.Value.RegisterLinkedDisposable(objectBinder3);
		}, null, scheduler.Scheduler).Bind((MediaAction l) => l.WhenPropertyChanges("SelectedTransition"), (Pro.Entity.IAction.Types.IMediaType r) => r.Transition.WhenValueChanges, delegate(MediaAction l, Pro.Entity.IAction.Types.IMediaType r)
		{
			if ((object)l.SelectedTransition == null)
			{
				r.Transition.Set(null);
			}
			ITransition transition = entityFactory.Create<ITransition>();
			r.Transition.Set(transition);
			ObjectBinder<TransitionParameters, ITransition> objectBinder4 = TransitionParameters.CreateBinder(entityFactory, l.SelectedTransition, r.Transition.Value);
			objectBinder4.InitializeRightFromLeft();
			transition.RegisterLinkedDisposable(objectBinder4);
		}, delegate(Pro.Entity.IAction.Types.IMediaType r, MediaAction l)
		{
			if (r.Transition.Value == null)
			{
				l.SelectedTransition = null;
			}
			else
			{
				ObjectBinder<TransitionParameters, ITransition> objectBinder5 = TransitionParameters.CreateBinder(entityFactory, l.SelectedTransition, r.Transition.Value);
				objectBinder5.InitializeLeftFromRight();
				r.Transition.Value.RegisterLinkedDisposable(objectBinder5);
			}
		}).Bind((MediaAction l) => l.WhenPropertyChanges("TriggerLayer"), (Pro.Entity.IAction.Types.IMediaType r) => r.LayerType.WhenValueChanges, delegate(MediaAction l, Pro.Entity.IAction.Types.IMediaType r)
		{
			r.LayerType.Set(l.TriggerLayer.ToEntityLayerType());
		}, delegate(Pro.Entity.IAction.Types.IMediaType r, MediaAction l)
		{
			l._triggerLayer = r.LayerType.Value.ToTriggerLayer();
			l.OnPropertyChanged("TriggerLayer");
		})
			.Bind<Unit, Unit>(null, (Pro.Entity.IAction.Types.IMediaType r) => r._MediaType.WhenValueChanges.ToUnit(), delegate(MediaAction l, Pro.Entity.IAction.Types.IMediaType r)
			{
				Pro.Entity.IAction.Types.IMediaType.Types.IMediaType.IAudio audio = entityFactory.Create<Pro.Entity.IAction.Types.IMediaType.Types.IMediaType.IAudio>();
				r._MediaType.Set(audio);
				ObjectBinder<AudioMedia, Pro.Entity.IAction.Types.IMediaType.Types.IMediaType.IAudio> objectBinder6 = ProPresenter.DO.Media.AudioMedia.CreateMediaTypeBinder(l.Media as AudioMedia, audio);
				objectBinder6.InitializeRightFromLeft();
				audio.Value.RegisterLinkedDisposable(objectBinder6);
			}, delegate(Pro.Entity.IAction.Types.IMediaType r, MediaAction l)
			{
				if (r._MediaType.Value is Pro.Entity.IAction.Types.IMediaType.Types.IMediaType.IAudio audio2)
				{
					ObjectBinder<AudioMedia, Pro.Entity.IAction.Types.IMediaType.Types.IMediaType.IAudio> objectBinder7 = ProPresenter.DO.Media.AudioMedia.CreateMediaTypeBinder(l.Media as AudioMedia, audio2);
					objectBinder7.InitializeLeftFromRight();
					audio2.Value.RegisterLinkedDisposable(objectBinder7);
				}
			}, null, scheduler.Scheduler)
			.DoOnInitializeRightFromLeft(playbackMarkerBinders.InitializeRightFromLeft)
			.DoOnInitializeLeftFromRight(playbackMarkerBinders.InitializeLeftFromRight)
			.RegisterChildDisposable(() => playbackMarkerBinders);
		objectBinder.DoOnInitializeRightFromLeft(binder.InitializeRightFromLeft).DoOnInitializeLeftFromRight(binder.InitializeLeftFromRight).RegisterChildDisposable(() => binder);
		return objectBinder;
	}

	public MediaAction(MediaBase media, IApp app, ITransitionDescriptionCollection transitionDescriptions)
	{
		Media = media;
		_app = app;
		_transitionDescriptions = transitionDescriptions;
		PlaybackMarkers = new PlaybackMarkerCollection(app, ContainerId);
		Media.DataModified += Media_DataModified;
		Media.UpdateActionName += Media_UpdateActionName;
		Media.VisualInvalidated += Media_VisualInvalidated;
		if (media is FileMediaBase fileMediaBase)
		{
			if (!fileMediaBase.MetadataLoaded)
			{
				fileMediaBase.MetadataLoadSuccessful += Media_MetadataLoadSuccessful;
			}
			else
			{
				Media_MetadataLoadSuccessful(fileMediaBase);
			}
		}
		_triggerLayer = media.MediaType.ToTriggerLayer();
		LinkProperties("InOutDuration", "MediaDuration");
		LinkProperties("IsValid", "IsValid");
		if (media is ITransportMedia transportMedia)
		{
			transportMedia.Transport.PropertyChanged += base.RaiseLinkedValues;
		}
		Media.PropertyChanged += base.RaiseLinkedValues;
		PlaybackMarkers.DataModified += base.OnDataModified;
	}

	protected override void OnDurationChanged(TimeSlice oldDuration, TimeSlice newDuration)
	{
		OnPropertyChanged("MediaDuration");
	}

	private void Media_MetadataLoadSuccessful(FileMediaBase media)
	{
		media.MetadataLoadSuccessful -= Media_MetadataLoadSuccessful;
		if (string.IsNullOrEmpty(base.Name))
		{
			base.Name = media.SourceFile.Filename;
		}
		OnPropertyChanged("IsValid");
	}

	public override Pro.DO.Triggering.IAction Clone()
	{
		MediaAction clonedAction = CopyProperties(new MediaAction(Media.Clone(), _app, _transitionDescriptions)
		{
			SelectedTransition = _selectedTransition?.CloneTransitionParameters()
		});
		PlaybackMarkers.ForEach(delegate(IPlaybackMarker m)
		{
			clonedAction.PlaybackMarkers.AddMarker(m.Clone());
		});
		if (clonedAction.Media.MediaType != MediaType.Audio)
		{
			clonedAction.TriggerLayer = _triggerLayer;
		}
		if (clonedAction.Media is ITransportMedia transportMedia && Media is ITransportMedia transportMedia2)
		{
			transportMedia.Transport.RetriggerBehavior = transportMedia2.Transport.RetriggerBehavior;
		}
		return clonedAction;
	}

	public override void Deserialize(Pro.SerializationInterop.RVProtoData.Action data, ApplicationData? applicationData, string containerId)
	{
		base.Deserialize(data, applicationData, containerId);
		if (Media is IFileMedia fileMedia)
		{
			fileMedia.ProtoDeserialize(data.Media.Element, containerId);
		}
		else
		{
			Media.ProtoDeserialize(data.Media.Element);
		}
		PlaybackMarkers.UpdateContainerId(containerId);
		PlaybackMarkers.Deserialize(data.Media, applicationData);
		SelectedTransition = data.Media.Transition?.ToTransition(_transitionDescriptions);
		base.DelayTime = TimeSlice.FromSeconds(data.DelayTime);
		_triggerLayer = data.Media.LayerType.ToTriggerLayer();
		if (Media is ITransportMedia transportMedia && transportMedia.Transport.RetriggerBehavior == RetriggerBehavior.Unset)
		{
			transportMedia.Transport.RetriggerBehavior = (data.Media.AlwaysRetrigger ? RetriggerBehavior.Automatic : RetriggerBehavior.Never);
		}
		if (Media.MediaType == MediaType.Audio && AudioMedia != null)
		{
			AudioMedia.AudioType = data.Media.Audio?.AudioType.ToAudioType() ?? AudioType.AudioTrack;
		}
	}

	public override Pro.SerializationInterop.RVProtoData.Action Serialize()
	{
		Pro.SerializationInterop.RVProtoData.Action action = base.Serialize();
		action.Type = Pro.SerializationInterop.RVProtoData.Action.Types.ActionType.Media;
		action.Media = new Pro.SerializationInterop.RVProtoData.Action.Types.MediaType
		{
			Element = Media.ProtoSerialize(),
			Transition = SelectedTransition?.Serialize(),
			LayerType = TriggerLayer.ToProtoLayerType()
		};
		if (this is ITransportMedia transportMedia)
		{
			action.Media.AlwaysRetrigger = transportMedia.Transport.RetriggerBehavior == RetriggerBehavior.Always;
		}
		PlaybackMarkers.Serialize(action.Media);
		switch (Media.MediaType)
		{
		case MediaType.Image:
			action.Media.Image = new Pro.SerializationInterop.RVProtoData.Action.Types.MediaType.Types.Image();
			break;
		case MediaType.Video:
			action.Media.Video = new Pro.SerializationInterop.RVProtoData.Action.Types.MediaType.Types.Video();
			action.DelayTime = base.DelayTime.TotalSeconds;
			break;
		case MediaType.Audio:
			if (AudioMedia != null)
			{
				action.Media.Audio = new Pro.SerializationInterop.RVProtoData.Action.Types.MediaType.Types.Audio
				{
					AudioType = AudioMedia.AudioType.ToProtoAudioType()
				};
			}
			break;
		case MediaType.LiveVideo:
			action.Media.LiveVideo = new Pro.SerializationInterop.RVProtoData.Action.Types.MediaType.Types.LiveVideo();
			break;
		}
		return action;
	}

	private void Media_DataModified(MediaBase media)
	{
		OnDataModified();
	}

	private void Media_UpdateActionName(string oldDefaultName, string newDefaultName)
	{
		if (base.Name == oldDefaultName)
		{
			base.Name = newDefaultName;
		}
	}

	private void Media_VisualInvalidated()
	{
		this.VisualInvalidated?.Invoke();
	}

	public static MediaAction ConstructMediaAction(Pro.SerializationInterop.RVProtoData.Action? data, IApp app, IMediaFactory mediaFactory, ITransitionDescriptionCollection transitionDescriptions, string containerId)
	{
		data.ThrowWhenNull("data");
		data.Media.ThrowWhenNull("data.Media");
		data.Media.Element.ThrowWhenNull("data.Media.Element");
		return new MediaAction(ConstructMedia(data.Media.Element.TypePropertiesCase, mediaFactory, containerId), app, transitionDescriptions);
	}

	private static MediaBase ConstructMedia(Pro.SerializationInterop.RVProtoData.Media.TypePropertiesOneofCase protoMediaType, IMediaFactory mediaFactory, string containerId)
	{
		return protoMediaType switch
		{
			Pro.SerializationInterop.RVProtoData.Media.TypePropertiesOneofCase.Audio => mediaFactory.CreateAudioMedia(containerId, null), 
			Pro.SerializationInterop.RVProtoData.Media.TypePropertiesOneofCase.Image => mediaFactory.CreateVisualMedia(containerId, null), 
			Pro.SerializationInterop.RVProtoData.Media.TypePropertiesOneofCase.Video => mediaFactory.CreateVideoMedia(containerId, null), 
			Pro.SerializationInterop.RVProtoData.Media.TypePropertiesOneofCase.LiveVideo => mediaFactory.CreateLiveVideoMedia(), 
			Pro.SerializationInterop.RVProtoData.Media.TypePropertiesOneofCase.WebContent => mediaFactory.CreateWebMedia(), 
			_ => throw new ArgumentOutOfRangeException("protoMediaType", protoMediaType, "Value not supported"), 
		};
	}

	protected override void OnUndoStackChanged(UndoStack undoStack)
	{
		base.OnUndoStackChanged(undoStack);
		Media.UndoStack = undoStack;
		PlaybackMarkers.UndoStack = undoStack;
	}

	public void UpdateContainerId(string newContainerId)
	{
		if (Media is ICanReceiveMediaContainerIdUpdates canReceiveMediaContainerIdUpdates)
		{
			canReceiveMediaContainerIdUpdates.UpdateContainerId(newContainerId);
		}
		PlaybackMarkers.UpdateContainerId(newContainerId);
	}
}
