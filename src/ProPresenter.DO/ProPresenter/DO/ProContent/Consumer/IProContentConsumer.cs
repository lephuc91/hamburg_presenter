using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using ProPresenter.DO.CloudOnboarding.Model;
using ProPresenter.DO.ProContent.Consumer.Model.Result;

namespace ProPresenter.DO.ProContent.Consumer;

public interface IProContentConsumer : INotifyPropertyChanged
{
	string ProContentApiBaseUrl { get; }

	string ProContentHomePageText { get; }

	bool IsAuthorized { get; }

	Task<IRequestResult> GetRootGroupsAsync(CancellationToken cancellationToken = default(CancellationToken));

	Task<IRequestResult> GetSearchResultAsync(string searchTerm, CancellationToken cancellationToken = default(CancellationToken));

	Task<IRequestResult> GetGroupAsync(string groupId, CancellationToken cancellationToken = default(CancellationToken));

	Task<IRequestResult> GetDownloadDataAsync(string assetFormatId, CancellationToken cancellationToken = default(CancellationToken));

	Uri GetAssetThumbnailUrl(string assetFormatId);

	Task<PricingOptionsResponse?> GetPricingOptionsAsync(long workspaceSizeBytes, string locale, CancellationToken ct = default(CancellationToken));
}
