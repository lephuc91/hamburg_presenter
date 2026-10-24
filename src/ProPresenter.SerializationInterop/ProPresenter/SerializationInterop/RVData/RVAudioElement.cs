using System;
using Pro.Serialization.Control;

namespace ProPresenter.SerializationInterop.RVData;

public class RVAudioElement
{
	[Trait]
	public Uri source { get; set; }

	[Trait]
	public float volume { get; set; }

	[Trait]
	public float playRate { get; set; }

	[Trait]
	public RVPlaybackBehaviorType loopBehavior { get; set; }

	[Trait]
	public int audioType { get; set; }

	[Trait]
	public float inPoint { get; set; }

	[Trait]
	public float outPoint { get; set; }

	[Trait]
	public string displayName { get; set; }

	[Trait]
	public string artist { get; set; }
}
