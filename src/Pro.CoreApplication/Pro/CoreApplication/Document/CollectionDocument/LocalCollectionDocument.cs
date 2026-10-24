using System;
using Pro.SerializationInterop.RVProtoData.Service.Document;

namespace Pro.CoreApplication.Document.CollectionDocument;

public abstract class LocalCollectionDocument<TSelector>(string path, Guid id, DateTimeOffset fileTimestamp) : IDocument where TSelector : IDocumentCollectionSelector
{
	public void SerializeTo(DocumentSet documentSet)
	{
		Pro.SerializationInterop.RVProtoData.Service.Document.Document item = new Pro.SerializationInterop.RVProtoData.Service.Document.Document
		{
			Uuid = _003Cid_003EP.ToString(),
			Path = _003Cpath_003EP,
			Local = new Local
			{
				Timestamp = (ulong)Math.Max(0L, _003CfileTimestamp_003EP.ToUnixTimeMilliseconds())
			}
		};
		TSelector.GetDocumentCollection(documentSet).Add(item);
	}
}
