using Pro.Serialization.Control;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.SerializationInterop.RVData;

public class RVGraphicsElement
{
	[Text]
	public Graphics.Types.Element Element { get; set; }
}
