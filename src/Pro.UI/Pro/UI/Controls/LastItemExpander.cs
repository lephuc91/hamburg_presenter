using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Common.Mathematics;

namespace Pro.UI.Controls;

public class LastItemExpander : Panel
{
	private const double LineHeight = 18.0;

	private static readonly bool ScrollScreen = SystemParameters.WheelScrollLines <= 0;

	private static readonly double ScrollScale = ((!ScrollScreen) ? ((double)SystemParameters.WheelScrollLines * 18.0) : 0.0);

	private const double MouseWheelBaseValue = 120.0;

	private const double ScrollBarVisibleTolerance = 5.0;

	private const double ScrollBarCollapsedTolerance = 15.0;

	private bool _scrollBarVisible;

	private readonly ScrollBar _scrollBar;

	public LastItemExpander()
	{
		base.ClipToBounds = true;
		_scrollBar = new ScrollBar
		{
			Orientation = Orientation.Vertical,
			Minimum = 0.0,
			SmallChange = 36.0,
			LargeChange = 108.0,
			Visibility = Visibility.Hidden
		};
		_scrollBar.Scroll += delegate
		{
			InvalidateArrange();
		};
		_scrollBar.ValueChanged += delegate
		{
			InvalidateArrange();
		};
		base.InternalChildren.Add(_scrollBar);
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		double num = MeasureChildren(availableSize);
		double num2 = ((Size)(ref availableSize)).Height - num;
		bool flag = _scrollBarVisible;
		if (num2 < 5.0)
		{
			flag = true;
		}
		else if (num2 >= 15.0)
		{
			flag = false;
		}
		_scrollBar.Measure(availableSize);
		if (_scrollBarVisible != flag)
		{
			_scrollBarVisible = flag;
			_scrollBar.Visibility = ((!_scrollBarVisible) ? Visibility.Hidden : Visibility.Visible);
			num = MeasureChildren(availableSize);
		}
		_scrollBar.Maximum = Math.Max(num - ((Size)(ref availableSize)).Height, 0.0);
		_scrollBar.ViewportSize = ((Size)(ref availableSize)).Height;
		return availableSize;
	}

	private double MeasureChildren(Size availableSize)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		double num = 0.0;
		double num2 = ((Size)(ref availableSize)).Height;
		double width = ((Size)(ref availableSize)).Width;
		double num3;
		Size desiredSize;
		if (!_scrollBarVisible)
		{
			num3 = 0.0;
		}
		else
		{
			desiredSize = _scrollBar.DesiredSize;
			num3 = ((Size)(ref desiredSize)).Width;
		}
		Vector2<double> vector = new Vector2<double>(width - num3, double.PositiveInfinity);
		FrameworkElement[] layoutChildren = GetLayoutChildren();
		FrameworkElement[] array = layoutChildren;
		foreach (FrameworkElement frameworkElement in array)
		{
			frameworkElement.Height = double.NaN;
			frameworkElement.Measure(vector);
			double num4 = num;
			desiredSize = frameworkElement.DesiredSize;
			num = num4 + ((Size)(ref desiredSize)).Height;
			double num5 = num2;
			desiredSize = frameworkElement.DesiredSize;
			if (num5 > ((Size)(ref desiredSize)).Height && frameworkElement == layoutChildren.Last())
			{
				frameworkElement.Height = num2;
				frameworkElement.Measure(vector);
			}
			else
			{
				double num6 = num2;
				desiredSize = frameworkElement.DesiredSize;
				num2 = num6 - ((Size)(ref desiredSize)).Height;
			}
		}
		return num;
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		double num = 0.0 - _scrollBar.Value;
		double width = ((Size)(ref finalSize)).Width;
		double num2;
		Size desiredSize;
		if (!_scrollBarVisible)
		{
			num2 = 0.0;
		}
		else
		{
			desiredSize = _scrollBar.DesiredSize;
			num2 = ((Size)(ref desiredSize)).Width;
		}
		double w = width - num2;
		FrameworkElement[] layoutChildren = GetLayoutChildren();
		foreach (FrameworkElement obj in layoutChildren)
		{
			desiredSize = obj.DesiredSize;
			double height = ((Size)(ref desiredSize)).Height;
			obj.Arrange(new Rect<double>(0.0, num, w, height));
			num += height;
		}
		ScrollBar scrollBar = _scrollBar;
		double width2 = ((Size)(ref finalSize)).Width;
		desiredSize = _scrollBar.DesiredSize;
		double x = width2 - ((Size)(ref desiredSize)).Width;
		desiredSize = _scrollBar.DesiredSize;
		scrollBar.Arrange(new Rect<double>(x, 0.0, ((Size)(ref desiredSize)).Width, ((Size)(ref finalSize)).Height));
		return finalSize;
	}

	protected override void OnMouseWheel(MouseWheelEventArgs e)
	{
		if (base.IsMouseOver)
		{
			e.Handled = true;
			_scrollBar.Value += (double)(-e.Delta) / 120.0 * ((!ScrollScreen) ? ScrollScale : _scrollBar.ViewportSize);
			InvalidateArrange();
		}
	}

	private FrameworkElement[] GetLayoutChildren()
	{
		return base.InternalChildren.OfType<FrameworkElement>().Except(_scrollBar).NonNull()
			.ToArray();
	}
}
