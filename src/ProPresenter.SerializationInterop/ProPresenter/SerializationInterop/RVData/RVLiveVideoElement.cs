using Pro.Serialization.Control;

namespace ProPresenter.SerializationInterop.RVData;

public class RVLiveVideoElement : RVImageElement
{
	[Trait]
	public string videoSourceModelName { get; set; }

	[Trait]
	public string videoSourceID { get; set; }

	[Trait]
	public string videoSourceModelID { get; set; }

	[Trait]
	public int videoFormatIndex { get; set; }

	[Trait]
	public string audioSourceModelName { get; set; }

	[Trait]
	public string audioSourceID { get; set; }

	[Trait]
	public string audioSourceModelID { get; set; }

	[Trait]
	public float audioVolume { get; set; }
}
