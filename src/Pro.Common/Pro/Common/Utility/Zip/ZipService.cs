namespace Pro.Common.Utility.Zip;

public class ZipService : IZipService
{
	public void UnzipFile(string filename, string destination, IUnzipPathStrategy? unzipPathStrategy = null)
	{
		filename.UnzipFile(destination, unzipPathStrategy);
	}

	public void UnzipFile(IZipArchive archive, string destination, IUnzipPathStrategy? unzipPathStrategy = null)
	{
		archive.UnzipFile(destination, unzipPathStrategy);
	}
}
