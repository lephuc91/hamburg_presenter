using System.Threading.Tasks;

namespace ProPresenter.ViewModels.Settings.Pages.Media;

public interface IMediaCleanupService
{
	Task CleanUpMediaFilesAsync();
}
