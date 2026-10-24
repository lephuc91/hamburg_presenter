using System.Collections.Generic;

namespace Pro.Common.Utility.Zip;

public interface IZipHelper
{
	void UnzipFile(string filename, string? destination, IUnzipPathStrategy? unzipPathStrategy = null);

	void UnzipFile(IZipArchive archive, string? destination, IUnzipPathStrategy? unzipPathStrategy = null);

	void ZipFolder(string sourceDirectoryName, string destinationArchiveFileName);

	void ZipFolderExcluding(string sourceDirectoryName, string destinationArchiveFileName, IEnumerable<string> excludedFolders);
}
