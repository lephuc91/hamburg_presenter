using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace ProPresenter.UI.Registration.PopUpAlerts;

public partial class LaunchPopUpContent : UserControl, IComponentConnector
{
	public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(LaunchPopUpContent));

	public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(LaunchPopUpContent));

	public static readonly DependencyProperty SkipForNowButtonTitleProperty = DependencyProperty.Register("SkipForNowButtonTitle", typeof(string), typeof(LaunchPopUpContent));

	public static readonly DependencyProperty ButtonsProperty = DependencyProperty.Register("Buttons", typeof(Collection<Button>), typeof(LaunchPopUpContent));

	public static readonly DependencyProperty HelpCommandProperty = DependencyProperty.Register("HelpCommand", typeof(ICommand), typeof(LaunchPopUpContent));

	public static readonly DependencyProperty CloseCommandProperty = DependencyProperty.Register("CloseCommand", typeof(ICommand), typeof(LaunchPopUpContent));

	public string? Title
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(TitleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TitleProperty, (object)value);
		}
	}

	public string? Text
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(TextProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TextProperty, (object)value);
		}
	}

	public string? SkipForNowButtonTitle
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(SkipForNowButtonTitleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SkipForNowButtonTitleProperty, (object)value);
		}
	}

	public Collection<Button> Buttons
	{
		get
		{
			return (Collection<Button>)((DependencyObject)this).GetValue(ButtonsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ButtonsProperty, (object)value);
		}
	}

	public ICommand? HelpCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(HelpCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HelpCommandProperty, (object)value);
		}
	}

	public ICommand? CloseCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(CloseCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CloseCommandProperty, (object)value);
		}
	}

	public LaunchPopUpContent()
	{
		InitializeComponent();
		Buttons = new ObservableCollection<Button>();
	}
}
