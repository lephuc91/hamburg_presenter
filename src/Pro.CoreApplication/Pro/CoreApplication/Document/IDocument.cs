using Pro.SerializationInterop.RVProtoData.Service.Document;

namespace Pro.CoreApplication.Document;

public interface IDocument
{
	void SerializeTo(DocumentSet documentSet);
}
