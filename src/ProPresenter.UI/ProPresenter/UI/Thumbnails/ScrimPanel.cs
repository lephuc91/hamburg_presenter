using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Pro.Common.Mathematics;
using Pro.UI.Utility;
using ProPresenter.DO;

namespace ProPresenter.UI.Thumbnails;

public class ScrimPanel : WrapPanel
{
	public ScrimPanel()
	{
		base.SizeChanged += delegate
		{
			InvalidateArrange();
		};
	}

	public FrameworkElement? GetScrimItem(IScrimSource scrimItem)
	{
		return ((DependencyObject)(object)this).FindVisualChildren<FrameworkElement>().FirstOrDefault((FrameworkElement b) => b.DataContext == scrimItem);
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_0217: Unknown result type (might be due to invalid IL or missing references)
		//IL_021c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		foreach (object child in base.Children)
		{
			if (!(child is FrameworkElement { DataContext: IScrimSource dataContext } frameworkElement))
			{
				continue;
			}
			Size desiredSize;
			switch (dataContext.Position)
			{
			case ScrimPosition.TopLeft:
			{
				double num9 = num;
				desiredSize = frameworkElement.DesiredSize;
				if (num9 + ((Size)(ref desiredSize)).Width > base.ActualWidth)
				{
					num = 0.0;
					double num10 = num5;
					desiredSize = frameworkElement.DesiredSize;
					num5 = num10 + ((Size)(ref desiredSize)).Height;
				}
				Vector2<double> position4 = new Vector2<double>(num, num5);
				desiredSize = frameworkElement.DesiredSize;
				double width4 = ((Size)(ref desiredSize)).Width;
				desiredSize = frameworkElement.DesiredSize;
				frameworkElement.Arrange(new Rect<double>(position4, new Vector2<double>(width4, ((Size)(ref desiredSize)).Height)));
				double num11 = num;
				desiredSize = frameworkElement.DesiredSize;
				num = num11 + ((Size)(ref desiredSize)).Width;
				break;
			}
			case ScrimPosition.TopRight:
			{
				double num8 = num2;
				desiredSize = frameworkElement.DesiredSize;
				num2 = num8 + ((Size)(ref desiredSize)).Width;
				Vector2<double> position3 = new Vector2<double>(base.ActualWidth - num2, 0.0);
				desiredSize = frameworkElement.DesiredSize;
				double width3 = ((Size)(ref desiredSize)).Width;
				desiredSize = frameworkElement.DesiredSize;
				frameworkElement.Arrange(new Rect<double>(position3, new Vector2<double>(width3, ((Size)(ref desiredSize)).Height)));
				break;
			}
			case ScrimPosition.BottomRight:
			{
				double num7 = num3;
				desiredSize = frameworkElement.DesiredSize;
				num3 = num7 + ((Size)(ref desiredSize)).Width;
				double x2 = base.ActualWidth - num3;
				double actualHeight2 = base.ActualHeight;
				desiredSize = frameworkElement.DesiredSize;
				Vector2<double> position2 = new Vector2<double>(x2, actualHeight2 - ((Size)(ref desiredSize)).Height);
				desiredSize = frameworkElement.DesiredSize;
				double width2 = ((Size)(ref desiredSize)).Width;
				desiredSize = frameworkElement.DesiredSize;
				frameworkElement.Arrange(new Rect<double>(position2, new Vector2<double>(width2, ((Size)(ref desiredSize)).Height)));
				break;
			}
			case ScrimPosition.BottomLeft:
			{
				double x = num4;
				double actualHeight = base.ActualHeight;
				desiredSize = frameworkElement.DesiredSize;
				Vector2<double> position = new Vector2<double>(x, actualHeight - ((Size)(ref desiredSize)).Height);
				desiredSize = frameworkElement.DesiredSize;
				double width = ((Size)(ref desiredSize)).Width;
				desiredSize = frameworkElement.DesiredSize;
				frameworkElement.Arrange(new Rect<double>(position, new Vector2<double>(width, ((Size)(ref desiredSize)).Height)));
				double num6 = num4;
				desiredSize = frameworkElement.DesiredSize;
				num4 = num6 + ((Size)(ref desiredSize)).Width;
				break;
			}
			}
		}
		return finalSize;
	}
}
