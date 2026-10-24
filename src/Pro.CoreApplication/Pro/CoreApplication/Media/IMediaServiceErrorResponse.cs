using System;

namespace Pro.CoreApplication.Media;

public interface IMediaServiceErrorResponse : IMediaServiceResponse
{
	string? ContainerId { get; }

	Guid? MediaReferenceId { get; }
}
