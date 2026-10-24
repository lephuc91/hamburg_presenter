using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Pro.Common.Collections;
using Pro.Common.ErrorReporting;
using Pro.Common.Logging;
using Pro.Common.Strings;
using Pro.Common.Time;
using Pro.Common.Utility;
using Pro.Common.Win32;

namespace Pro.Common.FileSystem;

public static class FileHelper
{
	private sealed class CopyProgressState
	{
		public long BytesCopied { get; set; }
	}

	private static readonly TimeSlice DefaultFileAccessTimeout = TimeSlice.FromSeconds(0.25);

	public static readonly int MaxFilenameLength = 248;

	private static readonly string[] ReservedWords = new string[25]
	{
		"CON", "PRN", "AUX", "CLOCK$", "NUL", "COM0", "COM1", "COM2", "COM3", "COM4",
		"COM5", "COM6", "COM7", "COM8", "COM9", "LPT0", "LPT1", "LPT2", "LPT3", "LPT4",
		"LPT5", "LPT6", "LPT7", "LPT8", "LPT9"
	};

	private const int GUID_D_FORMAT_LENGTH = 36;

	public static string GenerateNewFilename(string filename)
	{
		string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filename);
		string extension = Path.GetExtension(filename);
		string? obj = Path.GetDirectoryName(filename) ?? string.Empty;
		IEnumerable<string> otherEntries = Directory.GetFiles(obj).Collect((string f) => Path.GetFileNameWithoutExtension(f));
		string text = fileNameWithoutExtension.DuplicateName(otherEntries, (string file) => file);
		return Path.Combine(obj, text + extension);
	}

	public static string GenerateNewFolderName(string path)
	{
		if (string.IsNullOrWhiteSpace(path))
		{
			throw new ArgumentException("Path cannot be null or empty.", "path");
		}
		return (Directory.GetParent(path)?.FullName ?? string.Empty).GenerateNewFolderName(Path.GetFileName(path));
	}

	public static string GenerateNewFolderName(this string parentDirectory, string baseFolderName)
	{
		if (string.IsNullOrWhiteSpace(parentDirectory))
		{
			throw new ArgumentException("Parent directory cannot be null or empty.", "parentDirectory");
		}
		List<string> otherFolders = (Directory.Exists(parentDirectory) ? Directory.GetDirectories(parentDirectory).Select(Path.GetFileName).NotNull()
			.ToList() : new List<string>());
		return parentDirectory.GenerateNewFolderName(baseFolderName, otherFolders);
	}

	public static string GenerateNewFolderName(this string parentDirectory, string baseFolderName, IReadOnlyCollection<string> otherFolders)
	{
		if (string.IsNullOrWhiteSpace(parentDirectory))
		{
			throw new ArgumentException("Parent directory cannot be null or empty.", "parentDirectory");
		}
		if (string.IsNullOrWhiteSpace(baseFolderName))
		{
			throw new ArgumentException("Base folder name cannot be null or empty.", "baseFolderName");
		}
		string path = baseFolderName.SanitizeFilename().DuplicateName(otherFolders, (string f) => f);
		return Path.Combine(parentDirectory, path);
	}

	public static string SanitizeFilename(this string source, string replaceWith = "_")
	{
		string text = Path.GetInvalidFileNameChars().Aggregate(source, (string current, char c) => current.Replace(c.ToString(), replaceWith));
		string[] reservedWords = ReservedWords;
		foreach (string arg in reservedWords)
		{
			string pattern = $"^{arg}\\.";
			text = Regex.Replace(text, pattern, replaceWith, RegexOptions.IgnoreCase);
		}
		return text.Truncate(MaxFilenameLength);
	}

	public static string SanitizeFilePath(this string filePath, string replaceWith = "")
	{
		if (string.IsNullOrWhiteSpace(filePath))
		{
			return filePath;
		}
		foreach (string item in from f in Path.GetInvalidFileNameChars()
			select $"\\{f}")
		{
			if (filePath.Contains(item))
			{
				filePath = filePath.Replace(item, replaceWith);
			}
		}
		int num = filePath.LastIndexOf(Path.DirectorySeparatorChar);
		if (num < 0)
		{
			num = filePath.LastIndexOf(Path.AltDirectorySeparatorChar);
		}
		if (num >= 0)
		{
			string path = filePath.Substring(0, num);
			string source = filePath.Substring(num + 1, filePath.Length - num - 1);
			source = source.SanitizeFilename(replaceWith);
			return Path.Combine(path, source);
		}
		return filePath.SanitizeFilename(replaceWith);
	}

	public static bool DoesIncludeReservedWords(this string source, [NotNullWhen(true)] out List<string>? invalidKeywords)
	{
		bool result = false;
		invalidKeywords = null;
		string[] reservedWords = ReservedWords;
		foreach (string text in reservedWords)
		{
			if (source == text || source.StartsWith(text + "."))
			{
				if (invalidKeywords == null)
				{
					invalidKeywords = new List<string>();
				}
				invalidKeywords.Add(text);
				result = true;
			}
		}
		return result;
	}

	public static FileIOResult WaitForFileAccess(string filename, bool enforceFileExists = false, TimeSlice? timeout = null, FileAccess fileAccess = FileAccess.ReadWrite, bool logFailure = true)
	{
		FileStream fileStream;
		FileIOResult result = WaitForFileAccess(filename, out fileStream, enforceFileExists, timeout, fileAccess, logFailure);
		if (result.Successful)
		{
			fileStream?.Close();
		}
		return result;
	}

	public static FileIOResult WaitForFileAccess(string filename, out FileStream? fileStream, bool enforceFileExists = false, TimeSlice? timeout = null, FileAccess fileAccess = FileAccess.ReadWrite, bool logFailure = true)
	{
		fileStream = null;
		if (!enforceFileExists && !File.Exists(filename))
		{
			return FileIOResult.Success();
		}
		if (!timeout.HasValue)
		{
			timeout = DefaultFileAccessTimeout;
		}
		bool flag = false;
		Clock clock = new Clock(autoStart: true);
		while (true)
		{
			try
			{
				fileStream = new FileStream(filename, FileMode.Open, fileAccess);
				return FileIOResult.Success();
			}
			catch (Exception ex)
			{
				if (ex is UnauthorizedAccessException || ex is FileNotFoundException)
				{
					return FileIOResult.Exception(filename, ex);
				}
				if (timeout.Value <= TimeSlice.Zero || clock.ElapsedTime < timeout.Value)
				{
					if (!flag && logFailure)
					{
						Log.Warning("Waiting to access file: {0}", ex.ToString());
						flag = true;
					}
					Thread.Sleep(10);
					continue;
				}
				string message = $"Timed out while waiting to access file: {ex.ToString()}";
				if (logFailure)
				{
					Log.Warning(message);
				}
				return FileIOResult.Exception(filename, ex);
			}
		}
	}

	public static string GetTempFile(string baseDirectory, string extension)
	{
		return Path.Combine(baseDirectory, Guid.NewGuid().ToString() + extension);
	}

	public static string GetTempDirectory(string baseDirectory)
	{
		return Directory.CreateDirectory(Path.Combine(baseDirectory, Path.GetRandomFileName())).FullName;
	}

	public static FileIOResult CopyAll(string source, string target, bool overwrite)
	{
		return CopyAll(new DirectoryInfo(source), new DirectoryInfo(target), overwrite);
	}

	public static FileIOResult MoveToRecycleBin(string filename)
	{
		SHFILEOPSTRUCT sHFILEOPSTRUCT = default(SHFILEOPSTRUCT);
		sHFILEOPSTRUCT.Operation = FO.DELETE;
		sHFILEOPSTRUCT.From = filename;
		sHFILEOPSTRUCT.Flags = FOF.NO_UI | FOF.ALLOWUNDO;
		SHFILEOPSTRUCT fileOp = sHFILEOPSTRUCT;
		SHFILEOPERROR sHFILEOPERROR = WindowsFunctions.SHFileOperationW(ref fileOp);
		if (sHFILEOPERROR == SHFILEOPERROR.DE_SUCCESS && !fileOp.WasAborted)
		{
			return FileIOResult.Success();
		}
		Log.Warning("Failed to move \"{0}\" to the recycle bin. Error: {1}", filename, sHFILEOPERROR);
		return FileIOResult.TimedOut(filename);
	}

	private static FileIOResult CopyAll(DirectoryInfo source, DirectoryInfo target, bool overwrite)
	{
		try
		{
			Directory.CreateDirectory(target.FullName);
			FileInfo[] files = source.GetFiles();
			foreach (FileInfo fileInfo in files)
			{
				string text = Path.Combine(target.FullName, fileInfo.Name);
				if (File.Exists(text))
				{
					if (overwrite)
					{
						fileInfo.CopyTo(text, overwrite: true);
					}
				}
				else
				{
					fileInfo.CopyTo(text);
				}
			}
			DirectoryInfo[] directories = source.GetDirectories();
			foreach (DirectoryInfo directoryInfo in directories)
			{
				CopyAll(directoryInfo, target.CreateSubdirectory(directoryInfo.Name), overwrite);
			}
		}
		catch (Exception e)
		{
			return FileIOResult.Exception(target.FullName, e);
		}
		return FileIOResult.Success();
	}

	public static FileIOResult Copy(string source, string destination, Action? started, Action<double>? progress, Action? completed, IErrorReporter errorReporter)
	{
		string fullPath = Path.GetFullPath(source);
		string fullPath2 = Path.GetFullPath(destination);
		if (fullPath == fullPath2)
		{
			started?.Invoke();
			progress?.Invoke(100.0);
			completed?.Invoke();
			return FileIOResult.Success();
		}
		FileIOResult fileIOResult = WaitForFileAccess(destination, enforceFileExists: false, null);
		if (!fileIOResult)
		{
			return fileIOResult;
		}
		try
		{
			using FileCopy fileCopy = new FileCopy(fullPath, fullPath2);
			fileCopy.Copy(started, progress, delegate
			{
				completed?.Invoke();
			});
		}
		catch (Exception e)
		{
			errorReporter.Error(e, "[{0}] Failed to copy file \"{1}\" (\"{3}\") to destination \"{2}\" (\"{4}\").", "FileHelper", source, destination, fullPath, fullPath2);
			return FileIOResult.Exception(destination, e);
		}
		return FileIOResult.Success();
	}

	public static FileIOResult DeleteDirectory(string folder)
	{
		try
		{
			if (!Directory.Exists(folder))
			{
				return FileIOResult.Success();
			}
			File.SetAttributes(folder, FileAttributes.Normal);
			string[] files = Directory.GetFiles(folder);
			foreach (string path in files)
			{
				File.SetAttributes(path, FileAttributes.Normal);
				File.Delete(path);
			}
			Directory.GetDirectories(folder).ForEach(delegate(string t)
			{
				DeleteDirectory(t);
			});
			Directory.Delete(folder, recursive: false);
		}
		catch (Exception ex)
		{
			Log.Error("Failed to delete folder: " + folder);
			Log.Error(ex);
			return FileIOResult.Exception(folder, ex);
		}
		return FileIOResult.Success();
	}

	public static FileIOResult DeleteFile(string filePath)
	{
		try
		{
			if (!File.Exists(filePath))
			{
				return FileIOResult.Success();
			}
			File.SetAttributes(filePath, FileAttributes.Normal);
			File.Delete(filePath);
		}
		catch (Exception ex)
		{
			Log.Error("Failed to delete file: " + filePath);
			Log.Error(ex);
			return FileIOResult.Exception(filePath, ex);
		}
		return FileIOResult.Success();
	}

	public static async Task WriteToTextFileAsync(string filePath, string contents)
	{
		if ((bool)WaitForFileAccess(filePath, enforceFileExists: false, null))
		{
			using StreamWriter file = File.CreateText(filePath);
			await file.WriteLineAsync(contents);
		}
	}

	public static bool CanEnumeratePath(string path)
	{
		if (new FileInfo(path).Attributes.HasFlag(FileAttributes.Directory))
		{
			try
			{
				if (Directory.Exists(path))
				{
					Directory.GetDirectories(path);
				}
				return true;
			}
			catch (Exception exception)
			{
				Log.Error(exception);
				return false;
			}
		}
		return false;
	}

	public static bool IsFolderNameUnique(string folderName, string directoryPath)
	{
		return !(from path in Directory.GetDirectories(directoryPath)
			select Path.GetFileName(path)).Any((string existingFolder) => string.Equals(existingFolder, folderName, StringComparison.OrdinalIgnoreCase));
	}

	public static async Task<FileIOResult> CopyAllAsync(string source, string target, bool overwrite, IProgress<double>? progress = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		CopyProgressState state = new CopyProgressState();
		return await CopyAllAsync(new DirectoryInfo(source), new DirectoryInfo(target), overwrite, progress, cancellationToken, state);
	}

	private static async Task<FileIOResult> CopyAllAsync(DirectoryInfo source, DirectoryInfo target, bool overwrite, IProgress<double>? progress, CancellationToken cancellationToken, CopyProgressState state)
	{
		_ = 1;
		try
		{
			Directory.CreateDirectory(target.FullName);
			FileInfo[] files = source.GetFiles();
			foreach (FileInfo fileInfo in files)
			{
				cancellationToken.ThrowIfCancellationRequested();
				string text = Path.Combine(target.FullName, fileInfo.Name);
				if (!File.Exists(text) || overwrite)
				{
					await CopyFileAsync(fileInfo.FullName, text, overwrite, cancellationToken, state, progress);
				}
			}
			DirectoryInfo[] directories = source.GetDirectories();
			foreach (DirectoryInfo directoryInfo in directories)
			{
				cancellationToken.ThrowIfCancellationRequested();
				DirectoryInfo target2 = target.CreateSubdirectory(directoryInfo.Name);
				await CopyAllAsync(directoryInfo, target2, overwrite, progress, cancellationToken, state);
			}
		}
		catch (Exception e)
		{
			if (Directory.Exists(target.FullName))
			{
				DeleteDirectory(target.FullName);
			}
			return FileIOResult.Exception(target.FullName, e);
		}
		return FileIOResult.Success();
	}

	private static async Task<long> CopyFileAsync(string sourceFilePath, string targetFilePath, bool overwrite, CancellationToken cancellationToken, CopyProgressState state, IProgress<double>? progress)
	{
		long fileBytesCopied = 0L;
		long result;
		await using (FileStream sourceStream = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read, FileShare.Read, 81920, useAsync: true))
		{
			long num2;
			await using (FileStream targetStream = new FileStream(targetFilePath, (!overwrite) ? FileMode.CreateNew : FileMode.Create, FileAccess.Write, FileShare.None, 81920, useAsync: true))
			{
				byte[] buffer = new byte[81920];
				while (true)
				{
					int num;
					int bytesRead = (num = await sourceStream.ReadAsync(buffer, 0, buffer.Length, cancellationToken));
					if (num <= 0)
					{
						break;
					}
					await targetStream.WriteAsync(buffer, 0, bytesRead, cancellationToken);
					fileBytesCopied += bytesRead;
					state.BytesCopied += bytesRead;
					progress?.Report(state.BytesCopied);
				}
				num2 = fileBytesCopied;
			}
			result = num2;
		}
		return result;
	}

	public static long GetTotalSize(string path)
	{
		if (string.IsNullOrEmpty(path) || !Directory.Exists(path))
		{
			return 0L;
		}
		return Directory.GetFiles(path, "*", SearchOption.AllDirectories).Sum((string file) => new FileInfo(file).Length);
	}

	public static void RenameFolder(string path, string newName)
	{
		string directoryName = Path.GetDirectoryName(Path.GetFullPath(path.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)));
		if (directoryName != null)
		{
			string destDirName = Path.Combine(directoryName, newName);
			Directory.Move(path, destDirName);
		}
	}

	public static bool TryGetIdFromFile(this string file, string baseFilename, [NotNullWhen(true)] out Guid? id)
	{
		id = null;
		if (string.IsNullOrEmpty(file) || string.IsNullOrEmpty(baseFilename))
		{
			return false;
		}
		string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file);
		if (string.IsNullOrEmpty(fileNameWithoutExtension) || !fileNameWithoutExtension.StartsWith(baseFilename, StringComparison.Ordinal))
		{
			return false;
		}
		if (Guid.TryParse(fileNameWithoutExtension.Substring(baseFilename.Length).TrimStart('-'), out var result))
		{
			id = result;
			return true;
		}
		return false;
	}

	public static (string FileName, Guid FileId)? FindCrdtDocument(this string baseFileName, IEnumerable<string> files, Guid? fileId = null)
	{
		foreach (string item in files.Select((string f) => Path.GetFileName(f)))
		{
			if (item.TryGetIdFromFile(baseFileName, out var id) && (!fileId.HasValue || id == fileId.Value))
			{
				return (item, id.Value);
			}
		}
		return null;
	}

	public static bool TryParseFilenameAndIdFromCrdtFile(this string fullPath, [NotNullWhen(true)] out string? baseFilename, [NotNullWhen(true)] out Guid? id)
	{
		baseFilename = null;
		id = null;
		string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fullPath);
		if (fileNameWithoutExtension.Length < 36)
		{
			return false;
		}
		int num = fileNameWithoutExtension.Length - 36;
		if (Guid.TryParse(fileNameWithoutExtension.Substring(num, 36), out var result))
		{
			string text = fileNameWithoutExtension.Substring(0, num).TrimEnd('-');
			baseFilename = text;
			id = result;
			return true;
		}
		return false;
	}

	public static bool TryGetTrimmedCrdtFilePath(this string fullPath, [NotNullWhen(true)] out string? trimmedPath)
	{
		string? fileName = Path.GetFileName(fullPath);
		string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fullPath);
		int num = fileName.Length - fileNameWithoutExtension.Length;
		if (fileNameWithoutExtension.Length <= 37)
		{
			trimmedPath = null;
			return false;
		}
		trimmedPath = fullPath.Substring(0, fullPath.Length - 36 - 1 - num);
		return true;
	}

	public static string CreateCrdtFileName(this string baseFileName, Guid id)
	{
		string text = id.FormatCrdtFileNameId();
		return baseFileName + "-" + text + ".proCloud";
	}

	public static string FormatCrdtFileNameId(this Guid id)
	{
		return id.ToString("D").ToUpper();
	}
}
