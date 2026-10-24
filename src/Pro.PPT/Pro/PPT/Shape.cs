using Microsoft.Office.Core;
using Microsoft.Office.Interop.PowerPoint;

namespace Pro.PPT;

public class Shape
{
	private readonly Microsoft.Office.Interop.PowerPoint.Shape _shape;

	public bool IsPlaceHolder
	{
		get
		{
			if (_shape.Type == MsoShapeType.msoPlaceholder)
			{
				return _shape.PlaceholderFormat.Type == PpPlaceholderType.ppPlaceholderBody;
			}
			return false;
		}
	}

	public string Text => _shape.TextFrame.TextRange.Text;

	internal Shape(Microsoft.Office.Interop.PowerPoint.Shape s)
	{
		_shape = s;
	}
}
