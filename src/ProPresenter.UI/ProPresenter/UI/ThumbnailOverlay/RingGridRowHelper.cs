using System.Windows;
using System.Windows.Controls;

namespace ProPresenter.UI.ThumbnailOverlay;

public static class RingGridRowHelper
{
	public const string RingRowMargin = "RingRowMargin";

	public const string RingRow = "RingRow";

	public static readonly DependencyProperty RingRowMarginProperty = DependencyProperty.RegisterAttached("RingRowMargin", typeof(RingSize), typeof(RingGridRowHelper), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(RingRowMarginChanged)));

	public static readonly DependencyProperty RingRowProperty = DependencyProperty.RegisterAttached("RingRow", typeof(RingSize), typeof(RingGridRowHelper), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(RingRowChanged)));

	public static RowDefinition GetRingRowMargin(RowDefinition element)
	{
		return (RowDefinition)((DependencyObject)element).GetValue(RingRowMarginProperty);
	}

	public static void SetRingRowMargin(RowDefinition element, RowDefinition value)
	{
		((DependencyObject)element).SetValue(RingRowMarginProperty, (object)value);
	}

	public static RowDefinition GetRingRow(RowDefinition element)
	{
		return (RowDefinition)((DependencyObject)element).GetValue(RingRowProperty);
	}

	public static void SetRingRow(RowDefinition element, RowDefinition value)
	{
		((DependencyObject)element).SetValue(RingRowProperty, (object)value);
	}

	private static void RingRowMarginChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is RowDefinition rowDefinition)
		{
			OnRingRowMarginChanged(rowDefinition, (RingSize)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	private static void RingRowChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is RowDefinition rowDefinition)
		{
			OnRingRowChanged(rowDefinition, (RingSize)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	private static void OnRingRowMarginChanged(RowDefinition rowDefinition, RingSize ringSize)
	{
		rowDefinition.Height = ringSize switch
		{
			RingSize.Small => OverlayGridHeightConstants.SmallRingMarginRowHeight, 
			RingSize.Large => OverlayGridHeightConstants.RingMarginRowHeight, 
			_ => new GridLength(1.0, GridUnitType.Star), 
		};
	}

	private static void OnRingRowChanged(RowDefinition rowDefinition, RingSize ringSize)
	{
		rowDefinition.Height = ringSize switch
		{
			RingSize.Small => OverlayGridHeightConstants.SmallRingRowHeight, 
			RingSize.Large => OverlayGridHeightConstants.RingRowHeight, 
			_ => new GridLength(1.0, GridUnitType.Star), 
		};
	}
}
