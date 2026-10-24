using System.Diagnostics.CodeAnalysis;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.OutputConfiguration;

namespace ProPresenter.UI.OutputConfiguration;

internal static class CustomSizeHelper
{
	internal static bool TrySetCustomSize(IDeviceMode? defaultMode, [NotNullWhen(true)] out DeviceMode? mode)
	{
		mode = null;
		CustomNDIDialog customNDIDialog = new CustomNDIDialog(defaultMode);
		if (customNDIDialog.ShowDialog() == true)
		{
			DisplayMode displayMode = new DisplayMode
			{
				Height = (uint)customNDIDialog.DeviceModeHeight,
				Width = (uint)customNDIDialog.DeviceModeWidth,
				RefreshRate = customNDIDialog.DeviceModeFrameRate,
				Interlaced = customNDIDialog.IsInterlaced
			};
			displayMode.Name = DeviceMode.GenerateNDIModeName(displayMode);
			mode = new CustomDeviceMode(displayMode);
			return true;
		}
		return false;
	}
}
