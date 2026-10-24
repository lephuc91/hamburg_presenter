using System.Windows;
using Pro.Common.Dispatcher;
using Pro.Common.Time.Timer;
using Pro.Localization;
using Pro.UI.DialogService;
using ProPresenter.UI.Capture;
using ProPresenter.UI.ViewModels.Capture;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.ViewModels.Capture;

public class CapturePrompt : ICapturePrompt
{
	private CustomEncoderDialog? _customEncoderDialog;

	private CaptureNameDialog? _captureNameDialog;

	private Window? _parentWindow;

	private readonly ITimerFactory _timerFactory;

	private readonly IUiDispatcher _uiDispatcher;

	public CapturePrompt(ITimerFactory timerFactory, IUiDispatcher uiDispatcher)
	{
		_timerFactory = timerFactory;
		_uiDispatcher = uiDispatcher;
	}

	public void ShowCritical()
	{
		MessageDialogService.ShowDialog(LocalizedStrings.Get("RECORDING_DISK_SPACE_CRITICAL_ALERT_message"), LocalizedStrings.Get("RECORDING_DISK_SPACE_CRITICAL_ALERT_info"), DefaultButtons.OK, DefaultButtons.OK);
	}

	public DiskWarningButtons ShowLowSpace(bool isStreaming)
	{
		DiskWarningButtons buttons = (isStreaming ? (DiskWarningButtons.Continue | DiskWarningButtons.Stop | DiskWarningButtons.StopBackupOnly) : (DiskWarningButtons.Continue | DiskWarningButtons.Stop));
		return MessageDialogService.ShowDialog(LocalizedStrings.Get("RECORDING_DISK_SPACE_LOW_ALERT_message"), LocalizedStrings.Get("RECORDING_DISK_SPACE_LOW_ALERT_info"), buttons, DiskWarningButtons.Continue) ?? DiskWarningButtons.Continue;
	}

	public void ShowStartCaptureError(ProResult result, int errorCode)
	{
		if (result == ProResult.InsufficientDiskSpace)
		{
			MessageDialogService.ShowDialog(string.Empty, LocalizedStrings.Get("RECORDING_DISK_SPACE_INSUFFICIENT_ERROR_label"), DefaultButtons.OK, DefaultButtons.OK);
			return;
		}
		MessageDialogService.ShowDialog(string.Empty, LocalizedStrings.Get("RECORDING_WINDOW_START_CAPTURE_ERROR_win32_label", new object[1] { errorCode }), DefaultButtons.OK, DefaultButtons.OK);
	}

	public void ShowStartCaptureActionError(int errorCode, string? presetName)
	{
		_uiDispatcher.InvokeAsync(delegate
		{
			MessageDialogService.ShowDialog(LocalizedStrings.Get("CAPTURE_ACTION_START_CAPTURE_FAILURE_ALERT_title"), LocalizedStrings.Get("CAPTURE_ACTION_START_CAPTURE_FAILURE_ALERT_message", errorCode, presetName), DefaultButtons.OK, DefaultButtons.OK);
		});
	}

	public void ShowResiStartStreamError()
	{
		MessageDialogService.ShowDialog(LocalizedStrings.Get("RECORDING_WINDOW_START_RESI_CAPTURE_ERROR_title"), LocalizedStrings.Get("RECORDING_WINDOW_START_RESI_CAPTURE_ERROR_message"), DefaultButtons.OK, DefaultButtons.OK);
	}

	public bool ShowEncoderInvalid()
	{
		return MessageDialogService.ShowDialog(string.Empty, LocalizedStrings.Get("RECORDING_ENCODER_VALIDATION_FAILED_ALERT_message"), EncoderInvalidButtons.CANCEL | EncoderInvalidButtons.CONTINUE, EncoderInvalidButtons.CONTINUE) == EncoderInvalidButtons.CONTINUE;
	}

	public bool ShowCustomEncoderDialog(ICustomEncoderVM customEncoderVM)
	{
		if (_customEncoderDialog == null)
		{
			_customEncoderDialog = new CustomEncoderDialog
			{
				DataContext = customEncoderVM
			};
		}
		_customEncoderDialog.Owner = _parentWindow ?? Application.Current.MainWindow;
		bool valueOrDefault = _customEncoderDialog.ShowDialog() == true;
		_customEncoderDialog.DataContext = null;
		_customEncoderDialog = null;
		return valueOrDefault;
	}

	public void CloseCustomEncoderDialog()
	{
		if (_customEncoderDialog != null)
		{
			_customEncoderDialog.DialogResult = true;
			_customEncoderDialog.Close();
		}
	}

	public bool ShowPresetNameDialog(ICaptureNameVM captureNameVM, bool rename = false)
	{
		if (_captureNameDialog == null)
		{
			_captureNameDialog = new CaptureNameDialog
			{
				DataContext = captureNameVM
			};
		}
		_captureNameDialog.Owner = _parentWindow ?? Application.Current.MainWindow;
		bool valueOrDefault = _captureNameDialog.ShowDialog() == true;
		_captureNameDialog.DataContext = null;
		_captureNameDialog = null;
		return valueOrDefault;
	}

	public void ClosePresetNameDialog()
	{
		if (_captureNameDialog != null)
		{
			_captureNameDialog.DialogResult = true;
			_captureNameDialog.Close();
		}
	}

	public void SetParentWindow(Window window)
	{
		_parentWindow = window;
	}

	public bool ConfirmStopCapture()
	{
		return MessageDialogService.ShowDialog(string.Empty, LocalizedStrings.Get("RECORDING_CONFIRM_STOP_CAPTURE_ALERT_title") + "\n\n" + LocalizedStrings.Get("RECORDING_CONFIRM_STOP_CAPTURE_ALERT_message"), ConfirmStopCaptureButtons.CANCEL | ConfirmStopCaptureButtons.CONTINUE, ConfirmStopCaptureButtons.CONTINUE) == ConfirmStopCaptureButtons.CONTINUE;
	}

	public ResiDetails GetResiEventDetails()
	{
		ResiEventDialog resiEventDialog = new ResiEventDialog();
		ResiEventDetailsVM resiEventDetailsVM2 = (ResiEventDetailsVM)(resiEventDialog.DataContext = new ResiEventDetailsVM(_timerFactory, resiEventDialog));
		return new ResiDetails(resiEventDialog.ShowDialog() == true, resiEventDetailsVM2.Name, resiEventDetailsVM2.Description);
	}
}
