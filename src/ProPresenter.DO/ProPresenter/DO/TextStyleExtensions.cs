using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Themes;

namespace ProPresenter.DO;

public static class TextStyleExtensions
{
	public static TextStyle? GetTextStyle(this ClosedBezierPath element)
	{
		if (element != null)
		{
			if (!(element.Text != null))
			{
				return null;
			}
			return new TextStyle(element.Text);
		}
		return null;
	}

	public static void Apply(this TextStyle textStyle, IEnumerable<ClosedBezierPath> elements)
	{
		if (!elements.Empty())
		{
			UndoStack? undoStack = elements.First().UndoStack;
			undoStack?.BeginCommit(UndoActionTypes.PasteStyle.ToAction());
			elements.ForEach(delegate(ClosedBezierPath e)
			{
				textStyle.Document.ApplyAttributes(e.Text);
			});
			undoStack?.EndCommit(null, null, autoFinalize: true);
		}
	}
}
