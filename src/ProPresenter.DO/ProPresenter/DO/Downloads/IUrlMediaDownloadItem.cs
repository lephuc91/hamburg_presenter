using System;
using Pro.Common.Downloads;

namespace ProPresenter.DO.Downloads;

public interface IUrlMediaDownloadItem : IDownloadItem, IDisposable
{
	bool MatchesActiveDownload(string url);
}
