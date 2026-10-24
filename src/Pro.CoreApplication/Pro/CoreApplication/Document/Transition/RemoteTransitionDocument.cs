using System;
using Pro.SerializationInterop.RVProtoData.Service.Document;

namespace Pro.CoreApplication.Document.Transition;

public record RemoteTransitionDocument(string Path, Guid Id) : IDocument
{
	public void SerializeTo(DocumentSet documentSet)
	{
	}
}
