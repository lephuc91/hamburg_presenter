using Pro.Common.Components;

namespace ProPresenter.DO.Resi;

public class UploadInfo : NotifyPropertyChangedBase
{
	public int Current { get; }

	public int TotalFiles { get; }

	public double Progress { get; }

	public UploadInfo(int current, int totalFiles)
	{
		Current = current;
		TotalFiles = totalFiles;
		Progress = ((totalFiles > 0 && current >= 0) ? ((double)current / (double)totalFiles) : (-1.0));
	}
}
