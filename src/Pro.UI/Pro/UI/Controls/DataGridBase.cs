using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Common.Utility;
using Pro.UI.Commands;
using Pro.UI.Utility;

namespace Pro.UI.Controls;

public abstract class DataGridBase<T, I> : DataGrid where T : class where I : DataGridRow, new()
{
	private bool _ignoreSelectionChanges;

	public static readonly DependencyProperty RenameNextItemProperty;

	public static readonly DependencyProperty SelectedDataGridItemProperty;

	public static readonly DependencyProperty SelectedDataGridItemsProperty;

	public static readonly DependencyProperty SelectOnMouseUpProperty;

	public static readonly DependencyProperty DeselectOnLostFocusProperty;

	public static readonly DependencyProperty EnterKeySelectsNextRowProperty;

	public bool RenameNextItem
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(RenameNextItemProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RenameNextItemProperty, (object)value);
		}
	}

	public T? SelectedDataGridItem
	{
		get
		{
			return (T)((DependencyObject)this).GetValue(SelectedDataGridItemProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedDataGridItemProperty, (object)value);
		}
	}

	public ObservableCollection<T>? SelectedDataGridItems
	{
		get
		{
			return (ObservableCollection<T>)((DependencyObject)this).GetValue(SelectedDataGridItemsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedDataGridItemsProperty, (object)value);
		}
	}

	public bool SelectOnMouseUp
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(SelectOnMouseUpProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectOnMouseUpProperty, (object)value);
		}
	}

	public bool DeselectOnLostFocus
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(DeselectOnLostFocusProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DeselectOnLostFocusProperty, (object)value);
		}
	}

	public bool EnterKeySelectsNextRow
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(EnterKeySelectsNextRowProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(EnterKeySelectsNextRowProperty, (object)value);
		}
	}

	private static void SelectedDataGridItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((DataGridBase<T, I>)(object)d).UpdateSelectedDataGridItems();
	}

	private static void SelectedDataGridItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((DataGridBase<T, I>)(object)d).OnSelectedDataGridItemsChanged(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as ObservableCollection<T>, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as ObservableCollection<T>);
	}

	static DataGridBase()
	{
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected O, but got Unknown
		RenameNextItemProperty = DependencyProperty.Register("RenameNextItem", typeof(bool), typeof(DataGridBase<T, I>));
		SelectedDataGridItemProperty = DependencyProperty.Register("SelectedDataGridItem", typeof(T), typeof(DataGridBase<T, I>), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(SelectedDataGridItemChanged)));
		SelectedDataGridItemsProperty = DependencyProperty.Register("SelectedDataGridItems", typeof(ObservableCollection<T>), typeof(DataGridBase<T, I>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)new ObservableCollection<T>(), new PropertyChangedCallback(SelectedDataGridItemsChanged)));
		SelectOnMouseUpProperty = DependencyProperty.Register("SelectOnMouseUp", typeof(bool), typeof(DataGridBase<T, I>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));
		DeselectOnLostFocusProperty = DependencyProperty.Register("DeselectOnLostFocus", typeof(bool), typeof(DataGridBase<T, I>));
		EnterKeySelectsNextRowProperty = DependencyProperty.Register("EnterKeySelectsNextRow", typeof(bool), typeof(DataGridBase<T, I>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));
		DataGrid.SelectionModeProperty.OverrideMetadata(typeof(DataGridBase<T, I>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)DataGridSelectionMode.Single));
	}

	public DataGridBase()
	{
		base.CommandBindings.Add(CommonApplicationCommands.SelectAllCommand, delegate
		{
			SetSelection(base.Items.Cast<T>());
		}, () => base.HasItems);
		base.CommandBindings.Add(CommonApplicationCommands.DeselectAll, DeselectAll, () => SelectedDataGridItems?.Any() ?? false);
		base.ItemContainerGenerator.StatusChanged += ItemContainerGenerator_StatusChanged;
		base.Focusable = false;
	}

	protected override void OnPreviewKeyDown(KeyEventArgs e)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Invalid comparison between Unknown and I4
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Invalid comparison between Unknown and I4
		e.Handled = !EnterKeySelectsNextRow && !(e.OriginalSource is TextBox) && ((int)e.Key == 6 || (int)e.Key == 6);
	}

	protected override DependencyObject GetContainerForItemOverride()
	{
		return (DependencyObject)(object)new I();
	}

	protected override bool IsItemItsOwnContainerOverride(object item)
	{
		return item is I;
	}

	protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
	{
		base.OnItemsChanged(e);
		T newItem;
		if (base.IsLoaded && RenameNextItem)
		{
			IList? newItems = e.NewItems;
			newItem = ((newItems != null) ? newItems.Cast<T>().FirstOrDefault() : null);
			if (newItem != null)
			{
				base.ItemContainerGenerator.StatusChanged += statusChanged;
			}
		}
		void loaded(object? sender, EventArgs arg)
		{
			if (sender is I val2)
			{
				val2.Loaded -= loaded;
				rename(val2);
			}
		}
		void rename(I item)
		{
			item.Focus();
			CommonApplicationCommands.Rename.Invoke();
			RenameNextItem = false;
		}
		void statusChanged(object? sender, EventArgs arg)
		{
			I val = (I)(DataGridRow)(object)base.ItemContainerGenerator.ContainerFromItem(newItem);
			if (val != null)
			{
				base.ItemContainerGenerator.StatusChanged -= statusChanged;
				if (val.IsLoaded)
				{
					rename(val);
				}
				else
				{
					val.Loaded += loaded;
				}
			}
		}
	}

	protected override void OnSelectionChanged(SelectionChangedEventArgs e)
	{
		base.OnSelectionChanged(e);
		IList addedItems = e.AddedItems;
		T val = ((addedItems != null) ? addedItems.Cast<T>().LastOrDefault() : null);
		if (val != null)
		{
			ScrollIntoView(val);
		}
	}

	private void OnSelectedDataGridItemsChanged(ObservableCollection<T>? oldValue, ObservableCollection<T>? newValue)
	{
		if (oldValue != null)
		{
			oldValue.CollectionChanged -= OnSelectedItemsChanged;
		}
		if (newValue != null)
		{
			newValue.CollectionChanged += OnSelectedItemsChanged;
		}
		UpdateSelectedDataGridItems();
	}

	private void OnSelectedItemsChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		UpdateSelectedDataGridItems();
	}

	protected override void OnPreviewMouseRightButtonDown(MouseButtonEventArgs e)
	{
		e.Handled = true;
	}

	protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
	{
		if (!SelectOnMouseUp)
		{
			UpdateSelection(e);
		}
	}

	protected override void OnPreviewMouseLeftButtonUp(MouseButtonEventArgs e)
	{
		if (ShouldDeselectOnMouseUp(e))
		{
			DeselectAll();
			Focus();
		}
		else if (SelectOnMouseUp)
		{
			UpdateSelection(e);
		}
	}

	protected virtual bool ShouldDeselectOnMouseUp(MouseButtonEventArgs e)
	{
		return e.FindHitElement<I>(this) == null;
	}

	protected override void OnPreviewMouseRightButtonUp(MouseButtonEventArgs e)
	{
		object originalSource = e.OriginalSource;
		if (((DependencyObject)((originalSource is DependencyObject) ? originalSource : null))?.FindVisualParent<I>()?.DataContext is T val && SelectedDataGridItem != val)
		{
			ObservableCollection<T>? selectedDataGridItems = SelectedDataGridItems;
			if (selectedDataGridItems == null || !selectedDataGridItems.Contains(val))
			{
				SetSelection(new T[1] { val });
			}
		}
	}

	private void ItemContainerGenerator_StatusChanged(object? sender, EventArgs e)
	{
		if (base.ItemContainerGenerator.Status == GeneratorStatus.ContainersGenerated)
		{
			UpdateSelectedDataGridItems(scrollToSelectedItem: false);
		}
	}

	protected void SetSelection(IEnumerable<T> selectedItems)
	{
		_ignoreSelectionChanges = true;
		((DependencyObject)this).SetCurrentValue(SelectedDataGridItemProperty, (object)selectedItems.FirstOrDefault());
		SelectedDataGridItems?.Clear();
		SelectedDataGridItems?.AddRange(selectedItems.Where((T i) => i != null));
		_ignoreSelectionChanges = false;
		UpdateSelectedDataGridItems();
	}

	private void UpdateSelectedDataGridItems(bool scrollToSelectedItem = true)
	{
		if (_ignoreSelectionChanges)
		{
			return;
		}
		if (SelectedDataGridItems != null && SelectedDataGridItems.Count > 0 && SelectedDataGridItem != null && !SelectedDataGridItems.Contains(SelectedDataGridItem))
		{
			((DependencyObject)this).SetCurrentValue(SelectedDataGridItemProperty, (object)null);
		}
		foreach (object item in (IEnumerable)base.Items)
		{
			((I)(DataGridRow)(object)base.ItemContainerGenerator.ContainerFromItem(item))?.SetIsSelected(item == SelectedDataGridItem || (SelectedDataGridItems?.Contains(item) ?? false));
		}
		if (scrollToSelectedItem && SelectedDataGridItem != null)
		{
			ScrollIntoView(SelectedDataGridItem);
		}
	}

	private void UpdateSelection(MouseButtonEventArgs e)
	{
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		object originalSource = e.OriginalSource;
		if (((DependencyObject)((originalSource is DependencyObject) ? originalSource : null))?.FindVisualParent<I>()?.DataContext is T targetItem)
		{
			IEnumerable<T> selectedItems = Enumerable.Empty<T>();
			ObservableCollection<T>? selectedDataGridItems = SelectedDataGridItems;
			if (selectedDataGridItems != null && selectedDataGridItems.Any())
			{
				selectedItems = SelectedDataGridItems.ToArray();
			}
			else if (SelectedDataGridItem != null)
			{
				selectedItems = new T[1] { SelectedDataGridItem };
			}
			SetSelection(SelectionHelper<T>.FindSelectedItems(base.Items.Cast<T>(), selectedItems, targetItem, Keyboard.Modifiers).ToArray());
		}
	}

	protected void DeselectAll()
	{
		_ignoreSelectionChanges = true;
		((DependencyObject)this).SetCurrentValue(SelectedDataGridItemProperty, (object)null);
		SelectedDataGridItems?.Clear();
		_ignoreSelectionChanges = false;
		UpdateSelectedDataGridItems();
	}
}
