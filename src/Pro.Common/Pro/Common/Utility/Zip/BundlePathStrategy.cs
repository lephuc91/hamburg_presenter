using System.IO;
using Pro.Common.FileSystem;
using Pro.Common.Nullability;

namespace Pro.Common.Utility.Zip;

public class BundlePathStrategy : IUnzipPathStrategy
{
	public string GetFilename(string path)
	{
		string fileName = Path.GetFileName(path);
		string? directoryNameWithoutPath = path.GetDirectoryNameWithoutPath();
		directoryNameWithoutPath.ThrowWhenNull("folder");
		return Path.Combine(directoryNameWithoutPath, fileName);
	}
}
