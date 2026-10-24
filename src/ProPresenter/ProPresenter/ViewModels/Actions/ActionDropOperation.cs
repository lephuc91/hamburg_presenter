using System.Collections.Generic;
using System.IO;
using System.Linq;
using Pro.Common.Components;
using Pro.DO.Transitions;
using Pro.DO.Triggering;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Import;
using ProPresenter.DO.Media;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Settings;

namespace ProPresenter.ViewModels.Actions;

public class ActionDropOperation : IActionDropOperation
{
	private readonly IMediaActionHandler _mediaActionHandler;

	private readonly IPlaylistActionHandler _playlistActionHandler;

	private readonly IActionHandler _actionHandler;

	private readonly IApp _app;

	private readonly ITransitionDescriptionCollection _transitionDescriptions;

	private readonly IImportProcessFactory _importProcessFactory;

	private readonly IMediaFactory _mediaFactory;

	public ActionDropOperation(IMediaActionHandler mediaActionHandler, IPlaylistActionHandler playlistActionHandler, IActionHandler actionHandler, IApp app, IImportProcessFactory importProcessFactory, IMediaFactory mediaFactory, ITransitionDescriptionCollection transitionDescriptions)
	{
		_mediaActionHandler = mediaActionHandler;
		_playlistActionHandler = playlistActionHandler;
		_actionHandler = actionHandler;
		_app = app;
		_importProcessFactory = importProcessFactory;
		_mediaFactory = mediaFactory;
		_transitionDescriptions = transitionDescriptions;
	}

	public void Execute(IEnumerable<MediaCue> mediaCues, IActionRepoContainer repoContainer, IActionRepository? repo, bool droppedBefore, bool droppedOutside, bool shouldCloneAction = true)
	{
		_mediaActionHandler.Execute(MediaActionProviderFactory.Create(mediaCues, shouldCloneAction), repoContainer, repo, droppedOutside, droppedBefore);
	}

	public void Execute(IEnumerable<FileInfo> files, IActionRepoContainer repoContainer, IActionRepository? repo, bool droppedBefore, bool droppedOutside, string containerId)
	{
		_mediaActionHandler.ExecuteWithGrouping(MediaActionProviderFactory.Create(files, repoContainer, droppedOutside, _app, _importProcessFactory, _mediaFactory, _transitionDescriptions, containerId), repoContainer, repo, droppedOutside, droppedBefore);
	}

	public void Execute(IRemoteFile remoteFile, IActionRepoContainer repoContainer, IActionRepository? repo, bool droppedBefore, bool droppedOutside, string containerId)
	{
		remoteFile.DownloadFile(delegate(FileInfo f)
		{
			Execute(new global::_003C_003Ez__ReadOnlySingleElementList<FileInfo>(f), repoContainer, repo, droppedBefore, droppedOutside, containerId);
		});
	}

	public IAction? Execute<T>(IEnumerable<IPlaylist<T>> playlists, IActionRepoContainer repoContainer, IActionRepository? repo, bool droppedBefore, bool droppedOutside, out IActionRepository? placement) where T : ProPresenterCue
	{
		return _playlistActionHandler.Execute(playlists.ToArray(), repoContainer, repo, droppedBefore, droppedOutside, out placement);
	}

	public IAction? Execute(IEnumerable<IAction>? actions, IActionRepoContainer repoContainer, IActionRepository? repo, bool droppedBefore, bool droppedOutside, out IActionRepository? placement)
	{
		return _actionHandler.Execute(actions, repoContainer, repo, droppedBefore, droppedOutside, out placement);
	}

	public IAction? Execute(IEnumerable<IAction>? actions, IActionRepoContainer repoContainer, IActionRepository? repo, bool droppedBefore, bool droppedOutside)
	{
		IActionRepository placement;
		return _actionHandler.Execute(actions, repoContainer, repo, droppedBefore, droppedOutside, out placement);
	}

	public (IAction? FirstAction, IActionRepository? Placement) Execute(MediaType mediaType, IActionRepoContainer repoContainer, IActionRepository? repo, bool droppedBefore, bool droppedOutside, string containerId)
	{
		IMediaActionProvider mediaActionProvider = MediaActionProviderFactory.Create(mediaType, repoContainer, droppedOutside, _app, _importProcessFactory, _mediaFactory, _transitionDescriptions, containerId);
		return _mediaActionHandler.Execute(mediaActionProvider, repoContainer, repo, droppedOutside, droppedBefore);
	}
}
