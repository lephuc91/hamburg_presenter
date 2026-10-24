using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using CommunityToolkit.Mvvm.Input;
using Pro.UI.Controls;
using ProPresenter.DO.LiveVideo;

namespace ProPresenter.UI.Settings.PageTemplates.Inputs.Video;

public partial class DirectXPreview : UserControl, IComponentConnector
{
	public static readonly DependencyProperty VideoInputProperty = DependencyProperty.Register("VideoInput", typeof(LiveVideoInput), typeof(DirectXPreview));

	public static readonly DependencyProperty RequestRenderCommandProperty = DependencyProperty.Register("RequestRenderCommand", typeof(IRelayCommand<RequestRenderParameter>), typeof(DirectXPreview));

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

	public IRelayCommand<RequestRenderParameter>? RequestRenderCommand
	{
		get
		{
			return (IRelayCommand<RequestRenderParameter>)((DependencyObject)this).GetValue(RequestRenderCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RequestRenderCommandProperty, (object)value);
		}
	}

	public DirectXPreview()
	{
		InitializeComponent();
	}
}
