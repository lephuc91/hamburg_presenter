using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using ProPresenter.UI.ViewModels.MediaLibrary;

namespace ProPresenter.UI.MediaLibrary;

public partial class MediaBinHeaderNavigator : UserControl, IComponentConnector
{
	private sealed class PathItemTemplateSelector : DataTemplateSelector
	{
		private readonly ResourceDictionary _resources;

		private readonly ItemsControl _owner;

		public PathItemTemplateSelector(ResourceDictionary resources, ItemsControl owner)
		{
			_resources = resources;
			_owner = owner;
		}

		public override DataTemplate? SelectTemplate(object item, DependencyObject container)
		{
			if (item is INavigationItem)
			{
				DataTemplate result = _resources[ItemButton] as DataTemplate;
				bool num = _owner.Items.IndexOf(item) == 0;
				bool flag = _owner.Items.Count == _owner.Items.IndexOf(item) + 1;
				if (num)
				{
					result = _resources[FirstItemButton] as DataTemplate;
				}
				if (flag)
				{
					result = _resources[LastItemButton] as DataTemplate;
				}
				return result;
			}
			return base.SelectTemplate(item, container);
		}
	}

	public static readonly ComponentResourceKey FirstItemButton = new ComponentResourceKey(typeof(MediaBinHeaderNavigator), "ProContentHeaderNavigator_FirstItemButton");

	public static readonly ComponentResourceKey LastItemButton = new ComponentResourceKey(typeof(MediaBinHeaderNavigator), "ProContentHeaderNavigator_LastItemButton");

	public static readonly ComponentResourceKey ItemButton = new ComponentResourceKey(typeof(MediaBinHeaderNavigator), "ProContentHeaderNavigator_ItemButton");

	public static readonly ComponentResourceKey MenuItemStyle = new ComponentResourceKey(typeof(MediaBinHeaderNavigator), "ProContentHeaderNavigator_MenuItemStyle");

	public MediaBinHeaderNavigator()
	{
		InitializeComponent();
		PathItemsControl.ItemTemplateSelector = new PathItemTemplateSelector(base.Resources, PathItemsControl);
	}

	private void Navigate_Click(object? sender, RoutedEventArgs e)
	{
		Focus();
	}
}
