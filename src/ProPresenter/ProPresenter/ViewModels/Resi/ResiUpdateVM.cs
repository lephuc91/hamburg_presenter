using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Pro.Common.Background;
using Pro.Common.Components;
using Pro.Common.MessageService;
using Pro.Common.MessageService.AppMessages;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Time;
using Pro.Common.Time.Timer;
using Pro.Common.Utility;
using Pro.Localization;
using Pro.UI.Components;
using Pro.UI.DialogService;
using Pro.UI.Utility;
using ProPresenter.DO.Resi;
using ProPresenter.DO.Settings;
using ProPresenter.UI.Resi;
using ProPresenter.UI.ViewModels.Resi;

namespace ProPresenter.ViewModels.Resi;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_periodicUpdateCheck" })]
public class ResiUpdateVM : LinkedNotifyPropertyChangedBase, IResiUpdateVM, INotifyPropertyChanged, IDisposable
{
	private readonly Lazy<UpdateWindow> _updateWindow;

	private readonly IResiController _controller;

	private readonly IApp _app;

	private string _updateDisplayText = string.Empty;

	private readonly IPeriodicTimer _periodicUpdateCheck;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public UpdateStatus UpdateStatus => _controller.UpdateStatus;

	public string UpdateDisplayText
	{
		get
		{
			return _updateDisplayText;
		}
		set
		{
			SetValue("UpdateDisplayText", ref _updateDisplayText, value);
		}
	}

	private UpdateWindow Window => _updateWindow.Value;

	public double DownloadProgress => _controller.DownloadProgress;

	public ICommand InstallNowCommand => new RelayCommand(OnInstall);

	public ICommand InstallLaterCommand => new RelayCommand(Window.Close);

	public ICommand CancelDownloadCommand => new RelayCommand(delegate
	{
		_controller.CancelDownload();
		Window.Close();
	});

	public ResiUpdateVM(IResiController controller, IApp app, ITimerFactory timerFactory, IMessageService messageService)
	{
		_controller = controller;
		_app = app;
		_updateWindow = new Lazy<UpdateWindow>(() => new UpdateWindow().WithDataContext(this));
		LinkAction("UpdateStatus", delegate
		{
			OnPropertyChanged("UpdateStatus");
			if (_controller.UpdateStatus == UpdateStatus.None)
			{
				Window.Close();
			}
		});
		LinkProperties("DownloadProgress", "DownloadProgress");
		LinkAction("PluginVersion", delegate
		{
			if (_controller.PluginVersion != null)
			{
				CheckForUpdateAsync(manualCheck: false).ExecuteAsync();
			}
		});
		_controller.PropertyChanged += base.RaiseLinkedValues;
		_periodicUpdateCheck = timerFactory.CreatePeriodicDispatched(TimeSlice.FromDays(1.0), delegate
		{
			CheckForEncodeUpdates().ExecuteAsync();
		});
		messageService.SubscribeToMessage<MainWindowContentRenderedMessage>(delegate
		{
			CheckForEncodeUpdates().ExecuteAsync();
		});
	}

	public async Task CheckForUpdateAsync(bool manualCheck)
	{
		if (!InternetAccessCheck.IsInternetAvailable() || !_controller.CanCheckForUpdate)
		{
			return;
		}
		Version version = await _controller.CheckUpdateAsync();
		if (!(_controller.PluginVersion != null))
		{
			return;
		}
		if (_controller.UpdateAvailable)
		{
			if (manualCheck || _app.NotifyUpdates)
			{
				UpdateDisplayText = LocalizedStrings.Get("RESI_UPDATE_MANAGER_SHOULD_UPDATE_NOW_message") + "\n\n" + LocalizedStrings.Get("RESI_UPDATE_MANAGER_SHOULD_UPDATE_NOW_informative", new object[2]
				{
					_controller.PluginVersion.ToString(),
					version?.ToString() ?? string.Empty
				});
				Window.ShowDialog();
			}
		}
		else if (manualCheck)
		{
			MessageDialogService.ShowAlert(LocalizedStrings.Get("RESI_UPDATE_MANAGER_PLUGIN_IS_UP_TO_DATE_message"));
		}
	}

	private async Task CheckForEncodeUpdates()
	{
		if (_controller.PluginVersion != null)
		{
			await CheckForUpdateAsync(manualCheck: false);
		}
	}

	private void OnInstall()
	{
		_controller.Download();
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
			OnDispose();
			_periodicUpdateCheck.Dispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		_periodicUpdateCheck.Stop();
	}
}
