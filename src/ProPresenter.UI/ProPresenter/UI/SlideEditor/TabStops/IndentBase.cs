using System.Collections.Generic;
using Pro.Editor.Canvas.TabStop;
using Pro.Text;
using ProPresenter.DO.Slide.Custom.Elements;

namespace ProPresenter.UI.SlideEditor.TabStops;

public abstract class IndentBase : TabStopControlBase
{
	public IEnumerable<ParagraphSettings> Settings { get; }

	protected IndentBase(IEnumerable<ParagraphSettings> settings)
		: base(null)
	{
		Settings = settings;
	}

	public void SetElement(ClosedBezierPath? textElement)
	{
		_element = textElement;
	}
}
