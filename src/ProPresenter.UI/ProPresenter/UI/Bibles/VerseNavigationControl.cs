using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace ProPresenter.UI.Bibles;

public partial class VerseNavigationControl : UserControl, IComponentConnector
{
	public static readonly DependencyProperty GoToPreviousVerseCommandProperty = DependencyProperty.Register("GoToPreviousVerseCommand", typeof(ICommand), typeof(VerseNavigationControl));

	public static readonly DependencyProperty GoToNextVerseCommandProperty = DependencyProperty.Register("GoToNextVerseCommand", typeof(ICommand), typeof(VerseNavigationControl));

	public ICommand? GoToPreviousVerseCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(GoToPreviousVerseCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(GoToPreviousVerseCommandProperty, (object)value);
		}
	}

	public ICommand? GoToNextVerseCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(GoToNextVerseCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(GoToNextVerseCommandProperty, (object)value);
		}
	}

	public VerseNavigationControl()
	{
		InitializeComponent();
	}
}
