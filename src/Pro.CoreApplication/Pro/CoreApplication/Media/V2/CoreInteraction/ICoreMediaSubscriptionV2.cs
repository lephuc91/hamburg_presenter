using System;
using Pro.CoreApplication.Media.CoreInteraction;
using Pro.SerializationInterop.RVProtoData.MediaManagement.v2;

namespace Pro.CoreApplication.Media.V2.CoreInteraction;

public interface ICoreMediaSubscriptionV2
{
	IObservable<MediaReference> WhenMediaReferenceChanged { get; }

	IObservable<ImportMediaV2> WhenMediaImported { get; }

	IObservable<ConnectionStatus> WhenConnectionStatusChanged { get; }

	IObservable<MediaManagementStatus> WhenMediaManagementStatusUpdated { get; }
}
