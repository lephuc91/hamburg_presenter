using System.Collections.Generic;
using System.IO;

namespace ProPresenter.DO.Sync.Local;

public interface IFileProvider
{
	IEnumerable<FileInfo> GetFiles(string path);
}
