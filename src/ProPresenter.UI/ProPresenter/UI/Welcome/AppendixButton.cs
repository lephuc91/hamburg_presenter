using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;

namespace ProPresenter.UI.Welcome;

public partial class AppendixButton : UserControl, IComponentConnector
{
	public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(AppendixButton), new PropertyMetadata((object)string.Empty));

	public static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(ImageSource), typeof(AppendixButton));

	public static readonly DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(AppendixButton));

	public string Title
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

	public ImageSource? Icon
	{
		get
		{
			return (ImageSource)((DependencyObject)this).GetValue(IconProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IconProperty, (object)value);
		}
	}

	public ICommand Command
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(CommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CommandProperty, (object)value);
		}
	}

	public AppendixButton()
	{
		InitializeComponent();
	}
}
