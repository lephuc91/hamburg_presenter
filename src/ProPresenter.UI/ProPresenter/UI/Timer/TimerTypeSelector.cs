using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using System.Windows.Media;
using Pro.UI.Utility;
using ProPresenter.DO.Timer;

namespace ProPresenter.UI.Timer;

public partial class TimerTypeSelector : UserControl, IComponentConnector
{
	public static readonly DependencyProperty DisplayIconsProperty = DependencyProperty.Register("DisplayIcons", typeof(bool), typeof(TimerTypeSelector), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public static readonly DependencyProperty SelectedTimerTypeProperty = DependencyProperty.Register("SelectedTimerType", typeof(TimerType), typeof(TimerTypeSelector));

	public TimerType SelectedTimerType
	{
		get
		{
			return (TimerType)((DependencyObject)this).GetValue(SelectedTimerTypeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedTimerTypeProperty, (object)value);
		}
	}

	public bool DisplayIcons
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(DisplayIconsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DisplayIconsProperty, (object)value);
		}
	}

	public TimerTypeSelector()
	{
		InitializeComponent();
		base.Loaded += TimerTypeSelector_Loaded;
	}

	private void TimerTypeSelector_Loaded(object? sender, RoutedEventArgs e)
	{
		ToggleButton toggleButton = ((DependencyObject)(object)TimerTypeSelectorIcon).FindVisualChild((ToggleButton t) => t.Name.Equals("toggleButton"));
		if (toggleButton != null)
		{
			toggleButton.Background = Brushes.Transparent;
			toggleButton.BorderThickness = new Thickness(0.0);
		}
	}
}
