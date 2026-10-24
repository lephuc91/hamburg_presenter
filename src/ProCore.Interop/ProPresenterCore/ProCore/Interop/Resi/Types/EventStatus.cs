namespace ProPresenterCore.ProCore.Interop.Resi.Types;

public class EventStatus
{
	public ProResiStreamState CurrentState { get; }

	public ProResiStreamState RequestedState { get; }

	public ProResiAccountStatus AccountStatus { get; }

	public FileUploadStatus FileUploadStatus { get; }

	public ProResiErrorCode ErrorCodes { get; }

	public ProResiUploadHealth UploadHealth { get; }

	public EventStatus(ProResiEventStatus.__Internal eventStatus)
	{
		CurrentState = eventStatus.currentState;
		RequestedState = eventStatus.requestedState;
		AccountStatus = eventStatus.accountStatus;
		FileUploadStatus = new FileUploadStatus(eventStatus.fileUploadStatus);
		ErrorCodes = eventStatus.errorCodes;
		UploadHealth = eventStatus.uploadHealth;
	}
}
