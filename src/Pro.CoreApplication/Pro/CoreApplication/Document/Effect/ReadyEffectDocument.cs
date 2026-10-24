using System;
using Pro.SerializationInterop.RVProtoData.Service.Document;

namespace Pro.CoreApplication.Document.Effect;

public record ReadyEffectDocument(string Path, Guid Id, byte[] Data) : IReadyDocument, IDocument
{
	public void SerializeTo(DocumentSet documentSet)
	{
	}
}
