using System;
using Pro.SerializationInterop.RVProtoData.Service.Document;

namespace Pro.CoreApplication.Document.CoreInteraction;

public interface ICoreCloudDocumentSubscription
{
	IObservable<Notification.Types.Patch> WhenPatchReceived { get; }

	IObservable<Notification.Types.Required> WhenDocumentRequired { get; }

	IObservable<Notification.Types.Added> WhenDocumentAdded { get; }

	IObservable<Notification.Types.Available> WhenDocumentAvailable { get; }

	IObservable<Notification.Types.Moved> WhenDocumentRelocated { get; }

	IObservable<Notification.Types.Removed> WhenDocumentRemoved { get; }
}
