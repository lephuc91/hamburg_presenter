using Google.Protobuf.Collections;
using Pro.CoreApplication.Document.CollectionDocument;
using Pro.SerializationInterop.RVProtoData.Service.Document;

namespace Pro.CoreApplication.Document.Theme;

public sealed class ThemeCollectionSelector : IDocumentCollectionSelector
{
	public static RepeatedField<Pro.SerializationInterop.RVProtoData.Service.Document.Document> GetDocumentCollection(DocumentSet documentSet)
	{
		return documentSet.Themes;
	}
}
