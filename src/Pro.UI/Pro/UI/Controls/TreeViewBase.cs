using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;
using Pro.Common.Collections;
using Pro.Common.Mathematics;
using Pro.Common.Utility;
using Pro.UI.Commands;
using Pro.UI.Utility;

namespace Pro.UI.Controls;

public abstract class TreeViewBase<T, I> : TreeView where T : class where I : TreeViewItem<I>, new()
{
	private bool _ignoreSelectionChanges;

	private readonly ItemGroupAdorner _itemGroupAdorner;

	public static readonly DependencyProperty ActiveItemProperty = DependencyProperty.Register("ActiveItem", typeof(T), typeof(TreeViewBase<T, I>), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(ActiveItemChanged)));

	public static readonly DependencyProperty SelectedTreeItemProperty = DependencyProperty.Register("SelectedTreeItem", typeof(T), typeof(TreeViewBase<T, I>), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(SelectedTreeItemChanged)));

	public static readonly DependencyProperty SelectedTreeItemsProperty = DependencyProperty.Register("SelectedTreeItems", typeof(ObservableCollection<T>), typeof(TreeViewBase<T, I>), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(SelectedTreeItemsChanged)));

	public static readonly DependencyProperty SelectOnMouseUpProperty = DependencyProperty.Register("SelectOnMouseUp", typeof(bool), typeof(TreeViewBase<T, I>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public static readonly DependencyProperty DeselectOnLostFocusProperty = DependencyProperty.Register("DeselectOnLostFocus", typeof(bool), typeof(TreeViewBase<T, I>));

	public static readonly DependencyProperty RenameNextItemProperty = DependencyProperty.Register("RenameNextItem", typeof(bool), typeof(TreeViewBase<T, I>));

	public T ActiveItem
	{
		get
		{
			return (T)((DependencyObject)this).GetValue(ActiveItemProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ActiveItemProperty, (object)value);
		}
	}

	public T SelectedTreeItem
	{
		get
		{
			return (T)((DependencyObject)this).GetValue(SelectedTreeItemProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedTreeItemProperty, (object)value);
		}
	}

	public ObservableCollection<T>? SelectedTreeItems
	{
		get
		{
			return (ObservableCollection<T>)((DependencyObject)this).GetValue(SelectedTreeItemsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedTreeItemsProperty, (object)value);
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

	public event Action<bool>? NavigationCrested;

	private static void ActiveItemChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		((TreeViewBase<T, I>)(object)callerObject).OnActiveItemChanged(((DependencyPropertyChangedEventArgs)(ref e)).NewValue as T);
	}

	private static void SelectedTreeItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((TreeViewBase<T, I>)(object)d).UpdateSelectedItems();
	}

	private static void SelectedTreeItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((TreeViewBase<T, I>)(object)d).OnSelectedTreeItemsChanged(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as ObservableCollection<T>, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as ObservableCollection<T>);
	}

	protected TreeViewBase()
	{
		base.CommandBindings.Add(CommonApplicationCommands.SelectAllCommand, SelectAll, () => base.HasItems);
		base.CommandBindings.Add(CommonApplicationCommands.DeselectAll, DeselectAll, () => SelectedTreeItems?.Any() ?? false);
		_itemGroupAdorner = new ItemGroupAdorner(this);
		base.ClipToBounds = true;
		base.Loaded += TreeViewBase_Loaded;
	}

	private void TreeViewBase_Loaded(object? sender, RoutedEventArgs e)
	{
		base.Loaded -= TreeViewBase_Loaded;
		this.AddAdorner(_itemGroupAdorner);
	}

	protected abstract IEnumerable<T> FlattenItemSource();

	protected override DependencyObject GetContainerForItemOverride()
	{
		I val = new I();
		val.ContextMenuOpening += Container_ContextMenuOpening;
		val.ContextMenuClosing += Container_ContextMenuClosing;
		val.SetBinding(TreeViewItem<TreeViewItem>.RenameNextItemProperty, new Binding("RenameNextItem")
		{
			Source = this,
			Mode = BindingMode.TwoWay
		});
		return (DependencyObject)(object)val;
	}

	private I? FindChild(T? item)
	{
		return ((DependencyObject)(object)this).FindVisualChild((I c) => (T)c.DataContext == item);
	}

	protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
	{
		base.OnItemsChanged(e);
		_itemGroupAdorner.Hide();
		if (!base.IsLoaded || !RenameNextItem)
		{
			return;
		}
		IList? newItems = e.NewItems;
		T val = ((newItems != null) ? newItems.Cast<T>().FirstOrDefault() : null);
		I item;
		if (val != null)
		{
			item = FindChild(val);
			if (item != null)
			{
				item.Loaded += rename;
			}
		}
		void rename(object? sender, RoutedEventArgs _)
		{
			item.Loaded -= rename;
			item.Focus();
			CommonApplicationCommands.Rename.Invoke();
			RenameNextItem = false;
		}
	}

	private void Container_ContextMenuOpening(object? sender, ContextMenuEventArgs e)
	{
		((DispatcherObject)this).Dispatcher.InvokeAsync((Action)delegate
		{
			IEnumerable<IEnumerable<Rect<double>>> rects = from i in ((DependencyObject)(object)this).FindVisualChildren<I>().ContiguousGroups((I i) => i.IsSelected)
				select i.Select(getContainerBounds);
			_itemGroupAdorner.UpdateBounds(rects);
		});
		Rect<double> getContainerBounds(I i)
		{
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			Border border = ((DependencyObject)(object)i).FindVisualChild((Border p) => p.Name == "Bd");
			if (border == null)
			{
				return Rect<double>.Empty;
			}
			return new Rect<double>((Vector2<double>)border.TranslatePoint(Vector2<double>.Zero, this), new Vector2<double>(border.ActualWidth, border.ActualHeight));
		}
	}

	private void Container_ContextMenuClosing(object? sender, ContextMenuEventArgs e)
	{
		_itemGroupAdorner.Hide();
		FrameworkElement obj = (FrameworkElement)FocusManager.GetFocusedElement((DependencyObject)(object)Application.Current.MainWindow);
		if (obj == null || !((object)obj).GetType().IsInputRestricted())
		{
			(sender as UIElement)?.Focus();
		}
	}

	protected override bool IsItemItsOwnContainerOverride(object item)
	{
		return item is I;
	}

	private void SelectAll()
	{
		SetSelection(FlattenItemSource());
	}

	protected void DeselectAll()
	{
		_ignoreSelectionChanges = true;
		((DependencyObject)this).SetCurrentValue(SelectedTreeItemProperty, (object)null);
		SelectedTreeItems?.Clear();
		_ignoreSelectionChanges = false;
		UpdateSelectedItems();
	}

	private void UpdateSelectedItems()
	{
		_itemGroupAdorner.Hide();
		if (_ignoreSelectionChanges)
		{
			return;
		}
		if (SelectedTreeItems != null && !SelectedTreeItems.Contains(SelectedTreeItem))
		{
			((DependencyObject)this).SetCurrentValue(SelectedTreeItemProperty, (object)null);
		}
		((DispatcherObject)this).Dispatcher.InvokeAsync((Action)delegate
		{
			foreach (I item in ((DependencyObject)(object)this).FindVisualChildren<I>())
			{
				T val = (T)item.DataContext;
				item.SetIsSelected(val == SelectedTreeItem || (SelectedTreeItems?.Contains(val) ?? false));
				if (item.HasItems && item.IsSelected)
				{
					item.BringIntoView();
				}
			}
		});
	}

	private void OnSelectedTreeItemsChanged(ObservableCollection<T>? oldCollection, ObservableCollection<T>? newCollection)
	{
		if (oldCollection != null)
		{
			oldCollection.CollectionChanged -= OnSelectedItemsChanged;
		}
		if (newCollection != null)
		{
			newCollection.CollectionChanged += OnSelectedItemsChanged;
		}
		UpdateSelectedItems();
	}

	private void OnSelectedItemsChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		UpdateSelectedItems();
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
		if (e.FindHitElement<I>(this) == null)
		{
			DeselectAll();
			Focus();
		}
		else if (SelectOnMouseUp)
		{
			UpdateSelection(e);
		}
	}

	protected override void OnPreviewLostKeyboardFocus(KeyboardFocusChangedEventArgs e)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		if (DeselectOnLostFocus && e.NewFocus != null && Window.GetWindow((DependencyObject)e.NewFocus) == Window.GetWindow((DependencyObject)(object)this) && ((DependencyObject)(object)this).FindVisualChildren<I>().None((I i) => i == e.NewFocus || (i.ContextMenu?.IsOpen ?? false)))
		{
			DeselectAll();
		}
	}

	private void UpdateSelection(MouseButtonEventArgs e)
	{
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		if (((DependencyObject)(object)(e.OriginalSource as FrameworkElement))?.FindVisualParent<I>()?.DataContext is T val)
		{
			if ((int)Keyboard.Modifiers == 0)
			{
				((DependencyObject)this).SetCurrentValue(ActiveItemProperty, (object)val);
			}
			IEnumerable<T> sourceCollection = FlattenItemSource();
			ObservableCollection<T>? selectedTreeItems = SelectedTreeItems;
			SetSelection(SelectionHelper<T>.FindSelectedItems(sourceCollection, (selectedTreeItems != null && selectedTreeItems.Any()) ? ((IEnumerable<T>)SelectedTreeItems.ToArray()) : ((IEnumerable<T>)new T[1] { SelectedTreeItem ?? ActiveItem }), val, Keyboard.Modifiers).ToArray());
		}
	}

	protected override void OnPreviewMouseRightButtonDown(MouseButtonEventArgs e)
	{
		e.Handled = true;
	}

	protected override void OnPreviewMouseRightButtonUp(MouseButtonEventArgs e)
	{
		object originalSource = e.OriginalSource;
		if (((DependencyObject)((originalSource is DependencyObject) ? originalSource : null))?.FindVisualParent<I>()?.DataContext is T val && SelectedTreeItem != val)
		{
			ObservableCollection<T>? selectedTreeItems = SelectedTreeItems;
			if (selectedTreeItems == null || !selectedTreeItems.Contains(val))
			{
				SetSelection(new T[1] { val });
			}
		}
	}

	protected override void OnPreviewKeyDown(KeyEventArgs e)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Invalid comparison between Unknown and I4
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Invalid comparison between Unknown and I4
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Invalid comparison between Unknown and I4
		if (!e.Handled && ((int)e.Key == 26 || (int)e.Key == 24))
		{
			Navigate((int)e.Key == 26);
			e.Handled = true;
		}
	}

	private void Navigate(bool isDown)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		IEnumerable<T> enumerable = FlattenItemSource();
		ObservableCollection<T>? selectedTreeItems = SelectedTreeItems;
		T[] currentSelection = ((selectedTreeItems != null && selectedTreeItems.Any()) ? SelectedTreeItems.ToArray() : new T[1] { SelectedTreeItem ?? ActiveItem });
		T[] array = SelectionHelper<T>.FindSelectedItems(enumerable, currentSelection.OrderBy((T i) => currentSelection.IndexOf(i)), isDown, Keyboard.Modifiers).ToArray();
		if (array.Any() && (int)Keyboard.Modifiers == 0)
		{
			T val = array[0];
			((DependencyObject)this).SetCurrentValue(ActiveItemProperty, (object)val);
			FindChild(val)?.Focus();
			if ((val == currentSelection.First() && val == enumerable.First()) || (val == currentSelection.Last() && val == enumerable.Last()))
			{
				this.NavigationCrested?.Invoke(isDown);
				return;
			}
		}
		SetSelection(array);
	}

	private void OnActiveItemChanged(T? activeItem)
	{
		UpdateActiveItem();
		((DispatcherObject)this).Dispatcher.InvokeAsync((Action)delegate
		{
			FindChild(activeItem)?.BringIntoView();
		});
	}

	private void UpdateActiveItem()
	{
		((DispatcherObject)this).Dispatcher.InvokeAsync((Action)delegate
		{
			((DependencyObject)(object)this).FindVisualChildren<I>().ForEach(delegate(I c)
			{
				c.IsActive = (T)c.DataContext == ActiveItem;
			});
		});
	}

	protected void SetSelection(IEnumerable<T?>? selectedItems)
	{
		_ignoreSelectionChanges = true;
		((DependencyObject)this).SetCurrentValue(SelectedTreeItemProperty, (object)((selectedItems != null) ? selectedItems.FirstOrDefault() : null));
		SelectedTreeItems?.Clear();
		SelectedTreeItems?.AddRange(selectedItems?.NotNull() ?? Enumerable.Empty<T>());
		_ignoreSelectionChanges = false;
		UpdateSelectedItems();
	}
}
