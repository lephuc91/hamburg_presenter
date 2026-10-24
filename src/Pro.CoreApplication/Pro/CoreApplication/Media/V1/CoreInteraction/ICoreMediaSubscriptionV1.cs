using System;
using Pro.CoreApplication.Media.CoreInteraction;
using Pro.SerializationInterop.RVProtoData.MediaManagement.v1;

namespace Pro.CoreApplication.Media.V1.CoreInteraction;

public interface ICoreMediaSubscriptionV1
{
	IObservable<MediaReference> WhenMediaReferenceChanged { get; }

	IObservable<ConnectionStatus> WhenConnectionStatusChanged { get; }

	IObservable<MediaManagementStatus> WhenMediaManagementStatusUpdated { get; }
}
