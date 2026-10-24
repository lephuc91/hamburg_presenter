using ProPresenter.DO.Import.Requests;
using ProPresenter.DO.Web;

namespace ProPresenter.DO.Media.Sample;

public class DownloadData
{
	public SampleData Data { get; }

	public WebFileDownload FileDownload { get; }

	public PlaylistLocation Location { get; }

	public string FileDestination { get; }

	public bool Success { get; set; }

	public DownloadData(SampleData data, WebFileDownload fileDownload, PlaylistLocation location, string fileDestination)
	{
		Data = data;
		FileDownload = fileDownload;
		Location = location;
		FileDestination = fileDestination;
	}
}
