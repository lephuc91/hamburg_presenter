using System;

namespace Pro.Common.FileSystem;

public class DataVaultException : Exception
{
	public ErrorCode Error { get; }

	public DataVaultException(ErrorCode error)
	{
		Error = error;
	}
}
