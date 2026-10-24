using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using ProPresenter.DO.LiveVideo;

namespace ProPresenter.UI.LiveVideo;

public partial class VideoInputPreview : UserControl, IComponentConnector
{
	private static readonly DependencyProperty VideoInputProperty = DependencyProperty.Register("VideoInput", typeof(LiveVideoInput), typeof(VideoInputPreview));

	public LiveVideoInput? VideoInput
	{
		get
		{
			return (LiveVideoInput)((DependencyObject)this).GetValue(VideoInputProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(VideoInputProperty, (object)value);
		}
	}

	public VideoInputPreview()
	{
		InitializeComponent();
	}
}
