using System.Collections.Generic;
using System.Threading.Tasks;
using Pro.CoreApplication.Media;

namespace ProPresenter.DO.Media.Services;

public interface ITrackedMediaHelpers
{
	void AddToMediaService(IReadOnlyList<ITrackedMedia> mediaToAdd, bool useUserInitiatedPriority, bool applyTransform);

	Task<IReadOnlyList<IMediaServiceResponse>> AddToMediaServiceAsync(IReadOnlyList<ITrackedMedia> mediaToAdd, bool useUserInitiatedPriority, bool applyTransform);

	void RemoveFromMediaService(IReadOnlyList<ITrackedMedia> mediaToRemove, bool deleteAssets);

	Task<IMediaServiceResponse> RemoveFromMediaServiceAsync(IReadOnlyList<ITrackedMedia> mediaToRemove, bool deleteAssets);
}
