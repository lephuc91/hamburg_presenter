using Pro.Localization;
using Pro.UI.Controls;
using ProPresenter.DO.OutputConfiguration;

namespace ProPresenter.UI.OutputConfiguration;

public class DynamicPlaceHolderDeviceMode : DynamicPlaceHolderBase<PlaceholderDeviceMode>
{
	public DynamicPlaceHolderDeviceMode()
	{
		base.DisplayMember = LocalizedStrings.Get("SCREEN_CONFIGURATION_HARDWARE_TAB_DEVICE_MENU_PLACEHOLDER_CUSTOM_SIZE_title");
	}

	protected override void OnDisplayValueChanged(PlaceholderDeviceMode oldValue, PlaceholderDeviceMode newValue)
	{
		base.DisplayMember = ((newValue == null) ? LocalizedStrings.Get("SCREEN_CONFIGURATION_HARDWARE_TAB_DEVICE_MENU_PLACEHOLDER_CUSTOM_SIZE_title") : (base.DisplayValue?.Name ?? string.Empty));
	}
}
