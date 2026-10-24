using System;
using System.Windows.Media;
using Pro.Serialization.Control;

namespace ProPresenter.SerializationInterop.RVData;

public class RVShapeElement : RVDisplayElement
{
	[Trait]
	public Uri source { get; set; }

	[Trait]
	public double bezelRadius { get; set; }

	[Trait]
	public double rotation { get; set; }

	[Trait]
	public bool drawingFill { get; set; }

	[Trait]
	public bool drawingShadow { get; set; }

	[Trait]
	public bool drawingStroke { get; set; }

	[Trait]
	public Color fillColor { get; set; }
}
