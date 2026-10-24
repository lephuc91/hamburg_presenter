namespace ProPresenter.DO.Import;

public delegate void HandlingCompleteDelegate(IImportRequest request, RequestHandlerType handlerType, IImportResult? result);
