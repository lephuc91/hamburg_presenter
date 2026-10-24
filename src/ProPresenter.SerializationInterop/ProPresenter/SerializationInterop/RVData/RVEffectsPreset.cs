using Pro.Serialization.Control;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.SerializationInterop.RVData;

public class RVEffectsPreset
{
	[Text]
	public Effect.Types.Preset preset { get; set; }
}
