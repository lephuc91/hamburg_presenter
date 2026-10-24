using System;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;
using Pro.Common.Components;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Application;
using Pro.DO.Storage;
using Pro.DO.Transitions;
using Pro.DO.Triggering;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Analytics;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Media;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Settings;

namespace ProPresenter.DO.Actions;

public class PlaceholderAction : ActionBase, ICanReceiveMediaContainerIdUpdates
{
	private readonly IApp _app;

	private readonly IProPresenterResourceService _resourceService;

	private readonly IMediaFactory _mediaFactory;

	private readonly ITransitionDescriptionCollection _transitionDescriptions;

	private LinkState _state;

	private DocumentAction? _documentAction;

	private MediaAction? _mediaAction;

	private PlaylistItem.Types.Presentation? _unreferencedPresentationInformation;

	private string _containerId = "";

	public override ActionType ActionType => ActionType.Placeholder;

	public LinkState State
	{
		get
		{
			return _state;
		}
		private set
		{
			SetValue("State", ref _state, value);
		}
	}

	public DocumentAction? DocumentAction
	{
		get
		{
			return _documentAction;
		}
		private set
		{
			SetValue("DocumentAction", ref _documentAction, value, OnDocumentActionChanged);
		}
	}

	public MediaAction? MediaAction
	{
		get
		{
			return _mediaAction;
		}
		private set
		{
			SetValue<MediaAction>("MediaAction", ref _mediaAction, value, delegate(MediaAction o, MediaAction n)
			{
				if (o != null)
				{
					o.PropertyChanged -= base.RaiseLinkedValues;
				}
				if (n != null)
				{
					n.PropertyChanged += base.RaiseLinkedValues;
				}
			});
		}
	}

	public override string ContainerId => _containerId;

	public ObjectBinder<PlaceholderAction, IPlaylistItem.Types.IPlaceholder> CreateBinder(IUiScheduler scheduler, IEntityFactory entityFactory, IActionBinderFactory actionBinderFactory, IPlaylistItem.Types.IPlaceholder right)
	{
		return new ObjectBinder<PlaceholderAction, IPlaylistItem.Types.IPlaceholder>(this, right).Bind((PlaceholderAction l) => Observable.Merge<PropertyChangedEventArgs>(l.WhenPropertyChanges("State"), l.WhenPropertyChanges("DocumentAction"), l.WhenPropertyChanges("MediaAction")).ToUnit(), (IPlaylistItem.Types.IPlaceholder r) => r.LinkedData.WhenValueChanges, delegate(PlaceholderAction l, IPlaylistItem.Types.IPlaceholder r)
		{
			IPlaylistItem playlistItem = null;
			if (l.State == LinkState.DocumentLinked && l.DocumentAction != null)
			{
				playlistItem = entityFactory.Create<IPlaylistItem>();
				IPlaylistItem.Types.IItemType.IPresentation presentation = entityFactory.Create<IPlaylistItem.Types.IItemType.IPresentation>();
				IPlaylistItem.Types.IPresentation presentation2 = entityFactory.Create<IPlaylistItem.Types.IPresentation>();
				presentation.Set(presentation2);
				ObjectBinder<DocumentAction, IPlaylistItem.Types.IPresentation> objectBinder = l.DocumentAction.CreatePlaylistBinder(scheduler, entityFactory, presentation2);
				objectBinder.InitializeRightFromLeft();
				playlistItem.ItemType.Set(presentation);
				playlistItem.RegisterLinkedDisposable(objectBinder);
			}
			else if (l.State == LinkState.MediaLinked && l.MediaAction != null)
			{
				playlistItem = entityFactory.Create<IPlaylistItem>();
				IPlaylistItem.Types.IItemType.ICue cue = entityFactory.Create<IPlaylistItem.Types.IItemType.ICue>();
				ICue cue2 = entityFactory.Create<ICue>();
				cue.Set(cue2);
				Pro.Entity.IAction action = entityFactory.Create<Pro.Entity.IAction>();
				cue2.Actions.Add(action);
				IReadOnlyObjectBinder<Pro.DO.Triggering.IAction, Pro.Entity.IAction> readOnlyObjectBinder = actionBinderFactory.CreateBinder(l.MediaAction, action);
				readOnlyObjectBinder.InitializeRightFromLeft();
				playlistItem.ItemType.Set(cue);
				playlistItem.RegisterLinkedDisposable(readOnlyObjectBinder);
			}
			r.LinkedData.Set(playlistItem);
		}, delegate(IPlaylistItem.Types.IPlaceholder r, PlaceholderAction l)
		{
			if (r.LinkedData.Value?.ItemType.Value is IPlaylistItem.Types.IItemType.IPresentation { Value: { } value } presentation3)
			{
				l.DocumentAction = new DocumentAction(presentation3);
				ObjectBinder<DocumentAction, IPlaylistItem.Types.IPresentation> objectBinder2 = l.DocumentAction.CreatePlaylistBinder(scheduler, entityFactory, value);
				objectBinder2.InitializeLeftFromRight();
				presentation3.RegisterLinkedDisposable(objectBinder2);
				l.State = LinkState.DocumentLinked;
			}
			else if (r.LinkedData.Value?.ItemType.Value is IPlaylistItem.Types.IItemType.ICue { Value: { } value2 } cue3)
			{
				Pro.Entity.IAction action2 = value2.Actions.Items.FirstOrDefault();
				if (action2 != null && actionBinderFactory.CreateAction(action2, l.ContainerId) is MediaAction mediaAction)
				{
					l.MediaAction = mediaAction;
					IReadOnlyObjectBinder<Pro.DO.Triggering.IAction, Pro.Entity.IAction> readOnlyObjectBinder2 = actionBinderFactory.CreateBinder(l.MediaAction, action2);
					readOnlyObjectBinder2.InitializeLeftFromRight();
					cue3.RegisterLinkedDisposable(readOnlyObjectBinder2);
					l.State = LinkState.MediaLinked;
				}
			}
			else
			{
				l.Unlink();
			}
		}, null, scheduler.Scheduler);
	}

