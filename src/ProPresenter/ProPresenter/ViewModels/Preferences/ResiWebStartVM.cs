using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using Pro.Common.Components;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using Pro.UI.Components;
using ProPresenter.DO.Analytics.Events.TrackedEvents;
using ProPresenter.DO.Capture;
using ProPresenter.DO.Resi;
using ProPresenter.UI.Resi;
using ProPresenter.UI.ViewModels.Resi;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.ViewModels.Preferences;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { })]
public class ResiWebStartVM : NotifyPropertyChangedBase, IResiWebStartVM, INotifyPropertyChanged, IDisposable
{
	private readonly TimeSpan StartCaptureTimeInternal = TimeSpan.FromSeconds(1.0);

	private readonly Lazy<ResiWebStartWindow> _window;

	private string _message = string.Empty;

	private readonly IResiController _resiController;

	private readonly ICaptureService _captureService;

	private readonly IResiRemote _resiRemote;

	private bool _isLive;

	private bool _isCaptureStart;

	private readonly DispatcherTimer _startCaptureTimer = new DispatcherTimer();

	private int _countDown = 15;

	private string _abortButtonText = string.Empty;

	private string _beginButtonText = string.Empty;

	private bool _shouldStartCapture;

	private bool? _dialogResult;

	private readonly ICrashRecovery _crashRecovery;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public string Message
	{
		get
		{
			return _message;
		}
		private set
		{
			SetValue("Message", ref _message, value);
		}
	}

	public string AbortButtonText
	{
		get
		{
			return _abortButtonText;
		}
		set
		{
			SetValue("AbortButtonText", ref _abortButtonText, value);
		}
	}

	public string BeginButtonText
	{
		get
		{
			return _beginButtonText;
		}
		set
		{
			SetValue("BeginButtonText", ref _beginButtonText, value);
		}
	}

	public ICommand AbortCommand => new RelayCommand(OnAbortCommand);

	public ICommand BeginCommand => new RelayCommand(OnBeginCommand);

	private ResiWebStartWindow WebStartWindow => _window.Value;

	public ResiWebStartVM(IResiController resiController, ICaptureService captureService, IResiRemote resiRemote, ICrashRecovery crashRecovery)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		_resiController = resiController;
		_captureService = captureService;
		_resiRemote = resiRemote;
		_crashRecovery = crashRecovery;
		_window = new Lazy<ResiWebStartWindow>(delegate
		{
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Expected O, but got Unknown
			ResiWebStartWindow value = new ResiWebStartWindow
			{
				DataContext = this
			};
			value.IsVisibleChanged += (DependencyPropertyChangedEventHandler)delegate
			{
				if (!value.IsVisible)
				{
					RemoteStreamStartEvent.Publish((!_dialogResult.HasValue) ? StartStreamResult.Failure : ((!_dialogResult.Value) ? StartStreamResult.UserCanceled : StartStreamResult.Success));
				}
			};
			return value;
		});
		_resiController.StartCaptureRequested += Service_StartCaptureRequested;
		_resiController.StopCaptureRequested += Service_StopCaptureRequested;
		_captureService.ScreenCaptureStatusChanged += ScreenCaptureStatusChanged;
		_startCaptureTimer.Interval = StartCaptureTimeInternal;
		_startCaptureTimer.Tick += StartCaptureTimer_Tick;
	}

	private void StartCaptureTimer_Tick(object? sender, EventArgs e)
	{
		_countDown--;
		Message = (_isLive ? LocalizedStrings.Get((_countDown > 1) ? "RESI_CONTROL_INTERRUPTS_CURRENT_STREAM_ALERT_PLURAL_info" : "RESI_CONTROL_INTERRUPTS_CURRENT_STREAM_ALERT_SINGULAR_info", new object[1] { _countDown }) : LocalizedStrings.Get((_countDown > 1) ? "RESI_CONTROL_ACTIVATE_STREAM_PLURAL_info" : "RESI_CONTROL_ACTIVATE_STREAM_SINGULAR_info", new object[1] { _countDown }));
		if (_countDown <= 0)
		{
			OnBeginCommand();
			_countDown = 15;
		}
	}

	private void ScreenCaptureStatusChanged(object? sender, ScreenCaptureStatusEventArgs e)
	{
		ProScreenCaptureStatus proScreenCaptureStatus = e?.ScreenCaptureStatus;
		if (proScreenCaptureStatus == null)
		{
			return;
		}
		_isLive = proScreenCaptureStatus.State != ProScreenCaptureState.Inactive;
		if (_isLive)
		{
			if (_isCaptureStart)
			{
				_isCaptureStart = false;
			}
		}
		else if (_shouldStartCapture)
		{
			_shouldStartCapture = false;
			OnStartCapture();
		}
	}

	private void Service_StartCaptureRequested()
	{
		if (_crashRecovery.CanStart && !WebStartWindow.IsVisible)
		{
			Message = LocalizedStrings.Get(_isLive ? "RESI_CONTROL_INTERRUPTS_CURRENT_STREAM_ALERT_PLURAL_info" : "RESI_CONTROL_ACTIVATE_STREAM_PLURAL_info", new object[1] { _countDown });
			AbortButtonText = LocalizedStrings.Get(_isLive ? "RESI_CONTROL_INTERRUPTS_CURRENT_STREAM_ABORT_BUTTON_title" : "RESI_CONTROL_ACTIVATE_STREAM_ABORT_BUTTON_title");
			BeginButtonText = LocalizedStrings.Get(_isLive ? "RESI_CONTROL_INTERRUPTS_CURRENT_STREAM_CONTINUE_BUTTON_title" : "RESI_CONTROL_ACTIVATE_STREAM_BEGIN_BUTTON_title");
			_startCaptureTimer.Start();
			_dialogResult = null;
			WebStartWindow.Show();
		}
	}

	private void Service_StopCaptureRequested()
	{
		int num;
		if (_isLive)
		{
			num = ((!WebStartWindow.IsVisible) ? 1 : 0);
			if (num != 0)
			{
				OnStopCapture();
			}
		}
		else
		{
			num = 0;
		}
		RemoteStreamStopEvent.Publish((byte)num != 0);
	}

	private void OnAbortCommand()
	{
		_dialogResult = false;
		Reset();
		OnStopCapture();
	}

	private void OnBeginCommand()
	{
		_dialogResult = true;
		if (_isLive)
		{
			OnStopCapture();
			if (!_isLive)
			{
				OnStartCapture();
			}
			_shouldStartCapture = true;
		}
		else
		{
			OnStartCapture();
		}
		_isCaptureStart = true;
		Reset();
	}

	private void Reset()
	{
		_startCaptureTimer.Stop();
		WebStartWindow.Close();
		_countDown = 15;
	}

	private void OnStopCapture()
	{
		_resiRemote.StopRemoteCapture();
	}

	private void OnStartCapture()
	{
		Recording.Types.Stream lastCapture = _crashRecovery.LastCapture;
		if (lastCapture != null)
		{
			_captureService.Stream?.Deserialize(lastCapture);
		}
		_resiRemote.StartRemoteCapture();
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			OnDispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		_resiController.StartCaptureRequested -= Service_StartCaptureRequested;
		_resiController.StopCaptureRequested -= Service_StopCaptureRequested;
		_captureService.ScreenCaptureStatusChanged -= ScreenCaptureStatusChanged;
		_startCaptureTimer.Tick -= StartCaptureTimer_Tick;
	}
}
