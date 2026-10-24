using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.UI.Components;
using ProPresenter.DO.ClearGroups;

namespace ProPresenter.UI.ClearGroups;

public partial class ClearGroupIconSelector : UserControl, IComponentConnector
{
	public static readonly DependencyProperty SelectIconCommandProperty = DependencyProperty.Register("SelectIconCommand", typeof(ICommand<ImageType>), typeof(ClearGroupIconSelector));

	public ICommand<ImageType>? SelectIconCommand
	{
		get
		{
			return (ICommand<ImageType>)((DependencyObject)this).GetValue(SelectIconCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectIconCommandProperty, (object)value);
		}
	}

	public ClearGroupIconSelector()
	{
		InitializeComponent();
	}
}
