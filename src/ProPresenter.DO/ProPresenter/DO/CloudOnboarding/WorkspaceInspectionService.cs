using System;
using System.Linq;
using System.Threading.Tasks;
using Pro.Common.Logging;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Workspaces;

namespace ProPresenter.DO.CloudOnboarding;

public sealed class WorkspaceInspectionService : IWorkspaceInspectionService
{
	private readonly IWorkspaceService _workspaces;

	private readonly IVisualPlaylistRepo _visualPlaylistRepo;

	private readonly IMediaFileProvider _mediaFileProvider;

	private readonly ILogger _logger;

	public WorkspaceInspectionService(IWorkspaceService workspaces, IVisualPlaylistRepo visualPlaylistRepo, IMediaFileProvider mediaFileProvider, ILogger logger)
	{
		_workspaces = workspaces;
		_visualPlaylistRepo = visualPlaylistRepo;
		_mediaFileProvider = mediaFileProvider;
		_logger = logger;
	}

	public async Task<WorkspaceIssueFlags> DetectIssuesAsync()
	{
		_workspaces.Workspaces.First((IWorkspace w) => w.Active);
		WorkspaceIssueFlags flags = WorkspaceIssueFlags.None;
		try
		{
			if (_visualPlaylistRepo.Playlists.GetPlaylists().Any((IPlaylist<MediaCue> p) => p.Type == PlaylistType.Smart))
			{
				flags |= WorkspaceIssueFlags.SmartPlaylists;
			}
			if (await HasUnmanagedMediaAsync().ConfigureAwait(continueOnCapturedContext: false))
			{
				flags |= WorkspaceIssueFlags.UnmanagedMedia;
			}
		}
		catch (OperationCanceledException)
		{
			throw;
		}
		catch (Exception value)
		{
			_logger.Debug($"WorkspaceInspectionService: non-fatal inspection error: {value}");
		}
		return flags;
	}

	public async Task<bool> HasUnmanagedMediaAsync()
	{
		return await _mediaFileProvider.GetUnmanagedMediaBytesAsync().ConfigureAwait(continueOnCapturedContext: false) > 0;
	}
}
