using Pro.Localization;
using Pro.UI.Controls;
using ProPresenter.DO.OutputConfiguration;

namespace ProPresenter.UI.OutputConfiguration;

public class DynamicDeviceMode : DynamicPlaceHolderBase<DeviceModeBase>
{
	public DynamicDeviceMode()
	{
		base.DisplayMember = LocalizedStrings.Get("SCREEN_CONFIGURATION_HARDWARE_TAB_DEVICE_MENU_PLACEHOLDER_CUSTOM_SIZE_title");
	}

	protected override void OnDisplayValueChanged(DeviceModeBase oldValue, DeviceModeBase newValue)
	{
		base.DisplayMember = ((newValue == null) ? LocalizedStrings.Get("SCREEN_CONFIGURATION_HARDWARE_TAB_DEVICE_MENU_PLACEHOLDER_CUSTOM_SIZE_title") : (base.DisplayValue?.Name ?? string.Empty));
	}
}
