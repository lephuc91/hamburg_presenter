using System;
using System.IO;
using System.Threading.Tasks;
using Pro.Common.Logging;
using Pro.Common.Strings;

namespace Pro.Common.FileSystem;

public class FileUtility : IFileUtility
{
	private readonly ILogger _logger;

	public FileUtility(ILogger logger)
	{
		_logger = logger;
	}

	public async Task<bool> MoveToRecycleBin(string filePath)
	{
		return await Task.Run(delegate
		{
			try
			{
				return FileHelper.MoveToRecycleBin(filePath);
			}
			catch
			{
				return false;
			}
		});
	}

	public async Task<bool> MoveToFolder(string filePath, string targetFolder)
	{
		return await Task.Run(delegate
		{
			try
			{
				string[] files = Directory.GetFiles(targetFolder);
				string extension = Path.GetExtension(filePath);
				string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
				fileNameWithoutExtension = fileNameWithoutExtension.DuplicateName(files, (string s) => Path.GetFileNameWithoutExtension(s), isCaseInsensitive: false);
				string destFileName = Path.Combine(targetFolder, fileNameWithoutExtension + extension);
				File.Move(filePath, destFileName);
				return true;
			}
			catch (Exception value)
			{
				_logger.Error($"Unable to move file \"{filePath}\" to \"{targetFolder}\" with error - {value}");
				return false;
			}
		});
	}
}
