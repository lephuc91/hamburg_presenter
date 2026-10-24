using System;

namespace Pro.CoreApplication.Media;

public interface IMediaService
{
	IObservable<IMediaServiceResponse> WhenMediaReferenceChanged { get; }

	IObservable<MediaManagementStatus> WhenMediaManagementStatusChanged { get; }
}
