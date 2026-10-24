using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Threading;
using Pro.Common.Collections;
using Pro.Common.Mathematics;
using Pro.Common.Utility;
using Pro.UI.Commands;
using Pro.UI.Utility;

namespace Pro.UI.Controls;

public abstract class ListBoxBase<T, I> : ListBox where T : class where I : ListBoxItem, new()
{
	private bool _ignoreSelectionChanges;

	private bool _adornerAdded;

	private readonly ItemGroupAdorner _itemGroupAdorner;

	public static readonly DependencyProperty ActiveItemProperty = DependencyProperty.Register("ActiveItem", typeof(T), typeof(ListBoxBase<T, I>), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(ActiveItemChanged)));

	public static readonly DependencyProperty SelectedListItemProperty = DependencyProperty.Register("SelectedListItem", typeof(T), typeof(ListBoxBase<T, I>), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(SelectedListItemChanged)));

	public static readonly DependencyProperty SelectedListItemsProperty = DependencyProperty.Register("SelectedListItems", typeof(ObservableCollection<T>), typeof(ListBoxBase<T, I>), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(SelectedListItemsChanged)));

	public static readonly DependencyProperty SelectOnMouseUpProperty = DependencyProperty.Register("SelectOnMouseUp", typeof(bool), typeof(ListBoxBase<T, I>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public static readonly DependencyProperty DeselectOnLostFocusProperty = DependencyProperty.Register("DeselectOnLostFocus", typeof(bool), typeof(ListBoxBase<T, I>));

	public static readonly DependencyProperty RenameNextItemProperty = DependencyProperty.Register("RenameNextItem", typeof(bool), typeof(ListBoxBase<T, I>));

	public T? ActiveItem
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

	public T? SelectedListItem
	{
		get
		{
			return (T)((DependencyObject)this).GetValue(SelectedListItemProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedListItemProperty, (object)value);
		}
	}

	public ObservableCollection<T>? SelectedListItems
	{
		get
		{
			return (ObservableCollection<T>)((DependencyObject)this).GetValue(SelectedListItemsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedListItemsProperty, (object)value);
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
		((ListBoxBase<T, I>)(object)callerObject).OnActiveItemChanged(((DependencyPropertyChangedEventArgs)(ref e)).NewValue as T);
	}

	private static void SelectedListItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((ListBoxBase<T, I>)(object)d).UpdateSelectedItems();
	}

	private static void SelectedListItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((ListBoxBase<T, I>)(object)d).OnSelectedListItemsChanged(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as ObservableCollection<T>, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as ObservableCollection<T>);
	}

	protected ListBoxBase()
	{
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Expected O, but got Unknown
		base.InputBindings.Add(new KeyBinding(CommonApplicationCommands.SelectAllCommand, new KeyGesture((Key)44, (ModifierKeys)2)));
		base.CommandBindings.Add(CommonApplicationCommands.SelectAllCommand, delegate
		{
			SetSelection(base.Items.Cast<T>(), leftClick: false);
		}, () => base.HasItems);
		base.CommandBindings.Add(CommonApplicationCommands.DeselectAll, DeselectAll, () => SelectedListItems?.Any() ?? false);
		base.ItemContainerGenerator.StatusChanged += ItemContainerGenerator_StatusChanged;
		_itemGroupAdorner = new ItemGroupAdorner(this);
		base.ClipToBounds = true;
		base.Loaded += ListBoxBase_Loaded;
		base.IsVisibleChanged += new DependencyPropertyChangedEventHandler(ListBoxBase_IsVisibleChanged);
	}

	private void ListBoxBase_Loaded(object? sender, RoutedEventArgs e)
	{
		base.Loaded -= ListBoxBase_Loaded;
		if (!_adornerAdded)
		{
			_adornerAdded = this.AddAdorner(_itemGroupAdorner);
		}
	}

	private void ListBoxBase_IsVisibleChanged(object? sender, DependencyPropertyChangedEventArgs e)
	{
		if (base.IsVisible)
		{
			if (!_adornerAdded)
			{
				_adornerAdded = this.AddAdorner(_itemGroupAdorner);
				return;
			}
			Adorner[] obj = this.GetAdornerLayer()?.GetAdorners(this);
			if (obj == null || !obj.Contains(_itemGroupAdorner))
			{
				_adornerAdded = this.AddAdorner(_itemGroupAdorner);
			}
		}
		else
		{
			_itemGroupAdorner.Hide();
		}
	}

	protected override DependencyObject GetContainerForItemOverride()
	{
		I val = new I();
		val.ContextMenuOpening += Container_ContextMenuOpening;
		val.ContextMenuClosing += Container_ContextMenuClosing;
		return (DependencyObject)(object)val;
	}

	protected override bool IsItemItsOwnContainerOverride(object item)
	{
		return item is I;
	}

	protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
	{
		base.OnItemsChanged(e);
		_itemGroupAdorner.Hide();
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
			I val = (I)(ListBoxItem)(object)base.ItemContainerGenerator.ContainerFromItem(newItem);
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

	private void Container_ContextMenuOpening(object? sender, ContextMenuEventArgs e)
	{
		IEnumerable<IEnumerable<Rect<double>>> rects = from i in (from T i in base.Items
				select (I)(ListBoxItem)(object)base.ItemContainerGenerator.ContainerFromItem(i) into i
				where i?.ContextMenu != null
				select i).ContiguousGroups((I i) => i?.IsSelected ?? false)
			select from s in i
				select new Rect<double>((Vector2<double>)s.TranslatePoint(Vector2<double>.Zero, this), (Vector2<double>)s.RenderSize);
		_itemGroupAdorner.UpdateBounds(rects);
	}

	private void Container_ContextMenuClosing(object? sender, ContextMenuEventArgs e)
	{
		_itemGroupAdorner.Hide();
		Window window = Window.GetWindow((DependencyObject)(object)this);
		if (window != null)
		{
			FrameworkElement frameworkElement = (FrameworkElement)FocusManager.GetFocusedElement((DependencyObject)(object)window);
			if (sender is I val && val.FocusOnContextMenuClose && (frameworkElement == null || !((object)frameworkElement).GetType().IsInputRestricted()))
			{
				(sender as UIElement)?.Focus();
			}
		}
	}

	private void OnSelectedListItemsChanged(ObservableCollection<T>? oldCollection, ObservableCollection<T>? newCollection)
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
		if (!(e.OriginalSource is Thumb))
		{
			return e.FindHitElement<I>(this) == null;
		}
		return false;
	}

	protected override void OnPreviewLostKeyboardFocus(KeyboardFocusChangedEventArgs e)
	{
		if (DeselectOnLostFocus)
		{
			IInputElement newFocus = e.NewFocus;
			DependencyObject val = (DependencyObject)((newFocus is DependencyObject) ? newFocus : null);
			if (val != null && Window.GetWindow(val) == Window.GetWindow((DependencyObject)(object)this) && val.FindVisualParent<ListBoxBase<T, I>>() != this && ((DependencyObject)(object)this).FindVisualChildren<I>().None((I i) => i.ContextMenu?.IsOpen ?? false))
			{
				DeselectAll();
			}
		}
	}

	private void UpdateSelection(MouseButtonEventArgs e)
	{
		object originalSource = e.OriginalSource;
		if (((DependencyObject)((originalSource is DependencyObject) ? originalSource : null))?.FindVisualParent<I>()?.DataContext is T item && CanSelect(item, e))
		{
			OnUpdateSelection(item);
		}
	}

	protected virtual void OnUpdateSelection(T item)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		if ((int)Keyboard.Modifiers == 0)
		{
			((DependencyObject)this).SetCurrentValue(ActiveItemProperty, (object)item);
		}
		ObservableCollection<T>? selectedListItems = SelectedListItems;
		IEnumerable<T> enumerable;
		if (selectedListItems == null || !selectedListItems.Any())
		{
			enumerable = SelectedListItem.ToEnumerable();
		}
		else
		{
			IEnumerable<T> selectedListItems2 = SelectedListItems;
			enumerable = selectedListItems2;
		}
		IEnumerable<T> source = enumerable;
		SetSelection(SelectionHelper<T>.FindSelectedItems(base.Items.Cast<T>(), source.NonNull(), item, Keyboard.Modifiers).ToArray(), leftClick: true);
	}

	protected virtual bool CanSelect(T item, MouseButtonEventArgs? e)
	{
		return true;
	}

	protected override void OnPreviewMouseRightButtonDown(MouseButtonEventArgs e)
	{
		e.Handled = true;
	}

	protected override void OnPreviewMouseRightButtonUp(MouseButtonEventArgs e)
	{
		object originalSource = e.OriginalSource;
		if (((DependencyObject)((originalSource is DependencyObject) ? originalSource : null))?.FindVisualParent<I>()?.DataContext is T val && SelectedListItem != val)
		{
			ObservableCollection<T>? selectedListItems = SelectedListItems;
			if (selectedListItems == null || !selectedListItems.Contains(val))
			{
				SetSelection(new T[1] { val }, leftClick: false);
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

	protected override void OnKeyDown(KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		Key key = e.Key;
		Key[] array = new Key[3];
		RuntimeHelpers.InitializeArray(array, (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/);
		if (!key.IsAnyOf((Key[])(object)array))
		{
			base.OnKeyDown(e);
		}
	}

	private void Navigate(bool isDown)
	{
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		IEnumerable<T> enumerable = from T i in base.Items
			where CanSelect(i, null)
			select i;
		IEnumerable<T> selectedListItems = SelectedListItems;
		IEnumerable<T> source = selectedListItems ?? (SelectedListItem ?? ActiveItem).ToEnumerable();
		T[] array = SelectionHelper<T>.FindSelectedItems(enumerable, source.NonNull(), isDown, Keyboard.Modifiers).ToArray();
		T item;
		if (array.Any() && (int)Keyboard.Modifiers == 0)
		{
			item = array[0];
			((DispatcherObject)this).Dispatcher.BeginInvoke((DispatcherPriority)4, (Delegate)new Action(focusAction));
			((DependencyObject)this).SetCurrentValue(ActiveItemProperty, (object)item);
			if ((item == source.First() && item == enumerable.First()) || (item == source.Last() && item == enumerable.Last()))
			{
				this.NavigationCrested?.Invoke(isDown);
				return;
			}
		}
		SetSelection(array, leftClick: false);
		void focusAction()
		{
			((I)(ListBoxItem)(object)base.ItemContainerGenerator.ContainerFromItem(item))?.Focus();
		}
	}

	protected virtual void SetSelection(IEnumerable<T> selectedItems, bool leftClick)
	{
		_ignoreSelectionChanges = true;
		((DependencyObject)this).SetCurrentValue(SelectedListItemProperty, (object)selectedItems.FirstOrDefault());
		SelectedListItems?.Clear();
		SelectedListItems?.AddRange(selectedItems.Where((T i) => i != null));
		_ignoreSelectionChanges = false;
		UpdateSelectedItems();
	}

	private void ItemContainerGenerator_StatusChanged(object? sender, EventArgs e)
	{
		if (base.ItemContainerGenerator.Status == GeneratorStatus.ContainersGenerated)
		{
			UpdateActiveItem();
			UpdateSelectedItems(scrollToSelectedItem: false);
		}
	}

	protected virtual void OnActiveItemChanged(T? activeItem)
	{
		UpdateActiveItem();
		((DispatcherObject)this).Dispatcher.InvokeAsync((Action)delegate
		{
			ScrollIntoView(activeItem);
		});
	}

	private void UpdateActiveItem()
	{
		foreach (object item in (IEnumerable)base.Items)
		{
			I val = (I)(ListBoxItem)(object)base.ItemContainerGenerator.ContainerFromItem(item);
			if (val != null)
			{
				val.IsActive = item == ActiveItem;
			}
		}
	}

	private void DeselectAll()
	{
		_ignoreSelectionChanges = true;
		((DependencyObject)this).SetCurrentValue(SelectedListItemProperty, (object)null);
		SelectedListItems?.Clear();
		_ignoreSelectionChanges = false;
		UpdateSelectedItems();
	}

	private void UpdateSelectedItems(bool scrollToSelectedItem = true)
	{
		_itemGroupAdorner.Hide();
		if (_ignoreSelectionChanges)
		{
			return;
		}
		if (SelectedListItems != null && SelectedListItem != null && !SelectedListItems.Contains(SelectedListItem))
		{
			((DependencyObject)this).SetCurrentValue(SelectedListItemProperty, (object)null);
		}
		foreach (object item in (IEnumerable)base.Items)
		{
			if (item != null)
			{
				I val = (I)(ListBoxItem)(object)base.ItemContainerGenerator.ContainerFromItem(item);
				if (val != null && !(val is Separator))
				{
					val.SetIsSelected(item == SelectedListItem || (SelectedListItems?.Contains(item) ?? false));
				}
			}
		}
		if (scrollToSelectedItem)
		{
			ScrollIntoView(SelectedListItem);
		}
	}
}
