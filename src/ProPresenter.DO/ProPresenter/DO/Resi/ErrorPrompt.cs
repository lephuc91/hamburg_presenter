using Pro.Localization;
using Pro.UI.DialogService;
using ProPresenter.DO.Capture;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.DO.Resi;

public class ErrorPrompt : IErrorPrompt
{
	private ErrorCode _shownErrorCode;

	private readonly ICaptureSettingsDocument _captureSettingsDocument;

	private bool CanShowError
	{
		get
		{
			ICapturePreset? activePreset = _captureSettingsDocument.ActivePreset;
			if (activePreset == null)
			{
				return false;
			}
			return activePreset.DefaultStream.DestinationType == DestinationType.Resi;
		}
	}

	public ErrorPrompt(ICaptureSettingsDocument captureSettingsDocument)
	{
		_captureSettingsDocument = captureSettingsDocument;
		ResetErrorCodesShown();
	}

	public void ShowError(ProResiTransferType proResiTransferType)
	{
		if (CanShowError)
		{
			switch (proResiTransferType)
			{
			case ProResiTransferType.kProResiTransferEncoderProfiles:
				MessageDialogService.ShowDialog(LocalizedStrings.Get("RECORDING_WINDOW_CHECK_NETWORK_SETTINGS_info"), LocalizedStrings.Get("RECORDING_WINDOW_GET_RESI_ENCODER_PROFILES_ERROR_message"), DefaultButtons.OK, DefaultButtons.OK);
				break;
			case ProResiTransferType.kProResiTransferDestinationGroups:
				MessageDialogService.ShowDialog(LocalizedStrings.Get("RECORDING_WINDOW_CHECK_NETWORK_SETTINGS_info"), LocalizedStrings.Get("RECORDING_WINDOW_GET_RESI_DESTINATION_GROUPS_ERROR_message"), DefaultButtons.OK, DefaultButtons.OK);
				break;
			case ProResiTransferType.kProResiTransferProcessStart:
			case ProResiTransferType.kProResiTransferProcessStop:
			case ProResiTransferType.kProResiTransferStreamStart:
			case ProResiTransferType.kProResiTransferStreamStop:
			case ProResiTransferType.kProResiTransferAboutInfo:
			case ProResiTransferType.kProResiTransferEventStatus:
			case ProResiTransferType.kProResiTransferBeginUpdateReady:
				break;
			}
		}
	}

	public void ShowError(ErrorCode errorCode)
	{
		if (!CanShowError)
		{
			if (errorCode.HasFlag(ErrorCode.DestinationGroupInUse) && !_shownErrorCode.HasFlag(ErrorCode.DestinationGroupInUse))
			{
				_shownErrorCode |= ErrorCode.DestinationGroupInUse;
				MessageDialogService.ShowDialog(LocalizedStrings.Get("RESI_STREAM_ERROR_CODE_DESTINATION_GROUP_IN_USE_title"), LocalizedStrings.Get("RESI_STREAM_ERROR_CODE_DESTINATION_GROUP_IN_USE_message"), DefaultButtons.OK, DefaultButtons.OK);
			}
			else if (errorCode.HasFlag(ErrorCode.DestinationGroupDeleted) && !_shownErrorCode.HasFlag(ErrorCode.DestinationGroupDeleted))
			{
				_shownErrorCode |= ErrorCode.DestinationGroupDeleted;
				MessageDialogService.ShowDialog(LocalizedStrings.Get("RESI_STREAM_ERROR_CODE_DESTINATION_GROUP_DELETED_title"), LocalizedStrings.Get("RESI_STREAM_ERROR_CODE_DESTINATION_GROUP_DELETED_message"), DefaultButtons.OK, DefaultButtons.OK);
			}
		}
	}

	public void ResetErrorCodesShown()
	{
		_shownErrorCode = ErrorCode.None;
	}
}
