using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Application;
using Pro.DO.Storage;
using Pro.DO.Transitions;
using Pro.DO.Triggering;
using Pro.DO.Triggering.CompletionTargets;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;
using Pro.ssAPI;
using ProPresenter.DO.Actions;
using ProPresenter.DO.LiveVideo;
using ProPresenter.DO.Media;
using ProPresenter.DO.Media.Properties;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Settings;

namespace ProPresenter.DO.Cues;

public class MediaCue : ProPresenterCue, IMediaCue, IFileResource, IHasMediaContainerId, ICloneable<MediaCue>, ITimelineItem, ITriggerable, INotifyPropertyChanged
{
	private readonly bool _supportsPlaybackMarkers;

	public override CueType Type => CueType.Media;

	public MediaAction? MediaAction => base.Actions.FirstOrDefaultOf<MediaAction>();

	public LiveVideoInput? LiveVideoInput => (MediaAction?.Media as LiveVideoMedia)?.LiveVideo.Input;

	public double ThumbnailAspectRatio => 1.7777777777777777;

	public TimelineItemType TimelineItemType => TimelineItemType.VisualMedia;

	public RelativePath Path => MediaAction?.FileMedia?.SourceFile ?? RelativePath.Empty();

	public bool SupportsPlaybackMarkers
	{
		get
		{
			if (_supportsPlaybackMarkers && MediaAction?.Media != null)
			{
				if (MediaAction.Media.MediaType != MediaType.Video)
				{
					return MediaAction.Media.MediaType == MediaType.Audio;
				}
				return true;
			}
			return false;
		}
	}

	public event System.Action? VisualInvalidated;

	public override IReadOnlyObjectBinder<ProPresenterCue, IPlaylistItem> Bind(IUiScheduler scheduler, IEntityFactory entityFactory, IActionBinderFactory actionBinderFactory, IPlaylistItem right)
	{
		IPlaylistItem.Types.IItemType.ICue cue = right.ItemType.Value as IPlaylistItem.Types.IItemType.ICue;
		if (cue == null)
		{
			cue = entityFactory.Create<IPlaylistItem.Types.IItemType.ICue>();
			right.ItemType.Set(cue);
		}
		ObjectBinder<Pro.DO.Triggering.Cue, ICue> baseBinder = Pro.DO.Triggering.Cue.CreateBinder(scheduler, entityFactory, actionBinderFactory, this, cue.Value);
		ObjectBinder<MediaCue, IPlaylistItem> objectBinder = new ObjectBinder<MediaCue, IPlaylistItem>(this, right);
		objectBinder.Bind((MediaCue l) => l.WhenPropertyChanges("ID"), (IPlaylistItem r) => r.Uuid.WhenValueChanges, delegate(MediaCue l, IPlaylistItem r)
		{
			r.Uuid.Set(l.ID);
		}, delegate(IPlaylistItem r, MediaCue l)
		{
			l.ID = r.Uuid.Value;
		});
		objectBinder.Bind((MediaCue l) => l.WhenPropertyChanges("Name"), (IPlaylistItem r) => r.Name.WhenValueChanges, delegate(MediaCue l, IPlaylistItem r)
		{
			r.Name.Set(l.Name);
		}, delegate(IPlaylistItem r, MediaCue l)
		{
			l.Name = r.Name.Value;
		});
		objectBinder.DoOnInitializeLeftFromRight(baseBinder.InitializeLeftFromRight).DoOnInitializeRightFromLeft(baseBinder.InitializeRightFromLeft).RegisterChildDisposable(() => baseBinder);
		return objectBinder;
	}

	public MediaCue(MediaAction? action, bool supportsPlaybackMarkers = true, string containerId = "")
	{
		base.Actions.CollectionChanged += Actions_CollectionChanged;
		UpdateContainerId((!(containerId == "")) ? containerId : (action?.ContainerId ?? ""));
		UndoStack = action?.UndoStack;
		UndoStack?.StartIgnoring();
		if (action != null)
		{
			Name = action.Name;
			AddAction(action);
		}
		base.CompletionAction = CompletionAction.First;
		LinkAction("Name", delegate
		{
			Name = MediaAction?.Name ?? string.Empty;
		});
		LinkAction("PlaybackBehaviorType", delegate
		{
			if (MediaAction?.Media is ITransportMedia transportMedia && (transportMedia.Transport.PlaybackBehaviorType == PlaybackBehaviorType.Loop || (MediaAction.Media is IVideoMedia videoMedia && videoMedia.Video.SoftLoop)))
			{
				base.CompletionTarget = new NoTarget();
			}
		});
		_supportsPlaybackMarkers = supportsPlaybackMarkers;
		UndoStack?.StopIgnoring();
	}

