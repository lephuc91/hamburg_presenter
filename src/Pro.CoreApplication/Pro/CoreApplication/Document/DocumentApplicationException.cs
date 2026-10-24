using System;
using Pro.SerializationInterop.RVProtoData.Service.Document.Call;

namespace Pro.CoreApplication.Document;

public class DocumentApplicationException : Exception
{
	public Error? Error { get; }

	public DocumentApplicationException()
	{
	}

	public DocumentApplicationException(Error error)
		: base($"ErrorCode: {error.Code}")
	{
		Error = error;
	}

	public DocumentApplicationException(nint reference)
		: base($"Received native reference but expected proto array. Received:{reference}")
	{
	}

	public DocumentApplicationException(string errorDescription)
		: base(errorDescription)
	{
	}
}
