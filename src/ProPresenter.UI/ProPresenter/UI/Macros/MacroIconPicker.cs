using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.DO.Triggering;
using Pro.UI.Components;

namespace ProPresenter.UI.Macros;

public partial class MacroIconPicker : UserControl, IComponentConnector
{
	public static readonly DependencyProperty SelectIconCommandProperty = DependencyProperty.Register("SelectIconCommand", typeof(ICommand<ImageType>), typeof(MacroIconPicker));

	public ICommand<ImageType> SelectIconCommand
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

	public MacroIconPicker()
	{
		InitializeComponent();
	}
}