	public MediaCue(IApp app, MediaBase? media, ITransitionDescriptionCollection transitionDescriptions, bool supportsPlaybackMarkers = true)
		: this((media == null) ? null : new MediaAction(media, app, transitionDescriptions), supportsPlaybackMarkers)
	{
	}

	public MediaCue(string containerId)
		: this(null, supportsPlaybackMarkers: true, containerId)
	{
	}

	private void Actions_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.OfType<MediaAction>().ForEach(TeardownAction);
		e.NewItems?.OfType<MediaAction>().ForEach(SetupAction);
	}

	private void TeardownAction(MediaAction action)
	{
		MediaBase media = action.Media;
		TransportProperties transportProperties = (media as ITransportMedia)?.Transport;
		action.PropertyChanged -= base.RaiseLinkedValues;
		action.VisualInvalidated -= OnVisualInvalidated;
		media.PropertyChanged -= base.RaiseLinkedValues;
		if (transportProperties != null)
		{
			transportProperties.PropertyChanged -= base.RaiseLinkedValues;
		}
	}

	private void SetupAction(MediaAction action)
	{
		MediaBase media = action.Media;
		TransportProperties transportProperties = (media as ITransportMedia)?.Transport;
		action.PropertyChanged += base.RaiseLinkedValues;
		action.VisualInvalidated += OnVisualInvalidated;
		media.PropertyChanged += base.RaiseLinkedValues;
		if (transportProperties != null)
		{
			transportProperties.PropertyChanged += base.RaiseLinkedValues;
		}
	}

	protected override void OnNameChanged(string oldName, string newName)
	{
		if (MediaAction != null)
		{
			MediaAction.Name = Name;
		}
	}

	protected override void OnCompletionTargetChanged(CompletionTargetBase oldCompletionTarget, CompletionTargetBase newCompletionTarget)
	{
		if (newCompletionTarget.Type != 0 && MediaAction?.Media is ITransportMedia transportMedia && transportMedia.Transport.PlaybackBehaviorType == PlaybackBehaviorType.Loop && MediaAction.Media is IVideoMedia videoMedia)
		{
			videoMedia.Video.SoftLoop = false;
			transportMedia.Transport.PlaybackBehaviorType = PlaybackBehaviorType.Stop;
		}
	}

	MediaCue ICloneable<MediaCue>.Clone()
	{
		return (MediaCue)Clone();
	}

	public override Pro.DO.Triggering.Cue Clone()
	{
		MediaCue cue = new MediaCue(base.ContainerId);
		return CopyProperties(cue);
	}

	protected override void OnProtoSerializePlaylistItem(PlaylistItem playlistItem)
	{
		if (MediaAction != null)
		{
			playlistItem.Cue = Serialize();
		}
	}

	protected override void OnProtoDeserializePlaylistItem(PlaylistItem playlistItem, ApplicationData? applicationData, string containerId)
	{
		Pro.SerializationInterop.RVProtoData.Action action = playlistItem.Cue.Actions.FirstOrDefault((Pro.SerializationInterop.RVProtoData.Action a) => a.Media != null);
		string text = (string.IsNullOrEmpty(playlistItem.Cue.Name) ? playlistItem.Name : playlistItem.Cue.Name);
		if (action != null && action.Name != text)
		{
			if (string.IsNullOrEmpty(action.Name) && !string.IsNullOrEmpty(text))
			{
				action.Name = text;
			}
			playlistItem.Cue.Name = text;
		}
		Deserialize(playlistItem.Cue, applicationData, containerId);
		MediaAction? mediaAction = MediaAction;
		if (mediaAction != null && mediaAction.Media.MediaType == MediaType.Audio && base.CompletionTarget.Type == CompletionTargetType.Next)
		{
			AudioMedia? audioMedia = MediaAction.AudioMedia;
			if (audioMedia != null && audioMedia.Transport.PlaybackBehaviorType == PlaybackBehaviorType.Loop)
			{
				MediaAction.AudioMedia.Transport.PlaybackBehaviorType = PlaybackBehaviorType.Stop;
			}
		}
	}

	internal void OnDeserializeMediaPlaylistItem(PlaylistItem playlistItem, ApplicationData? applicationData, string containerId)
	{
		OnProtoDeserializePlaylistItem(playlistItem, applicationData, containerId);
	}

	private void OnVisualInvalidated()
	{
		this.VisualInvalidated?.Invoke();
	}

	bool ITimelineItem.get_IsEnabled()
	{
		return base.IsEnabled;
	}
}
