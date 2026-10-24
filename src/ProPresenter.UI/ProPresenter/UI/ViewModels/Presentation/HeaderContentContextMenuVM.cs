using System.Collections.Generic;
using System.Windows;
using Pro.Common.Components;
using Pro.Common.Mathematics;
using Pro.Localization.Services;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.UI.PresentationView;

namespace ProPresenter.UI.ViewModels.Presentation;

public class HeaderContentContextMenuVM : NotifyPropertyChangedBase, IHeaderContentContextMenuVM
{
	private readonly ILocalization _localization;

	public List<HeaderContextMenuItem> MenuItems { get; } = new List<HeaderContextMenuItem>();

	public HeaderContentContextMenuVM(ILocalization localization)
	{
		_localization = localization;
	}

	public void BuildMenuItems(IPresentationHeaderVM viewModel)
	{
		MenuItems.Clear();
		bool flag = !viewModel.SizeIsConfigured;
		bool hasMissingFonts = viewModel.HasMissingFonts;
		if (flag && !hasMissingFonts)
		{
			AddSizeSelectorItems(viewModel);
		}
		else if (!flag && hasMissingFonts)
		{
			AddMissingFontItems(viewModel);
		}
		else if (flag && hasMissingFonts)
		{
			AddCombinedItems(viewModel);
		}
		OnPropertyChanged("MenuItems");
	}

	private void AddSizeSelectorItems(IPresentationHeaderVM viewModel)
	{
		ISizeSelectorVM sizeSelector = viewModel.SizeSelector;
		MenuItems.Add(new HeaderContextMenuItem
		{
			Header = _localization.Get("EDITOR_PRESENTATION_PRESENTATION_INSPECTOR_SCREEN_SIZE_placeholder"),
			IsEnabled = false,
			FontWeight = FontWeights.Bold,
			ItemType = HeaderContextMenuItemType.Header
		});
		foreach (ScreenArrangementBase targetScreen in sizeSelector.TargetScreens)
		{
			MenuItems.Add(new HeaderContextMenuItem
			{
				Header = FormatScreenResolution(targetScreen),
				Command = sizeSelector.SelectSizeCommand,
				CommandParameter = targetScreen.TotalSize,
				IsCheckable = true,
				IsChecked = targetScreen.TotalSize.Equals(sizeSelector.SelectedSize),
				ItemType = HeaderContextMenuItemType.TargetScreen
			});
		}
		MenuItems.Add(new HeaderContextMenuItem
		{
			ItemType = HeaderContextMenuItemType.Separator
		});
		MenuItems.Add(new HeaderContextMenuItem
		{
			Header = _localization.Get("EDITOR_PRESENTATION_PRESENTATION_INSPECTOR_COMMON_SCREEN_SIZES_HEADER_label"),
			IsEnabled = false,
			FontWeight = FontWeights.Bold,
			ItemType = HeaderContextMenuItemType.Header
		});
		foreach (Vector2<double> commonSize in sizeSelector.CommonSizes)
		{
			MenuItems.Add(new HeaderContextMenuItem
			{
				Header = FormatResolution(commonSize),
				Command = sizeSelector.SelectSizeCommand,
				CommandParameter = commonSize,
				IsCheckable = true,
				IsChecked = commonSize.Equals(sizeSelector.SelectedSize),
				ItemType = HeaderContextMenuItemType.CommonSize
			});
		}
		MenuItems.Add(new HeaderContextMenuItem
		{
			ItemType = HeaderContextMenuItemType.Separator
		});
		MenuItems.Add(new HeaderContextMenuItem
		{
			Header = _localization.Get("PRESENTATION_HEADER_RESIZE_title"),
			Command = sizeSelector.CustomSizeCommand,
			ItemType = HeaderContextMenuItemType.CustomSize
		});
		if (sizeSelector.CustomSize.HasValue)
		{
			MenuItems.Add(new HeaderContextMenuItem
			{
				Header = FormatResolution(sizeSelector.CustomSize.Value),
				Command = sizeSelector.SelectSizeCommand,
				CommandParameter = sizeSelector.CustomSize.Value,
				IsCheckable = true,
				IsChecked = sizeSelector.CustomSize.Value.Equals(sizeSelector.SelectedSize),
				ItemType = HeaderContextMenuItemType.CustomSizeValue
			});
		}
	}

