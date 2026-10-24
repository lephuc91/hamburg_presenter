using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO.Abstractions;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Components;
using Pro.Common.HTTP;
using Pro.Localization.Services;
using Pro.UI.Themes;
using Pro.UI.Utility;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Sync.Local;
using ProPresenter.DO.Web;
using ProPresenter.UI.ViewModels.Navigation;
using ProPresenter.UI.ViewModels.Settings;
using ProPresenter.UI.ViewModels.Settings.Pages.Sync;
using ProPresenter.UI.ViewModels.Settings.Search;
using ProPresenter.ViewModels.Settings.Search;

namespace ProPresenter.ViewModels.Settings.Pages;

public class SyncSettingsVM : LinkedObservableObjectBase, ISyncSettingsVM, ISettingsItemVM, ISettingsListItem, INotifyPropertyChanged, ISettingsSearchPage, INavigationItem
{
	private readonly ISync _sync;

	private readonly IFileSelectorService _fileSelector;

	private readonly ILocalization _localization;

	private readonly IFileSystem _fileSystem;

	private readonly IHyperlinkService _hyperlinkService;

	private readonly IWebSourceProvider _webSourceProvider;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? addSourceCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? syncCommand;

	public Guid ID { get; } = Guid.NewGuid();

	public IEnumerable<ISettingsSearchPageField> Fields { get; }

	public ISettingsSearchPageField PageField { get; }

	public IEnumerable<ISettingsSearchPage> SubPages { get; } = Enumerable.Empty<ISettingsSearchPage>();

	public ISyncController SyncController { get; }

	public SyncDirection Direction
	{
		get
		{
			if (!_sync.LocalSyncUp)
			{
				return SyncDirection.SyncDown;
			}
			return SyncDirection.SyncUp;
		}
		set
		{
			switch (value)
			{
			case SyncDirection.SyncDown:
				_sync.LocalSyncDown = true;
				_sync.LocalSyncUp = false;
				break;
			case SyncDirection.SyncUp:
				_sync.LocalSyncDown = false;
				_sync.LocalSyncUp = true;
				break;
			}
		}
	}

	public string Source
	{
		get
		{
			return _sync.LocalSyncSource;
		}
		set
		{
			_sync.LocalSyncSource = value;
		}
	}

	public bool IncludeLibraries
	{
		get
		{
			return _sync.LocalSyncIncludeLibraryDoc;
		}
		set
		{
			_sync.LocalSyncIncludeLibraryDoc = value;
		}
	}

	public bool IncludePlaylists
	{
		get
		{
			return _sync.LocalSyncIncludePlaylists;
		}
		set
		{
			_sync.LocalSyncIncludePlaylists = value;
		}
	}

	public bool IncludeThemes
	{
		get
		{
			return _sync.LocalSyncIncludeTemplates;
		}
		set
		{
			_sync.LocalSyncIncludeTemplates = value;
		}
	}

	public bool IncludeMedia
	{
		get
		{
			return _sync.LocalSyncIncludeMedia;
		}
		set
		{
			_sync.LocalSyncIncludeMedia = value;
		}
	}

	public bool IncludeConfiguration
	{
		get
		{
			return _sync.LocalSyncIncludeUserData;
		}
		set
		{
			_sync.LocalSyncIncludeUserData = value;
		}
	}

	public bool ReplaceFiles
	{
		get
		{
			return _sync.ReplaceFiles;
		}
		set
		{
			_sync.ReplaceFiles = value;
		}
	}

	public ISettingsItemVM? Parent => null;

	public string Name { get; }

	public string ReadySyncTitle => Direction switch
	{
		SyncDirection.SyncDown => _localization.Get("SETTINGS_SYNC_READY_SYNC_DOWN_title"), 
		SyncDirection.SyncUp => _localization.Get("SETTINGS_SYNC_READY_SYNC_UP_title"), 
		_ => string.Empty, 
	};

