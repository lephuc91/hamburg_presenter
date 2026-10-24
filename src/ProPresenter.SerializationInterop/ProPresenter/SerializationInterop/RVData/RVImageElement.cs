using Pro.Common.Mathematics;
using Pro.Serialization.Control;

namespace ProPresenter.SerializationInterop.RVData;

public class RVImageElement : RVShapeElement
{
	[Trait]
	public RVScaleBehavior scaleBehavior { get; set; }

	[Trait]
	public bool flippedHorizontally { get; set; }

	[Trait]
	public bool flippedVertically { get; set; }

	[Trait]
	public Vector2<double> scaleSize { get; set; }

	[Trait]
	public Vector2<double> imageOffset { get; set; }

	[Trait]
	public string manufactureURL { get; set; }

	[Trait]
	public string manufactureName { get; set; }

	[Trait]
	public string format { get; set; }

	[Optional]
	[Child]
	public RVEffectsPreset effectsPreset { get; set; }
}
