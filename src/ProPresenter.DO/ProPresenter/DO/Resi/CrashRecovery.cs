using System;
using System.IO;
using System.Linq;
using System.Windows.Threading;
using Pro.Localization;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;
using Pro.UI.DialogService;
using ProPresenter.DO.Capture;

namespace ProPresenter.DO.Resi;

public class CrashRecovery : ICrashRecovery
{
	[Flags]
	public enum ResumeCaptureButtons
	{
		[LocalizedString("GLOBAL_RESUME_BUTTON_title")]
		Resume = 1,
		[LocalizedString("GLOBAL_CANCEL_BUTTON_title")]
		Cancel = 2
	}

	private readonly TimeSpan IgnoreStartTimeInternal = TimeSpan.FromSeconds(1.0);

	private readonly DispatcherTimer _ignoreStartTimer = new DispatcherTimer();

	private int _ignoreCounter = 15;

	private Recording.Types.Stream? _lastCapture;

	private readonly ICaptureSettingsDocument _captureSettingsDocument;

	private readonly string LastCaptureFile = Path.Combine(CommonPaths.Temp, "last_capture");

	public Recording.Types.Stream? LastCapture
	{
		get
		{
			EnsureLastCaptureValid();
			return _lastCapture;
		}
	}

	public DestinationType LastCaptureDestinationType
	{
		get
		{
			EnsureLastCaptureValid();
			return (_lastCapture?.Destinations.FirstOrDefault()?.DestinationCase.ToDestinationType()).GetValueOrDefault();
		}
	}

	public bool CaptureStopped => !File.Exists(LastCaptureFile);

	private IStream? Stream => _captureSettingsDocument.ActivePreset?.DefaultStream;

	public bool CanStart { get; private set; } = true;

	public event System.Action? StartCapture;

	public CrashRecovery(ICaptureSettingsDocument captureSettingsDocument)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		_ignoreStartTimer.Interval = IgnoreStartTimeInternal;
		_ignoreStartTimer.Tick += IgnoreStartTimer_Tick;
		_captureSettingsDocument = captureSettingsDocument;
	}

	private void IgnoreStartTimer_Tick(object? sender, EventArgs e)
	{
		_ignoreCounter--;
		if (_ignoreCounter <= 0)
		{
			CanStart = true;
			_ignoreStartTimer.Stop();
		}
	}

	public void CheckResumeCapture()
	{
		if (CaptureStopped)
		{
			return;
		}
		ResumeCaptureButtons? resumeCaptureButtons = MessageDialogService.ShowDialog(LocalizedStrings.Get("RECORDING_UNFINISHED_CAPTURE_MESSAGE_title"), LocalizedStrings.Get("RECORDING_UNFINISHED_CAPTURE_INFORMATION_title"), ResumeCaptureButtons.Resume | ResumeCaptureButtons.Cancel, ResumeCaptureButtons.Resume);
		if (resumeCaptureButtons.HasValue)
		{
			ResumeCaptureButtons valueOrDefault = resumeCaptureButtons.GetValueOrDefault();
			if (valueOrDefault == ResumeCaptureButtons.Resume)
			{
				UseLastCaptureInfo();
				this.StartCapture?.Invoke();
				return;
			}
		}
		RemoveLastCaptureInfo();
		CanStart = false;
		_ignoreStartTimer.Start();
	}

	public void SaveLastCaptureInfo()
	{
		_lastCapture = null;
		ProtoHelper.WriteFile(LastCaptureFile, Stream?.Serialize());
	}

	private void EnsureLastCaptureValid()
	{
		if (_lastCapture == null && (bool)ProtoHelper.TryReadFile<Recording.Types.Stream>(LastCaptureFile, out Recording.Types.Stream data))
		{
			_lastCapture = data;
		}
	}

	private void UseLastCaptureInfo()
	{
		Recording.Types.Stream lastCapture = LastCapture;
		if (lastCapture != null)
		{
			Stream?.Deserialize(lastCapture);
		}
	}

	public void RemoveLastCaptureInfo()
	{
		_lastCapture = null;
		if (!CaptureStopped)
		{
			File.Delete(LastCaptureFile);
		}
	}
}
