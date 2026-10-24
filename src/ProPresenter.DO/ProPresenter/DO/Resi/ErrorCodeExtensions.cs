using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.DO.Resi;

public static class ErrorCodeExtensions
{
	public static ErrorCode ToErrorCodes(this ProResiErrorCode proResiErrorCode)
	{
		return proResiErrorCode switch
		{
			ProResiErrorCode.None => ErrorCode.None, 
			ProResiErrorCode.CentralStartError => ErrorCode.CentralStartError, 
			ProResiErrorCode.FolderStartError => ErrorCode.FolderStartError, 
			ProResiErrorCode.UnknownStartError => ErrorCode.UnknownStartError, 
			ProResiErrorCode.CentralStopError => ErrorCode.CentralStopError, 
			ProResiErrorCode.FolderStopError => ErrorCode.FolderStopError, 
			ProResiErrorCode.UnknownStopError => ErrorCode.UnknownStopError, 
			ProResiErrorCode.DestinationGroupInUse => ErrorCode.DestinationGroupInUse, 
			ProResiErrorCode.NetworkOffline => ErrorCode.NetworkOffline, 
			ProResiErrorCode.DestinationGroupDeleted => ErrorCode.DestinationGroupDeleted, 
			_ => ErrorCode.Unknown, 
		};
	}
}
