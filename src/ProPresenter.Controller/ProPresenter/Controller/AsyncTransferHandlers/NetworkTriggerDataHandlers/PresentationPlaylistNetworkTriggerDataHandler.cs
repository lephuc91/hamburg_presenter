using System.Linq;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.Controller.Triggering;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Cues.PCO;
using ProPresenter.DO.Playlists;

namespace ProPresenter.Controller.AsyncTransferHandlers.NetworkTriggerDataHandlers;

public class PresentationPlaylistNetworkTriggerDataHandler : INetworkTriggerDataHandler
{
	private readonly ICoreManager _coreManager;

	private readonly LibraryPlaylistCollection _playlists;

	public PresentationPlaylistNetworkTriggerDataHandler(ICoreManager coreManager, LibraryPlaylistCollection playlists)
	{
		_coreManager = coreManager;
		_playlists = playlists;
	}

	public NetworkTriggerDataItem? Handle(NetworkIdentifier id, ITriggerOperation op)
	{
		if (_playlists == null)
		{
			return null;
		}
		Playlist<ProPresenterCue> matchPlaylist;
		int nextLevel;
		ProPresenterCue proPresenterCue = id.FindPlaylistItem(_playlists, out matchPlaylist, out nextLevel);
		if (proPresenterCue == null)
		{
			return null;
		}
		switch (proPresenterCue.Type)
		{
		case CueType.Document:
			return handleDocumentCue<DocumentCue>((DocumentCue)proPresenterCue);
		case CueType.Media:
			return handleMediaCue((MediaCue)proPresenterCue);
		case CueType.Placeholder:
		{
			PlaceholderCue placeholderCue = (PlaceholderCue)proPresenterCue;
			switch (placeholderCue.PlaceholderAction?.State)
			{
			case LinkState.DocumentLinked:
				return handleDocumentCue<PlaceholderCue>(placeholderCue);
			case LinkState.MediaLinked:
				return handleMediaCue(new MediaCue(placeholderCue.MediaAction));
			}
			break;
		}
		case CueType.PCO:
			if (proPresenterCue is PCOCueBase pCOCueBase)
			{
				switch (pCOCueBase.PCOAction?.LinkedObjectType)
				{
				case LinkState.DocumentLinked:
					return handleDocumentCue<PCOCueBase>(pCOCueBase);
				case LinkState.MediaLinked:
					return handleMediaCue(new MediaCue(pCOCueBase.MediaAction));
				}
			}
			break;
		}
		return null;
		NetworkTriggerDataItem? handleDocumentCue<T>(T documentCue) where T : notnull, ProPresenterCue, IDocumentCue
		{
			ArrangedCue slide = ((nextLevel < id.Identifiers.Count) ? id.Identifiers[nextLevel].FindItem(documentCue.DocumentAction?.ActiveArrangement?.ArrangedCues, (ArrangedCue s) => s.Name ?? string.Empty) : documentCue.DocumentAction?.ActiveArrangement?.ArrangedCues.FirstOrDefault());
			return _coreManager.ToTriggerDataItem(slide, documentCue, op);
		}
		NetworkTriggerDataItem? handleMediaCue(MediaCue mediaCue)
		{
			if (mediaCue != null && matchPlaylist != null)
			{
				op.AttachMediaCueInfo(CueLocation.PlaylistLibrary, mediaCue, matchPlaylist);
			}
			return mediaCue.ToTriggerDataItem(op, matchPlaylist);
		}
	}
}
