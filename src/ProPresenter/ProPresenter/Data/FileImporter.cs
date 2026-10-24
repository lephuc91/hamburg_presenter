using System;
using Pro.Common.Logging;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.Data;

public abstract class FileImporter
{
	private readonly Func<IMainLayoutVM?> _getMainLayoutVM;

	protected FileImporter(Func<IMainLayoutVM?> getMainLayoutVM)
	{
		_getMainLayoutVM = getMainLayoutVM;
	}

	protected void ImportFile(string fileName)
	{
		Log.Info("Importing pending file...");
		_getMainLayoutVM()?.ImportPendingFile(fileName);
	}
}
