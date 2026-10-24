using System;
using Pro.Common.Dispatcher;
using Pro.UI.DialogService;

namespace ProPresenter.DO.Import.Results;

public class ErrorResult : IImportResult
{
	public string Title { get; }

	public string Message { get; }

	public ErrorResult(string title, string message)
	{
		Title = title;
		Message = message;
	}

	public void CompleteImport(IImportProcess process, IImportRequest request, string name, bool overwrite, IUiDispatcher dispatcher, string containerId)
	{
		dispatcher.Invoke(delegate
		{
			MessageDialogService.ShowSimpleContent(Title, Message, canCancel: false);
		});
	}

	public string GetTargetFilename(IImportRequest request)
	{
		throw new NotImplementedException();
	}
}
