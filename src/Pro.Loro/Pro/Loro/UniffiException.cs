using System;

namespace Pro.Loro;

public class UniffiException : Exception
{
	public UniffiException()
	{
	}

	public UniffiException(string message)
		: base(message)
	{
	}
}
