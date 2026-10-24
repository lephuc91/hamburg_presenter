using System.Collections.Generic;
using System.IO;
using System.Linq;
using Pro.Common.FileSystem;
using ProPresenter.DO.Import.Requests;

namespace ProPresenter.DO.Import;

public class MediaFileChangedLibrary : IFileChangedLibrary
{
	private readonly Dictionary<string, string> _filenames = new Dictionary<string, string>();

	public void UpdateName(IImportRequest request, string newName)
	{
		if (request is FileImportRequest fileImportRequest)
		{
			_filenames[fileImportRequest.FullName] = newName;
		}
	}

	public string GetNewName(string filePath)
	{
		if (_filenames.Any())
		{
			try
			{
				string value = Path.Combine(filePath.GetDirectoryNameWithoutPath() ?? string.Empty, Path.GetFileName(filePath));
				if (!string.IsNullOrWhiteSpace(value))
				{
					foreach (var (text3, newValue) in _filenames)
					{
						if (text3.Contains(value))
						{
							string fileName = Path.GetFileName(filePath);
							string extension = Path.GetExtension(filePath);
							return filePath.Replace(fileName, newValue) + extension;
						}
					}
				}
			}
			catch
			{
			}
		}
		return filePath;
	}
}
