using System.Collections.Generic;
using System.Linq;
using Pro.Text;
using ProPresenter.DO.Slide.Custom.Elements;

namespace ProPresenter.UI.SlideEditor.TabStops;

public class LeftIndent : IndentBase
{
	public override double Position => (base.Settings?.FirstOrDefault()?.LeftIndent).GetValueOrDefault();

	public LeftIndent(IEnumerable<ParagraphSettings> paragraphSettings)
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
			double leftIndent = setting.LeftIndent;
			setting.LeftIndent = startPosition + dragPosition;
			setting.FirstLineIndent -= setting.LeftIndent - leftIndent;
		}
	}

	protected override double OnCalculatePosition()
	{
		double valueOrDefault = ((base.Element as ClosedBezierPath)?.Text?.Settings?.Margins.Left).GetValueOrDefault();
		return Position + valueOrDefault;
	}
}
