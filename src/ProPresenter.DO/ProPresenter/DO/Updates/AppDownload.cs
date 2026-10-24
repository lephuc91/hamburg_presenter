using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Pro.Common.Background;
using Pro.Common.Downloads;
using Pro.Common.Logging;
using Pro.Common.SourceGenerator.Attributes;
using ProPresenter.DO.Registration.Model;

namespace ProPresenter.DO.Updates;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_cancellableDownload" })]
public sealed class AppDownload : ObservableObject, IAppDownload, INotifyPropertyChanged, IDisposable
{
	[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_cts" })]
	private sealed class CancelableExecution : IDisposable
	{
		private readonly CancellationTokenSource _cts = new CancellationTokenSource();

		private bool _tokenDisposed;

		[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
		private bool _disposed;

		public CancelableExecution(Func<CancellationToken, Task> cancellable)
		{
			RunAsync(cancellable).ExecuteAsync();
		}

		private async Task RunAsync(Func<CancellationToken, Task> cancellable)
		{
			try
			{
				await cancellable(_cts.Token);
			}
			finally
			{
				lock (_cts)
				{
					_cts.Dispose();
					_tokenDisposed = true;
				}
			}
		}

		internal void Cancel()
		{
			lock (_cts)
			{
				if (!_tokenDisposed)
				{
					_cts.Cancel();
				}
			}
		}

		[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
		private void Dispose(bool disposing)
		{
			if (!_disposed && disposing)
			{
				_disposed = true;
				_cts.Dispose();
			}
		}
	}

	private readonly BuildInformation _downloadVersion;

	private readonly IDownloadProcessFactory _downloadProcessFactory;

	private readonly IAppInstallerFactory _appInstallerFactory;

	private readonly ILogger _logger;

	private readonly CancelableExecution _cancellableDownload;

	private IAppInstaller? _installer;

	[ObservableProperty]
	private int _downloadPercentComplete;

	[ObservableProperty]
	private long _bytesDownloaded;

	[ObservableProperty]
	private long _totalBytes;

	[ObservableProperty]
	private bool _downloadFinished;

	[ObservableProperty]
	private bool _downloadSuccessful;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int DownloadPercentComplete
	{
		get
		{
			return _downloadPercentComplete;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_downloadPercentComplete, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.DownloadPercentComplete);
				_downloadPercentComplete = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.DownloadPercentComplete);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public long BytesDownloaded
	{
		get
		{
			return _bytesDownloaded;
		}
		set
		{
			if (!EqualityComparer<long>.Default.Equals(_bytesDownloaded, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.BytesDownloaded);
				_bytesDownloaded = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.BytesDownloaded);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public long TotalBytes
	{
		get
		{
			return _totalBytes;
		}
		set
		{
			if (!EqualityComparer<long>.Default.Equals(_totalBytes, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.TotalBytes);
				_totalBytes = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.TotalBytes);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool DownloadFinished
	{
		get
		{
			return _downloadFinished;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_downloadFinished, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.DownloadFinished);
				_downloadFinished = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.DownloadFinished);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool DownloadSuccessful
	{
		get
		{
			return _downloadSuccessful;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_downloadSuccessful, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.DownloadSuccessful);
				_downloadSuccessful = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.DownloadSuccessful);
			}
		}
	}

	public AppDownload(BuildInformation downloadVersion, IDownloadProcessFactory downloadProcessFactory, IAppInstallerFactory appInstallerFactory, ILogger logger)
	{
		_downloadVersion = downloadVersion;
		_downloadProcessFactory = downloadProcessFactory;
		_appInstallerFactory = appInstallerFactory;
		_logger = logger;
		_cancellableDownload = new CancelableExecution(DoDownloadSoftwareAsync);
	}

	public void CancelDownload()
	{
		_cancellableDownload.Cancel();
	}

	public IAppInstaller? GetInstaller()
	{
		return _installer;
	}

	private async Task DoDownloadSoftwareAsync(CancellationToken token)
	{
		try
		{
			IDownloadProcess download = _downloadProcessFactory.Create(enableSpeedReporting: false);
			DownloadResult downloadResult = await RunDownloadWithProgressReportingAsync(download, _downloadVersion, token);
			if (downloadResult.IsSuccessful)
			{
				DownloadPercentComplete = 100;
				_installer = _appInstallerFactory.Create(downloadResult.Destination);
				DownloadSuccessful = true;
			}
		}
		catch (Exception ex)
		{
			_logger.Error("[{0}] Failed to download app update:\n{1}", "AppUpdateService", ex);
		}
		finally
		{
			DownloadFinished = true;
		}
	}

	private async Task<DownloadResult> RunDownloadWithProgressReportingAsync(IDownloadProcess download, BuildInformation downloadVersion, CancellationToken token)
	{
		using (download.WhenDownloadProgressChanged.Subscribe(delegate(DownloadProgress p)
		{
			DownloadPercentComplete = p.PercentComplete;
			TotalBytes = p.TotalBytes;
			BytesDownloaded = p.ReceivedBytes;
		}))
		{
			return await download.DownloadAsync(downloadVersion.DownloadUrl, token, null, Path.Combine(CommonPaths.Downloads, $"{downloadVersion.BuildNumber}.exe"));
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			_cancellableDownload.Dispose();
		}
	}
}
