using System.Collections.Generic;
using System.Linq;
using Pro.Text;
using ProPresenter.DO.Slide.Custom.Elements;

namespace ProPresenter.UI.SlideEditor.TabStops;

public class RightIndent : IndentBase
{
	public override double Position => (base.Settings?.FirstOrDefault()?.RightIndent).GetValueOrDefault();

	public RightIndent(IEnumerable<ParagraphSettings> paragraphSettings)
		: base(paragraphSettings)
	{
	}

	public override void Drag(double startPosition, double dragPosition)
	{
		if (base.Settings == null)
		{
			return;
		}
		foreach (ParagraphSettings setting in base.Settings)
		{
			setting.RightIndent = startPosition - dragPosition;
		}
	}

	protected override double OnCalculatePosition()
	{
		ClosedBezierPath obj = base.Element as ClosedBezierPath;
		double num = obj?.Size.X ?? base.ParentSize.X;
		double num2 = obj?.Text.Settings.Margins.Right ?? 0.0;
		return num - (Position + num2);
	}
}
