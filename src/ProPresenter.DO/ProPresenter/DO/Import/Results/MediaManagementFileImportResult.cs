using System;
using Pro.Common.Dispatcher;
using ProPresenter.DO.Media;

namespace ProPresenter.DO.Import.Results;

public sealed class MediaManagementFileImportResult(FileMediaBase? createdMedia) : IImportResult
{
	public FileMediaBase? CreatedMedia => createdMedia;

	public void CompleteImport(IImportProcess process, IImportRequest request, string name, bool overwrite, IUiDispatcher dispatcher, string containerId)
	{
		throw new NotImplementedException();
	}

	public string GetTargetFilename(IImportRequest request)
	{
		throw new NotImplementedException();
	}
}
