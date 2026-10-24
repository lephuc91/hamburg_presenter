using System.Windows.Input;

namespace ProPresenter.UI.ViewModels;

public interface IExportVM
{
	ICommand ExportToImagesCommand { get; }
}
