using Pro.Serialization.Control;

namespace ProPresenter.SerializationInterop.RVData;

public class RVPCOSongSequence
{
	[Trait]
	public int id { get; set; }

	[Trait]
	public string sequenceName { get; set; }
}
