namespace ProPresenterCore.ProCore.Interop.Resi.Types;

public class FileUploadStatus
{
	public int InitialCount { get; }

	public int CurrentCount { get; }

	public FileUploadStatus(ProResiFileUploadStatus.__Internal fileUploadStatus)
	{
		InitialCount = fileUploadStatus.initialCount;
		CurrentCount = fileUploadStatus.currentCount;
	}
}
