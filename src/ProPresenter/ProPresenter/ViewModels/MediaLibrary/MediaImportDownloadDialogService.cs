using Pro.Common.FeatureFlag;
using ProPresenter.DO;
using ProPresenter.DO.Media;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Repositories;
using ProPresenter.DO.Settings;
using ProPresenter.UI.MediaLibrary;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.ViewModels.MediaLibrary;

public class MediaImportDownloadDialogService : IMediaImportDownloadDialogService
{
	private readonly IProPresenterResourceService _resources;

	private readonly IApp _app;

	private readonly IMediaImportService _mediaImportService;

	private readonly IMediaFactory _mediaFactory;

	private readonly IOutputRepository _outputRepository;

	private readonly IFlagService _flagService;

	public MediaImportDownloadDialogService(IProPresenterResourceService resources, IApp app, IMediaImportService mediaImportService, IMediaFactory mediaFactory, IOutputRepository outputRepository, IFlagService flagService)
	{
		_resources = resources;
		_app = app;
		_mediaImportService = mediaImportService;
		_mediaFactory = mediaFactory;
		_outputRepository = outputRepository;
		_flagService = flagService;
	}

	public IMediaImportDownloadDialogResult? Show(bool isDownload = false)
	{
		MediaImportDownloadDialogVM mediaImportDownloadDialogVM = new MediaImportDownloadDialogVM(_resources, _app, isDownload);
		if (new MediaImportDownloadDialog
		{
			DataContext = mediaImportDownloadDialogVM
		}.ShowDialog() == true)
		{
			return new MediaImportDownloadDialogResult(mediaImportDownloadDialogVM.SelectedPlaylist ?? CreateAndInsertNewPlaylist(mediaImportDownloadDialogVM));
		}
		return null;
	}

	private VisualPlaylist CreateAndInsertNewPlaylist(MediaImportDownloadDialogVM context)
	{
		VisualPlaylist visualPlaylist = new VisualPlaylist(_app, _mediaImportService, _mediaFactory, _outputRepository.AvailableTransitions, _flagService, null, context.NewPlaylistName);
		visualPlaylist.InsertPlaylist(_resources.VisualPlaylists, _app.SelectedMediaPlaylist);
		return visualPlaylist;
	}
}
