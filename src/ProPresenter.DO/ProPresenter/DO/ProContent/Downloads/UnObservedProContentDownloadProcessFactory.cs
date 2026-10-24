using Pro.Common.Downloads;
using ProPresenter.DO.Analytics.Events.ProContent;
using ProPresenter.DO.Downloads;
using ProPresenter.DO.ProContent.Consumer;
using ProPresenter.DO.Settings;

namespace ProPresenter.DO.ProContent.Downloads;

public class UnObservedProContentDownloadProcessFactory : IUnObservedProContentDownloadProcessFactory
{
	private readonly IDownloadItemFactory _downloadItemFactory;

	private readonly IProContentConsumer _consumer;

	private readonly IProPresenterResourceService _resources;

	private readonly IApp _app;

	private readonly IProContentDownloadFailedDialogService _downloadDialogService;

	private readonly IProContentAnalyticEventsPublisher _analyticsPublisher;

	private readonly IDownloadManager _downloadManger;

	public UnObservedProContentDownloadProcessFactory(IDownloadItemFactory downloadItemFactory, IProContentConsumer consumer, IProPresenterResourceService resources, IApp app, IProContentDownloadFailedDialogService downloadDialogService, IProContentAnalyticEventsPublisher analyticsPublisher, IDownloadManager downloadManger)
	{
		_downloadItemFactory = downloadItemFactory;
		_consumer = consumer;
		_resources = resources;
		_app = app;
		_downloadDialogService = downloadDialogService;
		_analyticsPublisher = analyticsPublisher;
		_downloadManger = downloadManger;
	}

	public IProContentDownloadProcess Create()
	{
		return new ProContentDownloadProcess(_consumer, _downloadDialogService, _resources, _app, _downloadItemFactory, _downloadManger, _analyticsPublisher, null);
	}
}
