using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Pro.UI.Commands;
using Pro.UI.Utility;

namespace Pro.UI.Controls;

public class ListBoxItem : System.Windows.Controls.ListBoxItem
{
	private bool _canChangeSelection;

	public static readonly DependencyProperty IsActiveProperty;

	public static readonly DependencyProperty FocusOnContextMenuCloseProperty;

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

	public bool FocusOnContextMenuClose
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(FocusOnContextMenuCloseProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FocusOnContextMenuCloseProperty, (object)value);
		}
	}

	static ListBoxItem()
	{
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected O, but got Unknown
		IsActiveProperty = DependencyProperty.Register("IsActive", typeof(bool), typeof(ListBoxItem));
		FocusOnContextMenuCloseProperty = DependencyProperty.Register("FocusOnContextMenuClose", typeof(bool), typeof(ListBoxItem), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));
		System.Windows.Controls.ListBoxItem.IsSelectedProperty.OverrideMetadata(typeof(ListBoxItem), (PropertyMetadata)(object)new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, null, (CoerceValueCallback)delegate(DependencyObject d, object v)
		{
			ListBoxItem listBoxItem = (ListBoxItem)(object)d;
			return (!listBoxItem._canChangeSelection) ? ((object)listBoxItem.IsSelected) : v;
		}));
	}

	internal void SetIsSelected(bool isSelected)
	{
		_canChangeSelection = true;
		base.IsSelected = isSelected;
		_canChangeSelection = false;
	}

	protected override void OnKeyDown(KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		if ((int)e.Key == 6)
		{
			CommonApplicationCommands.Rename.Invoke();
		}
	}

	protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
	{
		base.OnMouseLeftButtonDown(e);
		if (e.ClickCount % 2 == 0)
		{
			CommonApplicationCommands.SubmitCommand.Invoke();
		}
	}
}
