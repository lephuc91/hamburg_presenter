using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProPresenter.DO.Sync.Local;

public class FileProvider : IFileProvider
{
	public IEnumerable<FileInfo> GetFiles(string path)
	{
		if (Directory.Exists(path))
		{
			return from f in Directory.GetFiles(path, "*.*", SearchOption.AllDirectories)
				select new FileInfo(f);
		}
		return Array.Empty<FileInfo>();
	}
}
