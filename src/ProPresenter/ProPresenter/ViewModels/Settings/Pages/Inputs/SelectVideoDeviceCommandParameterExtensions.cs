using System.Threading.Tasks;
using Pro.ssAPI.Devices;
using ProPresenter.UI.LiveVideo;

namespace ProPresenter.ViewModels.Settings.Pages.Inputs;

public static class SelectVideoDeviceCommandParameterExtensions
{
	public static async Task<bool> CanSelectVideoDeviceAsync(this SelectVideoDeviceCommandParameter? parameter, IAirCastPluginDownload airCastPluginDownload)
	{
		if ((object)parameter == null)
		{
			return false;
		}
		if (parameter.VideoInputDevice is IAirCastVideoInputDevice)
		{
			return await airCastPluginDownload.CheckAvailabilityAsync();
		}
		return true;
	}
}
