using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using Pro.Common.Mathematics;
using Pro.Common.Utility;
using ProPresenter.DO.LiveVideo;
using ProPresenter.DO.Slide.Custom;

namespace ProPresenter.UI;

public partial class ScaleToFitSlidePreview : UserControl, IComponentConnector
{
	public static readonly DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(CustomSlide), typeof(ScaleToFitSlidePreview), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(SourceChanged)));

	public static readonly DependencyProperty LiveVideoInputProperty = DependencyProperty.Register("LiveVideoInput", typeof(LiveVideoInput), typeof(ScaleToFitSlidePreview));

	public static readonly DependencyProperty SecondaryBackgroundColorProperty = DependencyProperty.Register("SecondaryBackgroundColor", typeof(Color), typeof(ScaleToFitSlidePreview));

	public static readonly DependencyProperty PrimaryCheckerboardBrushProperty = DependencyProperty.Register("PrimaryCheckerboardBrush", typeof(Brush), typeof(ScaleToFitSlidePreview));

	public static readonly DependencyProperty SecondaryCheckerboardBrushProperty = DependencyProperty.Register("SecondaryCheckerboardBrush", typeof(Brush), typeof(ScaleToFitSlidePreview));

	public static readonly DependencyProperty RenderTransparencyCheckerboardProperty = DependencyProperty.Register("RenderTransparencyCheckerboard", typeof(bool), typeof(ScaleToFitSlidePreview));

	public static readonly DependencyProperty IncludeTextPlaceholderProperty = DependencyProperty.Register("IncludeTextPlaceholder", typeof(bool), typeof(ScaleToFitSlidePreview));

	public static readonly DependencyProperty ForceBackgroundDrawProperty = DependencyProperty.Register("ForceBackgroundDraw", typeof(bool), typeof(ScaleToFitSlidePreview), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));

	public CustomSlide Source
	{
		get
		{
			return (CustomSlide)((DependencyObject)this).GetValue(SourceProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SourceProperty, (object)value);
		}
	}

	public LiveVideoInput LiveVideoInput
	{
		get
		{
			return (LiveVideoInput)((DependencyObject)this).GetValue(LiveVideoInputProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LiveVideoInputProperty, (object)value);
		}
	}

	public Color SecondaryBackgroundColor
	{
		get
		{
			return (Color)((DependencyObject)this).GetValue(SecondaryBackgroundColorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SecondaryBackgroundColorProperty, (object)value);
		}
	}

	public Brush PrimaryCheckerboardBrush
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(PrimaryCheckerboardBrushProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PrimaryCheckerboardBrushProperty, (object)value);
		}
	}

	public Brush SecondaryCheckerboardBrush
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(SecondaryCheckerboardBrushProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SecondaryCheckerboardBrushProperty, (object)value);
		}
	}

	public bool RenderTransparencyCheckerboard
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(RenderTransparencyCheckerboardProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RenderTransparencyCheckerboardProperty, (object)value);
		}
	}

	public bool IncludeTextPlaceholder
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IncludeTextPlaceholderProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IncludeTextPlaceholderProperty, (object)value);
		}
	}

	public bool ForceBackgroundDraw
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ForceBackgroundDrawProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ForceBackgroundDrawProperty, (object)value);
		}
	}

	private static void SourceChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		((ScaleToFitSlidePreview)(object)callerObject).OnSourceChanged((CustomSlide)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (CustomSlide)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	public ScaleToFitSlidePreview()
	{
		InitializeComponent();
	}

	private void OnSourceChanged(CustomSlide oldValue, CustomSlide newValue)
	{
		if (oldValue != null)
		{
			oldValue.PropertyChanged -= Slide_PropertyChanged;
		}
		if (newValue != null)
		{
			newValue.PropertyChanged += Slide_PropertyChanged;
		}
		UpdatePreviewSize();
	}

	private void Slide_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "Size")
		{
			UpdatePreviewSize();
		}
	}

	private void UpdatePreviewSize()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		if (Preview.Source != null)
		{
			Vector2<double> size = Preview.Source.Size;
			Vector2<double> targetSize = (Vector2<double>)base.RenderSize;
			Vector2<double> vector = size.ScaleToFitSize(targetSize);
			Preview.Width = vector.X;
			Preview.Height = vector.Y;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
