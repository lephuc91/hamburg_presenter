using System.Windows.Media;
using ProPresenter.DO.Slide.Custom.Elements;

namespace ProPresenter.Rendering.Drawing;

internal class DrawingParams
{
	public Geometry FillGeometry { get; }

	public Geometry? MaskGeometry { get; }

	public Brush? MaskBrush { get; }

	public BezierPath Path { get; }

	public DrawerSet Drawers { get; }

	public bool UseFullSizeMedia { get; }

	public RenderingMode RenderingMode { get; }

	public DrawingParams(Geometry fillGeometry, Geometry? maskGeometry, Brush? maskBrush, BezierPath path, DrawerSet drawers, bool useFullSizeMedia, RenderingMode renderingMode)
	{
		FillGeometry = fillGeometry;
		MaskGeometry = maskGeometry;
		MaskBrush = maskBrush;
		Path = path;
		Drawers = drawers;
		UseFullSizeMedia = useFullSizeMedia;
		RenderingMode = renderingMode;
	}
}
