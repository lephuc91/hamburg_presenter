using Pro.Serialization.Control;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.SerializationInterop.RVData;

public class RVTransition
{
	[Text]
	public Transition transition { get; set; }
}
