using System.Windows;
using Pro.Common.Mathematics;
using ProPresenter.UI.Thumbnails;

namespace ProPresenter.UI.Controls;

public class CenteredContentPreviewContainer : PreviewContainer
{
	protected override void OnArrangeChild(UIElement element, Size finalSize)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		Vector2<double> position = ((Vector2<double>)finalSize - (Vector2<double>)element.DesiredSize) / 2.0;
		Vector2<double> size = (Vector2<double>)element.DesiredSize;
		element.Arrange(new Rect<double>(position, size));
	}
}
