using System;
using Pro.SerializationInterop.RVProtoData.Application;

namespace Pro.CoreApplication;

public class ApplicationException : Exception
{
	public ApplicationException()
	{
	}

	public ApplicationException(Error error)
		: base(error.Description)
	{
	}

	public static ApplicationException ForInvalidPointer(nint ptr)
	{
		return new ApplicationException($"Received invalid pointer ({ptr}) from native code where a valid reference was expected.");
	}

	public static ApplicationException ForInvalidProto(nint reference)
	{
		return new ApplicationException($"Received native reference but expected proto array. Received: {reference}");
	}

	private ApplicationException(string message)
		: base(message)
	{
	}
}
