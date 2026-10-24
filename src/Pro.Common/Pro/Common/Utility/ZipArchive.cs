using System;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace Pro.Common.Utility;

public class ZipArchive : IZipArchive
{
	private readonly string _file;

	public ZipArchive(string file)
	{
		_file = file;
	}

	public void ExtractEntries(Action<IZipEntry> entryCallback)
	{
		try
		{
			using System.IO.Compression.ZipArchive zipArchive = ZipFile.OpenRead(_file);
			foreach (ZipArchiveEntry item in zipArchive.Entries.Where((ZipArchiveEntry e) => e.Length > 0 && !Path.EndsInDirectorySeparator(e.FullName)))
			{
				entryCallback(new ZipEntryAdapter(item));
			}
		}
		catch (Exception innerException)
		{
			throw new InvalidDataException("failed to extract " + _file, innerException);
		}
	}
}
