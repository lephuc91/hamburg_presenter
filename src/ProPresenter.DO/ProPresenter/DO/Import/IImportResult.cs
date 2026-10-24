using Pro.Common.Dispatcher;

namespace ProPresenter.DO.Import;

public interface IImportResult
{
	string GetTargetFilename(IImportRequest request);

	void CompleteImport(IImportProcess process, IImportRequest request, string name, bool overwrite, IUiDispatcher dispatcher, string containerId);
}
