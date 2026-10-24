using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace ProPresenter.UI.PresentationView;

public record HeaderContextMenuItem
{
	public object? Header { get; init; }

	public bool IsEnabled { get; init; } = true;

	public FontWeight FontWeight { get; init; } = FontWeights.Normal;

	public ICommand? Command { get; init; }

	public object? CommandParameter { get; init; }

	public bool IsCheckable { get; init; }

	public bool IsChecked { get; init; }

	public HeaderContextMenuItemType ItemType { get; init; }

	public List<HeaderContextMenuItem>? SubMenuItems { get; init; }
}
