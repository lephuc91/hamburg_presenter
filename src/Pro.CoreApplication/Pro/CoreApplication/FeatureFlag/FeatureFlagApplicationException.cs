using System;
using Pro.SerializationInterop.RVProtoData.FeatureFlags;

namespace Pro.CoreApplication.FeatureFlag;

public class FeatureFlagApplicationException : Exception
{
	public Error? Error { get; }

	public FeatureFlagApplicationException()
	{
	}

	public FeatureFlagApplicationException(Error error)
		: base($"ErrorCode: {error.Code}")
	{
		Error = error;
	}

	public FeatureFlagApplicationException(nint reference)
		: base($"Received native reference but expected proto array. Received:{reference}")
	{
	}
}
