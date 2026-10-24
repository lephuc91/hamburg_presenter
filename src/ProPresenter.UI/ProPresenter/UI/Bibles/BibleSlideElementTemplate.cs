using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using Pro.Common.Components;
using Pro.Common.Mathematics;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Themes;
using ProPresenter.Rendering;

namespace ProPresenter.UI.Bibles;

public partial class BibleSlideElementTemplate : UserControl, IComponentConnector
{
	public static readonly DependencyProperty TemplateSlideProperty = DependencyProperty.Register("TemplateSlide", typeof(TemplateSlide), typeof(BibleSlideElementTemplate), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnTemplateSlideChanged)));

	public static readonly DependencyProperty SlideElementProperty = DependencyProperty.Register("SlideElement", typeof(SlideElementBase), typeof(BibleSlideElementTemplate), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnSlideElementChanged)));

	public TemplateSlide? TemplateSlide
	{
		get
		{
			return (TemplateSlide)((DependencyObject)this).GetValue(TemplateSlideProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TemplateSlideProperty, (object)value);
		}
	}

	public SlideElementBase? SlideElement
	{
		get
		{
			return (SlideElementBase)((DependencyObject)this).GetValue(SlideElementProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SlideElementProperty, (object)value);
		}
	}

	private static void OnTemplateSlideChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((BibleSlideElementTemplate)(object)d).TemplateSlideChanged(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as TemplateSlide, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as TemplateSlide);
	}

	private static void OnSlideElementChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((BibleSlideElementTemplate)(object)d).UpdatePreviewImage();
	}

	public BibleSlideElementTemplate()
	{
		InitializeComponent();
	}

	private void TemplateSlideChanged(TemplateSlide? oldTemplate, TemplateSlide? newTemplate)
	{
		if (oldTemplate != null)
		{
			oldTemplate.Slide.VisualInvalidated -= UpdatePreviewImage;
		}
		if (newTemplate != null)
		{
			newTemplate.Slide.VisualInvalidated += UpdatePreviewImage;
		}
		UpdatePreviewImage();
	}

	private void UpdatePreviewImage()
	{
		if (SlideElement != null && TemplateSlide != null && TemplateSlide.Slide.Elements.Contains(SlideElement))
		{
			SlidePreviewRenderParams renderParams = new SlidePreviewRenderParams(new Vector2<int>((int)PreviewImage.Width, (int)PreviewImage.Height), IncludeBackground: true, IncludeBackgroundMedia: true, Colors.Black, ElementsRenderOption.ExclusiveHighlight, new SlideElementBase[1] { SlideElement });
			SlidePreviewRenderer.RenderSlidePreviewDeferred(TemplateSlide.Slide, renderParams, delegate(CustomSlide s, IBitmapHandle b)
			{
				PreviewImage.Source = b.BitmapSource;
			});
		}
	}
}
