using System;
using Pro.Localization;
using Pro.UI.DialogService;
using ProPresenter.DO.Capture;
using ProPresenter.DO.OutputConfiguration;

namespace ProPresenter.ViewModels;

public class RemoveRecordingScreenValidator : IRemoveScreenValidator
{
	private readonly ICaptureService _captureService;

	public RemoveRecordingScreenValidator(ICaptureService captureService)
	{
		_captureService = captureService;
	}

	public bool CanRemoveScreen(ScreenArrangementBase target)
	{
		if (_captureService.IsLive)
		{
			Guid iD = target.ID;
			Guid? obj = _captureService.Stream?.ScreenID;
			if (iD == obj)
			{
				return confirmDelete();
			}
		}
		return true;
		bool confirmDelete()
		{
			return MessageDialogService.ShowDialog(LocalizedStrings.Get("SCREEN_CONFIGURATION_DELETE_RECORDING_SCREEN_ALERT_message"), string.Format(LocalizedStrings.Get("SCREEN_CONFIGURATION_DELETE_RECORDING_SCREEN_ALERT_info"), target.Name), RemoveScreenButtons.DELETE | RemoveScreenButtons.CANCEL, RemoveScreenButtons.DELETE) == RemoveScreenButtons.DELETE;
		}
	}
}
