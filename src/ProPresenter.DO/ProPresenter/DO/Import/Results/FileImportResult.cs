using System;
using System.IO;
using Pro.Common.Dispatcher;
using Pro.Common.Logging;
using Pro.Entity.Persistence;
using ProPresenter.DO.Import.Requests;

namespace ProPresenter.DO.Import.Results;

public class FileImportResult : IImportResult
{
	private readonly string _filename;

	private readonly string _targetFolder;

	private readonly bool _appendExtension = true;

	private readonly bool _createDirectory;

	private readonly string? _targetFilename;

	private string _targetFile = string.Empty;

	private readonly IFileCreator _fileCreator;

	private readonly ICollectionStorage _collectionStorage;

	public FileImportResult(string filename, string targetFolder, IFileCreator fileCreator, ICollectionStorage collectionStorage, bool appendExtension = true, bool createDirectory = false, string? targetFilename = null)
	{
		if (string.IsNullOrWhiteSpace(targetFolder))
		{
			throw new Exception("Target folder not specified");
		}
		_filename = filename;
		_targetFolder = targetFolder;
		_appendExtension = appendExtension;
		_createDirectory = createDirectory;
		_targetFilename = targetFilename;
		_fileCreator = fileCreator;
		_collectionStorage = collectionStorage;
	}

	public string GetTargetFilename(IImportRequest request)
	{
		if (!string.IsNullOrEmpty(_targetFile))
		{
			return _targetFile;
		}
		if (request is FileImportRequest { SkipFileExistCheck: false } fileImportRequest)
		{
			string finalName = fileImportRequest.FinalName;
			IFileCreator fileCreator = _fileCreator;
			if (fileCreator != null && !fileCreator.DirectoryExists(_targetFolder) && !_createDirectory)
			{
				Log.Error("Target directory for import does not exist [{0}]", _targetFolder);
				return string.Empty;
			}
			_fileCreator?.CreateDirectory(_targetFolder);
			_targetFile = Path.Combine(_targetFolder, (_targetFilename ?? Path.GetFileName(finalName)) + (_appendExtension ? Path.GetExtension(_filename) : string.Empty));
		}
		else
		{
			_targetFile = _filename;
		}
		return _targetFile;
	}

	public void CompleteImport(IImportProcess process, IImportRequest request, string name, bool overwrite, IUiDispatcher dispatcher, string containerId)
	{
		string targetFilename = GetTargetFilename(request);
		_fileCreator?.Copy(_filename, targetFilename);
		if (!string.IsNullOrEmpty(targetFilename))
		{
			_collectionStorage.HandleLocalLegacyFileCreated(targetFilename);
		}
	}
}
