using System.Threading.Tasks;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.DO.Import;

public interface IRequestHandler
{
	bool CanHandle(IImportRequest request);

	ValueTask HandleAsync(ImportProcess process, IProCoreInstance? proCore, IImportRequest[] requests, UpdateStatusDelegate updateStatus, HandlingCompleteDelegate handlingComplete, AddRequestDelegate addRequest);
}
