using System;
using Pro.SerializationInterop.RVProtoData.Service.Document;

namespace Pro.CoreApplication.Document.Effect;

public record RemoteEffectDocument(string Path, Guid Id) : IDocument
{
	public void SerializeTo(DocumentSet documentSet)
	{
	}
}
