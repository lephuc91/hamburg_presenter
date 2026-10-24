using System.Windows.Media;

namespace ProPresenter.Rendering.Drawing;

internal interface IDrawer<T>
{
	void Draw(DrawingContext dc, RenderingMode renderMode, T data, DrawingParams drawingParams);
}
