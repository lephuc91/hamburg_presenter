using Pro.Serialization.Control;

namespace ProPresenter.SerializationInterop.RVData;

public class RVSlideTimerCue : RVCue
{
	[Trait]
	public bool loopToBeginning { get; set; }

	[Trait]
	public float duration { get; set; }
}
