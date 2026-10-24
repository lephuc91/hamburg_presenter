using System;

namespace Pro.Common.Utility;

public interface IZipArchive
{
	void ExtractEntries(Action<IZipEntry> entryCallback);
}
