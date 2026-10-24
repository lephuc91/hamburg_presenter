using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
using Pro.Common.Components;
using Pro.Common.FileSystem;
using Pro.Common.Logging;
using Pro.DO.Storage;
using Pro.Localization;
using Pro.UI.Components;
using Pro.UI.DialogService;
using Pro.UI.Utility;
using ProPresenter.Controller;
using ProPresenter.DO.Import;
using ProPresenter.DO.Import.AdditionalInfo;
using ProPresenter.DO.Import.Requests;
using ProPresenter.DO.Media;
using ProPresenter.DO.Migration;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.PowerPoint;
using ProPresenter.DO.Settings;
using ProPresenter.UI.Migration;
using ProPresenter.UI.ViewModels;
using ProPresenter.ViewModels.Library;

namespace ProPresenter.ViewModels;

public class MigrationVM : NotifyPropertyChangedBase, IMigrationVM, INotifyPropertyChanged
{
	private readonly IOutputConfiguration _outputConfiguration;

	private bool _migrateLibraries = true;

	private bool _addToCloud = true;

	private bool _migratePlaylists = true;

	private bool _migrateMedia = true;

	private bool _migrateSettings = true;

	private readonly MigrationProcess _process;

	private readonly ICoreManager _manager;

	private readonly IMediaImportDownloadDialogService _mediaImportDownloadDialogService;

	private readonly IImportProcessFactory _importProcessFactory;

	private readonly IPowerPointImportOptionsDialog _powerPointImportOptionsDialog;

	public bool MigrateLibraries
	{
		get
		{
			return _migrateLibraries;
		}
		set
		{
			SetValue("MigrateLibraries", ref _migrateLibraries, value);
		}
	}

	public bool AddToCloud
	{
		get
		{
			return _addToCloud;
		}
		set
		{
			SetValue("AddToCloud", ref _addToCloud, value);
		}
	}

	public bool MigratePlaylists
	{
		get
		{
			return _migratePlaylists;
		}
		set
		{
			SetValue("MigratePlaylists", ref _migratePlaylists, value);
		}
	}

	public bool MigrateMedia
	{
		get
		{
			return _migrateMedia;
		}
		set
		{
			SetValue("MigrateMedia", ref _migrateMedia, value);
		}
	}

	public bool MigrateSettings
	{
		get
		{
			return _migrateSettings;
		}
		set
		{
			SetValue("MigrateSettings", ref _migrateSettings, value);
		}
	}

	public MigrationLibraryCollection Libraries => _process.Libraries;

	public ICommand ImportPresentationCommand => new RelayCommand(OnImportPresentationCommand);

	public ICommand ImportFromClipboardCommand => new RelayCommand(OnImportFromClipboardCommand);

	public ICommand ImportPowerPointCommand => new RelayCommand(OnImportPowerpointCommand);

	public ICommand ImportPowerPointLegacyCommand => new RelayCommand(OnImportPowerpointLegacyCommand);

	public ICommand ImportMediaCommand => new RelayCommand(OnImportMediaCommand);

	public ICommand ImportFromPreviousVersionCommand => new RelayCommand(OnImportFromPreviousVersionCommand);

	public ICommand<MigrationLibrary?> ReplaceLibraryCommand => new RelayCommand<MigrationLibrary>(OnReplaceLibraryCommand, (MigrationLibrary? m) => m != null);

	public MigrationVM(ICoreManager manager, IMediaImportDownloadDialogService mediaImportDownloadDialogService, IApp app, INetwork network, IImportProcessFactory importProcessFactory, IPowerPointImportOptionsDialog powerPointImportOptionsDialog)
	{
		_process = new MigrationProcess(app, network, importProcessFactory);
		_importProcessFactory = importProcessFactory;
		_powerPointImportOptionsDialog = powerPointImportOptionsDialog;
		_outputConfiguration = manager.OutputConfiguration;
		_manager = manager;
		_mediaImportDownloadDialogService = mediaImportDownloadDialogService;
	}

	private void OnImportFromPreviousVersionCommand()
	{
		_process.RefreshFolders();
		if (_process.Pro6Available)
		{
			if (new MigrationAssistantDialog
			{
				DataContext = this,
				ReplaceLibraryCommand = ReplaceLibraryCommand
			}.ShowDialog() == true)
			{
				_manager.HideAudienceScreens();
				_manager.HideStageScreens();
				_process.StartMigration(MigrateLibraries && AddToCloud, MigrateLibraries && MigratePlaylists, MigrateMedia, MigrateMedia, MigrateSettings, _outputConfiguration);
			}
		}
		else
		{
			MessageDialogService.ShowAlert(LocalizedStrings.Get("IMPORT_MIGRATION_ALERT_info"));
		}
	}

