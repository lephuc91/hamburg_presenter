using System.Collections.Generic;
using System.Linq;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.PowerPoint;
using Pro.Common.Components;
using Pro.Common.Mathematics;

namespace Pro.PPT;

public class Presentation : DisposableBase
{
	private Application? _application;

	public IEnumerable<Slide> Slides { get; }

	public Vector2<double> Size { get; }

	internal Presentation(string path)
	{
		_application = new ApplicationClass();
		Microsoft.Office.Interop.PowerPoint.Presentation presentation = _application.Presentations.Open(path, MsoTriState.msoFalse, MsoTriState.msoFalse, MsoTriState.msoFalse);
		Slides = (from s in presentation.Slides.OfType<Microsoft.Office.Interop.PowerPoint.Slide>()
			where s.SlideShowTransition.Hidden == MsoTriState.msoFalse
			select new Slide(s)).ToArray();
		Size = new Vector2<double>(presentation.SlideMaster.Width, presentation.SlideMaster.Height);
	}

	protected override void OnDispose(bool disposeObjects)
	{
		_application?.Quit();
		_application = null;
	}
}
