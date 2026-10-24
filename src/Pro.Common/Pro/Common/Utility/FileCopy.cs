using System;
using System.IO;
using Pro.Common.Logging;

namespace Pro.Common.Utility;

public class FileCopy : StreamCopy
{
	private readonly string _source;

	private readonly string _destination;

	protected override long SourceLength => base.Source.Length;

	public FileCopy(string source, string destination)
		: base(GetReadStream(source), GetWriteStream(destination))
	{
		_source = source;
		_destination = destination;
	}

	private static Stream GetReadStream(string source)
	{
		return new FileStream(source, FileMode.Open, FileAccess.Read, FileShare.Read);
	}

	private static Stream GetWriteStream(string destination)
	{
		Directory.CreateDirectory(Path.GetDirectoryName(destination) ?? string.Empty);
		return new FileStream(destination, FileMode.Create, FileAccess.Write);
	}

	protected override void OnComplete(bool didSucceed)
	{
		if (didSucceed)
		{
			TryCopyFileAttributes();
			return;
		}
		Log.Error("Error in copying file {0} to {1}", _source, _destination);
		if (File.Exists(_destination))
		{
			File.Delete(_destination);
		}
	}

	private void TryCopyFileAttributes()
	{
		try
		{
			FileInfo fileInfo = new FileInfo(_source);
			File.SetLastWriteTimeUtc(_destination, fileInfo.LastWriteTimeUtc);
			File.SetAttributes(_destination, File.GetAttributes(_source));
		}
		catch (Exception ex)
		{
			Log.Error("Failed to adjust file attributes and write time when copying {0} to {1}\n{2}", _source, _destination, ex);
		}
	}
}
