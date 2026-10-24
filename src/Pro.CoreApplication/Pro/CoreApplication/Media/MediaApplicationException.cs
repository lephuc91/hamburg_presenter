using System;
using Pro.SerializationInterop.RVProtoData.MediaManagement.v1;

namespace Pro.CoreApplication.Media;

public class MediaApplicationException : Exception
{
	public MediaReference.Types.Error? Error { get; }

	public MediaApplicationException()
	{
	}

	public MediaApplicationException(MediaReference.Types.Error error)
		: base($"ErrorCode: {error.Code}")
	{
		Error = error;
	}

	public MediaApplicationException(nint reference)
		: base($"Received native reference but expected proto array. Received:{reference}")
	{
	}
}
