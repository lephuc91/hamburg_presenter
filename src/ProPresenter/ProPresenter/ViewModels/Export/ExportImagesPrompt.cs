using Pro.UI.Utility;
using ProPresenter.UI.Export;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.ViewModels.Export;

public class ExportImagesPrompt : IExportImagesPrompt
{
	private readonly IExportVM _exportVM;

	public ExportImagesPrompt(IExportVM exportVM)
	{
		_exportVM = exportVM;
	}

	public bool Confirm()
	{
		return new ExportImagesWindow().WithDataContext(_exportVM).ShowDialog() == true;
	}
}
