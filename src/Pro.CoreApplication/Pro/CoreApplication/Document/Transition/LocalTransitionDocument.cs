using System;
using Pro.SerializationInterop.RVProtoData.Service.Document;

namespace Pro.CoreApplication.Document.Transition;

public class LocalTransitionDocument : IDocument
{
	public LocalTransitionDocument(string path, Guid id, DateTimeOffset fileTimestamp)
	{
	}

	public void SerializeTo(DocumentSet documentSet)
	{
	}
}
