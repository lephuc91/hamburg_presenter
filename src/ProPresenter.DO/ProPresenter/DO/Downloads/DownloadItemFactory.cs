using System.IO.Abstractions;
using Pro.Common.Downloads;
using ProPresenter.DO.ProContent.Downloads;
using ProPresenter.DO.ProContent.Model.Download;

namespace ProPresenter.DO.Downloads;

public class DownloadItemFactory : IDownloadItemFactory
{
	private readonly IDownloadProcessFactory _downloadProcessFactory;

	private readonly IFileService _fileService;

	private readonly IFileSystem _fileSystem;

	public DownloadItemFactory(IDownloadProcessFactory downloadProcessFactory, IFileService fileService, IFileSystem fileSystem)
	{
		_downloadProcessFactory = downloadProcessFactory;
		_fileService = fileService;
		_fileSystem = fileSystem;
	}

	public IDownloadItem Create(ProContentFileDownload fileDownload, IProContentDownloadDataRefresher downloadRefresher)
	{
		return new ProContentDownloadItem(fileDownload, _downloadProcessFactory, _fileService, _fileSystem, downloadRefresher);
	}

	public IDownloadItem Create(string url, string destination, string name)
	{
		return new UrlMediaDownloadItem(url, destination, name, _downloadProcessFactory, _fileService, _fileSystem);
	}
}
