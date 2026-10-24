using Google.Protobuf.Collections;
using Pro.CoreApplication.Document.CollectionDocument;
using Pro.SerializationInterop.RVProtoData.Service.Document;

namespace Pro.CoreApplication.Document.Presentation;

public sealed class PresentationCollectionSelector : IDocumentCollectionSelector
{
	public static RepeatedField<Pro.SerializationInterop.RVProtoData.Service.Document.Document> GetDocumentCollection(DocumentSet documentSet)
	{
		return documentSet.Presentations;
	}
}
