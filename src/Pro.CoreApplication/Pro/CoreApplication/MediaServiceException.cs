using Pro.SerializationInterop.RVProtoData.Application;
using Pro.SerializationInterop.RVProtoData.MediaManagement.v1;

namespace Pro.CoreApplication;

public class MediaServiceException : ApplicationException
{
	public RequestError.Types.ErrorCode ErrorCode { get; }

	public MediaServiceException(Error error)
		: base(error)
	{
		ErrorCode = (RequestError.Types.ErrorCode)error.Code;
	}
}
