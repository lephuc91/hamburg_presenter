using System.Collections.Generic;

namespace Pro.Common.Utility.Zip;

public class ZipHelperImpl : IZipHelper
{
	public void UnzipFile(string filename, string? destination, IUnzipPathStrategy? unzipPathStrategy = null)
	{
		filename.UnzipFile(destination, unzipPathStrategy);
	}

	public void UnzipFile(IZipArchive archive, string? destination, IUnzipPathStrategy? unzipPathStrategy = null)
	{
		archive.UnzipFile(destination, unzipPathStrategy);
	}

	public void ZipFolder(string sourceDirectoryName, string destinationArchiveFileName)
	{
		ZipHelper.ZipFolder(sourceDirectoryName, destinationArchiveFileName);
	}

	public void ZipFolderExcluding(string sourceDirectoryName, string destinationArchiveFileName, IEnumerable<string> excludedFolders)
	{
		ZipHelper.ZipFolderExcluding(sourceDirectoryName, destinationArchiveFileName, excludedFolders);
	}
}
