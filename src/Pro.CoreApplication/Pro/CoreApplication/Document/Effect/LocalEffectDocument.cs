using System;
using Pro.SerializationInterop.RVProtoData.Service.Document;

namespace Pro.CoreApplication.Document.Effect;

public class LocalEffectDocument : IDocument
{
	public LocalEffectDocument(string path, Guid id, DateTimeOffset fileTimestamp)
	{
	}

	public void SerializeTo(DocumentSet documentSet)
	{
	}
}
