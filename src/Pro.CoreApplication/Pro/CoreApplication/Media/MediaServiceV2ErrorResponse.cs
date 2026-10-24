using System;

namespace Pro.CoreApplication.Media;

public record MediaServiceV2ErrorResponse<T>(string? ContainerId, Guid? MediaReferenceId, T Error) : IMediaServiceErrorResponse, IMediaServiceResponse;
