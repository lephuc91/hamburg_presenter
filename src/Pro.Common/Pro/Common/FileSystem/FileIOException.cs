using System;

namespace Pro.Common.FileSystem;

public class FileIOException : Exception
{
	public FileIOResult Result { get; }

	private FileIOException(FileIOResult result)
		: base(result.Error)
	{
		Result = result;
	}

	public static FileIOException Create(FileIOResult res)
	{
		return new FileIOException(res);
	}
}
