using System;
using System.Reactive.Linq;
using Pro.Common.Downloads;

namespace ProPresenter.DO.Downloads;

public static class DownloadItemExtension
{
	public static bool UrlDownloadItemMatchesActiveDownload(this IDownloadItem downloadItem, string url)
	{
		if (downloadItem is IUrlMediaDownloadItem urlMediaDownloadItem)
		{
			return urlMediaDownloadItem.MatchesActiveDownload(url);
		}
		return false;
	}

	public static void SubscribeCompletion(this IDownloadItem downloadItem, Action completionAction)
	{
		downloadItem.WhenDownloadProgressChanged.Where((DownloadProgress p) => p.Status == DownloadStatus.Completed).Subscribe(delegate
		{
			completionAction();
		});
	}
}
