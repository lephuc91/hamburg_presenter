using System;
using System.IO;
using System.IO.Compression;

namespace Pro.Common.Utility;

public class ZipEntryAdapter : IZipEntry
{
	public sealed class DecompressionException : Exception
	{
		public DecompressionException(string description)
			: base(description)
		{
		}
	}

	private readonly ZipArchiveEntry _zipEntry;

	public string Filename => _zipEntry.FullName;

	public ZipEntryAdapter(ZipArchiveEntry zipEntry)
	{
		_zipEntry = zipEntry;
	}

	public void Extract(string targetFilePath)
	{
		Directory.CreateDirectory(Path.GetDirectoryName(targetFilePath) ?? string.Empty);
		_zipEntry.ExtractToFile(targetFilePath, overwrite: true);
	}
}
