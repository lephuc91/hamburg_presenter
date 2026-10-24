using System;
using Pro.Common.Downloads;
using ProPresenter.DO.ProContent.Model.Download;

namespace ProPresenter.DO.ProContent.Downloads;

public interface IProContentDownloadItem : IDownloadItem, IDisposable
{
	string AssetIdentifier { get; }

	bool MatchesActiveDownload(ProContentFileDownload other);
}
