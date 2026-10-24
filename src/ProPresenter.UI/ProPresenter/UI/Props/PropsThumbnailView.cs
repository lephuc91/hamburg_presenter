using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using Pro.Common.Mathematics;

namespace ProPresenter.UI.Props;

[ContentProperty("Child")]
public partial class PropsThumbnailView : UserControl, IComponentConnector
{
	public static readonly DependencyProperty ThumbnailProperty = DependencyProperty.Register("Thumbnail", typeof(ImageSource), typeof(PropsThumbnailView));

	public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(double), typeof(PropsThumbnailView), new PropertyMetadata((object)8.0));

	public static readonly DependencyProperty AspectRatioProperty = DependencyProperty.Register("AspectRatio", typeof(double), typeof(PropsThumbnailView), new PropertyMetadata((object)1.0));

	public static readonly DependencyProperty ThumbnailSizeProperty = DependencyProperty.Register("ThumbnailSize", typeof(Vector2<int>), typeof(PropsThumbnailView), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Vector2<int>.Zero, FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty IsActiveBrushProperty = DependencyProperty.Register("IsActiveBrush", typeof(Brush), typeof(PropsThumbnailView), new PropertyMetadata((object)Brushes.Transparent));

	public static readonly DependencyProperty ChildProperty = DependencyProperty.Register("Child", typeof(UIElement), typeof(PropsThumbnailView));

	public ImageSource Thumbnail
	{
		get
		{
			return (ImageSource)((DependencyObject)this).GetValue(ThumbnailProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ThumbnailProperty, (object)value);
		}
	}

	public double CornerRadius
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(CornerRadiusProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CornerRadiusProperty, (object)value);
		}
	}

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

	public Vector2<int> ThumbnailSize
	{
		get
		{
			return (Vector2<int>)((DependencyObject)this).GetValue(ThumbnailSizeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ThumbnailSizeProperty, (object)value);
		}
	}

	public Brush IsActiveBrush
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(IsActiveBrushProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsActiveBrushProperty, (object)value);
		}
	}

	public UIElement Child
	{
		get
		{
			return (UIElement)((DependencyObject)this).GetValue(ChildProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ChildProperty, (object)value);
		}
	}

	public PropsThumbnailView()
	{
		InitializeComponent();
	}

	protected override void OnRender(DrawingContext drawingContext)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		((DependencyObject)this).SetCurrentValue(ThumbnailSizeProperty, (object)((Vector2<double>)base.RenderSize).Cast<int>());
		base.OnRender(drawingContext);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
