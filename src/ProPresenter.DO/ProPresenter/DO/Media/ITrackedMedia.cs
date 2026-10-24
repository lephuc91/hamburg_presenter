using System;
using System.Threading.Tasks;
using Pro.Common.Components;

namespace ProPresenter.DO.Media;

public interface ITrackedMedia : IHasMediaContainerId, ICanReceiveMediaContainerIdUpdates
{
	Guid ID { get; }

	string? Url { get; }

	MediaMetadataRequest GenerateMetadataRequest(bool userInitiated);

	Task AddToMediaServiceAsync(bool userInitiated);

	void AddToMediaService(bool userInitiated);

	void AddToMediaServiceAndApplyTransform(bool userInitiated);

	Task RemoveFromMediaServiceAsync(bool deleteAssets);

	void RemoveFromMediaService(bool deleteAssets);
}
