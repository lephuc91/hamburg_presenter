using System.Windows;
using System.Windows.Markup;
using Pro.UI.Components;
using ProPresenter.UI.ViewModels.Preview;

namespace ProPresenter.UI.Preview;

public partial class ScreenSelector : FrameworkCollection, IComponentConnector
{
	public static readonly DependencyProperty SelectedPreviewScreenProperty = DependencyProperty.Register("SelectedScreen", typeof(IOutputScreenVM), typeof(ScreenSelector));

	public static readonly DependencyProperty SelectScreenCommandProperty = DependencyProperty.Register("SelectScreenCommand", typeof(ICommand<IOutputScreenVM>), typeof(ScreenSelector));

	public IOutputScreenVM? SelectedScreen
	{
		get
		{
			return (IOutputScreenVM)((DependencyObject)this).GetValue(SelectedPreviewScreenProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedPreviewScreenProperty, (object)value);
		}
	}

	public ICommand<IOutputScreenVM?>? SelectScreenCommand
	{
		get
		{
			return (ICommand<IOutputScreenVM>)((DependencyObject)this).GetValue(SelectScreenCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectScreenCommandProperty, (object)value);
		}
	}

	public ScreenSelector()
	{
		InitializeComponent();
	}
}
