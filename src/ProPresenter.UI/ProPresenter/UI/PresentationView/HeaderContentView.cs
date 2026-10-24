using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using ProPresenter.UI.ViewModels;
using ProPresenter.UI.ViewModels.Presentation;

namespace ProPresenter.UI.PresentationView;

public partial class HeaderContentView : UserControl, IComponentConnector
{
	private readonly IHeaderContentContextMenuVM _contextMenuVM;

	public static readonly DependencyProperty ShowIconProperty = DependencyProperty.Register("ShowIcon", typeof(bool), typeof(HeaderContentView), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public static readonly DependencyProperty AdditionalContentProperty = DependencyProperty.Register("AdditionalContent", typeof(DataTemplate), typeof(HeaderContentView));

	public bool ShowIcon
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowIconProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowIconProperty, (object)value);
		}
	}

	public DataTemplate AdditionalContent
	{
		get
		{
			return (DataTemplate)((DependencyObject)this).GetValue(AdditionalContentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AdditionalContentProperty, (object)value);
		}
	}

	public HeaderContentView(IHeaderContentContextMenuVM headerContentContextMenuVm)
	{
		_contextMenuVM = headerContentContextMenuVm;
		InitializeComponent();
	}

	private void WarningContextMenu_Opened(object? sender, RoutedEventArgs e)
	{
		if (sender is ContextMenu contextMenu && base.DataContext is IPresentationHeaderVM viewModel)
		{
			_contextMenuVM.BuildMenuItems(viewModel);
			contextMenu.Items.Clear();
			BuildContextMenuFromViewModel(contextMenu, _contextMenuVM.MenuItems);
			contextMenu.Items.Refresh();
		}
	}

	private void BuildContextMenuFromViewModel(ItemsControl parentMenu, List<HeaderContextMenuItem> menuItems)
	{
		foreach (HeaderContextMenuItem menuItem in menuItems)
		{
			Control newItem = CreateMenuItemFromViewModel(menuItem);
			parentMenu.Items.Add(newItem);
		}
	}

	private Control CreateMenuItemFromViewModel(HeaderContextMenuItem item)
	{
		if (item.ItemType == HeaderContextMenuItemType.Separator)
		{
			return new Separator();
		}
		MenuItem menuItem = new MenuItem
		{
			Header = item.Header,
			IsEnabled = item.IsEnabled,
			FontWeight = item.FontWeight,
			Command = item.Command,
			CommandParameter = item.CommandParameter,
			IsCheckable = item.IsCheckable,
			IsChecked = item.IsChecked
		};
		List<HeaderContextMenuItem>? subMenuItems = item.SubMenuItems;
		if (subMenuItems != null && subMenuItems.Count == 0)
		{
			return menuItem;
		}
		if (item.SubMenuItems == null)
		{
			return menuItem;
		}
		foreach (HeaderContextMenuItem subMenuItem in item.SubMenuItems)
		{
			Control newItem = CreateMenuItemFromViewModel(subMenuItem);
			menuItem.Items.Add(newItem);
		}
		return menuItem;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
