using System;
using Pro.SerializationInterop.RVProtoData.MediaManagement.v1;

namespace Pro.CoreApplication.Media.V1;

public record MediaServiceV1ErrorResponse(Guid? MediaReferenceId, RequestError Error) : IMediaServiceErrorResponse, IMediaServiceResponse
{
	public string? ContainerId { get; }
}
