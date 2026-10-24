using Pro.DO.Application;
using Pro.SerializationInterop.RVProtoData;
using Pro.Text;
using Pro.Text.Fills;

namespace Pro.DO.Utility;

public class TextDocumentFactory : ITextDocumentFactory
{
	private readonly ITextFillMediaFactory _textFillMediaFactory;

	public TextDocumentFactory(ITextFillMediaFactory textFillMediaFactory)
	{
		_textFillMediaFactory = textFillMediaFactory;
	}

	public TextDocument? Create(Graphics.Types.Text protoText, string containerId, ApplicationData? applicationData = null)
	{
		return protoText.ToDocument(_textFillMediaFactory, containerId, applicationData);
	}

	public TextDocument? Create(byte[]? byteArr, string containerId)
	{
		return byteArr.FromByteArray(_textFillMediaFactory, containerId);
	}
}
