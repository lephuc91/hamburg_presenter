using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Cache;
using Pro.Common.Dispatcher;
using Pro.Common.Downloads;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Strings;
using Pro.Common.Time;
using Pro.Localization.Services;
using ProPresenter.DO.Cache;
using ProPresenter.UI.ViewModels.Downloads;
using ProPresenter.ViewModels.DispatchingExtensions;
using Reactive.Bindings;

namespace ProPresenter.ViewModels.Downloads;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_downloadStatusSubscription", "Name", "_thumbnailSubscription" })]
public class DownloadItemVM : ObservableObject, IDownloadItemVM, INotifyPropertyChanged, IDisposable
{
	private sealed class AsyncCachedItem<T> : IAsyncValue<T>
	{
		private readonly Func<Task<T>> _doLoadAsync;

		public AsyncCachedItem(Func<Task<T>> doLoadAsync)
		{
			_doLoadAsync = doLoadAsync;
		}

		public Task<T> LoadAsync()
		{
			return _doLoadAsync();
		}
	}

	private readonly IDownloadItem _item;

	private readonly ILocalization _localization;

	private readonly IDisposable _thumbnailSubscription;

	private readonly IDisposable _downloadStatusSubscription;

	private DownloadProgress? _currentDownloadProgress;

	private string? _downloadStatusText;

	private Uri? _currentThumbnailUri;

	[ObservableProperty]
	private int _percentComplete;

	[ObservableProperty]
	[NotifyCanExecuteChangedFor("RetryDownloadCommand")]
	private DownloadStatus _status;

	[ObservableProperty]
	private IAsyncValue<BitmapSource?> _thumbnail;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? cancelDownloadCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? retryDownloadCommand;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public ReadOnlyReactivePropertySlim<string> Name { get; }

	public string ReceivedStatus => _downloadStatusText ?? (_downloadStatusText = GetStatusText(_currentDownloadProgress));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int PercentComplete
	{
		get
		{
			return _percentComplete;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_percentComplete, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.PercentComplete);
				_percentComplete = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.PercentComplete);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public DownloadStatus Status
	{
		get
		{
			return _status;
		}
		set
		{
			if (!EqualityComparer<DownloadStatus>.Default.Equals(_status, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Status);
				_status = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Status);
				RetryDownloadCommand.NotifyCanExecuteChanged();
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncValue<BitmapSource?> Thumbnail
	{
		get
		{
			return _thumbnail;
		}
		[MemberNotNull("_thumbnail")]
		set
		{
			if (!EqualityComparer<IAsyncValue<BitmapSource>>.Default.Equals(_thumbnail, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Thumbnail);
				_thumbnail = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Thumbnail);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand CancelDownloadCommand => cancelDownloadCommand ?? (cancelDownloadCommand = new RelayCommand(CancelDownload));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand RetryDownloadCommand => retryDownloadCommand ?? (retryDownloadCommand = new RelayCommand(RetryDownload, CanRetryDownload));

	public DownloadItemVM(IDownloadItem item, ILocalization localization, IUriCacheService<NullableBitmapSource> thumbnailCacheService, IUiScheduler uiScheduler)
	{
		DownloadItemVM downloadItemVM = this;
		_item = item;
		_localization = localization;
		_downloadStatusSubscription = _item.WhenDownloadProgressChanged.ObserveOn(uiScheduler.Scheduler).Subscribe(delegate(DownloadProgress progress)
		{
			downloadItemVM._currentDownloadProgress = progress;
			downloadItemVM.PercentComplete = progress.PercentComplete;
			downloadItemVM.Status = progress.Status;
			downloadItemVM._downloadStatusText = null;
			downloadItemVM.OnPropertyChanged("ReceivedStatus");
		});
		Name = _item.WhenNameChanged.DistinctUntilChanged().ToReadOnlyReactivePropertySlim(uiScheduler, string.Empty);
		_thumbnail = new AsyncCachedItem<BitmapSource>(() => Task.FromResult<BitmapSource>(null));
		_thumbnailSubscription = _item.WhenThumbnailUrlChanged.DistinctUntilChanged().ObserveOn(uiScheduler.Scheduler).Subscribe(delegate(Uri uri)
		{
			if (downloadItemVM._currentThumbnailUri != uri)
			{
				downloadItemVM.Thumbnail = new AsyncCachedItem<BitmapSource>(async () => await LoadFromCacheAsync(uri, thumbnailCacheService));
				downloadItemVM._currentThumbnailUri = uri;
			}
		});
	}

	[RelayCommand]
	private void CancelDownload()
	{
		_item.Cancel();
	}

	[RelayCommand(CanExecute = "CanRetryDownload")]
	private void RetryDownload()
	{
		_item.Retry();
	}

	private bool CanRetryDownload()
	{
		return _item.CanRetry();
	}

	private static async Task<BitmapSource?> LoadFromCacheAsync(Uri? url, IUriCacheService<NullableBitmapSource> cacheService)
	{
		if ((object)url == null || !url.IsAbsoluteUri)
		{
			return null;
		}
		return await cacheService.GetAsync(url);
	}

	private string GetStatusText(DownloadProgress? progress)
	{
		if (!progress.HasValue)
		{
			return _localization.Get("DOWNLOADS_POPOVER_ROW_VIEW_DOWNLOAD_PENDING_LABEL_format");
		}
		return progress.Value.Status switch
		{
			DownloadStatus.Stopped => _localization.Get("DOWNLOADS_POPOVER_ROW_VIEW_DOWNLOAD_STOPPED_LABEL_format", new object[2]
			{
				progress.Value.ReceivedBytes.BytesToReadableSizeFormat(),
				progress.Value.TotalBytes.BytesToReadableSizeFormat()
			}), 
			DownloadStatus.Completed => progress.Value.TotalBytes.BytesToReadableSizeFormat(), 
			_ => GetDownloadStatusText(progress.Value), 
		};
	}

	private string GetDownloadStatusText(DownloadProgress progress)
	{
		TimeSlice downloadEta = GetDownloadEta(progress);
		string text = ((downloadEta.TotalMinutes > 1.0) ? _localization.Get("DOWNLOADS_POPOVER_ROW_VIEW_DOWNLOAD_PROGRESS_TIME_FORMAT_WITH_MINUTE_format", downloadEta.TotalMinutes.ToString("F0"), downloadEta.Seconds) : _localization.Get("DOWNLOADS_POPOVER_ROW_VIEW_DOWNLOAD_PROGRESS_TIME_FORMAT_SECOND_ONLY_format", new object[1] { downloadEta.Seconds }));
		return _localization.Get("DOWNLOADS_POPOVER_ROW_VIEW_DOWNLOAD_PROGRESS_LABEL_format", new object[4]
		{
			progress.ReceivedBytes.BytesToReadableSizeFormat(),
			progress.TotalBytes.BytesToReadableSizeFormat(),
			progress.BytesPerSecond.BytesToReadableSizeFormat(),
			text
		});
	}

	private static TimeSlice GetDownloadEta(DownloadProgress progress)
	{
		long num = progress.TotalBytes - progress.ReceivedBytes;
		return TimeSlice.FromSeconds((progress.BytesPerSecond == 0L) ? long.MaxValue : (num / progress.BytesPerSecond));
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			_downloadStatusSubscription.Dispose();
			Name.Dispose();
			_thumbnailSubscription.Dispose();
		}
	}
}
