using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using Pro.Text;
using ProPresenter.DO.Slide.Custom.Elements;

namespace ProPresenter.UI.SlideEditor.TabStops;

public class FirstLineIndent : IndentBase
{
	private const string MarkerPath = "M -6 0 L -6 3 L 0 3 L 0 6 L 0 3 L 6 3 L 6 0 Z";

	private readonly Geometry _marker;

	public override double Position => (base.Settings?.FirstOrDefault()?.FirstLineIndent).GetValueOrDefault();

	public override double YOrigin => 4.0;

	public FirstLineIndent(IEnumerable<ParagraphSettings> paragraphSettings)
		: base(paragraphSettings)
	{
		_marker = Geometry.Parse("M -6 0 L -6 3 L 0 3 L 0 6 L 0 3 L 6 3 L 6 0 Z");
	}

	public override void OnRenderTabStop(DrawingContext context, Pen pen)
	{
		context.DrawGeometry(pen.Brush, pen, _marker);
	}

	public override void Drag(double startPosition, double dragPosition)
	{
		if (base.Settings == null)
		{
			return;
		}
		foreach (ParagraphSettings setting in base.Settings)
		{
			setting.FirstLineIndent = startPosition + dragPosition;
		}
	}

	protected override double OnCalculatePosition()
	{
		double valueOrDefault = (base.Settings?.FirstOrDefault()?.LeftIndent).GetValueOrDefault();
		double valueOrDefault2 = ((base.Element as ClosedBezierPath)?.Text?.Settings?.Margins.Left).GetValueOrDefault();
		return valueOrDefault + Position + valueOrDefault2;
	}
}
