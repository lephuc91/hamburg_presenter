using System.Windows;
using System.Windows.Controls;
using Pro.Common.Mathematics;

namespace ProPresenter.UI;

public class IconSelectorPanel : WrapPanel
{
	public IconSelectorPanel()
	{
		base.SizeChanged += delegate
		{
			InvalidateArrange();
		};
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		double num = 0.0;
		double num2 = 0.0;
		foreach (object child in base.Children)
		{
			if (child is FrameworkElement frameworkElement)
			{
				double num3 = num;
				Size desiredSize = frameworkElement.DesiredSize;
				if (num3 + ((Size)(ref desiredSize)).Width > base.ActualWidth)
				{
					num = 0.0;
					double num4 = num2;
					desiredSize = frameworkElement.DesiredSize;
					num2 = num4 + ((Size)(ref desiredSize)).Height;
				}
				Vector2<double> position = new Vector2<double>(num, num2);
				desiredSize = frameworkElement.DesiredSize;
				double width = ((Size)(ref desiredSize)).Width;
				desiredSize = frameworkElement.DesiredSize;
				frameworkElement.Arrange(new Rect<double>(position, new Vector2<double>(width, ((Size)(ref desiredSize)).Height)));
				double num5 = num;
				desiredSize = frameworkElement.DesiredSize;
				num = num5 + ((Size)(ref desiredSize)).Width;
			}
		}
		return finalSize;
	}
}
