using System;
using System.IO.Abstractions;
using System.Reactive.Linq;
using Pro.Common.Downloads;

namespace ProPresenter.DO.Downloads;

public sealed class UrlMediaDownloadItem : DownloadItemBase, IUrlMediaDownloadItem, IDownloadItem, IDisposable
{
	private readonly string _destination;

	public override IObservable<string> WhenNameChanged { get; }

	public override IObservable<Uri> WhenThumbnailUrlChanged => Observable.Empty<Uri>();

	protected override string DownloadUrl { get; }

	public UrlMediaDownloadItem(string url, string destination, string name, IDownloadProcessFactory processFactory, IFileService fileService, IFileSystem fileSystem)
		: base(processFactory, fileService, fileSystem)
	{
		DownloadUrl = url;
		WhenNameChanged = Observable.Return(name);
		_destination = destination;
	}

	public bool MatchesActiveDownload(string url)
	{
		if (base.Status == DownloadStatus.Active)
		{
			return DownloadUrl == url;
		}
		return false;
	}

	protected override string GetImportDestination()
	{
		return _destination;
	}
}
