using System.Windows;
using System.Windows.Markup;

namespace Pro.CrashRecovery;

public partial class CrashWindow : Window, IComponentConnector
{
	public static readonly DependencyProperty AppNameProperty = DependencyProperty.Register("AppName", typeof(string), typeof(CrashWindow));

	public static readonly DependencyProperty CrashDetailsProperty = DependencyProperty.Register("CrashDetails", typeof(string), typeof(CrashWindow));

	public string AppName
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(AppNameProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AppNameProperty, (object)value);
		}
	}

	public string CrashDetails
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(CrashDetailsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CrashDetailsProperty, (object)value);
		}
	}

	public CrashWindow()
	{
		InitializeComponent();
	}

	private void Relaunch_Click(object sender, RoutedEventArgs e)
	{
		base.DialogResult = true;
	}
}