	public PlaceholderAction(IApp app, IProPresenterResourceService resourceService, IMediaFactory mediaFactory, ITransitionDescriptionCollection transitionDescriptions)
	{
		_app = app;
		_resourceService = resourceService;
		_mediaFactory = mediaFactory;
		_transitionDescriptions = transitionDescriptions;
		LinkProperties("Name", "State");
	}

	public bool NeedsResolve()
	{
		return _unreferencedPresentationInformation != null;
	}

	public void Resolve(ILibraryCollection libraries)
	{
		if (_unreferencedPresentationInformation != null)
		{
			RelativePath path = new RelativePath(_unreferencedPresentationInformation.DocumentPath);
			DocumentCue documentCue = libraries.FindDocument(path);
			if (documentCue != null)
			{
				LinkDocument(documentCue.DocumentAction.Presentation);
				ApplyArrangement(_unreferencedPresentationInformation.Arrangement.ToGuid());
				_unreferencedPresentationInformation = null;
			}
		}
	}

	public override Pro.DO.Triggering.IAction Clone()
	{
		PlaceholderAction placeholderAction = CopyProperties(new PlaceholderAction(_app, _resourceService, _mediaFactory, _transitionDescriptions)
		{
			State = State,
			DocumentAction = (DocumentAction)(DocumentAction?.Clone()),
			MediaAction = (MediaAction)(MediaAction?.Clone())
		});
		placeholderAction._containerId = ContainerId;
		return placeholderAction;
	}

	public void Unlink()
	{
		if (State != 0)
		{
			PlaceholderUnlinkEvent.Publish();
		}
		State = LinkState.Unlinked;
		MediaAction = null;
		DocumentAction = null;
		OnDataModified();
	}

	public void LinkDocument(ProPresenter.DO.Presentation.IPresentation? document)
	{
		Unlink();
		if (document != null)
		{
			DocumentAction = new DocumentAction(document);
			State = LinkState.DocumentLinked;
			OnDataModified();
		}
	}

	public void LinkMedia(MediaBase? media)
	{
		Unlink();
		if (media != null)
		{
			MediaAction = new MediaAction(media, _app, _transitionDescriptions);
			MediaAction.UpdateContainerId(_containerId);
			if (media is FileMediaBase fileMediaBase)
			{
				MediaAction.Name = fileMediaBase.SourceFile.Name;
			}
			State = LinkState.MediaLinked;
			MediaAction.ToForeground();
			OnDataModified();
		}
	}

