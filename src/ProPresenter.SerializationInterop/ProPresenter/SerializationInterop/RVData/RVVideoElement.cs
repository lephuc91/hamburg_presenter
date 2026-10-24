using Pro.Common.Mathematics;
using Pro.Serialization.Control;

namespace ProPresenter.SerializationInterop.RVData;

public class RVVideoElement : RVImageElement
{
	[Trait]
	public float audioVolume { get; set; }

	[Trait]
	public float playRate { get; set; }

	[Trait]
	public float frameRate { get; set; }

	[Trait]
	public RVPlaybackBehaviorType playbackBehavior { get; set; }

	[Trait]
	public int inPoint { get; set; }

	[Trait]
	public int outPoint { get; set; }

	[Trait]
	public int endPoint { get; set; }

	[Trait]
	public int timeScale { get; set; }

	[Trait]
	public Vector2<double> naturalSize { get; set; }

	[Trait]
	public int fieldType { get; set; }
}
