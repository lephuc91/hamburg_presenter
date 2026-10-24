namespace Pro.Common.Downloads;

public interface IDownloadProcessFactory
{
	IDownloadProcess Create(bool enableSpeedReporting = true);
}
