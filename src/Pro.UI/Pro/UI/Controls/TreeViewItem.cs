using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.UI.Commands;
using Pro.UI.Utility;

namespace Pro.UI.Controls;

public class TreeViewItem<T> : System.Windows.Controls.TreeViewItem where T : TreeViewItem<T>, new()
{
	private bool _canChangeSelection;

	public static readonly DependencyProperty IsActiveProperty;

	public static readonly DependencyProperty RenameNextItemProperty;

	public bool IsActive
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsActiveProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsActiveProperty, (object)value);
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

	static TreeViewItem()
	{
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected O, but got Unknown
		IsActiveProperty = DependencyProperty.Register("IsActive", typeof(bool), typeof(TreeViewItem<T>));
		RenameNextItemProperty = DependencyProperty.Register("RenameNextItem", typeof(bool), typeof(TreeViewItem<T>));
		System.Windows.Controls.TreeViewItem.IsSelectedProperty.OverrideMetadata(typeof(TreeViewItem<T>), (PropertyMetadata)(object)new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, null, (CoerceValueCallback)delegate(DependencyObject d, object v)
		{
			T val = (T)(TreeViewItem<T>)(object)d;
			return (!val._canChangeSelection) ? ((object)val.IsSelected) : v;
		}));
	}

	public TreeViewItem()
	{
		base.Loaded += OnLoaded;
	}

	private void OnLoaded(object? sender, RoutedEventArgs e)
	{
		base.Loaded -= OnLoaded;
		if (RenameNextItem)
		{
			Focus();
			CommonApplicationCommands.Rename.Invoke();
			RenameNextItem = false;
		}
	}

	protected override DependencyObject GetContainerForItemOverride()
	{
		T val = new T();
		val.SetBinding(TreeViewItem<TreeViewItem>.RenameNextItemProperty, new Binding("RenameNextItem")
		{
			Source = this,
			Mode = BindingMode.TwoWay
		});
		return (DependencyObject)(object)val;
	}

	protected override bool IsItemItsOwnContainerOverride(object item)
	{
		return item is T;
	}

	protected override void OnKeyDown(KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Invalid comparison between Unknown and I4
		if (!e.Key.IsAnyOf((Key[])(object)new Key[2]
		{
			(Key)24,
			(Key)26
		}))
		{
			base.OnKeyDown(e);
		}
		if ((int)e.Key == 6)
		{
			CommonApplicationCommands.Rename.Invoke();
		}
	}

	internal void SetIsSelected(bool isSelected)
	{
		_canChangeSelection = true;
		((DependencyObject)this).SetCurrentValue(System.Windows.Controls.TreeViewItem.IsSelectedProperty, (object)isSelected);
		_canChangeSelection = false;
	}
}
public class TreeViewItem : TreeViewItem<TreeViewItem>
{
}
