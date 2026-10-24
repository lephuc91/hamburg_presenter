using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.HTTP;
using Pro.UI.Components;
using ProPresenter.Controller;
using ProPresenter.DO.Analytics.Events.Welcome;
using ProPresenter.DO.Import;
using ProPresenter.DO.Migration;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Web;
using ProPresenter.UI.ViewModels.Welcome;
using ProPresenter.UI.Welcome;

namespace ProPresenter.ViewModels.Welcome;

public class WelcomeMigrationVM : LinkedNotifyPropertyChangedBase, IWelcomeMigrationVM, INotifyPropertyChanged
{
	private readonly ICoreManager _manager;

	private readonly IWelcomeAnalyticEventsPublisher _analytics;

	private readonly IWebSourceProvider _webSourceProvider;

	private readonly IHyperlinkService _hyperlinkService;

	private bool _playlists = true;

	private bool _mediaBin = true;

	private bool _audioBin = true;

	private bool _settingsSupportFiles = true;

	private MigrationStatus _migrationStatus;

	private readonly MigrationProcess _process;

	public MigrationLibraryCollection Libraries => _process.Libraries;

	public bool Playlists
	{
		get
		{
			return _playlists;
		}
		set
		{
			SetValue("Playlists", ref _playlists, value);
		}
	}

	public bool MediaBin
	{
		get
		{
			return _mediaBin;
		}
		set
		{
			SetValue("MediaBin", ref _mediaBin, value);
		}
	}

	public bool AudioBin
	{
		get
		{
			return _audioBin;
		}
		set
		{
			SetValue("AudioBin", ref _audioBin, value);
		}
	}

	public bool SettingsSupportFiles
	{
		get
		{
			return _settingsSupportFiles;
		}
		set
		{
			SetValue("SettingsSupportFiles", ref _settingsSupportFiles, value);
		}
	}

	public MigrationStatus Status
	{
		get
		{
			return _migrationStatus;
		}
		set
		{
			SetValue("Status", ref _migrationStatus, value);
		}
	}

	public double ImportProgress => _process.CompletedPercentage;

	public bool IsPro6Available => _process.Pro6Available;

	public bool CanMigrateLibraryPlaylists => Libraries.Any((MigrationLibrary l) => l.ShouldImport);

	public ICommand MigrationHelpCommand => new RelayCommand(OnMigrationHelpCommand);

	public WelcomeMigrationVM(ICoreManager manager, IApp app, IWelcomeAnalyticEventsPublisher analytics, INetwork network, IWebSourceProvider webSourceProvider, IHyperlinkService hyperlinkService, IImportProcessFactory importProcessFactory)
	{
		_manager = manager;
		_analytics = analytics;
		_webSourceProvider = webSourceProvider;
		_hyperlinkService = hyperlinkService;
		_process = new MigrationProcess(app, network, importProcessFactory);
		LinkProperties("CompletedPercentage", "ImportProgress");
		LinkProperties("ShouldImport", "CanMigrateLibraryPlaylists");
		_process.PropertyChanged += base.RaiseLinkedValues;
		_process.Libraries.CollectionChanged += Libraries_CollectionChanged;
	}

	public void Initialize()
	{
		Status = MigrationStatus.Init;
		_process.RefreshFolders();
		if (_process.Pro6Available)
		{
			OnPropertyChanged("Libraries");
		}
	}

	public void Complete()
	{
		if (Status == MigrationStatus.InProgress)
		{
			_process.AbortMigration();
			Status = MigrationStatus.Init;
			return;
		}
		_process.MigrateComplete += ImportProcess_MigrateComplete;
		Status = MigrationStatus.InProgress;
		_manager.HideAudienceScreens();
		_manager.HideStageScreens();
		_analytics.MigrationExecuted();
		_process.StartMigration(addToCloud: false, Playlists, MediaBin, AudioBin, SettingsSupportFiles, _manager.OutputConfiguration, showProgressDialog: false);
	}

	private void ImportProcess_MigrateComplete()
	{
		_process.MigrateComplete -= ImportProcess_MigrateComplete;
		Status = MigrationStatus.Completed;
	}

	private void OnMigrationHelpCommand()
	{
		_hyperlinkService.Open(_webSourceProvider.MigrationHelp);
	}

	private void Libraries_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.OfType<MigrationLibrary>().ForEach(delegate(MigrationLibrary ml)
		{
			ml.PropertyChanged -= base.RaiseLinkedValues;
		});
		e.NewItems?.OfType<MigrationLibrary>().ForEach(delegate(MigrationLibrary ml)
		{
			ml.PropertyChanged += base.RaiseLinkedValues;
		});
		OnPropertyChanged("CanMigrateLibraryPlaylists");
	}
}
