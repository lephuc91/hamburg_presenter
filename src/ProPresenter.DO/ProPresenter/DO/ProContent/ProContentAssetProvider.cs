using System;
using System.Threading.Tasks;
using ProPresenter.DO.ProContent.Consumer;
using ProPresenter.DO.ProContent.Downloads;

namespace ProPresenter.DO.ProContent;

public class ProContentAssetProvider : IProContentAssetProvider
{
	private readonly IProContentConsumer _consumer;

	private readonly IProContentUserInteractionBehavior _userInteractionBehavior;

	private readonly IUnObservedProContentDownloadProcessFactory _processFactory;

	public ProContentAssetProvider(IProContentConsumer consumer, IProContentUserInteractionBehavior userInteractionBehavior, IUnObservedProContentDownloadProcessFactory processFactory)
	{
		_consumer = consumer;
		_userInteractionBehavior = userInteractionBehavior;
		_processFactory = processFactory;
	}

	public Task StartDownloadAssetAsync(string assetId)
	{
		return _userInteractionBehavior.ExecuteDownloadAsync(DoDownloadAsync, assetId);
	}

	public Uri GetAssetThumbnailUrl(string assetFormatId)
	{
		return _consumer.GetAssetThumbnailUrl(assetFormatId);
	}

	private async Task DoDownloadAsync(string identifier)
	{
		await _processFactory.Create().StartDownloadAsync(identifier);
	}
}
