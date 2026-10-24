using System.Collections.Generic;
using System.IO;
using Pro.Common.Components;
using Pro.DO.Triggering;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Media;
using ProPresenter.DO.Playlists;

namespace ProPresenter.ViewModels.Actions;

public interface IActionDropOperation
{
	void Execute(IEnumerable<FileInfo> files, IActionRepoContainer repoContainer, IActionRepository? repo, bool droppedBefore, bool droppedOutside, string containerId);

	IAction? Execute(IEnumerable<IAction>? actions, IActionRepoContainer repoContainer, IActionRepository? repo, bool droppedBefore, bool droppedOutside);

	IAction? Execute(IEnumerable<IAction>? actions, IActionRepoContainer repoContainer, IActionRepository? repo, bool droppedBefore, bool droppedOutside, out IActionRepository? placement);

	void Execute(IEnumerable<MediaCue> mediaCues, IActionRepoContainer repoContainer, IActionRepository? repo, bool droppedBefore, bool droppedOutside, bool shouldCloneAction = true);

	void Execute(IRemoteFile remoteFile, IActionRepoContainer repoContainer, IActionRepository? repo, bool droppedBefore, bool droppedOutside, string containerId);

	(IAction? FirstAction, IActionRepository? Placement) Execute(MediaType mediaType, IActionRepoContainer repoContainer, IActionRepository? repo, bool droppedBefore, bool droppedOutside, string containerId);

	IAction? Execute<T>(IEnumerable<IPlaylist<T>> playlists, IActionRepoContainer repoContainer, IActionRepository? repo, bool droppedBefore, bool droppedOutside, out IActionRepository? placement) where T : ProPresenterCue;
}
