using System;
using Pro.SerializationInterop.RVProtoData.Service.Document;

namespace Pro.CoreApplication.Document.CollectionDocument;

public abstract record RemoteCollectionDocument<TSelector>(string Path, Guid Id) : IDocument where TSelector : IDocumentCollectionSelector
{
	public void SerializeTo(DocumentSet documentSet)
	{
		Pro.SerializationInterop.RVProtoData.Service.Document.Document item = new Pro.SerializationInterop.RVProtoData.Service.Document.Document
		{
			Uuid = Id.ToString(),
			Path = Path,
			Remote = new Remote()
		};
		TSelector.GetDocumentCollection(documentSet).Add(item);
	}
}
