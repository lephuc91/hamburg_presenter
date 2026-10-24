using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using Pro.Common.Mathematics;

namespace Pro.UI.Controls;

public class ItemGroupAdorner : Adorner
{
	private const double Padding = 0.25;

	private IEnumerable<IEnumerable<Rect<double>>>? _groupedRects;

	public static readonly DependencyProperty BorderBrushProperty = DependencyProperty.Register("BorderBrush", typeof(Brush), typeof(ItemGroupAdorner), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Brushes.White, FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty BorderThicknessProperty = DependencyProperty.Register("BorderThickness", typeof(double), typeof(ItemGroupAdorner), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)2.0, FrameworkPropertyMetadataOptions.AffectsRender));

	public Brush BorderBrush
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(BorderBrushProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(BorderBrushProperty, (object)value);
		}
	}

	public double BorderThickness
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(BorderThicknessProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(BorderThicknessProperty, (object)value);
		}
	}

	public ItemGroupAdorner(UIElement adornedElement)
		: base(adornedElement)
	{
		base.Initialized += delegate
		{
			base.IsClipEnabled = true;
		};
	}

	public void Hide()
	{
		UpdateBounds(null);
	}

	public void UpdateBounds(IEnumerable<IEnumerable<Rect<double>>>? rects)
	{
		_groupedRects = rects;
		InvalidateVisual();
	}

	protected override void OnRender(DrawingContext dc)
	{
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		if (_groupedRects == null)
		{
			return;
		}
		foreach (IEnumerable<Rect<double>> groupedRect in _groupedRects)
		{
			CombinedGeometry combinedGeometry = newGeometry();
			CombinedGeometry combinedGeometry2 = null;
			foreach (Rect<double> item in groupedRect.Select((Rect<double> r) => r.Pad(0.25)))
			{
				if (combinedGeometry2 == null)
				{
					combinedGeometry2 = newGeometry();
					combinedGeometry.Geometry1 = new RectangleGeometry(item);
					combinedGeometry.Geometry2 = combinedGeometry2;
				}
				else
				{
					combinedGeometry2.Geometry1 = new RectangleGeometry(item);
					CombinedGeometry combinedGeometry3 = (CombinedGeometry)(combinedGeometry2.Geometry2 = newGeometry());
					combinedGeometry2 = combinedGeometry3;
				}
			}
			dc.PushClip(combinedGeometry);
			dc.DrawGeometry(null, new Pen(BorderBrush, BorderThickness * 2.0), combinedGeometry);
		}
		static CombinedGeometry newGeometry()
		{
			return new CombinedGeometry
			{
				GeometryCombineMode = GeometryCombineMode.Union
			};
		}
	}
}
