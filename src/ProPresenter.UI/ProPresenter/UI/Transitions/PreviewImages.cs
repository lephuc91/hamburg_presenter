using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ProPresenter.UI.Transitions;

public static class PreviewImages
{
	public static BitmapImage StartImage { get; }

	public static BitmapImage EndImage { get; }

	static PreviewImages()
	{
		StartImage = new BitmapImage(new Uri("pack://application:,,,/ProPresenter.UI;component/Resources/Icons/Transitions/RainbowTransition.jpg", UriKind.Absolute));
		EndImage = new BitmapImage(new Uri("pack://application:,,,/ProPresenter.UI;component/Resources/Icons/Transitions/OceanTransition.jpg", UriKind.Absolute));
		((Freezable)StartImage).Freeze();
		((Freezable)EndImage).Freeze();
	}
}
