using System.Threading.Tasks;

namespace ProPresenter.ViewModels.Settings.Pages.Inputs;

public interface IAirCastPluginDownload
{
	Task<bool> CheckAvailabilityAsync();
}
