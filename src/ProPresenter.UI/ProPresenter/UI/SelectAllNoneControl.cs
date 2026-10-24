using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace ProPresenter.UI;

public partial class SelectAllNoneControl : UserControl, IComponentConnector
{
	public static readonly DependencyProperty SelectAllCommandProperty = DependencyProperty.Register("SelectAllCommand", typeof(ICommand), typeof(SelectAllNoneControl));

	public static readonly DependencyProperty SelectNoneCommandProperty = DependencyProperty.Register("SelectNoneCommand", typeof(ICommand), typeof(SelectAllNoneControl));

	public ICommand? SelectAllCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(SelectAllCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectAllCommandProperty, (object)value);
		}
	}

	public ICommand? SelectNoneCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(SelectNoneCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectNoneCommandProperty, (object)value);
		}
	}

	public SelectAllNoneControl()
	{
		InitializeComponent();
	}
}
