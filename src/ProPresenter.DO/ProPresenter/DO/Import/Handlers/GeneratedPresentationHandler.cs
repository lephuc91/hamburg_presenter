using System.Threading.Tasks;
using ProPresenter.DO.Import.Requests;
using ProPresenter.DO.Import.Results;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.DO.Import.Handlers;

internal class GeneratedPresentationHandler : IRequestHandler
{
	public bool CanHandle(IImportRequest request)
	{
		return request is GeneratedPresentationRequest;
	}

	public ValueTask HandleAsync(ImportProcess process, IProCoreInstance? proCore, IImportRequest[] requests, UpdateStatusDelegate updateStatus, HandlingCompleteDelegate handlingComplete, AddRequestDelegate addRequest)
	{
		Handle(process, proCore, requests, updateStatus, handlingComplete, addRequest);
		return default(ValueTask);
	}

	private void Handle(ImportProcess process, IProCoreInstance? proCore, IImportRequest[] requests, UpdateStatusDelegate updateStatus, HandlingCompleteDelegate handlingComplete, AddRequestDelegate addRequest)
	{
		foreach (IImportRequest importRequest in requests)
		{
			handlingComplete(importRequest, RequestHandlerType.Presentation, new MemoryImportResult(((GeneratedPresentationRequest)importRequest).Presentation));
		}
	}
}
