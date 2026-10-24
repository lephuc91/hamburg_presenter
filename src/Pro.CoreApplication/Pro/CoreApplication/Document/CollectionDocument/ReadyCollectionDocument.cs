using System;
using Google.Protobuf;
using Pro.SerializationInterop.RVProtoData.Service.Document;

namespace Pro.CoreApplication.Document.CollectionDocument;

public abstract record ReadyCollectionDocument<TSelector>(string Path, Guid Id, byte[] Data) : IReadyDocument, IDocument where TSelector : IDocumentCollectionSelector
{
	public void SerializeTo(DocumentSet documentSet)
	{
		Pro.SerializationInterop.RVProtoData.Service.Document.Document item = new Pro.SerializationInterop.RVProtoData.Service.Document.Document
		{
			Uuid = Id.ToString(),
			Path = Path,
			Ready = new Ready
			{
				Data = ByteString.CopyFrom(Data)
			}
		};
		TSelector.GetDocumentCollection(documentSet).Add(item);
	}
}
