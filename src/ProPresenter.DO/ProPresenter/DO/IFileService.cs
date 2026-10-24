using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Pro.Common.FileSystem;
using Pro.Common.Time;

namespace ProPresenter.DO;

public interface IFileService
{
	Task WriteToTextFileAsync(string filePath, string contents);

	void CopyFiles(string sourceFolder, string destinationFolder, bool overwrite);

	string GetTempDirectory();

	string GetTempFile(string extension);

	bool FileExists(string filePath);

	FileIOResult WaitForFileAccess(string filename, bool enforceFileExists = false, TimeSlice? timeout = null, FileAccess fileAccess = FileAccess.ReadWrite, bool logFailure = true);

	Task<bool> CopyFileAsync(string source, string destination);

	FileIOResult DeleteDirectory(string folder);

	string GenerateNewFolderName(string path, string folderName);

	bool IsFolderNameUnique(string folderName, string directoryPath);

	Task<FileIOResult> CopyAllAsync(string sourceFolder, string destinationFolder, bool overwrite, IProgress<double>? progress = null, CancellationToken cancellationToken = default(CancellationToken));

	long GetTotalSize(string path);

	void RenameFolder(string path, string newName);

	bool FolderExists(string? path);

	void ZipFolder(string sourceDirectoryName, string destinationArchiveFileName);
}
