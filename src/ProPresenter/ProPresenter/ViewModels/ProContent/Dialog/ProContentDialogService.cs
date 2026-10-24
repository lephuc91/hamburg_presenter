using System;
using System.Collections.Generic;
using System.Windows.Media;
using Pro.Common.Animation;
using Pro.Common.FeatureFlag;
using Pro.Common.Nullability;
using Pro.Localization.Services;
using Pro.UI.Themes;
using ProPresenter.DO;
using ProPresenter.DO.Cache;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Media;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.ProContent;
using ProPresenter.DO.ProContent.Model.Asset;
using ProPresenter.DO.ProContent.Model.Collection;
using ProPresenter.DO.Repositories;
using ProPresenter.DO.Settings;
using ProPresenter.UI.ProContent.Dialog.Download;
using ProPresenter.UI.ViewModels.ProContent.Dialog.Download;
using ProPresenter.ViewModels.ProContent.Dialog.Download;

namespace ProPresenter.ViewModels.ProContent.Dialog;

public class ProContentDialogService : IProContentDialogService
{
	private sealed class AutoDisposer : IDisposable
	{
		private readonly IDisposable _toDispose;

		public AutoDisposer(IDisposable toDispose)
		{
			_toDispose = toDispose;
		}

		public void Dispose()
		{
			_toDispose.Dispose();
		}
	}

	public static readonly ImageSource? ProContentLogo = Icons.GetIcon(Icons.ProContent);

	private readonly IProPresenterResourceService _resources;

	private readonly IApp _app;

	private readonly IOutputRepository _outputRepository;

	private readonly ILocalization _localization;

	private readonly IUriCacheService<NullableBitmapSource> _thumbnailCacheService;

	private readonly IUriCacheService<IReadOnlyList<IAnimationFrame>> _previewCacheService;

	private readonly IMediaImportService _mediaImportService;

	private readonly IMediaFactory _mediaFactory;

	private readonly IFlagService _flagService;

	public ProContentDialogService(IProPresenterResourceService resources, IApp app, ILocalization localization, IUriCacheService<NullableBitmapSource> thumbnailCacheService, IUriCacheService<IReadOnlyList<IAnimationFrame>> previewCacheService, IMediaImportService mediaImportService, IMediaFactory mediaFactory, IOutputRepository outputRepository, IFlagService flagService)
	{
		_resources = resources;
		_app = app;
		_localization = localization;
		_thumbnailCacheService = thumbnailCacheService;
		_previewCacheService = previewCacheService;
		_mediaImportService = mediaImportService;
		_mediaFactory = mediaFactory;
		_outputRepository = outputRepository;
		_flagService = flagService;
	}

	public IProContentDownloadInfo? Show(IProContentDownloadableAsset asset, VisualPlaylist? defautSelected = null)
	{
		return Show(new ProContentDownloadFileDialogVM(_resources, _app, _thumbnailCacheService, _previewCacheService, asset), defautSelected);
	}

	public IProContentDownloadInfo? Show(IProContentPackAsset asset, VisualPlaylist? defautSelected = null)
	{
		return ShowDisposing(new ProContentDownloadPackDialogVM(_resources, _app, _localization, _thumbnailCacheService, _previewCacheService, asset), defautSelected, CreateFilteredDownloadInfo);
	}

	public IProContentDownloadInfo? Show(IProContentDownloadableCollection collection, VisualPlaylist? defautSelected = null)
	{
		return Show(new ProContentDownloadCollectionDialogVM(_resources, _app, collection), defautSelected);
	}

	private IProContentDownloadInfo? ShowDisposing<TContext>(TContext context, VisualPlaylist? defautSelected = null, Func<TContext, IProContentDownloadInfo>? createDownloadInfo = null) where TContext : IDisposable, IProContentDownloadDialogVM
	{
		using (new AutoDisposer(context))
		{
			return Show(context, defautSelected, createDownloadInfo);
		}
	}

	private IProContentDownloadInfo? Show<TContext>(TContext context, VisualPlaylist? defautSelected = null, Func<TContext, IProContentDownloadInfo>? createDownloadInfo = null) where TContext : IProContentDownloadDialogVM
	{
		if (context == null)
		{
			return null;
		}
		if (defautSelected != null)
		{
			context.SelectedPlaylist = defautSelected;
		}
		if (new DownloadDialog(context).ShowDialog() == true && context.SelectedFormat != null)
		{
			return createDownloadInfo?.Invoke(context) ?? new ProContentDownloadInfo(context.SelectedFormat, GetSelectedPlaylist(context));
		}
		return null;
	}

	private IPlaylist<MediaCue> GetSelectedPlaylist(IProContentDownloadDialogVM context)
	{
		return context.SelectedPlaylist ?? new VisualPlaylist(_app, _mediaImportService, _mediaFactory, _outputRepository.AvailableTransitions, _flagService, null, context.NewPlaylistName);
	}

	private IProContentDownloadInfo CreateFilteredDownloadInfo(ProContentDownloadPackDialogVM context)
	{
		context.SelectedFormat.ThrowWhenNull("context.SelectedFormat");
		return new ProContentDownloadInfo(context.SelectedFormat, GetSelectedPlaylist(context), context.AssetTypesToDownload);
	}
}
