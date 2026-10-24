using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Security;

namespace Pro.Common.FileSystem;

public struct FileIOResult
{
	[MemberNotNullWhen(true, "FilePath")]
	public bool Successful
	{
		[MemberNotNullWhen(true, "FilePath")]
		get
		{
			return Status == IOResult.Success;
		}
	}

	public IOResult Status { get; }

	public string? FilePath { get; }

	public string? Error { get; }

	private FileIOResult(string? pathToFile, IOResult result = IOResult.Unknown, Exception? exc = null)
	{
		FilePath = pathToFile;
		Status = ((exc == null) ? result : ExceptionToResult(exc));
		Error = exc?.Message;
	}

	public static FileIOResult Success()
	{
		return new FileIOResult(null, IOResult.Success);
	}

	public static FileIOResult Exception(string pathToFile, Exception e)
	{
		return new FileIOResult(pathToFile, IOResult.Unknown, e);
	}

	public static FileIOResult Failure(string pathToFile, IOResult r)
	{
		return new FileIOResult(pathToFile, r);
	}

	public static FileIOResult TimedOut(string pathToFile)
	{
		return Failure(pathToFile, IOResult.TimedOut);
	}

	public static FileIOResult NotFound(string pathToFile)
	{
		return Failure(pathToFile, IOResult.NotFound);
	}

	public static FileIOResult Unauthorized(string pathToFile)
	{
		return Failure(pathToFile, IOResult.Unauthorized);
	}

	public static FileIOResult InvalidArgument(string pathToFile)
	{
		return Failure(pathToFile, IOResult.InvalidArgument);
	}

	public static FileIOResult InvalidOperation(string pathToFile)
	{
		return Failure(pathToFile, IOResult.InvalidOperation);
	}

	private static IOResult ExceptionToResult(Exception e)
	{
		if (!(e is ArgumentException))
		{
			if (!(e is InvalidOperationException))
			{
				if (!(e is FileNotFoundException))
				{
					if (!(e is DirectoryNotFoundException))
					{
						if (!(e is SecurityException))
						{
							if (!(e is UnauthorizedAccessException))
							{
								if (e is FileIOException)
								{
									return IOResult.Error;
								}
								return IOResult.Unknown;
							}
							return IOResult.Unauthorized;
						}
						return IOResult.Unauthorized;
					}
					return IOResult.NotFound;
				}
				return IOResult.NotFound;
			}
			return IOResult.InvalidOperation;
		}
		return IOResult.InvalidArgument;
	}

	public static implicit operator bool(FileIOResult result)
	{
		return result.Successful;
	}
}
