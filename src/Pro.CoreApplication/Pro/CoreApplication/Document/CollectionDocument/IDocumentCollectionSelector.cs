using Google.Protobuf.Collections;
using Pro.SerializationInterop.RVProtoData.Service.Document;

namespace Pro.CoreApplication.Document.CollectionDocument;

public interface IDocumentCollectionSelector
{
	static abstract RepeatedField<Pro.SerializationInterop.RVProtoData.Service.Document.Document> GetDocumentCollection(DocumentSet documentSet);
}
