using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using Pro.Common.Collections;
using Pro.Common.Mathematics;
using ProPresenter.DO;

namespace ProPresenter.UI.Thumbnails;

public class PreviewContainer : Panel
{
	private const double AspectRatioZeroEpsilon = 1E-08;

	public static readonly DependencyProperty ViewSettingsProperty = DependencyProperty.Register("ViewSettings", typeof(IPanelViewSettings), typeof(PreviewContainer), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange));

	public static readonly DependencyProperty AspectRatioProperty = DependencyProperty.Register("AspectRatio", typeof(double), typeof(PreviewContainer), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)1.0, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange), new ValidateValueCallback(ValidateAspectRatioCallback));

	public double AspectRatio
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(AspectRatioProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AspectRatioProperty, (object)value);
		}
	}

	public IPanelViewSettings? ViewSettings
	{
		get
		{
			return (IPanelViewSettings)((DependencyObject)this).GetValue(ViewSettingsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ViewSettingsProperty, (object)value);
		}
	}

	private static bool ValidateAspectRatioCallback(object value)
	{
		if (value is double value2)
		{
			return !IsZero(value2);
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool IsZero(double value)
	{
		return Math.Abs(value) < 1E-08;
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		Vector2<double> vector = (Vector2<double>)availableSize;
		Vector2<double> size = Vector2<double>.Zero;
		IPanelViewSettings? viewSettings = ViewSettings;
		if (viewSettings == null || viewSettings.ViewType != 0)
		{
			IPanelViewSettings? viewSettings2 = ViewSettings;
			if (viewSettings2 == null || viewSettings2.ViewType != PanelViewType.EasyView)
			{
				IPanelViewSettings? viewSettings3 = ViewSettings;
				if (viewSettings3 != null && viewSettings3.ViewType == PanelViewType.List)
				{
					size = ((!double.IsInfinity(vector.Y)) ? new Vector2<double>(vector.Y * AspectRatio, vector.Y) : Vector2<double>.Zero);
					goto IL_00e0;
				}
				throw new NotSupportedException("This view type is not currently supported");
			}
		}
		size = ((!double.IsInfinity(vector.X)) ? new Vector2<double>(vector.X, vector.X * (1.0 / AspectRatio)) : Vector2<double>.Zero);
		goto IL_00e0;
		IL_00e0:
		if (double.IsNaN(size.X) || double.IsNaN(size.Y))
		{
			size = Vector2<double>.Zero;
		}
		size = FilterSize(size);
		base.Children.Cast<UIElement>().ForEach(delegate(UIElement c)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			c.Measure(size);
		});
		return size;
	}

	protected virtual Vector2<double> FilterSize(Vector2<double> size)
	{
		return size;
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		base.Children.Cast<UIElement>().ForEach(delegate(UIElement c)
		{
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			OnArrangeChild(c, finalSize);
		});
		return finalSize;
	}

	protected virtual void OnArrangeChild(UIElement element, Size finalSize)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		element.Arrange(new Rect<double>((Vector2<double>)element.DesiredSize));
	}
}
