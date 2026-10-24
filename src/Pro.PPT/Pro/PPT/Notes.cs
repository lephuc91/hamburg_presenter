using System.Collections.Generic;
using System.Linq;
using Microsoft.Office.Interop.PowerPoint;

namespace Pro.PPT;

public class Notes
{
	private readonly IEnumerable<Shape> _shapes;

	public string AllText => string.Join(string.Empty, from s in _shapes
		where s.IsPlaceHolder
		select s.Text);

	internal Notes(SlideRange notes)
	{
		_shapes = (from s in notes.Shapes.OfType<Microsoft.Office.Interop.PowerPoint.Shape>()
			select new Shape(s)).ToArray();
	}
}
