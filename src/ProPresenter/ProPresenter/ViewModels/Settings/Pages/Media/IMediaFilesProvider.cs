using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProPresenter.ViewModels.Settings.Pages.Media;

public interface IMediaFilesProvider
{
	Task<IEnumerable<string>> GetUnlinkedMediaFilesAsync();
}
