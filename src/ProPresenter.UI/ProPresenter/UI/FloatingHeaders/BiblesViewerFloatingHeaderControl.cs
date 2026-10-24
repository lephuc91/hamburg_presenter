using System.Windows;

namespace ProPresenter.UI.FloatingHeaders;

public class BiblesViewerFloatingHeaderControl : PlaylistItemFloatingHeaderControl
{
	public static readonly DependencyProperty SlidesChangedProperty = DependencyProperty.Register("SlidesChanged", typeof(bool), typeof(BiblesViewerFloatingHeaderControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(SlidePresentationChanged)));

	public bool SlidesChanged
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(SlidesChangedProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SlidesChangedProperty, (object)value);
		}
	}

	private static void SlidePresentationChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((BiblesViewerFloatingHeaderControl)(object)d).BiblePresentationChanged((bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private void BiblePresentationChanged(bool newValue)
	{
		if (newValue)
		{
			ScrollToTop();
		}
	}

	private void ScrollToTop()
	{
		ScrollIntoView(base.ActivePlaylistItem, 0.0, null, scrollToTop: true);
	}
}
