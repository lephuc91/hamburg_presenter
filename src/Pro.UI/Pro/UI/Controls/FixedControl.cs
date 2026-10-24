using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Mathematics;

namespace Pro.UI.Controls;

public class FixedControl : Panel
{
	private const int SingleClickCount = 1;

	private const int DoubleClickCount = 2;

	public static readonly DependencyProperty LocationProperty = DependencyProperty.Register("Location", typeof(Vector2<double>), typeof(FixedControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata(Vector2<double>.Zero, FrameworkPropertyMetadataOptions.AffectsParentArrange, new PropertyChangedCallback(LocationPropertyChanged)));

	public static readonly DependencyProperty LocationScaleProperty = DependencyProperty.Register("LocationScale", typeof(double), typeof(FixedControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata(1.0, FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(LocationScalePropertyChanged)));

	public static readonly DependencyProperty OriginProperty = DependencyProperty.Register("Origin", typeof(Vector2<double>), typeof(FixedControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata(Vector2<double>.Zero, FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(OriginPropertyChanged)));

	public static readonly DependencyProperty ClickOnRightMouseDownProperty = DependencyProperty.Register("ClickOnRightMouseDown", typeof(bool), typeof(FixedControl));

	public Vector2<double> Location
	{
		get
		{
			return (Vector2<double>)((DependencyObject)this).GetValue(LocationProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LocationProperty, (object)value);
		}
	}

	public double LocationScale
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(LocationScaleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LocationScaleProperty, (object)value);
		}
	}

	public Vector2<double> Origin
	{
		get
		{
			return (Vector2<double>)((DependencyObject)this).GetValue(OriginProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(OriginProperty, (object)value);
		}
	}

	public bool ClickOnRightMouseDown
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ClickOnRightMouseDownProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ClickOnRightMouseDownProperty, (object)value);
		}
	}

	public FixedControl? FixedParent => VisualTreeHelper.GetParent((DependencyObject)(object)this) as FixedControl;

	private static void LocationPropertyChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		((FixedControl)(object)callerObject).OnLocationChanged((Vector2<double>)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void LocationScalePropertyChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		((FixedControl)(object)callerObject).OnLocationScaleChanged((double)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void OriginPropertyChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		((FixedControl)(object)callerObject).OnOriginChanged((Vector2<double>)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	protected virtual void OnLocationChanged(Vector2<double> location)
	{
	}

	protected virtual void OnLocationScaleChanged(double scale)
	{
	}

	protected virtual void OnOriginChanged(Vector2<double> origin)
	{
	}

	protected virtual void OnMouseClick(MouseButtonEventArgs e)
	{
	}

	protected virtual void OnMouseDoubleClick(MouseButtonEventArgs e)
	{
	}

	protected virtual Vector2<double> OnMeasure(Size availableSize)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		Vector2<double> result = Vector2<double>.Zero;
		foreach (UIElement internalChild in base.InternalChildren)
		{
			Vector2<double> vector = (Vector2<double>)internalChild.DesiredSize;
			result = new Vector2<double>(Math.Max(vector.X, result.X), Math.Max(vector.Y, result.Y));
		}
		return result;
	}

	protected override void OnMouseDown(MouseButtonEventArgs e)
	{
		if (e.ChangedButton == MouseButton.Left)
		{
			if (e.ClickCount == 1)
			{
				OnMouseClick(e);
			}
			else if (e.ClickCount == 2)
			{
				OnMouseDoubleClick(e);
			}
		}
		else if (ClickOnRightMouseDown && e.ChangedButton == MouseButton.Right && e.ClickCount == 1)
		{
			OnMouseClick(e);
		}
		e.Handled = true;
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		Size availableSize2 = default(Size);
		((Size)(ref availableSize2))._002Ector(double.PositiveInfinity, double.PositiveInfinity);
		foreach (UIElement internalChild in base.InternalChildren)
		{
			internalChild.Measure(availableSize2);
		}
		Vector2<double> vector = OnMeasure(availableSize);
		return new Vector2<double>(vector.X.IsReal() ? vector.X : 0.0, vector.Y.IsReal() ? vector.Y : 0.0);
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		Vector2<double> origin = Origin;
		double locationScale = LocationScale;
		foreach (UIElement internalChild in base.InternalChildren)
		{
			Vector2<double> vector = ((internalChild as FixedControl)?.Location ?? Vector2<double>.Zero) * locationScale + origin;
			internalChild.Arrange(new Rect((Point)vector, internalChild.DesiredSize));
		}
		return base.ArrangeOverride(finalSize);
	}

	public Vector2<double> GetMousePosition(MouseEventArgs e)
	{
		return GetMousePosition(e, Vector2<double>.Zero);
	}

	public Vector2<double> GetMousePosition(MouseEventArgs e, Vector2<double> offset)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		FixedControl fixedParent = FixedParent;
		Vector2<double> vector = fixedParent?.Origin ?? Vector2<double>.Zero;
		double num = fixedParent?.LocationScale ?? 1.0;
		return ((Vector2<double>)e.GetPosition(fixedParent ?? this) - vector - offset) / num;
	}
}
