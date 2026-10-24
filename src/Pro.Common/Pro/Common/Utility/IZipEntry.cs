namespace Pro.Common.Utility;

public interface IZipEntry
{
	string Filename { get; }

	void Extract(string targetFilePath);
}
