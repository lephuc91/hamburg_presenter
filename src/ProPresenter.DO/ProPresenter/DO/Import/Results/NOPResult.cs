using Pro.Common.Dispatcher;

namespace ProPresenter.DO.Import.Results;

public class NOPResult : IImportResult
{
	public string GetTargetFilename(IImportRequest request)
	{
		return string.Empty;
	}

	public void CompleteImport(IImportProcess process, IImportRequest request, string name, bool overwrite, IUiDispatcher dispatcher, string containerId)
	{
	}
}
