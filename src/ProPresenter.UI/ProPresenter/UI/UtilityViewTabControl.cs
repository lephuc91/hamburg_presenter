using System.Windows;
using System.Windows.Input;
using Pro.Common.Components;
using Pro.Common.Utility;
using Pro.UI.Controls;
using ProPresenter.DO;

namespace ProPresenter.UI;

public class UtilityViewTabControl : ReorderTabControl<UtilityViewType>
{
	protected override bool CanReorder => KeyboardHelper.IsModifierPressed((ModifierKeys)2);

	protected override IDragDropCollection<UtilityViewType>? SourceCollection => base.ItemsSource as IDragDropCollection<UtilityViewType>;

	protected override DependencyObject GetContainerForItemOverride()
	{
		DropTabItem dropTabItem = new DropTabItem();
		dropTabItem.AddDisallowDropTypes(typeof(UtilityViewType));
		return (DependencyObject)(object)dropTabItem;
	}
}
