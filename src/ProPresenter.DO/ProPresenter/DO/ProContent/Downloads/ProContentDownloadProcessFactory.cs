using System;
using Pro.Common.Downloads;
using ProPresenter.DO.Analytics.Events.ProContent;
using ProPresenter.DO.Downloads;
using ProPresenter.DO.ProContent.Consumer;
using ProPresenter.DO.Settings;

namespace ProPresenter.DO.ProContent.Downloads;

public class ProContentDownloadProcessFactory : IProContentDownloadProcessFactory
{
	private readonly IDownloadItemFactory _downloadItemFactory;

	private readonly IProContentConsumer _consumer;

	private readonly IProPresenterResourceService _resources;

	private readonly IApp _app;

	private readonly IProContentDownloadFailedDialogService _downloadDialogService;

	private readonly IProContentAnalyticEventsPublisher _analyticsPublisher;

	private readonly IDownloadManager _downloadManger;

	private readonly IFileDownloadObserverFactory _fileDownloadObserverFactory;

	public ProContentDownloadProcessFactory(IDownloadItemFactory downloadItemFactory, IProContentConsumer consumer, IProPresenterResourceService resources, IApp app, IProContentDownloadFailedDialogService downloadDialogService, IProContentAnalyticEventsPublisher analyticsPublisher, IDownloadManager downloadManger, IFileDownloadObserverFactory fileDownloadObserverFactory)
	{
		_downloadItemFactory = downloadItemFactory;
		_consumer = consumer;
		_resources = resources;
		_app = app;
		_downloadDialogService = downloadDialogService;
		_analyticsPublisher = analyticsPublisher;
		_downloadManger = downloadManger;
		_fileDownloadObserverFactory = fileDownloadObserverFactory;
	}

	public IProContentDownloadProcess Create(Action<IDownloadObserverCallbackData>? importCallback = null)
	{
		return new ProContentDownloadProcess(_consumer, _downloadDialogService, _resources, _app, _downloadItemFactory, _downloadManger, _analyticsPublisher, _fileDownloadObserverFactory, importCallback);
	}
}