	public ICommand HelpCommand => new RelayCommand(delegate
	{
		_hyperlinkService.Open(_webSourceProvider.GenerateLink(ResourceType.HelpSyncing));
	});

	public Brush? Background => SettingsListItemConstants.Purple;

	public ImageSource? Icon => Icons.GetIcon(Icons.SettingsSync);

	public bool IsNavigable => true;

	public bool CanExit => true;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand AddSourceCommand => addSourceCommand ?? (addSourceCommand = new RelayCommand(AddSource));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand SyncCommand => syncCommand ?? (syncCommand = new RelayCommand(Sync, CanSync));

	public SyncSettingsVM(ISync sync, ISyncController syncController, IFileSelectorService fileSelector, ILocalization localization, IFileSystem fileSystem, IHyperlinkService hyperlinkService, IWebSourceProvider webSourceProvider, ISettingsSearchFactory settingsSearchFactory)
	{
		_sync = sync;
		SyncController = syncController;
		_fileSelector = fileSelector;
		_localization = localization;
		_fileSystem = fileSystem;
		_hyperlinkService = hyperlinkService;
		_webSourceProvider = webSourceProvider;
		Name = localization.Get("SETTINGS_SYNC_PAGE_title");
		LinkAction("LocalSyncSource", delegate
		{
			OnPropertyChanged("Source");
			SyncCommand.NotifyCanExecuteChanged();
		});
		LinkProperties("LocalSyncIncludeLibraryDoc", "IncludeLibraries");
		LinkProperties("LocalSyncIncludePlaylists", "IncludeMedia");
		LinkProperties("LocalSyncIncludeTemplates", "IncludeThemes");
		LinkProperties("LocalSyncIncludeMedia", "IncludeMedia");
		LinkProperties("LocalSyncIncludeUserData", "IncludeConfiguration");
		LinkProperties("LocalSyncDown", new string[2] { "Direction", "ReadySyncTitle" });
		LinkProperties("LocalSyncUp", new string[2] { "Direction", "ReadySyncTitle" });
		LinkProperties("ReplaceFiles", "ReplaceFiles");
		LinkAction("IsSyncing", SyncCommand.NotifyCanExecuteChanged);
		_sync.PropertyChanged += base.RaiseLinkedValues;
		SyncController.PropertyChanged += base.RaiseLinkedValues;
		PageField = settingsSearchFactory.CreatePageField(Name, this);
		Fields = settingsSearchFactory.GetFields("SETTINGS_SYNC_PAGE_title", this, isComponent: false, PageField).Concat(settingsSearchFactory.GetFields("SETTINGS_SYNC_REPOSITORY_title", this, isComponent: true)).Concat(settingsSearchFactory.GetFields("SETTINGS_SYNC_DIRECTION_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_SYNC_REPLACE_FILES_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_SYNC_INCLUDE_OPTIONS_SECTION_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_SYNC_INCLUDE_LIBRARIES_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_SYNC_INCLUDE_MEDIA_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_SYNC_INCLUDE_PLAYLISTS_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_SYNC_INCLUDE_THEMES_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_SYNC_INCLUDE_SUPPORT_FILES_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_SYNC_SYNC_BUTTON_title", this, isComponent: true));
	}

	[RelayCommand]
	private void AddSource()
	{
		if (_fileSelector.SelectFolderPath(out string selectedPath))
		{
			Source = selectedPath;
		}
	}

	[RelayCommand(CanExecute = "CanSync")]
	private void Sync()
	{
		SyncController.Sync(Direction == SyncDirection.SyncUp, _sync.ReplaceFiles);
	}

	private bool CanSync()
	{
		if (!string.IsNullOrEmpty(Source) && _fileSystem.Directory.Exists(Source))
		{
			return !SyncController.IsSyncing;
		}
		return false;
	}

	public void PromptUnableToExit()
	{
		throw new NotImplementedException();
	}
}
