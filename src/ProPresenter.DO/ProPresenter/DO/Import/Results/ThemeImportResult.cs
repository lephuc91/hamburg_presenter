using System;
using System.IO.Abstractions;
using System.Linq;
using Pro.Common.Background;
using Pro.Common.Dispatcher;
using Pro.DO.Storage;
using Pro.Entity.Persistence;
using ProPresenter.DO.Media;
using ProPresenter.DO.Themes;

namespace ProPresenter.DO.Import.Results;

public class ThemeImportResult : IImportResult
{
	private readonly IThemeService _themeService;

	private readonly IMediaFactory _mediaFactory;

	private readonly string _unzippedFolder;

	private readonly IFileSystem _fileSystem;

	private readonly IFileService _fileService;

	private readonly IImportHelperServices _importHelpers;

	private readonly ICollectionStorage _collectionStorage;

	public bool ImportWithMediaManagement { get; }

	public ThemeImportResult(string unzippedFolder, IThemeService themeService, IMediaFactory mediaFactory, IFileSystem fileSystem, IFileService fileService, IImportHelperServices importHelpers, ICollectionStorage collectionStorage, bool importWithMediaManagement)
	{
		_unzippedFolder = unzippedFolder;
		_themeService = themeService;
		_mediaFactory = mediaFactory;
		_fileSystem = fileSystem;
		_fileService = fileService;
		_importHelpers = importHelpers;
		_collectionStorage = collectionStorage;
		ImportWithMediaManagement = importWithMediaManagement;
	}

	public string GetTargetFilename(IImportRequest request)
	{
		return string.Empty;
	}

	public void CompleteImport(IImportProcess process, IImportRequest request, string name, bool overwrite, IUiDispatcher dispatcher, string containerId)
	{
		string themes = CommonPaths.Themes;
		foreach (RelativePath item in from d in _fileSystem.Directory.GetDirectories(_unzippedFolder)
			select new RelativePath(d))
		{
			string text = _fileSystem.Path.Combine(item, "Assets");
			RelativePath relativePath = new RelativePath(_fileSystem.Path.Combine(item, "Theme"));
			if (relativePath?.FullPath == null || !_fileService.FileExists(relativePath.FullPath))
			{
				continue;
			}
			if (!ImportWithMediaManagement && relativePath.FullPath != null)
			{
				_importHelpers.RelinkThemeAssets(relativePath.FullPath, _fileSystem.Path.Combine(themes, name), ThemeExtensions.GetAssetPath(name));
			}
			else if (_fileSystem.Directory.Exists(text) && relativePath.FullPath != null)
			{
				_importHelpers.ImportThemeAssets(relativePath.FullPath, text, _fileSystem, _mediaFactory, containerId);
			}
			string text2 = _fileSystem.Path.Combine(themes, name);
			_fileSystem.Directory.CreateDirectory(text2);
			if (item.IsValid && (bool)_fileService.WaitForFileAccess(text2, enforceFileExists: false, null))
			{
				if (!ImportWithMediaManagement)
				{
					_fileService.CopyFiles(item, text2, overwrite: true);
				}
				else
				{
					_fileSystem.File.Copy(relativePath, _fileSystem.Path.Combine(text2, "Theme"), overwrite: true);
				}
				_collectionStorage.HandleLocalLegacyFileCreated(_fileSystem.Path.Combine(text2, _fileSystem.Path.GetFileName(relativePath)));
			}
			ImportSource source = request.Source;
			if ((source == ImportSource.MediaStore || source == ImportSource.WhatsNewModal) ? true : false)
			{
				_themeService?.AddNewlyImportedThemeAsync(new ImportedThemeModel(name, DateTime.Now, userAcknowledgedImportIndicator: false, hasUserViewedThemeDetails: false)).ExecuteAsync();
			}
		}
	}
}
