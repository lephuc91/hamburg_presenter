using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using Pro.Common.Mathematics;

namespace Pro.UI.Controls;

public partial class ImageRingProgress : UserControl, IComponentConnector
{
	public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(double), typeof(ImageRingProgress), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)0.0, FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(ImageSource), typeof(ImageRingProgress), new PropertyMetadata((PropertyChangedCallback)null));

	public static readonly DependencyProperty RingWidthPercentageProperty = DependencyProperty.Register("RingWidthPercentage", typeof(double), typeof(ImageRingProgress), new PropertyMetadata((object)0.0));

	public static readonly DependencyProperty ShowValueProperty = DependencyProperty.Register("ShowValue", typeof(bool), typeof(ImageRingProgress), new PropertyMetadata((object)true));

	public double Value
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(ValueProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ValueProperty, (object)value);
		}
	}

	public ImageSource? Source
	{
		get
		{
			return (ImageSource)((DependencyObject)this).GetValue(SourceProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SourceProperty, (object)value);
		}
	}

	public double RingWidthPercentage
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(RingWidthPercentageProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RingWidthPercentageProperty, (object)value);
		}
	}

	public bool ShowValue
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowValueProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowValueProperty, (object)value);
		}
	}

	public ImageRingProgress()
	{
		InitializeComponent();
	}

	protected override void OnRender(DrawingContext drawingContext)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		double num = Value / 100.0;
		if (num == 1.0)
		{
			base.OnRender(drawingContext);
			return;
		}
		Vector2<double> vector = (Vector2<double>)base.RenderSize / 2.0;
		Vector2<double> vector2 = new Vector2<double>(vector.X, 0.0);
		Vector2<double> vector3 = vector2.Rotate(vector, num * 360.0);
		PathGeometry pathGeometry = new PathGeometry();
		PathFigure pathFigure = new PathFigure
		{
			StartPoint = vector
		};
		pathFigure.Segments.Add(new LineSegment
		{
			Point = vector2
		});
		pathFigure.Segments.Add(new ArcSegment
		{
			IsLargeArc = (num >= 0.5),
			Point = vector3,
			Size = vector,
			SweepDirection = SweepDirection.Clockwise
		});
		pathGeometry.Figures.Add(pathFigure);
		imageControl.Clip = new CombinedGeometry
		{
			Geometry1 = pathGeometry,
			Geometry2 = CreateEndCircles(vector, num)
		};
		base.OnRender(drawingContext);
	}

	private Geometry CreateEndCircles(Vector2<double> center, double value)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		double num = center.X * (RingWidthPercentage / 100.0);
		Vector2<double> vector = new Vector2<double>(center.X, num);
		Vector2<double> vector2 = vector.Rotate(center, value * 360.0);
		return new CombinedGeometry
		{
			Geometry1 = new EllipseGeometry
			{
				Center = vector,
				RadiusX = num,
				RadiusY = num
			},
			Geometry2 = new EllipseGeometry
			{
				Center = vector2,
				RadiusX = num,
				RadiusY = num
			}
		};
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
