namespace ProPresenter.DO.Export;

public interface IRequestHandler
{
	bool CanHandle(IExportRequest request);

	void Handle(IExportProcess process, IExportRequest request, UpdateStatusDelegate updateStatus, ResolveConflictDelegate resolveConflict);
}
