using System;
using System.ComponentModel;
using Pro.DO.Storage;
using Pro.DO.Transitions;
using Pro.DO.Triggering;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Media;
using ProPresenter.DO.PCO;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Settings;

namespace ProPresenter.DO.Actions.PCO;

public abstract class PCOActionBase : ActionBase
{
	private sealed record MediaLinkRequest(MediaBase Media, ITransitionDescriptionCollection TransitionDescriptions);

	private PCOLinkStates _linkState = PCOLinkStates.Linking;

	private LinkState _linkedObjectType;

	private IDocumentAction? _documentAction;

	private MediaAction? _mediaAction;

	protected IApp App { get; }

	public PCOLinkStates LinkState
	{
		get
		{
			return _linkState;
		}
		set
		{
			SetValue("LinkState", ref _linkState, value, base.OnDataModified);
		}
	}

	public LinkState LinkedObjectType
	{
		get
		{
			return _linkedObjectType;
		}
		private set
		{
			SetValue("LinkedObjectType", ref _linkedObjectType, value);
		}
	}

	public IDocumentAction? DocumentAction
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
			SetValue("MediaAction", ref _mediaAction, value);
		}
	}

	protected PCOActionBase(IApp app)
	{
		App = app;
	}

	public override IAction Clone()
	{
		throw new NotSupportedException();
	}

	public void LinkMedia(MediaBase media, ITransitionDescriptionCollection transitionDescriptions)
	{
		OnLink(new MediaLinkRequest(media, transitionDescriptions), null);
	}

	public virtual void LinkDocument(IPresentation document, PCOItem? updatedPlanItem)
	{
		OnLink(null, document);
	}

	public void LinkDocument(IDocumentAction documentAction)
	{
		MediaAction = null;
		DocumentAction = documentAction;
		LinkedObjectType = ProPresenter.DO.Actions.LinkState.DocumentLinked;
		LinkState = PCOLinkStates.Linked;
	}

	public void LinkMedia(MediaAction mediaAction)
	{
		DocumentAction = null;
		MediaAction = mediaAction;
		LinkedObjectType = ProPresenter.DO.Actions.LinkState.MediaLinked;
		LinkState = PCOLinkStates.Linked;
	}

	public void Unlink()
	{
		OnLink(null, null);
	}

	private void OnLink(MediaLinkRequest? mediaLinkRequest, IPresentation? document)
	{
		MediaAction = ((mediaLinkRequest == null) ? null : new MediaAction(mediaLinkRequest.Media, App, mediaLinkRequest.TransitionDescriptions));
		DocumentAction = ((document == null) ? null : new DocumentAction(document));
		MediaAction?.ToForeground();
		LinkedObjectType = (((object)mediaLinkRequest != null) ? ProPresenter.DO.Actions.LinkState.MediaLinked : ((document != null) ? ProPresenter.DO.Actions.LinkState.DocumentLinked : ProPresenter.DO.Actions.LinkState.Unlinked));
		LinkState = ((LinkedObjectType != 0) ? PCOLinkStates.Linked : PCOLinkStates.Unlinked);
	}

	private void OnDocumentActionChanged(IDocumentAction? oldValue, IDocumentAction? newValue)
	{
		if (oldValue != null)
		{
			oldValue.PropertyChanged -= Document_PropertyChanged;
		}
		if (newValue != null)
		{
			newValue.PropertyChanged += Document_PropertyChanged;
		}
	}

	private void Document_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName.IsPlaylistRelevantProperty())
		{
			OnDataModified();
		}
	}

	internal void DeserializeLinkDocument(PlaylistItem.Types.Presentation presentation, LibraryCollection libraries)
	{
		IPresentation presentation2 = libraries.FindDocument(new RelativePath(presentation.DocumentPath))?.DocumentAction.Presentation;
		if (presentation2 != null)
		{
			OnLink(null, presentation2);
		}
	}
}
