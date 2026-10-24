using System;
using System.IO;
using Pro.Common.FileSystem;

namespace ProPresenter.DO.Import.Results;

public class FileCreator : IFileCreator
{
	public void Copy(string source, string dest)
	{
		if (!source.Equals(dest, StringComparison.OrdinalIgnoreCase))
		{
			if (!FileHelper.WaitForFileAccess(dest, enforceFileExists: false, null))
			{
				throw new Exception("Failed to copy file as target was in use");
			}
			if (File.Exists(source))
			{
				File.Copy(source, dest, overwrite: true);
			}
		}
	}

	public void CreateDirectory(string dir)
	{
		Directory.CreateDirectory(dir);
	}

	public bool DirectoryExists(string dir)
	{
		return Directory.Exists(dir);
	}
}
