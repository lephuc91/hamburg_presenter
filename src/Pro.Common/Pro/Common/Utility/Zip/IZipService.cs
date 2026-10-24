namespace Pro.Common.Utility.Zip;

public interface IZipService
{
	void UnzipFile(string filename, string destination, IUnzipPathStrategy? unzipPathStrategy = null);

	void UnzipFile(IZipArchive archive, string destination, IUnzipPathStrategy? unzipPathStrategy = null);
}