	private void AddMissingFontItems(IPresentationHeaderVM viewModel)
	{
		MenuItems.Add(new HeaderContextMenuItem
		{
			Header = _localization.Get("ISSUE_RESOLVER_FONTS_title"),
			Command = viewModel.ResolveMissingFontsCommand,
			ItemType = HeaderContextMenuItemType.ResolveFonts
		});
	}

	private void AddCombinedItems(IPresentationHeaderVM viewModel)
	{
		HeaderContextMenuItem item = new HeaderContextMenuItem
		{
			Header = _localization.Get("PRESENTATION_HEADER_RESIZE_title"),
			ItemType = HeaderContextMenuItemType.ResizeSubmenu,
			SubMenuItems = CreateSizeSelectorSubMenuItems(viewModel)
		};
		MenuItems.Add(item);
		MenuItems.Add(new HeaderContextMenuItem
		{
			ItemType = HeaderContextMenuItemType.Separator
		});
		MenuItems.Add(new HeaderContextMenuItem
		{
			Header = _localization.Get("ISSUE_RESOLVER_FONTS_title"),
			Command = viewModel.ResolveMissingFontsCommand,
			ItemType = HeaderContextMenuItemType.ResolveFonts
		});
	}

	private List<HeaderContextMenuItem> CreateSizeSelectorSubMenuItems(IPresentationHeaderVM viewModel)
	{
		List<HeaderContextMenuItem> list = new List<HeaderContextMenuItem>();
		ISizeSelectorVM sizeSelector = viewModel.SizeSelector;
		list.Add(new HeaderContextMenuItem
		{
			Header = _localization.Get("EDITOR_PRESENTATION_PRESENTATION_INSPECTOR_SCREEN_SIZE_placeholder"),
			IsEnabled = false,
			FontWeight = FontWeights.Bold,
			ItemType = HeaderContextMenuItemType.Header
		});
		foreach (ScreenArrangementBase targetScreen in sizeSelector.TargetScreens)
		{
			list.Add(new HeaderContextMenuItem
			{
				Header = FormatScreenResolution(targetScreen),
				Command = sizeSelector.SelectSizeCommand,
				CommandParameter = targetScreen.TotalSize,
				IsCheckable = true,
				IsChecked = targetScreen.TotalSize.Equals(sizeSelector.SelectedSize),
				ItemType = HeaderContextMenuItemType.TargetScreen
			});
		}
		list.Add(new HeaderContextMenuItem
		{
			ItemType = HeaderContextMenuItemType.Separator
		});
		list.Add(new HeaderContextMenuItem
		{
			Header = _localization.Get("EDITOR_PRESENTATION_PRESENTATION_INSPECTOR_COMMON_SCREEN_SIZES_HEADER_label"),
			IsEnabled = false,
			FontWeight = FontWeights.Bold,
			ItemType = HeaderContextMenuItemType.Header
		});
		foreach (Vector2<double> commonSize in sizeSelector.CommonSizes)
		{
			list.Add(new HeaderContextMenuItem
			{
				Header = FormatResolution(commonSize),
				Command = sizeSelector.SelectSizeCommand,
				CommandParameter = commonSize,
				IsCheckable = true,
				IsChecked = commonSize.Equals(sizeSelector.SelectedSize),
				ItemType = HeaderContextMenuItemType.CommonSize
			});
		}
		list.Add(new HeaderContextMenuItem
		{
			ItemType = HeaderContextMenuItemType.Separator
		});
		list.Add(new HeaderContextMenuItem
		{
			Header = _localization.Get("PRESENTATION_HEADER_RESIZE_title"),
			Command = sizeSelector.CustomSizeCommand,
			ItemType = HeaderContextMenuItemType.CustomSize
		});
		if (sizeSelector.CustomSize.HasValue)
		{
			list.Add(new HeaderContextMenuItem
			{
				Header = FormatResolution(sizeSelector.CustomSize.Value),
				Command = sizeSelector.SelectSizeCommand,
				CommandParameter = sizeSelector.CustomSize.Value,
				IsCheckable = true,
				IsChecked = sizeSelector.CustomSize.Value.Equals(sizeSelector.SelectedSize),
				ItemType = HeaderContextMenuItemType.CustomSizeValue
			});
		}
		return list;
	}

	private static string FormatScreenResolution(ScreenArrangementBase screen)
	{
		string value = screen.Name ?? "";
		Vector2<double> totalSize = screen.TotalSize;
		return $"{value}: {(int)totalSize.X} x {(int)totalSize.Y}";
	}

	private static string FormatResolution(Vector2<double> size)
	{
		return $"{(int)size.X} x {(int)size.Y}";
	}
}
