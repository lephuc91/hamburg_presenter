using System;
using Pro.Common.Mathematics;

namespace ProPresenter.UI.SlideEditor;

public class ViewportRequestor
{
	public Rect<double> Viewport => this.Request?.Invoke() ?? Rect<double>.Empty;

	public event Func<Rect<double>>? Request;
}
