using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.UI.Components;
using Pro.UI.Controls.Windowing;
using Pro.UI.Utility;
using ProPresenter.DO.Migration;

namespace ProPresenter.UI.Migration;

public partial class MigrationAssistantDialog : ChromedWindow, IComponentConnector, IStyleConnector
{
	public static readonly DependencyProperty ReplaceLibraryCommandProperty = DependencyProperty.Register("ReplaceLibraryCommand", typeof(ICommand<MigrationLibrary>), typeof(MigrationAssistantDialog));

	public ICommand<MigrationLibrary?>? ReplaceLibraryCommand
	{
		get
		{
			return (ICommand<MigrationLibrary>)((DependencyObject)this).GetValue(ReplaceLibraryCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ReplaceLibraryCommandProperty, (object)value);
		}
	}

	public MigrationAssistantDialog()
	{
		InitializeComponent();
	}

	private void ImportButton_Click(object? sender, RoutedEventArgs e)
	{
		base.DialogResult = true;
	}

	private void DataGridRow_MouseDoubleClick(object? sender, MouseButtonEventArgs e)
	{
		if (sender is DataGridRow dataGridRow)
		{
			ReplaceLibraryCommand?.Invoke<MigrationLibrary>(dataGridRow.DataContext as MigrationLibrary);
		}
	}
}
