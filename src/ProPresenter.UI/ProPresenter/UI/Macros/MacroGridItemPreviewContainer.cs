using Pro.Common.Mathematics;
using ProPresenter.UI.Controls;

namespace ProPresenter.UI.Macros;

public class MacroGridItemPreviewContainer : CenteredContentPreviewContainer
{
	protected override Vector2<double> FilterSize(Vector2<double> size)
	{
		return new Vector2<double>(size.X, 90.0);
	}
}
