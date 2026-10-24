using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using Pro.Common.Mathematics;

namespace Pro.UI.Controls;

public class Rotator : UserControl, IComponentConnector
{
	public static readonly DependencyProperty AngleProperty = DependencyProperty.Register("Angle", typeof(Angle<double>), typeof(Rotator), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Angle<double>.Zero));

	public static readonly DependencyProperty AngleOffsetProperty = DependencyProperty.Register("AngleOffset", typeof(double), typeof(Rotator), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)0.0));

	public static readonly DependencyProperty StepIncrementsProperty = DependencyProperty.Register("StepIncrements", typeof(double), typeof(Rotator), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)1.0));

	public static readonly DependencyProperty IsCartesianProperty = DependencyProperty.Register("IsCartesian", typeof(bool), typeof(Rotator), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public static readonly DependencyProperty RotatorBackgroundColorProperty = DependencyProperty.Register("RotatorBackgroundColor", typeof(Brush), typeof(Rotator), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Brushes.DimGray));

	public static readonly DependencyProperty RotatorControlColorProperty = DependencyProperty.Register("RotatorControlColor", typeof(Brush), typeof(Rotator), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Brushes.White));

	internal Rotator self;

	private bool _contentLoaded;

	public Angle<double> Angle
	{
		get
		{
			return (Angle<double>)((DependencyObject)this).GetValue(AngleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AngleProperty, (object)value);
		}
	}

	public double AngleOffset
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(AngleOffsetProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AngleOffsetProperty, (object)value);
		}
	}

	public double StepIncrements
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(StepIncrementsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(StepIncrementsProperty, (object)value);
		}
	}

	public bool IsCartesian
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsCartesianProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsCartesianProperty, (object)value);
		}
	}

	public Brush RotatorBackgroundColor
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(RotatorBackgroundColorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RotatorBackgroundColorProperty, (object)value);
		}
	}

	public Brush RotatorControlColor
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(RotatorControlColorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RotatorControlColorProperty, (object)value);
		}
	}

	public event Action<Angle<double>>? AngleUpdated;

	public Rotator()
	{
		InitializeComponent();
	}

	protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
	{
		UpdateAngle(e);
		CaptureMouse();
	}

	private void UpdateAngle(MouseEventArgs e)
	{
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		Angle<double> angle = new Angle<double>(Math.Round((((Vector2<double>)e.GetPosition(this)).Angle(new Vector2<double>(base.ActualWidth, base.ActualHeight) / 2.0) - AngleOffset) / StepIncrements) * StepIncrements);
		Angle = new Angle<double>(angle, IsCartesian);
		this.AngleUpdated?.Invoke(Angle);
	}

	protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
	{
		ReleaseMouseCapture();
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		if (base.IsMouseCaptured)
		{
			UpdateAngle(e);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	public void InitializeComponent()
	{
		if (!_contentLoaded)
		{
			_contentLoaded = true;
			Uri resourceLocator = new Uri("/Pro.UI;component/controls/rotator.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		if (connectionId == 1)
		{
			self = (Rotator)target;
		}
		else
		{
			_contentLoaded = true;
		}
	}
}
