using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Threading;
using Pro.Common.Background;
using Pro.Common.Components;
using Pro.Common.Mathematics;
using Pro.UI.DependencyInjection;
using ProPresenter.DO.LiveVideo;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.Rendering;
using ProPresenter.UI.ViewModels.Thumbnails;

namespace ProPresenter.UI;

public partial class SlidePreview : UserControl, IComponentConnector
{
	private ISlidePreviewService _slidePreviewRenderer;

	public static readonly DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(CustomSlide), typeof(SlidePreview), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange, new PropertyChangedCallback(SourceChanged)));

	public static readonly DependencyProperty IncludeBackgroundProperty = DependencyProperty.Register("IncludeBackground", typeof(bool), typeof(SlidePreview), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public static readonly DependencyProperty LiveVideoInputProperty = DependencyProperty.Register("LiveVideoInput", typeof(LiveVideoInput), typeof(SlidePreview));

	public static readonly DependencyProperty SecondaryBackgroundColorProperty = DependencyProperty.Register("SecondaryBackgroundColor", typeof(Color), typeof(SlidePreview), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Colors.Transparent, new PropertyChangedCallback(BackgroundChanged)));

	public static readonly DependencyProperty PrimaryCheckerboardBrushProperty = DependencyProperty.Register("PrimaryCheckerboardBrush", typeof(Brush), typeof(SlidePreview), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Brushes.White));

	public static readonly DependencyProperty SecondaryCheckerboardBrushProperty = DependencyProperty.Register("SecondaryCheckerboardBrush", typeof(Brush), typeof(SlidePreview), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Brushes.LightGray));

	public static readonly DependencyProperty RenderTransparencyCheckerboardProperty = DependencyProperty.Register("RenderTransparencyCheckerboard", typeof(bool), typeof(SlidePreview), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(RenderTransparencyCheckerboardChanged)));

	public static readonly DependencyProperty IncludeTextPlaceholderProperty = DependencyProperty.Register("IncludeTextPlaceholder", typeof(bool), typeof(SlidePreview));

	public static readonly DependencyProperty OverlayVMProperty = DependencyProperty.Register("OverlayVM", typeof(IMediaOverlayVM), typeof(SlidePreview));

	public static readonly DependencyProperty ForceBackgroundDrawProperty = DependencyProperty.Register("ForceBackgroundDraw", typeof(bool), typeof(SlidePreview), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));

	private static readonly DependencyProperty AspectRatioProperty = DependencyProperty.Register("AspectRatio", typeof(double), typeof(SlidePreview), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)1.7777777777777777, FrameworkPropertyMetadataOptions.AffectsRender));

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

	public bool IncludeBackground
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IncludeBackgroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IncludeBackgroundProperty, (object)value);
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

	public IMediaOverlayVM OverlayVM
	{
		get
		{
			return (IMediaOverlayVM)((DependencyObject)this).GetValue(OverlayVMProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(OverlayVMProperty, (object)value);
		}
	}

	private double AspectRatio
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
		((SlidePreview)(object)callerObject).OnSourceChanged((CustomSlide)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (CustomSlide)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void BackgroundChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		((SlidePreview)(object)callerObject).OnSourceInvalidated();
	}

	private static void RenderTransparencyCheckerboardChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		((SlidePreview)(object)callerObject).OnSourceInvalidated();
	}

	public SlidePreview()
	{
		InitializeComponent();
		_slidePreviewRenderer = UIServiceProvider.GetService<ISlidePreviewService>();
	}

	private void OnSourceChanged(CustomSlide oldValue, CustomSlide newValue)
	{
		if (oldValue != null)
		{
			oldValue.VisualInvalidated -= OnSourceInvalidated;
			oldValue.PropertyChanged -= Slide_PropertyChanged;
		}
		if (newValue != null)
		{
			newValue.VisualInvalidated += OnSourceInvalidated;
			newValue.PropertyChanged += Slide_PropertyChanged;
		}
		OnSizeInvalidated();
		OnSourceInvalidated();
	}

	private void Slide_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "Size")
		{
			OnSizeInvalidated();
		}
	}

	private void OnSourceInvalidated()
	{
		((DispatcherObject)this).Dispatcher.Invoke((Action)base.InvalidateVisual);
	}

	private void OnSizeInvalidated()
	{
		((DependencyObject)this).SetCurrentValue(AspectRatioProperty, (object)((Source == null) ? 1.0 : (Source.Size.X / Source.Size.Y)));
	}

	protected override void OnRender(DrawingContext drawingContext)
	{
		SetBackgroundImageAsync().ExecuteAsync();
		base.OnRender(drawingContext);
	}

	private async Task SetBackgroundImageAsync()
	{
		Vector2<int> previewSize = (Vector2<int>)PreviewContainer.RenderSize;
		if (Source == null || previewSize.X <= 0 || previewSize.Y <= 0)
		{
			return;
		}
		BackgroundImage.Source = Source.BackgroundMediaSampler?.Invoke()?.Source;
		Color secondaryBackground = ((!Source.UseBackgroundColor && RenderTransparencyCheckerboard && SecondaryBackgroundColor == Colors.Transparent) ? Colors.Transparent : SecondaryBackgroundColor);
		using IBitmapHandle bitmapHandle = await _slidePreviewRenderer.RenderSlidePreviewAsync(Source, new SlidePreviewRenderParams(previewSize, IncludeBackground, IncludeBackgroundMedia: false, secondaryBackground, ElementsRenderOption.None, null, IncludeTextPlaceholder, UseFullSizeMedia: false, UseScreenScalar: true, IncludeLinkIndicator: true, ForceBackgroundDraw));
		PreviewImage.Source = bitmapHandle.BitmapSource;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
