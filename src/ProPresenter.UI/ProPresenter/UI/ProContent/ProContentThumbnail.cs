using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media.Imaging;
using Pro.Common.Animation;
using Pro.Common.Background;
using Pro.Common.Cache;

namespace ProPresenter.UI.ProContent;

public partial class ProContentThumbnail : UserControl, IComponentConnector
{
	private static readonly DependencyProperty ThumbnailImageProperty = DependencyProperty.Register("ThumbnailImage", typeof(BitmapSource), typeof(ProContentThumbnail));

	public static readonly DependencyProperty ThumbnailProperty = DependencyProperty.Register("Thumbnail", typeof(IAsyncValue<BitmapSource>), typeof(ProContentThumbnail), new PropertyMetadata((PropertyChangedCallback)null)
	{
		PropertyChangedCallback = new PropertyChangedCallback(LoadableThumbnail_Changed)
	});

	private static readonly DependencyProperty PreviewImageProperty = DependencyProperty.Register("PreviewImage", typeof(IReadOnlyList<IAnimationFrame>), typeof(ProContentThumbnail), new PropertyMetadata((object)Array.Empty<IAnimationFrame>())
	{
		CoerceValueCallback = new CoerceValueCallback(PreviewImage_CoerceValueCallback)
	});

	public static readonly DependencyProperty PreviewProperty = DependencyProperty.Register("Preview", typeof(IAsyncValue<IReadOnlyList<IAnimationFrame>>), typeof(ProContentThumbnail), new PropertyMetadata
	{
		PropertyChangedCallback = new PropertyChangedCallback(LoadablePreview_Changed)
	});

	public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(double), typeof(ProContentThumbnail), new PropertyMetadata((object)8.0));

	public static readonly DependencyProperty AspectRatioProperty = DependencyProperty.Register("AspectRatio", typeof(double), typeof(ProContentThumbnail), new PropertyMetadata((object)1.0));

	public static readonly DependencyProperty ShouldShowPreviewIfAvailableProperty = DependencyProperty.Register("ShouldShowPreviewIfAvailable", typeof(bool), typeof(ProContentThumbnail), new PropertyMetadata((object)false)
	{
		PropertyChangedCallback = new PropertyChangedCallback(ShouldShowPreviewIfAvailableProperty_Changed)
	});

	public IAsyncValue<BitmapSource?>? Thumbnail
	{
		get
		{
			return (IAsyncValue<BitmapSource>)((DependencyObject)this).GetValue(ThumbnailProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ThumbnailProperty, (object)value);
		}
	}

	private BitmapSource? ThumbnailImage
	{
		get
		{
			return (BitmapSource)((DependencyObject)this).GetValue(ThumbnailImageProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ThumbnailImageProperty, (object)value);
		}
	}

	public IAsyncValue<IReadOnlyList<IAnimationFrame>>? Preview
	{
		get
		{
			return (IAsyncValue<IReadOnlyList<IAnimationFrame>>)((DependencyObject)this).GetValue(PreviewProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PreviewProperty, (object)value);
		}
	}

	private IReadOnlyList<IAnimationFrame> PreviewImage
	{
		get
		{
			return (IReadOnlyList<IAnimationFrame>)((DependencyObject)this).GetValue(PreviewImageProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PreviewImageProperty, (object)value);
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

	public bool ShouldShowPreviewIfAvailable
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShouldShowPreviewIfAvailableProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShouldShowPreviewIfAvailableProperty, (object)value);
		}
	}

	private static void LoadableThumbnail_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is ProContentThumbnail proContentThumbnail)
		{
			proContentThumbnail.ThumbnailRelevantPropertyChanged();
		}
	}

	private static void LoadablePreview_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is ProContentThumbnail proContentThumbnail)
		{
			proContentThumbnail.PreviewRelevantPropertyChanged();
		}
	}

	private static void ShouldShowPreviewIfAvailableProperty_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is ProContentThumbnail proContentThumbnail)
		{
			proContentThumbnail.PreviewRelevantPropertyChanged();
		}
	}

	private static object PreviewImage_CoerceValueCallback(DependencyObject d, object baseValue)
	{
		if (baseValue is IReadOnlyList<IAnimationFrame> result)
		{
			return result;
		}
		return Array.Empty<IAnimationFrame>();
	}

	public ProContentThumbnail()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		InitializeComponent();
		base.IsVisibleChanged += new DependencyPropertyChangedEventHandler(OnIsVisibleChanged);
	}

	private void OnIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
	{
		ThumbnailRelevantPropertyChanged();
	}

	private void PreviewRelevantPropertyChanged()
	{
		if (PreviewImage.Count <= 0 && ShouldShowPreviewIfAvailable)
		{
			ReadPreviewAsync().ExecuteAsync();
		}
		else if (!ShouldShowPreviewIfAvailable)
		{
			PreviewImage = Array.Empty<IAnimationFrame>();
		}
	}

	private void ThumbnailRelevantPropertyChanged()
	{
		if (base.IsVisible && ThumbnailImage == null)
		{
			ReadThumbnailAsync().ExecuteAsync();
		}
		else if (!base.IsVisible)
		{
			ThumbnailImage = null;
		}
	}

	private async Task ReadThumbnailAsync()
	{
		if (Thumbnail == null)
		{
			ThumbnailImage = null;
			return;
		}
		IAsyncValue<BitmapSource?> originalThumbnail = Thumbnail;
		BitmapSource thumbnailImage = await Thumbnail.LoadAsync();
		if (base.IsVisible && originalThumbnail == Thumbnail)
		{
			ThumbnailImage = thumbnailImage;
		}
	}

	private async Task ReadPreviewAsync()
	{
		if (Preview == null)
		{
			PreviewImage = Array.Empty<IAnimationFrame>();
			return;
		}
		IAsyncValue<IReadOnlyList<IAnimationFrame>> originalPreview = Preview;
		IReadOnlyList<IAnimationFrame> previewImage = await Preview.LoadAsync();
		if (ShouldShowPreviewIfAvailable && originalPreview == Preview)
		{
			PreviewImage = previewImage;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