	internal PlaylistItem.Types.Placeholder ProtoSerializePlaylistItemPlaceholder()
	{
		PlaylistItem.Types.Placeholder placeholder = new PlaylistItem.Types.Placeholder();
		PlaylistItem.Types.Placeholder placeholder2 = placeholder;
		placeholder2.LinkedData = State switch
		{
			LinkState.Unlinked => null, 
			LinkState.DocumentLinked => DocumentAction?.ToCue().ProtoSerializePlaylistItem(), 
			LinkState.MediaLinked => MediaAction?.ToCue().ProtoSerializePlaylistItem(), 
			_ => throw new NotSupportedException(), 
		};
		return placeholder;
	}

	public void ProtoDeserializePlaylistItemPlaceholder(PlaylistItem.Types.Placeholder placeholderPlaylistItem, ApplicationData? applicationData, string containerId)
	{
		UpdateContainerId(containerId);
		if (placeholderPlaylistItem.LinkedData == null)
		{
			Unlink();
			return;
		}
		switch (placeholderPlaylistItem.LinkedData.ItemTypeCase)
		{
		case PlaylistItem.ItemTypeOneofCase.Presentation:
		{
			DocumentCue documentCue = _resourceService.LibraryCollection.FindDocument(new RelativePath(placeholderPlaylistItem.LinkedData.Presentation.DocumentPath));
			if (documentCue != null)
			{
				LinkDocument(documentCue.DocumentAction.Presentation);
				ApplyArrangement(placeholderPlaylistItem.LinkedData.Presentation.Arrangement.ToGuid());
			}
			else
			{
				Unlink();
				_unreferencedPresentationInformation = placeholderPlaylistItem.LinkedData.Presentation;
			}
			break;
		}
		case PlaylistItem.ItemTypeOneofCase.Cue:
		{
			Pro.SerializationInterop.RVProtoData.Action action = placeholderPlaylistItem.LinkedData.Cue.Actions.FirstOrDefault();
			if (action == null)
			{
				break;
			}
			if (action.Type == Pro.SerializationInterop.RVProtoData.Action.Types.ActionType.Media)
			{
				LinkMedia(action.Media.MediaTypeCase switch
				{
					Pro.SerializationInterop.RVProtoData.Action.Types.MediaType.MediaTypeOneofCase.Audio => _mediaFactory.CreateAudioMedia(containerId, null), 
					Pro.SerializationInterop.RVProtoData.Action.Types.MediaType.MediaTypeOneofCase.Image => _mediaFactory.CreateVisualMedia(containerId, null), 
					Pro.SerializationInterop.RVProtoData.Action.Types.MediaType.MediaTypeOneofCase.Video => _mediaFactory.CreateVideoMedia(containerId, null), 
					_ => throw new NotImplementedException(), 
				});
				if (State == LinkState.MediaLinked)
				{
					MediaAction?.Deserialize(action, applicationData, containerId);
				}
			}
			else
			{
				Unlink();
			}
			break;
		}
		default:
			Unlink();
			break;
		}
	}

	private void OnDocumentActionChanged(DocumentAction? oldValue, DocumentAction? newValue)
	{
		if (oldValue != null)
		{
			oldValue.PropertyChanged -= OnDocumentPropertyChanged;
		}
		if (newValue != null)
		{
			newValue.PropertyChanged += OnDocumentPropertyChanged;
		}
		OnDataModified();
	}

	private void OnDocumentPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName.IsPlaylistRelevantProperty())
		{
			OnDataModified();
		}
	}

	private void ApplyArrangement(Guid arrangementId)
	{
		if (DocumentAction?.Presentation != null)
		{
			ProPresenter.DO.Presentation.IPresentation presentation = DocumentAction.Presentation;
			DocumentAction.ActiveArrangement = presentation.Arrangements.FirstOrDefault((IArrangement a) => a.ID == arrangementId) ?? presentation.DefaultArrangement;
		}
	}

	public void UpdateContainerId(string newContainerId)
	{
		_containerId = newContainerId;
		MediaAction?.UpdateContainerId(newContainerId);
	}
}
