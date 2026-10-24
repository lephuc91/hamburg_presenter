using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.UI.Utility;
using ProPresenter.DO.LiveVideo;

namespace ProPresenter.UI.LiveVideo;

public partial class VideoInputSelector : UserControl, IComponentConnector, IStyleConnector
{
	private sealed class VideoInputStyleSelector : StyleSelector
	{
		private const string InputStyle = "InputStyle";

		private const string RemoveInputStyle = "RemoveInputStyle";

		private const string OpenSetupStyle = "OpenSetupStyle";

		private const string NoVideoSource = "NoVideoSource";

		private const string OpenSetup = "OpenSetup";

		private readonly ResourceDictionary _resources;

		public VideoInputStyleSelector(ResourceDictionary resources)
		{
			_resources = resources;
		}

		public override Style SelectStyle(object item, DependencyObject container)
		{
			if (item is LiveVideoInput)
			{
				return (Style)_resources["InputStyle"];
			}
			if (item is TextBlock textBlock)
			{
				return (textBlock.Tag as string) switch
				{
					"NoVideoSource" => (Style)_resources["RemoveInputStyle"], 
					"OpenSetup" => (Style)_resources["OpenSetupStyle"], 
					_ => base.SelectStyle(item, container), 
				};
			}
			return base.SelectStyle(item, container);
		}
	}

	public static readonly DependencyProperty AvailableInputsProperty = DependencyProperty.Register("AvailableInputs", typeof(LiveVideoInputCollection), typeof(VideoInputSelector));

	public static readonly DependencyProperty LiveVideoInputProperty = DependencyProperty.Register("LiveVideoInput", typeof(LiveVideoInput), typeof(VideoInputSelector), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	public static readonly DependencyProperty OpenSetupCommandProperty = DependencyProperty.Register("OpenSetupCommand", typeof(ICommand), typeof(VideoInputSelector));

	public LiveVideoInputCollection? AvailableInputs
	{
		get
		{
			return (LiveVideoInputCollection)((DependencyObject)this).GetValue(AvailableInputsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AvailableInputsProperty, (object)value);
		}
	}

	public LiveVideoInput? LiveVideoInput
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

	public ICommand? OpenSetupCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(OpenSetupCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(OpenSetupCommandProperty, (object)value);
		}
	}

	public VideoInputSelector()
	{
		InitializeComponent();
		InputSelectorButton.ContextMenu.ItemContainerStyleSelector = new VideoInputStyleSelector(base.Resources);
	}

	private void InputClick(object? sender, RoutedEventArgs e)
	{
		LiveVideoInput liveVideoInput = (sender as MenuItem)?.DataContext as LiveVideoInput;
		((DependencyObject)this).SetCurrentValue(LiveVideoInputProperty, (object)liveVideoInput);
	}

	private void RemoveInputClick(object? sender, RoutedEventArgs e)
	{
		((DependencyObject)this).SetCurrentValue(LiveVideoInputProperty, (object)null);
	}

	private void OpenSetupClick(object? sender, RoutedEventArgs e)
	{
		OpenSetupCommand?.Invoke();
	}
}
