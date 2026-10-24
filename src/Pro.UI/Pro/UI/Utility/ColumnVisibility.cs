using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Pro.UI.Utility;

public static class ColumnVisibility
{
	private const string ToggleColumnVisibiliityPropertyName = "ToggleColumnVisibility";

	private static Dictionary<DataGrid, ContextMenu> _dataGridColumnContextMenu = new Dictionary<DataGrid, ContextMenu>();

	public static readonly DependencyProperty ToggleColumnVisibilityProperty = DependencyProperty.RegisterAttached("ToggleColumnVisibility", typeof(bool), typeof(ColumnVisibility), new PropertyMetadata((object)false, new PropertyChangedCallback(OnToggleColumnVisibilityChanged)));

	public static bool GetToggleColumnVisibility(DependencyObject obj)
	{
		return (bool)obj.GetValue(ToggleColumnVisibilityProperty);
	}

	public static void SetToggleColumnVisibility(DependencyObject obj, bool value)
	{
		obj.SetValue(ToggleColumnVisibilityProperty, (object)value);
	}

	private static void OnToggleColumnVisibilityChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		DataGrid datagrid = (DataGrid)(object)d;
		object newValue = ((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		SetDataGridColumnContextMenu(datagrid, newValue is bool && (bool)newValue);
	}

	private static void SetDataGridColumnContextMenu(DataGrid datagrid, bool canToggleVisibility)
	{
		ContextMenu columnsContextMenu = GetColumnsContextMenu(datagrid);
		if (!datagrid.Columns.Any())
		{
			return;
		}
		List<MenuItem> list = new List<MenuItem>();
		foreach (DataGridColumn column in datagrid.Columns)
		{
			MenuItem menuItem = new MenuItem();
			menuItem.Header = column.Header;
			menuItem.DataContext = column;
			menuItem.Click += MenuItem_Click;
			menuItem.IsChecked = true;
			list.Add(menuItem);
		}
		columnsContextMenu.ItemsSource = list;
		DataGridColumnHeadersPresenter dataGridColumnHeadersPresenter = ((DependencyObject)(object)datagrid).FindVisualChild<DataGridColumnHeadersPresenter>();
		if (dataGridColumnHeadersPresenter != null)
		{
			dataGridColumnHeadersPresenter.ContextMenu = (canToggleVisibility ? columnsContextMenu : null);
		}
	}

	private static void MenuItem_Click(object? sender, RoutedEventArgs e)
	{
		if (sender is MenuItem { DataContext: DataGridColumn dataContext } menuItem)
		{
			dataContext.Visibility = ((dataContext.Visibility == Visibility.Visible) ? Visibility.Collapsed : Visibility.Visible);
			menuItem.IsChecked = !menuItem.IsChecked;
		}
	}

	private static ContextMenu GetColumnsContextMenu(DataGrid d)
	{
		if (_dataGridColumnContextMenu.TryGetValue(d, out ContextMenu value))
		{
			return value;
		}
		value = new ContextMenu();
		_dataGridColumnContextMenu.Add(d, value);
		d.Loaded += DataGrid_Loaded;
		return value;
	}

	private static void DataGrid_Loaded(object? sender, RoutedEventArgs e)
	{
		if (sender is DataGrid dataGrid)
		{
			SetDataGridColumnContextMenu(dataGrid, GetToggleColumnVisibility((DependencyObject)(object)dataGrid));
		}
	}
}
