using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media.Imaging;
using Pro.Common.Background;
using Pro.Common.Cache;
using Pro.Common.Downloads;

namespace ProPresenter.UI.Downloads;

public partial class DownloadItemTemplate : UserControl, IComponentConnector
{
	private static readonly DependencyProperty ThumbnailImageProperty = DependencyProperty.Register("ThumbnailImage", typeof(BitmapSource), typeof(DownloadItemTemplate));

	public static readonly DependencyProperty ThumbnailProperty = DependencyProperty.Register("Thumbnail", typeof(IAsyncValue<BitmapSource>), typeof(DownloadItemTemplate), new PropertyMetadata((PropertyChangedCallback)null)
	{
		PropertyChangedCallback = new PropertyChangedCallback(LoadableThumbnail_Changed)
	});

	public static readonly DependencyProperty StatusProperty = DependencyProperty.Register("Status", typeof(DownloadStatus), typeof(DownloadItemTemplate));

	public static readonly DependencyProperty FileNameProperty = DependencyProperty.Register("FileName", typeof(string), typeof(DownloadItemTemplate));

	public static readonly DependencyProperty ReceivedStatusProperty = DependencyProperty.Register("ReceivedStatus", typeof(string), typeof(DownloadItemTemplate));

	public static readonly DependencyProperty CancelDownloadCommandProperty = DependencyProperty.Register("CancelDownloadCommand", typeof(ICommand), typeof(DownloadItemTemplate));

	public static readonly DependencyProperty PercentCompleteProperty = DependencyProperty.Register("PercentComplete", typeof(int), typeof(DownloadItemTemplate), new PropertyMetadata((object)0));

	public static readonly DependencyProperty RetryDownloadCommandProperty = DependencyProperty.Register("RetryDownloadCommand", typeof(ICommand), typeof(DownloadItemTemplate));

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

	public DownloadStatus? Status
	{
		get
		{
			return (DownloadStatus?)((DependencyObject)this).GetValue(StatusProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(StatusProperty, (object)value);
		}
	}

	public string? FileName
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(FileNameProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FileNameProperty, (object)value);
		}
	}

	public string? ReceivedStatus
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(ReceivedStatusProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ReceivedStatusProperty, (object)value);
		}
	}

	public ICommand? CancelDownloadCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(CancelDownloadCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CancelDownloadCommandProperty, (object)value);
		}
	}

	public int PercentComplete
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(PercentCompleteProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PercentCompleteProperty, (object)value);
		}
	}

	public ICommand? RetryDownloadCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(RetryDownloadCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RetryDownloadCommandProperty, (object)value);
		}
	}

	private static void LoadableThumbnail_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is DownloadItemTemplate downloadItemTemplate)
		{
			downloadItemTemplate.ThumbnailRelevantPropertyChanged();
		}
	}

	public DownloadItemTemplate()
	{
		InitializeComponent();
	}

	private void DownloadItemTemplate_IsVisibleChanged(object _, DependencyPropertyChangedEventArgs e)
	{
		ThumbnailRelevantPropertyChanged();
	}

	private void ThumbnailRelevantPropertyChanged()
	{
		if (!base.IsVisible)
		{
			ThumbnailImage = null;
		}
		else
		{
			ReadThumbnailAsync().ExecuteAsync();
		}
	}

	private async Task ReadThumbnailAsync()
	{
		if (Thumbnail == null)
		{
			ThumbnailImage = null;
		}
		else
		{
			ThumbnailImage = await Thumbnail.LoadAsync();
		}
	}
}
