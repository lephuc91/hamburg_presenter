using System;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using Pro.Common.Background;
using Pro.Common.Components;
using Pro.Common.Dispatcher;
using Pro.Common.Downloads;
using Pro.Common.FileSystem;
using Pro.Common.Logging;
using Pro.Common.Utility;
using Pro.Interprocess;
using ProPresenter.DO.Downloads;

namespace ProPresenter.DO.Resi;

public class UpdateClient : LinkedNotifyPropertyChangedBase, IUpdateClient, INotifyPropertyChanged, IDownloader, IDownloadProgress
{
	private static readonly string _installPath = CommonPaths.InstallLocation;

	private readonly IResiPlugin _plugin;

	private readonly IResiWebClient _resiWebClient;

	private UpdateStatus _updateStatus = UpdateStatus.Starting;

	private bool _isDownloading;

	private double _downloadProgress;

	private string _resiPluginUpdateFile = string.Empty;

	private readonly IUiDispatcher _dispatcher;

	private readonly IDownloadItemFactory _downloadItemFactory;

	private IDisposable? _downloadProgressSubscription;

	private readonly object _downloadLock = new object();

	private bool _didInitiateInstall;

	public UpdateStatus UpdateStatus
	{
		get
		{
			return _updateStatus;
		}
		private set
		{
			SetValue("UpdateStatus", ref _updateStatus, value);
		}
	}

	public bool IsDownloading
	{
		get
		{
			return _isDownloading;
		}
		private set
		{
			SetValue("IsDownloading", ref _isDownloading, value, delegate(bool o, bool n)
			{
				if (n)
				{
					UpdateStatus = UpdateStatus.Downloading;
				}
			});
		}
	}

	public double DownloadProgress
	{
		get
		{
			return _downloadProgress;
		}
		private set
		{
			SetValue("DownloadProgress", ref _downloadProgress, value);
		}
	}

	public UpdateClient(IResiPlugin plugin, IMessages<AppMessages> messages, IResiWebClient resiWebClient, IUiDispatcher uiDispatcher, IDownloadItemFactory downloadItemFactory)
	{
		_plugin = plugin;
		_resiWebClient = resiWebClient;
		_dispatcher = uiDispatcher;
		_downloadItemFactory = downloadItemFactory;
		messages.RegisterHandler(AppMessages.InstallFinished, delegate
		{
			if (_didInitiateInstall)
			{
				UpdateStatus = UpdateStatus.Starting;
				_plugin.EndUpdate();
			}
		});
		LinkAction("PluginStatus", delegate
		{
			switch (_plugin.PluginStatus)
			{
			case PluginStatus.Stopped:
				DoInstall();
				break;
			case PluginStatus.Starting:
				UpdateStatus = UpdateStatus.Starting;
				break;
			case PluginStatus.Started:
				UpdateStatus = UpdateStatus.None;
				_resiPluginUpdateFile = string.Empty;
				break;
			}
		});
		_plugin.PropertyChanged += base.RaiseLinkedValues;
		if (!_plugin.PluginInstalled)
		{
			UpdateStatus = UpdateStatus.None;
		}
	}

	public void Download()
	{
		DownloadProgress = 0.0;
		IsDownloading = true;
		OnDownloadPlugin().ExecuteAsync();
	}

	private async Task OnDownloadPlugin()
	{
		string text = await _resiWebClient.GetLatestVersionDownloadLinkAsync(_plugin.SupportedApiVersion);
		if (!string.IsNullOrEmpty(text) && _plugin.CanCheckForUpdate)
		{
			_resiPluginUpdateFile = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
			IDownloadItem downloadItem = _downloadItemFactory.Create(text, _resiPluginUpdateFile, "Resi Plugin");
			lock (_downloadLock)
			{
				_downloadProgressSubscription = downloadItem.WhenDownloadProgressChanged.Subscribe(OnDownloading, OnDownloadError);
			}
			downloadItem.Download();
		}
	}

	private void OnDownloading(DownloadProgress downloadProgress)
	{
		_dispatcher.InvokeAsync(delegate
		{
			IsDownloading = true;
			DownloadProgress = (IsDownloading ? downloadProgress.PercentComplete : 0);
			if (downloadProgress.Status == DownloadStatus.Completed)
			{
				OnDownloadComplete();
				lock (_downloadLock)
				{
					_downloadProgressSubscription?.Dispose();
					_downloadProgressSubscription = null;
				}
			}
		});
	}

	private void OnDownloadError(Exception e)
	{
		_dispatcher.InvokeAsync(delegate
		{
			IsDownloading = false;
			DownloadProgress = 0.0;
			Log.Error($"Unable to download resi plugin with error - {e}");
		});
	}

	private void OnDownloadComplete()
	{
		_dispatcher.InvokeAsync(delegate
		{
			UpdateStatus = UpdateStatus.Installing;
			IsDownloading = false;
			_plugin.BeginUpdate();
		});
	}

	private void DoInstall()
	{
		if (string.IsNullOrWhiteSpace(_resiPluginUpdateFile) || !File.Exists(_resiPluginUpdateFile))
		{
			return;
		}
		_didInitiateInstall = true;
		SharedWorkerPool.Queue.AddJob(delegate
		{
			string tempDirectory = FileHelper.GetTempDirectory(CommonPaths.Temp);
			_resiPluginUpdateFile.UnzipFile(tempDirectory);
			string text = tempDirectory + "\\ResiStreamingEngine";
			string text2 = _installPath + "\\ResiStreamingEngine";
			if (!ProcessHelper.StartProcess(Path.Combine(_installPath, "InstallHelper.exe"), "\"" + text + "\" \"" + text2 + "\""))
			{
				_dispatcher.InvokeAsync(delegate
				{
					UpdateStatus = UpdateStatus.None;
					_plugin.ResetStatus();
				});
			}
			if ((bool)FileHelper.WaitForFileAccess(_resiPluginUpdateFile, enforceFileExists: false, null))
			{
				File.Delete(_resiPluginUpdateFile);
			}
			_resiPluginUpdateFile = string.Empty;
		});
	}

	public void CancelDownload()
	{
		UpdateStatus = UpdateStatus.None;
		IsDownloading = false;
		_resiPluginUpdateFile = string.Empty;
	}
}
