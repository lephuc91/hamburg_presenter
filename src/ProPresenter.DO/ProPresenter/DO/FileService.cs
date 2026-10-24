using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Pro.Common.FileSystem;
using Pro.Common.Logging;
using Pro.Common.Time;
using Pro.Common.Utility;
using Pro.Localization;
using Pro.UI.DialogService;
using ProPresenter.DO.Import;

namespace ProPresenter.DO;

public class FileService : IFileService
{
	public async Task WriteToTextFileAsync(string filePath, string contents)
	{
		await FileHelper.WriteToTextFileAsync(filePath, contents);
	}

	public void CopyFiles(string sourceFolder, string destinationFolder, bool overwrite)
	{
		FileHelper.CopyAll(sourceFolder, destinationFolder, overwrite);
	}

	public string GetTempDirectory()
	{
		return ImportHelper.GetTempDirectory();
	}

	public string GetTempFile(string extension)
	{
		return ImportHelper.GetTempFile(extension);
	}

	public bool FileExists(string filePath)
	{
		return File.Exists(filePath);
	}

	public FileIOResult WaitForFileAccess(string filename, bool enforceFileExists = false, TimeSlice? timeout = null, FileAccess fileAccess = FileAccess.ReadWrite, bool logFailure = true)
	{
		return FileHelper.WaitForFileAccess(filename, enforceFileExists, timeout, fileAccess, logFailure);
	}

	public async Task<bool> CopyFileAsync(string source, string destination)
	{
		if ((bool)WaitForFileAccess(destination, enforceFileExists: false, null))
		{
			try
			{
				using FileStream streamSource = File.OpenRead(source);
				using FileStream streamDestination = File.Create(destination);
				await streamSource.CopyToAsync(streamDestination);
				return true;
			}
			catch (Exception value)
			{
				Log.Warning($"Unable to copy file -\"{source}\" to \"{destination}\" with error {value}");
			}
		}
		else
		{
			MessageDialogService.ShowSimpleContent(LocalizedStrings.Get("IMPORT_ERROR_UNSUPPORTED_FILES_description"), LocalizedStrings.Get("IMPORT_ERROR_UNSUPPORTED_FILES_info", new object[1] { Path.GetFileName(destination) }), canCancel: false);
		}
		return false;
	}

	public FileIOResult DeleteDirectory(string folder)
	{
		return FileHelper.DeleteDirectory(folder);
	}

	public string GenerateNewFolderName(string path, string folderName)
	{
		return path.GenerateNewFolderName(folderName);
	}

	public bool IsFolderNameUnique(string folderName, string directoryPath)
	{
		return FileHelper.IsFolderNameUnique(folderName, directoryPath);
	}

	public async Task<FileIOResult> CopyAllAsync(string sourceFolder, string destinationFolder, bool overwrite, IProgress<double>? progress = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		return await FileHelper.CopyAllAsync(sourceFolder, destinationFolder, overwrite, progress, cancellationToken);
	}

	public long GetTotalSize(string path)
	{
		return FileHelper.GetTotalSize(path);
	}

	public void RenameFolder(string path, string newName)
	{
		FileHelper.RenameFolder(path, newName);
	}

	public bool FolderExists(string? path)
	{
		if (!string.IsNullOrEmpty(path))
		{
			return Directory.Exists(path);
		}
		return false;
	}

	public void ZipFolder(string sourceDirectoryName, string destinationArchiveFileName)
	{
		ZipHelper.ZipFolder(sourceDirectoryName, destinationArchiveFileName);
	}
}
