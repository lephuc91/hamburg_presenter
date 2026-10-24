using Pro.DO.Application;
using Pro.SerializationInterop.RVProtoData;
using Pro.Text;

namespace Pro.DO.Utility;

public interface ITextDocumentFactory
{
	TextDocument? Create(Graphics.Types.Text protoText, string containerId, ApplicationData? applicationData = null);

	TextDocument? Create(byte[]? byteArr, string containerId);
}
