using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.UI.Components;
using Pro.UI.Utility;
using ProPresenter.DO.OutputConfiguration;

namespace ProPresenter.UI.OutputConfiguration;

public partial class ScreenControlHeader : UserControl, IComponentConnector
{
	public static readonly DependencyProperty SelectedScreenArrangementProperty = DependencyProperty.Register("SelectedScreenArrangement", typeof(ScreenArrangementBase), typeof(ScreenControlHeader));

	public static readonly DependencyProperty RemoveScreenArrangementCommandProperty = DependencyProperty.Register("RemoveScreenArrangementCommand", typeof(ICommand), typeof(ScreenControlHeader));

	public static readonly DependencyProperty ChangeArrangementTypeCommandProperty = DependencyProperty.Register("ChangeArrangementTypeCommand", typeof(ICommand<ScreenArrangementType>), typeof(ScreenControlHeader));

	public ScreenArrangementBase? SelectedScreenArrangement
	{
		get
		{
			return (ScreenArrangementBase)((DependencyObject)this).GetValue(SelectedScreenArrangementProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedScreenArrangementProperty, (object)value);
		}
	}

	public ICommand? RemoveScreenArrangementCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(RemoveScreenArrangementCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RemoveScreenArrangementCommandProperty, (object)value);
		}
	}

	public ICommand<ScreenArrangementType>? ChangeArrangementTypeCommand
	{
		get
		{
			return (ICommand<ScreenArrangementType>)((DependencyObject)this).GetValue(ChangeArrangementTypeCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ChangeArrangementTypeCommandProperty, (object)value);
		}
	}

	public ScreenControlHeader()
	{
		InitializeComponent();
	}

	private void ScreenArrangementTypeComboBox_DropDownClosed(object? sender, EventArgs e)
	{
		ScreenArrangementType screenArrangementType = (ScreenArrangementType)ScreenArrangementTypeComboBox.SelectedItem;
		if (screenArrangementType != SelectedScreenArrangement?.ArrangementType)
		{
			ChangeArrangementTypeCommand?.Invoke(screenArrangementType);
			ScreenArrangementTypeComboBox.GetBindingExpression(Selector.SelectedItemProperty)?.UpdateTarget();
		}
	}
}
