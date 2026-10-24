using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;

namespace ProPresenter.UI.ThumbnailOverlay;

public partial class MissingMediaRing : UserControl, IComponentConnector
{
	static MissingMediaRing()
	{
		Control.ForegroundProperty.OverrideMetadata(typeof(MissingMediaRing), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Brushes.White));
	}

	public MissingMediaRing()
	{
		InitializeComponent();
	}
}