	private void OnReplaceLibraryCommand(MigrationLibrary? folderToReplace)
	{
		if (DialogHelper.SelectFolderPath(out string selectedPath))
		{
			_process.Libraries.ReplaceFolder(folderToReplace, selectedPath);
		}
	}

	private void OnImportPresentationCommand()
	{
		ImportFiles(FileFilters.ImportableFileFilter);
	}

	private void ImportFiles(string fileFilter, bool useLegacyPptImport = false)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog
		{
			Multiselect = true,
			Filter = fileFilter
		};
		if (openFileDialog.ShowDialog() == true && openFileDialog.FileNames.Length != 0)
		{
			IImportProcess importProcess = _importProcessFactory.Create(openFileDialog.FileNames);
			if (openFileDialog.FileNames.Any((string f) => f.IsOpenXmlPowerPointFile()))
			{
				importProcess.PowerPointInfo = new PowerPointInfo(useLegacyPptImport, IgnoreBackgrounds: false);
			}
			importProcess.SelectedPlaylist = _manager.ActiveLibraryPlaylist;
			importProcess.StartImport();
		}
	}

	private void OnImportFromClipboardCommand()
	{
		try
		{
			string text = string.Empty;
			try
			{
				text = Clipboard.GetText();
			}
			catch (COMException ex)
			{
				Log.Error("Failed to parse text from clipboard: {0}", ex);
			}
			if (!string.IsNullOrEmpty(text))
			{
				string text2 = string.Empty;
				StringReader stringReader = new StringReader(text);
				while (string.IsNullOrEmpty(text2))
				{
					text2 = stringReader.ReadLine()?.Trim() ?? string.Empty;
				}
				text2 = text2.Replace(":", "");
				text2 = ((text2.Length > 30) ? text2.Substring(0, 30).Trim() : text2);
				IImportProcess importProcess = _importProcessFactory.Create(new MemoryImportRequest(text2, text));
				importProcess.SelectedPlaylist = _manager.ActiveLibraryPlaylist;
				importProcess.StartImport();
			}
			else
			{
				MessageDialogService.ShowAlert(LocalizedStrings.Get("IMPORT_ERROR_CLIPBOARD_DOES_NOT_CONTAIN_TEXT_info"));
			}
		}
		catch (Exception ex2)
		{
			MessageDialogService.ShowAlert(ex2.Message);
		}
	}

	private void OnImportPowerpointCommand()
	{
		ImportFiles(FileFilters.OpenXMLPowerPointFilter);
	}

	private void OnImportPowerpointLegacyCommand()
	{
		if (CanImportPowerPoint())
		{
			ImportFiles(FileFilters.AllPowerPointFilter, useLegacyPptImport: true);
		}
		else
		{
			MessageDialogService.ShowAlert(LocalizedStrings.Get("IMPORT_ERROR_POWERPOINT_NOT_DETECTED_description"));
		}
	}

	private static bool CanImportPowerPoint()
	{
		return PowerPointHelper.IsPowerPointInstalled();
	}

	private void OnImportMediaCommand()
	{
		OpenFileDialog openFileDialog = new OpenFileDialog
		{
			Multiselect = true,
			Filter = FileFilters.VisualOnlyFilter
		};
		if (openFileDialog.ShowDialog() != true || !openFileDialog.FileNames.Any())
		{
			return;
		}
		VisualPlaylist targetPlaylist = _mediaImportDownloadDialogService.Show()?.SelectedPlaylist;
		if (targetPlaylist == null)
		{
			return;
		}
		if (targetPlaylist.Type == PlaylistType.Smart)
		{
			MessageDialogService.ShowAlert(LocalizedStrings.Get("PLAYLIST_GLOBAL_ALERT_SMART_PLAYLIST_IMPORT_message"));
			return;
		}
		FileImportRequest[] requests = openFileDialog.FileNames.Select((string f) => new FileImportRequest(f, delegate(string o, string n, FileMediaBase? createdMedia)
		{
			if (createdMedia != null)
			{
				targetPlaylist.AddMediaItem(createdMedia, userInitiated: true);
			}
			else
			{
				targetPlaylist.ImportMedia((RelativePath)n);
			}
		})).ToArray();
		_importProcessFactory.Create(requests).StartImport();
	}
}
