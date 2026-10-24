using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using ProPresenter.DO.Media;

namespace ProPresenter.UI.CueInspector;

public class PreviewImage : Image
{
	private const string AudioIcon = "pack://application:,,,/ProPresenter.UI;component/Resources/Icons/Outline/AudioItem@3x.png";

	private const string WebIcon = "pack://application:,,,/ProPresenter.UI;component/Resources/Icons/SlideElements/slideElementWeb@3x.png";

	public static readonly DependencyProperty ItemProperty = DependencyProperty.Register("Item", typeof(MediaBase), typeof(PreviewImage), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(ItemPropertyChanged)));

	public static readonly DependencyProperty ShowIconForNonVisualMediaProperty = DependencyProperty.Register("ShowIconForNonVisualMedia", typeof(bool), typeof(PreviewImage), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public MediaBase? Item
	{
		get
		{
			return (MediaBase)((DependencyObject)this).GetValue(ItemProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ItemProperty, (object)value);
		}
	}

	public bool ShowIconForNonVisualMedia
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowIconForNonVisualMediaProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowIconForNonVisualMediaProperty, (object)value);
		}
	}

	private static void ItemPropertyChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		((PreviewImage)(object)callerObject).ItemChanged(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as MediaBase, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as MediaBase);
	}

	private void ItemChanged(MediaBase? oldItem, MediaBase? newItem)
	{
		if (oldItem != null)
		{
			oldItem.VisualInvalidated -= UpdatePreviewImage;
		}
		if (newItem != null)
		{
			newItem.VisualInvalidated += UpdatePreviewImage;
		}
		UpdatePreviewImage();
	}

	private void UpdatePreviewImage()
	{
		if (Item != null)
		{
			base.Source = Item.MediaType switch
			{
				MediaType.Image => ((IDrawMedia)Item).Drawing.PreviewImage, 
				MediaType.Video => ((IDrawMedia)Item).Drawing.PreviewImage, 
				MediaType.Audio => ShowIconForNonVisualMedia ? new BitmapImage(new Uri("pack://application:,,,/ProPresenter.UI;component/Resources/Icons/Outline/AudioItem@3x.png")) : null, 
				MediaType.Web => ShowIconForNonVisualMedia ? new BitmapImage(new Uri("pack://application:,,,/ProPresenter.UI;component/Resources/Icons/SlideElements/slideElementWeb@3x.png")) : null, 
				_ => null, 
			};
		}
	}
}
